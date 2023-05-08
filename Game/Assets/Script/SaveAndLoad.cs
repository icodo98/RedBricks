using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Experimental.RestService;
using UnityEngine;

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