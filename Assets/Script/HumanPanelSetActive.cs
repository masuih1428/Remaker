using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanPanelSetActive : MonoBehaviour
{
    public GameObject humanPanel;
    public GameObject HumIcon;

    public  void OnClick()
    {
        var toggle = HumIcon.GetComponent<Toggle>();
        if (toggle.isOn)
        {
            humanPanel.gameObject.SetActive(true);
        }
        else
        {
            humanPanel.gameObject.SetActive(false);
        }
    }
}
