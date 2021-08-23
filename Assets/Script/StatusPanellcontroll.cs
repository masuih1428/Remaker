using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusPanellcontroll : MonoBehaviour
{
    public GameObject statusPanellPrefb;
    public Text statusPanell;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj2 = statusPanellPrefb.transform.GetChild(1).gameObject;
        Text text1 = obj2.GetComponent<Text>();
        text1.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj2 = statusPanellPrefb.transform.GetChild(1).gameObject;
        Text text1 = obj2.GetComponent<Text>();
        statusPanell.text = text1.text;
    }
}
