using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    // Start is called before the first frame update
    public float fallingSpeed;
    public bool blCount = false;
    public bool blLeft = false;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(0,-fallingSpeed*Time.deltaTime,0);
        blCount = (transform.childCount > 0)? false : true;
        blLeft = (GetComponent<CreateScene>().leftBlock > 0)? false : true;
        if(blCount&&blLeft)
        {
            EventManager.Instance.PostNotification(myEventType.StageClear, this);
        }
    }
}
