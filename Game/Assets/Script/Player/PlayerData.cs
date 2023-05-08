using System;
using System.IO;
using UnityEngine;

namespace PlayerInformation
{
    [Serializable]
    public class PlayerData
    {
        public float Amor; //단단력
        public float Attack; //공격력
        public float Speed; //공의 속도
        public float BarLength; //바의 길이 증가
        public float Critical; //치명타확률 증가
        public float[] ElementDamage; //속성 데미지
        public bool AddBall; //시작시 추가 공
        public int Resurrection; // 부활기회
        public bool EnableSelection; //bit 계승 가능
        public float FallingPenalty; // 떨어졌을때 패널티 감소
        public int IncreaseHealth; //최대체력 증가
        
    }
    public class PlayerDataUtils : MonoBehaviour
    {
        public static PlayerData ReadData(string Path)
        {
            PlayerData LoadData= new PlayerData();
            if (File.Exists(Path))
            {
                string data = File.ReadAllText(Path);
                LoadData = JsonUtility.FromJson<PlayerData>(data);
            }
            else return null;
            return LoadData;
        }

        public static bool SaveDataAsJson(string Path, object data) {
            Type dataType = data.GetType();
            if (!dataType.IsSerializable) return false;
            string dataWrite = JsonUtility.ToJson(data);
            try
            {
                File.WriteAllText(Path, dataWrite);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
    
}