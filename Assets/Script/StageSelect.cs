using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    public SaveData saveData;
    public GameObject sougenn;
    public GameObject kaigan;
    public GameObject kazan;
    public void SelectStage1()
    {
        saveData.stage = "‘Œ´";
        sougenn.SetActive(true);
        kaigan.SetActive(false);
        kazan.SetActive(false);
    }

    public void SelectStage2()
    {
        saveData.stage = "ŠCŠİ";
        sougenn.SetActive(false);
        kaigan.SetActive(true);
        kazan.SetActive(false);
    }

    public void SelectStage3()
    {
        saveData.stage = "‰ÎR";
        sougenn.SetActive(false);
        kaigan.SetActive(false);
        kazan.SetActive(true);
    }
}
