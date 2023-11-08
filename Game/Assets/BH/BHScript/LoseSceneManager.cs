using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PlayerInformation;
using TMPro;
using System.Text;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class LoseSceneManager : MonoBehaviour,IListener
{
     
       GameObject ItemTemplate;
       GameObject g;
        public Transform ShopView;

    

    public List<Sprite> RelicImageList;

    public List<GameObject> bitList;
    public List<Sprite> obtainedBitAndRelicSprite;
    public List<string> obtainedRelic;
    private int _priority = 1;
    public Text blockText;
    public Text coinText;
     public Text adPoint;

     public GameObject NoItem;

    public Animator animator;

   

    public int priority { 
        get => _priority; 
        set => _priority = value; 
    }

    private void Awake()
    {
        SkillTreeSaveJson skillTreeSaveJson = new SkillTreeSaveJson();
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
               // GameObject.FindGameObjectWithTag("Ball").GetComponent<PlayerCollision>().countScore();
                BlockScore();
                CoinScore();
                obtainSkillPoint();
                bringitem();
                setItem();
                skillPoint();
                Time.timeScale = 0;
                break;
            default: throw new System.Exception("There is a unhandled event at " + this.name);
        }
    }
    public void BlockScore()
    {
        if(blockText != null)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(PlayerInfo.playerInfo.curRun.brokenBlock.ToString());
            blockText.text = stringBuilder.ToString();
        }
    }
    private void skillPoint()
    {

        if (File.Exists(Application.dataPath + "/JsonDataSkillTree.text"))
        {
            StreamReader sr = new StreamReader(Application.dataPath + "/JsonDataSkillTree.text");
            string JsonString = sr.ReadToEnd();
            sr.Close();
            SkillTreeSaveJson save = JsonUtility.FromJson<SkillTreeSaveJson>(JsonString);
            

            save.RemainPoint += PlayerInfo.playerInfo.curRun.brokenBlock / 10;

            JsonString = JsonUtility.ToJson(save);
            StreamWriter sw = new StreamWriter(Application.dataPath + "/JsonDataSkillTree.text");
            sw.Write(JsonString);
            sw.Close();
        }
    }

    private void obtainSkillPoint()
    {
        if(adPoint != null)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int temp = PlayerInfo.playerInfo.curRun.brokenBlock/10;
            stringBuilder.Append(temp.ToString());
            adPoint.text = stringBuilder.ToString();
        }
        
    }

   public void CoinScore()
    {
        if(coinText != null)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(PlayerInfo.playerInfo.curRun.coin.ToString());
            coinText.text = stringBuilder.ToString();
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
                      g.transform.GetChild(0).GetComponent<Image>().sprite = obtainedBitAndRelicSprite[i];    
            
            }
            Destroy(ItemTemplate);
            if(len == 0){
                NoItem.SetActive(true);
            }
    }
    
    public void bringitem()
    {
        
        int lenBit = PlayerInformation.PlayerInfo.playerInfo.bitsList.Count;
        int lenRelic = PlayerInformation.PlayerInfo.playerInfo.curRun.relicList.Count;
        for(int i=0; i<lenBit; i++)
        {
            string tempbits = PlayerInformation.PlayerInfo.playerInfo.bitsList[i].name;
            GameObject tempGameobejetBits = bitList.Find(x => x.name == tempbits);
            obtainedBitAndRelicSprite.Add(tempGameobejetBits.GetComponent<SpriteRenderer>().sprite);
        }
        for(int i=0; i<lenRelic; i++)
        {
            string temp = PlayerInformation.PlayerInfo.playerInfo.curRun.relicList[i];
            Sprite tempSprite = RelicImageList.Find(x => x.name == temp);
            obtainedBitAndRelicSprite.Add(tempSprite);
        }
    }

    public void Close(){
        StartCoroutine(CloseAfterDelay());
    }

    private IEnumerator CloseAfterDelay()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        animator.ResetTrigger("close");
    }
}

