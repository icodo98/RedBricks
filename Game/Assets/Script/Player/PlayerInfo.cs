using System.Collections.Generic;
using UnityEngine;
using System;

namespace PlayerInformation
{
    [Serializable]
    public class PlayerInfo : MonoBehaviour, IListener
    {
        public static PlayerInfo playerInfo;
        public List<Bits> bitsList;
        public List<GameObject> bitPrefs;


        
        //TO Do : 
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
            EventManager.Instance.AddListener(myEventType.StageClear, playerInfo);
            EventManager.Instance.AddListener(myEventType.GameOver, playerInfo);
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
                    PlayerDataUtils.SaveDataAsJson(dataFilePath, curData);
                    break;
                default: throw new System.Exception("There is a unhandled event at " + this.name);

            }
        }
        private void OnApplicationQuit()
        {
           PlayerDataUtils.SaveDataAsJson(dataFilePath, curData);
        }

        public void LoadPlayerInfo()
        {
            PlayerRun loaded = PlayerDataUtils.ReadInfo(infoFilePath);
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
            PlayerDataUtils.SaveDataAsJson(infoFilePath, curRun);

        }

    }
}



