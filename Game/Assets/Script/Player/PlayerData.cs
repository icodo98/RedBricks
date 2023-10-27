using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace PlayerInformation
{
    [Serializable]
    public class PlayerData
    {
        public float Amor; //�ܴܷ� ���� �ε������� ������ ����
        public float Attack; //���ݷ�
        public float Speed; //���� �ӵ�
        public float BarLength; //���� ���� ����
        public float Critical; //ġ��ŸȮ�� ����
        public float[] ElementDamage; //�Ӽ� ������
        public bool AddBall; //���۽� �߰� ��
        public int Resurrection; // ��Ȱ��ȸ
        public bool EnableSelection; //bit ��� ����
        public float FallingPenalty; // ���������� �г�Ƽ ����
        public int IncreaseHealth; //�ִ�ü�� ����
        public int curResurrection; //���� ���� ��Ȱ��ȸ
        public float RegenHealth; // ��� �����
        public List<Bits> bitsList; //���� ������ �ִ� bit



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