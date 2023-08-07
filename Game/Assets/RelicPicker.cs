using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RelicPicker : MonoBehaviour
{
    Rito.WeightedRandomPicker<GameObject> wrRelicPicker = new Rito.WeightedRandomPicker<GameObject>();
    public Vector3[] positions = new Vector3[3];
    private void Start()
    {
        Transform[] Relics = GetComponentsInChildren<Transform>();
        foreach (Transform trRelic in Relics)
        {
            wrRelicPicker.Add(trRelic.gameObject,10);
        }



        //getRelic();
    }

    public void getRelic()
    {
        int i = 0;
        foreach (int idx in woDuplicateRandomRange(transform.childCount,3))
        {
            transform.GetChild(idx).position = positions[i++];
        }
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
