using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Sale : MonoBehaviour
{

    public SaveData saveData;
    public GameObject obj;
    public GameObject nakami;
    public GameObject textPanel;
    public GameObject image;
    public Sprite spriteImage;
    public int a;
    public GameObject yes;
    public GameObject no;
    public GameObject pop;
    public GameObject backButton;
    public Text text;
    public string word;
  //  public RectTransform x;


    // Start is called before the first frame update
    void Start()
    {
        a = saveData.drops.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int DropOnclick()
    {
        
            GameObject obj = nakami.transform.GetChild(1).gameObject;
            // Debug.Log(obj);
           Drop script = obj.GetComponent<Drop>();
            //  Debug.Log(script);
           
           for(int i=0; i<saveData.drops.Count; i++)
        {
           
           
           
             if (saveData.drops[i].GetComponent<Drop>().partName.Equals(script.partName))
             {
                 a = i;
                word = script.partName+"\n";
             }
        }

        //ÉLÉÉÉââÊëúÇÃï\é¶
        Debug.Log(a);
            return a;
        
       
    }






    public void sakuzyo()
    {
        saveData.drops.RemoveAt(a);
        text.text = "";
        SceneManager.LoadScene("ëfçﬁàÍóó");
    }


    public void window()
    {
        Debug.Log(a);
        Debug.Log(saveData.drops.Count);
        if (text.text.Equals("") || a== saveData.drops.Count)
        {
            text.fontSize = 8;
            text.text = "îÑãpÇ∑ÇÈÇ‡ÇÃÇëIÇÒÇ≈Ç≠ÇæÇ≥Ç¢";
            //yes.gameObject.SetActive(true);

            // no.gameObject.SetActive(true);
            backButton.gameObject.SetActive(true);
            pop.gameObject.SetActive(true);
        }
        else
        {
            text.fontSize = 10;
            text.text += "\nÇñ{ìñÇ…îÑãpÇµÇ‹Ç∑Ç©ÅH";
            yes.gameObject.SetActive(true);
            no.gameObject.SetActive(true);
            pop.gameObject.SetActive(true);
        }
        Debug.Log(text.text);
       

    }


    public void back()
    {
        text.text = "";
        yes.gameObject.SetActive(false);
        no.gameObject.SetActive(false);
        pop.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
    }



}
