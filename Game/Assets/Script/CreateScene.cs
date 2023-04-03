using PlasticGui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateScene : MonoBehaviour
{
    public GameObject prefabBlock;
    [SerializeField]
    private Vector3 startPoint = new Vector3(-0.85f, 0.45f, 0f);

    [SerializeField]
    private Vector3 endPoint = new Vector3(0.8f, 1.9f, 0f);

    [SerializeField]
    private int MaxCols = 7;
    [SerializeField]
    private int MaxRows = 4;
    [SerializeField]
    private int MaxBloNums = 40;
    [SerializeField]
    private int IniBloNums = 20;

    public int leftBlock
    {
        get { return LeftBloNum; }
    }
    private int LeftBloNum;
    /*
     * 초기에 IniBloNums의 크기 만큼 블럭을 만들어 낸다.
     * 전체 중에서 블럭이 생길 수 있는 x,y좌표를 설정한뒤 하나의 벡터로 만들어서
     * 각 위치에 블럭을 인스턴스화한다.
     */
    void Start()
    {
        
        GameObject Blocks = this.gameObject;
        int cols = MaxCols;
        int rows = MaxRows;
        float h = endPoint.y - startPoint.y;
        float w = endPoint.x - startPoint.x;
        h /= cols;
        w /= rows;
        LeftBloNum = MaxBloNums - IniBloNums;

        float[] colPoint = new float[cols];
        for (int i = 0; i < cols; i++)
        {
            colPoint[i] = startPoint.y + h * i;
        }
        float[] rowPoint = new float[rows];
        for (int i = 0; i < rows; i++)
        {
            rowPoint[i] = startPoint.x + w * i;
        }
        List<Vector3> allPoints = new List<Vector3>();
       
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                allPoints.Add(new Vector3(rowPoint[j], colPoint[i]));
            }
        }

        while (IniBloNums > 0 && allPoints.Count > 0)
        {
            int i = Random.Range(0, allPoints.Count);
            Instantiate(prefabBlock, allPoints[i], Quaternion.identity, Blocks.transform);
            allPoints.RemoveAt(i);
            IniBloNums--;
        }
        StartCoroutine(CreateNewRow(LeftBloNum));
        
    }
    /*
     * 생성해야할 블럭이 남아 있다면 매3초 마다 새로운 블럭을 만들어 낸다.
     */
    IEnumerator CreateNewRow(int LeftBloNum)
    {
        while (LeftBloNum > 0)
        {
            Debug.Log("In the coroutine while");
            float h = endPoint.y;
            float w = endPoint.x - startPoint.x;
            w /= MaxRows;

            int newBlock = Random.Range(0, MaxRows);
            newBlock = (newBlock < LeftBloNum) ? newBlock : LeftBloNum;
            LeftBloNum -= newBlock;

            float[] rowPoint = new float[MaxRows];
            for (int i = 0; i < MaxRows; i++)
            {
                rowPoint[i] = startPoint.x + w * i;
            }
            List<Vector3> newPoints = new List<Vector3>();
            foreach (float item in rowPoint)
            {
                Debug.Log("row points are " + item);
                newPoints.Add(new Vector3(item, h, 0));
            }
            
            while (newBlock > 0 && newPoints.Count > 0)
            {
                int i = Random.Range(0, newPoints.Count);
                Debug.Log("random position's index is " + i);
                Debug.Log("random position is " + newPoints[i]);
                Instantiate(prefabBlock, newPoints[i], Quaternion.identity, this.transform);
                newPoints.RemoveAt(i);
                newBlock--;
            }
            yield return new WaitForSeconds(3f);
        }
        
        yield break;
    }
}
