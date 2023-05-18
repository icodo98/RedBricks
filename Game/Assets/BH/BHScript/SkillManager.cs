using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    public Skill[] skills;
    public SkillButton[] skillButtons;

    public Skill activateSkill;
    public int totalPoints;
    public int reamainPoint;
    public Text PointsText;
    

    [Header("STAGE 04")]
    public Text[] skillLevelTexts;
    //public Text SkillLevelDisplayText;

    [Header("Game object")]
    public GameObject Amor, Attack, Speed, BarLength,Critical, ElementDamage, AddBall, Resurrection,EnableSeletion,FallinfPenalty,IncreaseHealth;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        reamainPoint = totalPoints;
        LoadByJSON();
        DisplaySkillPoint();
     //   UpadteSkillImage();
        DisplaySkillLevel();
        
    }
        private void DisplaySkillPoint()
        {
        PointsText.text = "RemainPoint : " + reamainPoint;
        }
    
/*    private void UpadteSkillImage()
    {
     for(int i =0; i< skills.Length; i++)
     {
         if(skills[i].isUpgrade)
         {
             skills[i].GetComponent<Image>().color = new Vector4(1,1,1,1);
             
         }
         else
         {
              skills[i].GetComponent<Image>().color = new Vector4(0.39f,0.39f,0.39f,1);
         }
     }
    }
    */
    public void UpgradeButton()
    {  
        //single time upgrade
         /*
        if(!activateSkill.isUpgrade && reamainPoint >=1)
        {
            for(int i = 0; i < activateSkill.previousSkill.Length; i++)
            {
                if(activateSkill.previousSkill[i].isUpgrade)
                {
                    activateSkill.isUpgrade = true;
                     reamainPoint -=1;
                     activateSkill.skillLevel++;
                }
                else
                {
                    Debug.Log("UPGRADE YOUR PREVIOUS SKILL FIRST");
                }
            }
            
        }
        else
        {
            Debug.Log("Not enough skill points OR" + activateSkill + " is upgraded yet");
        } */

        //levelup skill
        /*
        for(int i = 0; i < activateSkill.previousSkill.Length; i++)
        {
            if(activateSkill.previousSkill[i].isUpgrade && reamainPoint > 0)
            {
                reamainPoint -= 1;
                activateSkill.isUpgrade= true;
                activateSkill.skillLevel++;
            }
        }*/
        //redbreak
         if( activateSkill.skillLevel < activateSkill.skillMaxLevel && reamainPoint > 0)
            {
                reamainPoint -= 1;
                activateSkill.isUpgrade= true;
                activateSkill.skillLevel++;
            }
     //   UpadteSkillImage();
        DisplaySkillPoint();
        DisplaySkillLevel();
        SaveByJSON();
    }
    public void DisplaySkillLevel()
    {
        
            for(int i =0; i<skills.Length; i++)
        {
            if(skills[i].isUpgrade)
            {
                skillLevelTexts[i].text = skills[i].skillLevel.ToString();
            }
            else
            {
                skillLevelTexts[i].text = "";
            }
        }


       
        
    }
    
    private SkillTreeSaveJson saveGameObject()
    {
        SkillTreeSaveJson save = new SkillTreeSaveJson();

        save.RemainPoint = reamainPoint;

        save.AddBall = AddBall.GetComponent<Skill>().skillLevel;
        save.Amor = Amor.GetComponent<Skill>().skillLevel;
        save.Attack = Attack.GetComponent<Skill>().skillLevel;
        save.BarLength = BarLength.GetComponent<Skill>().skillLevel;
        save.Critiacal = Critical.GetComponent<Skill>().skillLevel;
        save.ElementDamage = ElementDamage.GetComponent<Skill>().skillLevel;
        save.EnalbeSeletion = EnableSeletion.GetComponent<Skill>().skillLevel;
        save.FallingPenalty = FallinfPenalty.GetComponent<Skill>().skillLevel;
        save.IncreaseHealth = IncreaseHealth.GetComponent<Skill>().skillLevel;
        save.Resurrection = Resurrection.GetComponent<Skill>().skillLevel;
        save.Speed = Speed.GetComponent<Skill>().skillLevel;

        save.AddBallisUpgrad = AddBall.GetComponent<Skill>().isUpgrade;
        save.AmorisUpgrad = Amor.GetComponent<Skill>().isUpgrade;
        save.AttackisUpgrad = Attack.GetComponent<Skill>().isUpgrade;
        save.BarLengthisUpgrad = BarLength.GetComponent<Skill>().isUpgrade;
        save.CritiacalisUpgrad = Critical.GetComponent<Skill>().isUpgrade;
        save.ElementDamageisUpgrad = ElementDamage.GetComponent<Skill>().isUpgrade;
        save.EnalbeSeletionisUpgrad = EnableSeletion.GetComponent<Skill>().isUpgrade;
        save.FallingPenaltyisUpgrad = FallinfPenalty.GetComponent<Skill>().isUpgrade;
        save.IncreaseHealthisUpgrad = IncreaseHealth.GetComponent<Skill>().isUpgrade;
        save.ResurrectionisUpgrad = Resurrection.GetComponent<Skill>().isUpgrade;
        save.SpeedisUpgrad = Speed.GetComponent<Skill>().isUpgrade;
    
        return save;
    }
    private void SaveByJSON()
    {
        SkillTreeSaveJson save = saveGameObject();
        string JsonString = JsonUtility.ToJson(save);
        StreamWriter sw = new StreamWriter(Application.dataPath + "/JsonDataSkillTree.text");
        sw.Write(JsonString);
        sw.Close();
        Debug.Log("Save");
        
    }
    private void LoadByJSON()
    {
        if(File.Exists(Application.dataPath + "/JsonDataSkillTree.text"))
        {
            StreamReader sr = new StreamReader(Application.dataPath + "/JsonDataSkillTree.text");
            string JsonString = sr.ReadToEnd();
            sr.Close();
            SkillTreeSaveJson save =JsonUtility.FromJson<SkillTreeSaveJson>(JsonString);
            Debug.Log("LOADED");

        ////
        reamainPoint = save.RemainPoint;

        AddBall.GetComponent<Skill>().skillLevel = save.AddBall;
        Amor.GetComponent<Skill>().skillLevel =save.Amor;
        Attack.GetComponent<Skill>().skillLevel = save.Attack;
        BarLength.GetComponent<Skill>().skillLevel = save.BarLength;
        Critical.GetComponent<Skill>().skillLevel = save.Critiacal;
      ElementDamage.GetComponent<Skill>().skillLevel =  save.ElementDamage;
        EnableSeletion.GetComponent<Skill>().skillLevel = save.EnalbeSeletion;
        FallinfPenalty.GetComponent<Skill>().skillLevel = save.FallingPenalty;
        IncreaseHealth.GetComponent<Skill>().skillLevel = save.IncreaseHealth;
        Resurrection.GetComponent<Skill>().skillLevel = save.Resurrection;
        Speed.GetComponent<Skill>().skillLevel= save.Speed;

        AddBall.GetComponent<Skill>().isUpgrade = save.AddBallisUpgrad;
        Amor.GetComponent<Skill>().isUpgrade =save.AmorisUpgrad;
        Attack.GetComponent<Skill>().isUpgrade = save.AttackisUpgrad;
        BarLength.GetComponent<Skill>().isUpgrade = save.BarLengthisUpgrad;
        Critical.GetComponent<Skill>().isUpgrade = save.CritiacalisUpgrad;
      ElementDamage.GetComponent<Skill>().isUpgrade =  save.ElementDamageisUpgrad;
        EnableSeletion.GetComponent<Skill>().isUpgrade = save.EnalbeSeletionisUpgrad;
        FallinfPenalty.GetComponent<Skill>().isUpgrade= save.FallingPenaltyisUpgrad;
        IncreaseHealth.GetComponent<Skill>().isUpgrade = save.IncreaseHealthisUpgrad;
        Resurrection.GetComponent<Skill>().isUpgrade = save.ResurrectionisUpgrad;
        Speed.GetComponent<Skill>().isUpgrade= save.SpeedisUpgrad;
        ///
        }
        else
        {
            Debug.Log("NOT FOUND SAVE FILE");
        }
    }
    
    public void testButton()
    {
        SkillTreeSaveJson save = new SkillTreeSaveJson();

        save.RemainPoint = 15;
        save.AddBall = 0;
        save.Amor = 0;
        save.Attack = 0;
        save.BarLength = 0;
        save.Critiacal = 0;
        save.ElementDamage =0;
        save.EnalbeSeletion = 0;
        save.FallingPenalty = 0;
        save.IncreaseHealth = 0;
        save.Resurrection = 0;
        save.Speed = 0;

        save.AddBallisUpgrad = false;
        save.AmorisUpgrad = false;
        save.AttackisUpgrad = false;
        save.BarLengthisUpgrad = false;
        save.CritiacalisUpgrad = false;
        save.ElementDamageisUpgrad = false;
        save.EnalbeSeletionisUpgrad = false;
        save.FallingPenaltyisUpgrad = false;
        save.IncreaseHealthisUpgrad = false;
        save.ResurrectionisUpgrad = false;
        save.SpeedisUpgrad = false;

     string JsonString = JsonUtility.ToJson(save);
        StreamWriter sw = new StreamWriter(Application.dataPath + "/JsonDataSkillTree.text");
        sw.Write(JsonString);
        sw.Close();
        Debug.Log("Save");
        LoadByJSON();
        DisplaySkillPoint();
        DisplaySkillLevel();
    }
}
