using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelstatus : MonoBehaviour
{
    public GameObject nakami;
    public GameObject textPanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Onclick()
    {
        try
        {
            GameObject obj = nakami.transform.GetChild(0).gameObject;
            // Debug.Log(obj);
            drop script = obj.GetComponent<drop>();
            GameObject obj1 = textPanel.transform.GetChild(1).gameObject;
            Text text = obj1.GetComponent<Text>();
            text.text = script.Tostring();
            return;
        } catch (Exception e)
        {
            Debug.Log(e.Data);
        }
        textClear();
    }

    public void textClear()
    {
        
        GameObject obj2 = textPanel.transform.GetChild(1).gameObject;
        Text text1 = obj2.GetComponent<Text>();
        text1.text = "";
    }
}
