using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panelstatus : MonoBehaviour
{
    public GameObject nakami;
    public GameObject textPanel;
    public GameObject image;
    public Sprite spriteImage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DropOnclick()
    {
        try
        {
            GameObject obj = nakami.transform.GetChild(1).gameObject;
            // Debug.Log(obj);
            Drop script = obj.GetComponent<Drop>();
            GameObject obj1 = textPanel.transform.GetChild(1).gameObject;
            //�X�e�[�^�X�p�l���̓��e�̕ύX
            Text text = obj1.GetComponent<Text>();
            text.text = script.Tostring();
            //�L�����摜�̕\��
            image.GetComponent<Image>().sprite = obj.GetComponent<SpriteRenderer>().sprite;
            return;
        } catch (Exception e)
        {
            Debug.Log(e.Data);
        }
        textClear();
        imageClear();
    }

    public void HumanOnclick()
    {
        try
        {
            GameObject obj = nakami.transform.GetChild(1).gameObject;
            // Debug.Log(obj);
            CharaScript script = obj.GetComponent<CharaScript>();
            Debug.Log(script);
            GameObject obj1 = textPanel.transform.GetChild(1).gameObject;
            //�X�e�[�^�X�p�l���̓��e�̕ύX
            Debug.Log(obj1);
            Text text = obj1.GetComponent<Text>();
            text.text = script.ToString();
            //�L�����摜�̕\��
            image.GetComponent<Image>().sprite = obj.GetComponent<SpriteRenderer>().sprite;
            return;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        textClear();
        imageClear();
    }

    public void textClear()
    {
        
        GameObject obj2 = textPanel.transform.GetChild(1).gameObject;
        Text text1 = obj2.GetComponent<Text>();
        //�e�L�X�g�̏�����
        text1.text = "";
    }

    public void imageClear()
    {
        image.GetComponent<Image>().sprite = spriteImage;
    }
}
