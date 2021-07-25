using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelControl : MonoBehaviour
{
    [SerializeField]
    public SaveData saveData;
    public GameObject content;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < saveData.drops.Count; i++)
        {
            GameObject panelObj = (GameObject)Instantiate(panel);
            panelObj.transform.SetParent(content.transform, false);
            GameObject dropObj = (GameObject)Instantiate(saveData.drops[i],panelObj.transform);
            dropObj.transform.parent.SetParent(panelObj.transform, false);
            drop drop = dropObj.GetComponent<drop>();//ドロップスクリプトを取得
            drop.rareStart();
            dropObj.SetActive(false);//画面から消去
            GameObject nakamiImage = panelObj.transform.GetChild(0).gameObject;//panelの中のnakamiImageを取得
            SpriteRenderer spriteRenderer =  dropObj.GetComponent<SpriteRenderer>();//dropのimageを取得
            Image image = nakamiImage.GetComponent<Image>();
            image.sprite = spriteRenderer.sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
