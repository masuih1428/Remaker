using System.Collections;
using System.Collections.Generic;
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
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < saveData.drops.Count; i++)
        {
            GameObject panelObj = (GameObject)Instantiate(panel);
            switch (saveData.drops[i].GetComponent<Drop>().part)
            {
                case "head":
                    panelObj.transform.SetParent(headContent.transform, false);
                    break;
                case "body":
                    panelObj.transform.SetParent(bodyContent.transform, false);
                    break;
                case "hand":
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
            Drop drop = dropObj.GetComponent<Drop>();//�h���b�v�X�N���v�g���擾
            drop.rareStart();
            dropObj.SetActive(false);//��ʂ������
            GameObject nakamiImage = panelObj.transform.GetChild(0).gameObject;//panel�̒���nakamiImage���擾
            SpriteRenderer spriteRenderer =  dropObj.GetComponent<SpriteRenderer>();//drop��image���擾
            Image image = nakamiImage.GetComponent<Image>();
            image.sprite = spriteRenderer.sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
