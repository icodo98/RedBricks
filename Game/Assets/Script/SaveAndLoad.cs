using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Experimental.RestService;
using UnityEngine;

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
    public void printValue()
    {
        string str = "This is the vaule :";
        Debug.Log(str + Amor);

    }
}
public class SaveAndLoad : MonoBehaviour
{
    PlayerData LoadData;
    // Start is called before the first frame update
    void Start()
    {
        string FileName = "PlayerData";
        
        string Path = Application.dataPath + "/PlayerData.json";
        Debug.Log("Path : " + Path);
        if (!File.Exists(Path))
        {
            LoadData = new PlayerData();
        }
        else
        {
            string data = File.ReadAllText(Path);
            LoadData = JsonUtility.FromJson<PlayerData>(data);
        }
        LoadData.printValue();
        LoadData.Amor += 5;
        string classToJson = JsonUtility.ToJson(LoadData,true);
        File.WriteAllText(Path, classToJson);
    }

}