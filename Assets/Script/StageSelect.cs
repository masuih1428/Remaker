using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{
    public SaveData saveData;
    public void SelectStage1()
    {
        saveData.stage = "����";
    }

    public void SelectStage2()
    {
        saveData.stage = "�C��";
    }

    public void SelectStage3()
    {
        saveData.stage = "�ΎR";
    }
}
