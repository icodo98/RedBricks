using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        DisplaySkillPoint();
        UpadteSkillImage();
        DisplaySkillLevel();
    }
        private void DisplaySkillPoint()
        {
        PointsText.text = reamainPoint + "/"+ totalPoints;
        }
    
    private void UpadteSkillImage()
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
        UpadteSkillImage();
        DisplaySkillPoint();
        DisplaySkillLevel();
    }
    public void DisplaySkillLevel()
    {
        if(activateSkill !=null)
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
        else
        {
            return;
        }
        
    }
}
