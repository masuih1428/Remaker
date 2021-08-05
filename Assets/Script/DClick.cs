using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class DClick : MonoBehaviour
{
    public GameObject Imageobj;
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
        Debug.Log("Single");
    }

    void DoubleClick()
    {
        Imageobj.GetComponent<Image>().sprite = image;

        try
        {
            Destroy(gameObject.transform.GetChild(1).gameObject); //çÌèú
        }
        catch(Exception)
        {

        }


    }

}