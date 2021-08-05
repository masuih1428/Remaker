using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PanelControl : MonoBehaviour
{
    [SerializeField]
    public SaveData saveData;
    public GameObject headContent;
    public GameObject bodyContent;
    public GameObject armContent;
    public GameObject legContent;
    public GameObject weponContent;
    public GameObject humanContent;
    public GameObject dropPanel;
    public GameObject humanPanel;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < saveData.drops.Count; i++)
        {
            GameObject panelObj = (GameObject)Instantiate(dropPanel);
            switch (saveData.drops[i].GetComponent<Drop>().part)
            {
                case "head":
                    panelObj.transform.SetParent(headContent.transform, false);
                    break;
                case "body":
                    panelObj.transform.SetParent(bodyContent.transform, false);
                    break;
                case "arm":
                    panelObj.transform.SetParent(armContent.transform, false);
                    break;
                case "leg":
                    panelObj.transform.SetParent(legContent.transform, false);
                    break;
                case "wepon":
                    panelObj.transform.SetParent(weponContent.transform, false);
                    break;
            }
            
            GameObject dropObj = (GameObject)Instantiate(saveData.drops[i],panelObj.transform);
            dropObj.transform.parent.SetParent(panelObj.transform, false);
            dropObj.SetActive(false);//��ʂ������
            GameObject nakamiImage = panelObj.transform.GetChild(0).gameObject;//panel�̒���nakamiImage���擾
            SpriteRenderer spriteRenderer =  dropObj.GetComponent<SpriteRenderer>();//drop��image���擾
            Image image = nakamiImage.GetComponent<Image>();
            image.sprite = spriteRenderer.sprite;
        }

        //�����L�����̓��I�z�u
        Debug.Log(saveData.humanList.Count);
        for (int i = 0; i < saveData.humanList.Count; i++)
        {
            GameObject panelObj = (GameObject)Instantiate(humanPanel);
            panelObj.transform.SetParent(humanContent.transform, false);
            GameObject dropObj = (GameObject)PrefabUtility.InstantiatePrefab(saveData.humanList[i], panelObj.transform);
            dropObj.transform.parent.SetParent(panelObj.transform, false);
            dropObj.SetActive(false);//��ʂ������
            GameObject nakamiImage = panelObj.transform.GetChild(0).gameObject;//panel�̒���nakamiImage���擾
            SpriteRenderer spriteRenderer = dropObj.GetComponent<SpriteRenderer>();//drop��image���擾
            Image image = nakamiImage.GetComponent<Image>();
            image.sprite = spriteRenderer.sprite;
            Debug.Log(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
