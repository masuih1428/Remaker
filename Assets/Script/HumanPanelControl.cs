using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanPanelControl : MonoBehaviour
{
    public SaveData saveData;
    public GameObject content;
    public GameObject prefbPanel;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < saveData.humanList.Count; i++)
        {
            GameObject panelObj = (GameObject)Instantiate(prefbPanel);
            panelObj.transform.SetParent(content.transform, false);
            GameObject humanObj = (GameObject)UnityEditor.PrefabUtility.InstantiatePrefab(saveData.humanList[i], panelObj.transform);
            humanObj.transform.parent.SetParent(panelObj.transform, false);
            humanObj.SetActive(false);
            GameObject nakamiImage = panelObj.transform.GetChild(0).gameObject;//panelの中のnakamiImageを取得
            SpriteRenderer spriteRenderer = humanObj.GetComponent<SpriteRenderer>();//dropのimageを取得
            Image image = nakamiImage.GetComponent<Image>();
            image.sprite = spriteRenderer.sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
