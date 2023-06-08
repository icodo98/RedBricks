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
        public PlayerData curData;
        public Rito.WeightedRandomPicker<Bits> RandomPicker = new Rito.WeightedRandomPicker<Bits>();
        private int _priority = 0;
        public int priority
        {
            get => _priority;
            set => _priority = value;
        }

        public int HP
        {
            get => _HP;
            set => _HP = value;
        }
        private int _HP;
        private string dataFilePath;
        private string infoFilePath;
        public int MaxHP = 100;

        public void Awake()
        {
            DontDestroyOnLoad(gameObject);
            dataFilePath = Application.dataPath + "/PlayerData.json";
            dataFilePath = Application.dataPath + "/PlayerInfo.json";


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
            HP = curData.IncreaseHealth * MaxHP;
        }
        

        /*
         * stageClear�� �߻��� �̺�Ʈ. ���� bit�� �߰��Ͽ�����.
         */
        public void OnEvent(myEventType eventType, Component Sender, object Param = null)
        {
            switch (eventType)
            {
                case myEventType.StageClear:
                    if (curData.EnableSelection) break;
                    Bits[] temp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBits>().temporalBits.ToArray();
                    if (temp.Length == 0) break;
                    int i = UnityEngine.Random.Range(0, temp.Length);
                    Bits aBits = GetComponent(temp[i].GetType()) as Bits;
                    bitsList.Add(aBits);
                    break;
                case myEventType.GameOver:
                    // game over�� Map reloading�� ���� ǥ����.
                    PlayerPrefs.SetInt("GameOver", 1);
                    PlayerDataUtils.SaveDataAsJson(dataFilePath, curData);
                    break;
                default: throw new System.Exception("There is a unhandled event at " + this.name);

            }
        }
        private void OnApplicationQuit()
        {
           PlayerDataUtils.SaveDataAsJson(dataFilePath, curData);
        }
        private void onSatgeClear()
        {
            PlayerDataUtils.SaveDataAsJson(infoFilePath, this);
        }
        public void LoadPlayerInfo()
        {
            PlayerInfo loaded = PlayerDataUtils.ReadInfo(infoFilePath);
            if (loaded != null)
            {
                playerInfo = loaded;
            }

        }
    }
}



