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

        public List<GameObject> Relic;


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

        public int HP
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
            LoadData = PlayerDataUtils.ReadData(dataFilePath);
            curData = new PlayerData(LoadData);
            //ToDo 게임 오버 후에 게임을 끄는 것이 아닌 new game을 시작할 경우 Load를 해오지 않음. 수정 필요.
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
        

        /*
         * stageClear시 발생할 이벤트. 영구 bit을 추가하여야함.
         */
        public void OnEvent(myEventType eventType, Component Sender, object Param = null)
        {
            switch (eventType)
            {
                case myEventType.StageClear:
                    break;
                case myEventType.GameOver:
                    // game over시 Map reloading을 위해 표시함.
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



