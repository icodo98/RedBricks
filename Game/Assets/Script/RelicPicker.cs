using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelicPicker : MonoBehaviour
{
    Rito.WeightedRandomPicker<GameObject> wrRelicPicker = new Rito.WeightedRandomPicker<GameObject>();
    public Vector3[] positions = new Vector3[3];
    private int[] pickedRelic = new int[3];
    public Button[] btns = new Button[3];
    private void Start()
    {
        Transform[] Relics = GetComponentsInChildren<Transform>();
        foreach (Transform trRelic in Relics)
        {
            wrRelicPicker.Add(trRelic.gameObject,10);
        }
    
    //    getRelic();
    }
    
    public void getRelic()
    {
        int i = 0;
        pickedRelic = woDuplicateRandomRange(transform.childCount, 3);
        foreach (int idx in pickedRelic)
        {
            transform.GetChild(idx).position = positions[i];
            
            btns[i].onClick.AddListener(() => transform.GetChild(idx).GetComponent<Animator>().SetTrigger("Dance"));
            i++;
        }
    }
    public void addRelic(int idx)
    {
        transform.GetChild(pickedRelic[--idx]).GetComponent<Relic.Relic>().Power();
        PlayerInformation.PlayerDataUtils.SavePlayerInfo();
        PlayerInformation.PlayerDataUtils.SaveCurData();
    }
    private int[] woDuplicateRandomRange (int max,int count)
    {
        int[] returnArray = new int[count];
        List<int> tempArray = new List<int>();
        for (int i = 0;i < max; i++)
        {
            tempArray.Add(i);
        }
        for (int i = 0; i < count; i++)
        {
            int j = Random.Range(0, tempArray.Count) ;
            returnArray[i] = tempArray[j];
            tempArray.RemoveAt(j);

        }
        return returnArray;


    }

}
