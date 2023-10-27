using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace PlayerInformation
{
    [Serializable]
    public class PlayerData
    {
        public float Amor; //단단력 공과 부딪힐때의 데미지 감소
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
        public int curResurrection; //현재 남은 부활기회
        public float RegenHealth; // 재력 재생량
        public List<Bits> bitsList; //현재 가지고 있는 bit



        public PlayerData()
        {
            curResurrection = Resurrection;
            AddBall = false;
        }
        public PlayerData( PlayerData loadData)
        {
            Amor= loadData.Amor;
            Attack= loadData.Attack;
            Speed= loadData.Speed;
            BarLength= loadData.BarLength;
            Critical= loadData.Critical;    
            ElementDamage= loadData.ElementDamage;
            AddBall= loadData.AddBall;
            curResurrection = loadData.Resurrection;
            EnableSelection= loadData.EnableSelection;
            FallingPenalty= loadData.FallingPenalty;
            IncreaseHealth= loadData.IncreaseHealth;
            Resurrection = loadData.Resurrection;
            RegenHealth = loadData.RegenHealth;
            bitsList = loadData.bitsList;
        }

    }
    public enum DamageType
    {
        Non,
        Explosion,
        Poision,
        Dark,
        Electricity
    }
    public class PlayerDataUtils : MonoBehaviour
    {
        public static PlayerData ReadData(string Path)
        {
            PlayerData LoadData= new ();
            if(Path == null)
            {
                Path = Application.dataPath + "/PlayerData.json";
            }
            if (File.Exists(Path))
            {
                string data = File.ReadAllText(Path);
                LoadData = JsonUtility.FromJson<PlayerData>(data);
            }
            else throw new Exception("There is no save flie!");
            return LoadData;
        }
        public static PlayerRun ReadInfo(string Path)
        { 
            if (File.Exists(Path))
            {
                string data = File.ReadAllText(Path);
                return JsonUtility.FromJson<PlayerRun>(data);
            }
            else throw new Exception("There is no save flie!");
        }
        public static bool SaveDataAsJson(string Path, object data) {
            Type dataType = data.GetType();
            if (!dataType.IsSerializable) return false;
            string dataWrite = JsonUtility.ToJson(data,true);
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
        public static bool SavePerData() {
            return SaveDataAsJson(Application.dataPath + "/PlayerData.json", PlayerInfo.playerInfo.curData);
        }
        public static bool SavePlayerInfo()
        {

            return SaveDataAsJson(Application.dataPath + "/PlayerInfo.json", PlayerInfo.playerInfo.curRun);
        }
        public static bool SaveCurData()
        {
            return SaveDataAsJson(Application.dataPath + "/PlayerCurData.json", PlayerInfo.playerInfo.curData);
        }
    }
    
}