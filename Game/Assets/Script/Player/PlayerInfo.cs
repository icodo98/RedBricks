using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Diagnostics;

namespace PlayerInformation
{
    [Serializable]
    public class PlayerInfo : MonoBehaviour, IListener
    {
        public static PlayerInfo playerInfo;
        public List<Bits> bitsList;
        public List<GameObject> bitPrefs;


        PlayerData LoadData;
        public PlayerRun curRun;
        public PlayerData curData;
        public Rito.WeightedRandomPicker<Bits> RandomPicker = new ();
        private int _priority = 0;
        public int priority
        {
            get => _priority;
            set => _priority = value;
        }

        public float HP
        {
            get => curRun.HP;
            set => curRun.HP = value;
        }
        private string dataFilePath;
        private string infoFilePath;
        public int MaxHP
        {
            get => curRun.MaxHP;
            set => curRun.MaxHP = value;
        }

        /// <summary>
        /// Map scene���� ó�� �����Ǿ� �� �� don't destory�� ���� ������ �Ϸ���.
        /// </summary>
        public void Awake()
        {
            DontDestroyOnLoad(gameObject);
            dataFilePath = Application.dataPath + "/PlayerData.json";
            infoFilePath = Application.dataPath + "/PlayerInfo.json";


            if (playerInfo == null)
            {
                playerInfo = this;
            }
            else if (playerInfo != this)
            {
                Destroy(gameObject);
            }
            //newGame();
        }
        public void Start()
        {
            if(EventManager.Instance != null)
            {
                EventManager.Instance.AddListener(myEventType.StageClear, playerInfo);
                EventManager.Instance.AddListener(myEventType.GameOver, playerInfo);
            }
            foreach (GameObject obj in bitPrefs)
            {
                Bits bits = obj.GetComponent<Bits>();
                RandomPicker.Add(bits, bits.weight);
            }
        }
        /// <summary>
        /// ����Ǿ��� ��ų �����͸� �ε��ϰ� ������ ü�°� bit List�� ���� �ʱ�ȭ��.
        /// </summary>
        public void newGame()
        {
            LoadData = PlayerDataUtils.ReadData(dataFilePath);
            curData = new PlayerData(LoadData);
            if (PlayerPrefs.HasKey("GameOver"))
            {
                if (PlayerPrefs.GetInt("GameOver") == 0)
                {
                    LoadPlayerInfo();
                }

                else
                {
                    curRun = new();
                    if (curData.IncreaseHealth > 1) curRun.MaxHP = curData.IncreaseHealth * curRun.MaxHP;
                    curRun.HP = curRun.MaxHP;
                }
            }
        }
        public void OnEvent(myEventType eventType, Component Sender, object Param = null)
        {
            switch (eventType)
            {
                case myEventType.StageClear:
                    break;
                case myEventType.GameOver:
                    // game over�� Map reloading�� ���� ǥ����.
                    PlayerPrefs.SetInt("GameOver", 1);
                    PlayerPrefs.Save();
                    PlayerDataUtils.SaveCurData();
                    //PlayerDataUtils.SaveDataAsJson(dataFilePath, curData);
                    break;
                default: throw new System.Exception("There is a unhandled event at " + this.name);

            }
        }
        private void OnApplicationQuit()
        {
            //PlayerDataUtils.SaveDataAsJson(dataFilePath, curData);
            PlayerDataUtils.SaveCurData();
        }

        public void LoadPlayerInfo()
        {
            PlayerRun loaded = PlayerDataUtils.ReadInfo(infoFilePath);
            curData = PlayerDataUtils.ReadData(Application.dataPath + "/PlayerCurData.json");
            if (loaded != null)
            {
                curRun = loaded;
            }
            else throw new System.Exception("There is no save file!");
            bitsList = new List<Bits>();
            foreach (string name in  curRun.bitList) {
                bitsList.Add(bitPrefs[curRun.BitsDic[name]].GetComponent<Bits>());
            }

        }
        /// <summary>
        /// bits ����Ʈ�� Index�� �ִ� ��Ʈ�� ���� bit�� �߰���.
        /// </summary>
        /// <param name="bits"></param>
        /// <param name="index"></param>
        public void addParmentBit(List<Bits> bits,int index)
        {
            if(index > 0) {
                if(--index > bits.Count)
                {
                    index--;
                }
                bitsList.Add(bits[--index]);
            }
            curRun.bitList = new();
            foreach (var item in bitsList)
            {
                curRun.bitList.Add(item.name);
            }
            //PlayerDataUtils.SaveDataAsJson(infoFilePath, curRun);
            PlayerDataUtils.SavePlayerInfo();
        }
        /// <summary>
        /// ���� ��Ʈ�� �߰�
        /// </summary>
        /// <param name="bits"></param>
        public void addParmentBit(Bits bits)
        {
            bitsList.Add((Bits)bits);
            curRun.bitList.Add(bits.name);
            PlayerDataUtils.SavePlayerInfo();
        }
        public void ParmentSavePalyerInfo()
        {
            
            PlayerDataUtils.SavePlayerInfo();
        }

    }
}



