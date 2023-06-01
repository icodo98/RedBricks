using System.Collections.Generic;
using UnityEngine;
using System.IO;


namespace PlayerInformation
{
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

        private string FilePath;

        public void Awake()
        {
            DontDestroyOnLoad(gameObject);
            FilePath = Application.dataPath + "/PlayerData.json";

            if (playerInfo == null)
            {
                playerInfo = this;
            }
            else if (playerInfo != this)
            {
                Destroy(gameObject);
            }
            LoadData = PlayerDataUtils.ReadData(FilePath);
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
        }
        

        /*
         * stageClear시 발생할 이벤트. 영구 bit을 추가하여야함.
         */
        public void OnEvent(myEventType eventType, Component Sender, object Param = null)
        {
            switch (eventType)
            {
                case myEventType.StageClear:
                    if (curData.EnableSelection) break;
                    Bits[] temp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBits>().temporalBits.ToArray();
                    if (temp.Length == 0) break;
                    int i = Random.Range(0, temp.Length);
                    Bits aBits = GetComponent(temp[i].GetType()) as Bits;
                    bitsList.Add(aBits);
                    break;
                case myEventType.GameOver:
                    // game over시 Map reloading을 위해 표시함.
                    PlayerPrefs.SetInt("GameOver", 1);
                    PlayerDataUtils.SaveDataAsJson(FilePath, curData);
                    break;
                default: throw new System.Exception("There is a unhandled event at " + this.name);

            }
        }
        private void OnApplicationQuit()
        {
           PlayerDataUtils.SaveDataAsJson(FilePath, curData);
        }
    }
}



