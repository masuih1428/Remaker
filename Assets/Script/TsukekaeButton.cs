using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TsukekaeButton : MonoBehaviour
{
    public GameObject HumIcon;
    public GameObject Tsukekae;

    void Start()
    {
        Tsukekae.SetActive(false);
    }

    // Update is called once per frame
    public void ToggleOn()
    {
        var toggle = HumIcon.GetComponent<Toggle>();
        if (toggle.isOn)
        {
            Tsukekae.gameObject.SetActive(true);
        } else
        {
            Tsukekae.gameObject.SetActive(false);
        }
    }
}
