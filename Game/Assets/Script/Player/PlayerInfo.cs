using System.Collections.Generic;
using UnityEngine;
using System.IO;


namespace PlayerInformation
{
    public class PlayerInfo : MonoBehaviour, IListener
    {
        public static PlayerInfo playerInfo;
        public List<Bits> bitsList;
        PlayerData LoadData;
        private int _priority = 0;
        public int priority
        {
            get => _priority;
            set => _priority = value;
        }

        public void Awake()
        {
            DontDestroyOnLoad(gameObject);
            if (playerInfo == null)
            {
                playerInfo = this;
            }
            else if (playerInfo != this)
            {
                Destroy(gameObject);
            }
        }
        public void Start()
        {
            EventManager.Instance.AddListener(myEventType.StageClear, playerInfo);
            EventManager.Instance.AddListener(myEventType.GameOver, playerInfo);
            string FileName = "PlayerData.json";

            string Path = Application.dataPath + "/" + FileName;
            LoadData = PlayerDataUtils.ReadData(Path);
        }
        

        /*
         * stageClear시 발생할 이벤트. 영구 bit을 추가하여야함.
         */
        public void OnEvent(myEventType eventType, Component Sender, object Param = null)
        {
            switch (eventType)
            {
                case myEventType.StageClear:
                    Bits[] temp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBits>().temporalBits.ToArray();
                    if (temp.Length == 0) break;
                    int i = Random.Range(0, temp.Length);
                    Bits aBits = GetComponent(temp[i].GetType()) as Bits;
                    bitsList.Add(aBits);
                    break;
                case myEventType.GameOver:
                    PlayerPrefs.SetInt("GameOver", 1);
                    break;
                default: throw new System.Exception("There is a unhandled event at " + this.name);

            }
        }
    }
}



