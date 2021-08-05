using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPanelSetActive : MonoBehaviour
{
    public GameObject humanPanel;

    public  void OnClick()
    {
        humanPanel.SetActive(false);
    }
}
