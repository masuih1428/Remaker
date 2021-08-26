using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    public SaveData saveData;
    public GameObject sougenn;
    public GameObject kaigan;
    public GameObject kazan;
    public void SelectStage1()
    {
        saveData.stage = "ëêå¥";
        sougenn.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        kaigan.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        kazan.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }

    public void SelectStage2()
    {
        saveData.stage = "äCä›";
        sougenn.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        kaigan.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        kazan.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }

    public void SelectStage3()
    {
        saveData.stage = "âŒéR";
        sougenn.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        kaigan.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        kazan.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
    }

}
