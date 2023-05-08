using System;
using System.IO;
using UnityEngine;

namespace PlayerInformation
{
    [Serializable]
    public class PlayerData
    {
        public float Amor; //�ܴܷ�
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