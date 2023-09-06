using UnityEngine;
using UnityEngine.SceneManagement;
using PlayerInformation;
using TMPro;
using System.Text;
using System.Linq.Expressions;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Security.Cryptography.X509Certificates;

public class LoseSceneManager : MonoBehaviour,IListener
{
    
       GameObject ItemTemplate;
       GameObject g;
        public Transform ShopView;

    

    public List<GameObject> RelicList;
    public List<Sprite> obtainedBitAndRelicSprite;
    public List<string> obtainedRelic;
    private int _priority = 1;
    public TextMeshProUGUI blockScore;
    public int priority { 
        get => _priority; 
        set => _priority = value; 
    }

    private void Awake()
    {
        
    }
    private void Start()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        EventManager.Instance.AddListener(myEventType.GameOver, this);
    }
    public void OnEvent(myEventType eventType, Component Sender, object Param = null)
    {
        switch (eventType)
        {
            case myEventType.GameOver:
                this.transform.GetChild(0).gameObject.SetActive(true);
                BlockScore();
                bringitem();
                setItem();
                Time.timeScale = 0;
                break;
            default: throw new System.Exception("There is a unhandled event at " + this.name);
        }
    }
    public void BlockScore()
    {
        if(blockScore != null)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Broken block : ");
            stringBuilder.Append(PlayerInfo.playerInfo.curRun.brokenBlock.ToString());
            blockScore.text = stringBuilder.ToString();
        }
    }
    public void TitleButton()
    {
        Time.timeScale+= 1;
        SceneManager.LoadScene(0);
    }

    public void RetryButton()
    {
        PlayerInfo.playerInfo.curData.curResurrection--;
        PlayerPrefs.SetInt("GameOver",0);
        EventManager.Instance.PostNotification(myEventType.GameResume,this,true);
        Time.timeScale = 1;
        transform.GetChild(0).gameObject.SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void setItem()
    {
        ItemTemplate = ShopView.GetChild(0).gameObject;
         int len =obtainedBitAndRelicSprite.Count;
              for(int i =0; i <len; i++)
            {
                      g = Instantiate ( ItemTemplate, ShopView);
                      g.transform.GetComponent<SpriteRenderer>().sprite = obtainedBitAndRelicSprite[i];    
            }
            Destroy(ItemTemplate);
    }
    
    public void bringitem()
    {
        int lenBit = PlayerInformation.PlayerInfo.playerInfo.bitsList.Count;
        int lenRelic = PlayerInformation.PlayerInfo.playerInfo.curRun.relicList.Count;
        for(int i=0; i<lenBit; i++)
        {
            obtainedBitAndRelicSprite.Add(PlayerInformation.PlayerInfo.playerInfo.bitsList[i].GetComponent<Sprite>());
        }
        for(int i=0; i<lenRelic; i++)
        {
            string temp = PlayerInformation.PlayerInfo.playerInfo.curRun.relicList[i];
            GameObject tempGameobejet = RelicList.Find(x => x.name == temp);
            obtainedBitAndRelicSprite.Add(tempGameobejet.GetComponent<Sprite>());
        }
    }
}

