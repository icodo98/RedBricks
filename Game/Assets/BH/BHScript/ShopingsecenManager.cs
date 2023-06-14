using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopingsecenManager : MonoBehaviour
{
   [System.Serializable] class ShopItem
   {
    public Sprite Image;
    public int Price;
    public bool IsPurchased = false;
   }
   
   [SerializeField] List<ShopItem> ShopItemList;
    
    GameObject ItemTemplate;
   GameObject g;
   [SerializeField] Transform ShopView;

   void Start()
   {
    ItemTemplate = ShopView.GetChild(0).gameObject;
    int len =ShopItemList.Count;
    for(int i =0; i <len; i++)
    {
        g = Instantiate ( ItemTemplate, ShopView);
        g.transform.GetChild (0).GetComponent<Image>().sprite = ShopItemList[i].Image;
        g.transform.GetChild (1).GetComponent<Text>().text = ShopItemList[i].Price.ToString();
        g.transform.GetChild (2).GetComponent<Button>().interactable = !ShopItemList[i].IsPurchased;
    }
    Destroy(ItemTemplate);
   }
   
    public void ToMain()
   {
        StartCoroutine(LoadLevel(2));
   }
    
   
    public Animator transtiton;
    public float transtitonTime = 1f;
    
    
    IEnumerator LoadLevel(int scene)
    {
        transtiton.SetTrigger("Start");
        yield return new WaitForSeconds(transtitonTime);
        SceneManager.LoadScene(scene);
    }
    
}
