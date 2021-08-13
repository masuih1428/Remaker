using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DClickHuman : MonoBehaviour
{
    public GameObject headIcon;
    public GameObject bodyIcon;
    public GameObject armIcon;
    public GameObject legIcon;
    public GameObject weponIcon;
    public GameObject Imageobj;
    public InputField text;
    public Sprite image;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool isClick;
    public void OnClick()
    {
        if (!isClick)
        {
            isClick = true;
            StartCoroutine(MeasureTime());
        }
        else
        {
            DoubleClick();
            isClick = false;
        }

    }

    IEnumerator MeasureTime()
    {
        var times = 0f;
        while (isClick)
        {
            times += Time.deltaTime;
            if (times < 0.5f)
            {
                yield return null;
            }
            else
            {
                isClick = false;
                SingleClick();
                yield break;
            }
        }
    }

    void SingleClick()
    {
        
    }

    void DoubleClick()
    {
        Imageobj.GetComponent<Image>().sprite = image;
        headIcon.transform.GetChild(0).GetComponent<Image>().sprite = image;
        bodyIcon.transform.GetChild(0).GetComponent<Image>().sprite = image;
        armIcon.transform.GetChild(0).GetComponent<Image>().sprite = image;
        legIcon.transform.GetChild(0).GetComponent<Image>().sprite = image;
        weponIcon.transform.GetChild(0).GetComponent<Image>().sprite = image;

        try
        {
            Destroy(gameObject.transform.GetChild(1).gameObject); //çÌèú
            Destroy(headIcon.transform.GetChild(1).gameObject);
            Destroy(bodyIcon.transform.GetChild(1).gameObject);
            Destroy(armIcon.transform.GetChild(1).gameObject);
            Destroy(legIcon.transform.GetChild(1).gameObject);
            Destroy(weponIcon.transform.GetChild(1).gameObject);
            text.text = "";
        }
        catch(Exception)
        {

        }


    }

}