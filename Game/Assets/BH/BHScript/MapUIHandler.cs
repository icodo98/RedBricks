using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapUIHandler : MonoBehaviour
{
    public Button[] Stages;
   int stageTempMem;

private void Start() {
    unlockStages();
    
}
    private void Update() {
        Debug.Log(stageTempMem);
    }

    public void backToMain()
    {
        SceneManager.LoadScene(0);
    }
    
    public void backToMap()
    {
        SceneManager.LoadScene(1);
    }

    public void StartStageScene(int stageNum)
    {
        SceneManager.LoadScene("Stage" + stageNum.ToString());
    }

    public void stagesUnlockReset(){
        

        for(int i = 0 ; i < Stages.Length; i++)
        {
            Stages[i].interactable = false;
        }  
        Stages[0].interactable = true;
        stageTempMem = 0;
    }
    public void stageUnlocktempMem(int stageMem)
    {
        stageTempMem = stageMem;
    }
    public void unlockStages()
    {
        switch(stageTempMem){
            case 1:
                    for(int i = 0 ; i < Stages.Length; i++)
                     {
            Stages[i].interactable = false;
                    }  
                    Stages[1].interactable = true;
                    Stages[2].interactable = true;
                    Stages[3].interactable = true;
                    break;

            case 21:
                     for(int i = 0 ; i < Stages.Length; i++)
                     {
                     Stages[i].interactable = false;
                    }  
                    Stages[4].interactable = true;
    
                    break;
            case 22:

                    for(int i = 0 ; i < Stages.Length; i++)
                    {
                    Stages[i].interactable = false;
                    }  
                        Stages[4].interactable = true;
                        Stages[5].interactable = true;
                    break;

            case 23:
                    for(int i = 0 ; i < Stages.Length; i++)
                    {
                        Stages[i].interactable = false;
                    }  
                    Stages[5].interactable = true;
                    break;
            case 31:
                    for(int i = 0 ; i < Stages.Length; i++)
                        {
                        Stages[i].interactable = false;
                    }  
                    Stages[6].interactable = true;
                    Stages[7].interactable = true;
                     break;
            case 32:
                   for(int i = 0 ; i < Stages.Length; i++)
                    {
                     Stages[i].interactable = false;
                    }  
                     Stages[7].interactable = true;
                     Stages[8].interactable = true;
                    break;
        }
    }
}
