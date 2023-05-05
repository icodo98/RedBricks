using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    //public Image SkillImage;
    public Text skillNameText;
    //public Text skillDesText;

    public int skillButtonId;

    
    public void pressSkillButton()
    {
        SkillManager.instance.activateSkill = transform.GetComponent<Skill>();

      //  SkillImage.sprite = SkillManager.instance.skills[skillButtonId].skillSprite;
        skillNameText.text = SkillManager.instance.skills[skillButtonId].skillName;
      //  skillDesText.text = SkillManager.instance.skills[skillButtonId].skillDes;
    }
}
