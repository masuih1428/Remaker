using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FormationEnter : MonoBehaviour
{
    public SaveData saveData;
    public GameObject content1;
    public GameObject content2;
    public GameObject content3;
    public void Onclick()
    {
        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                    partyUpdate(saveData.humanParty1, 1);
                    break;
                case 1:
                    partyUpdate(saveData.humanParty2, 2);
                    break;
                case 2:
                    partyUpdate(saveData.humanParty3, 3);
                    break;
            }
        }
    }

    void partyUpdate(List<GameObject> party, int partyNum)
    {
        GameObject game = null;
        for (int j = 0; j < party.Count; j++)
        {
            switch (partyNum)
            {
                case 1:
                    game = content1;
                    break;
                case 2:
                    game = content2;
                    break;
                case 3:
                    game = content3;
                    break;
            }

            //更新処理
            GameObject gameChild1 = game.transform.GetChild(j).gameObject;
            GameObject gameChild2 = gameChild1.transform.GetChild(1).gameObject;
            Debug.Log((GameObject)PrefabUtility.GetCorrespondingObjectFromOriginalSource(gameChild2));
            try
            {
                party[j] = ((GameObject)PrefabUtility.GetCorrespondingObjectFromOriginalSource(gameChild2));
            } catch (Exception e)
            {
                Debug.Log(e);
            }
        }
        // 現在のSceneを取得
        Scene loadScene = SceneManager.GetActiveScene();
        // 現在のシーンを再読み込みする
        SceneManager.LoadScene(loadScene.name);
    }
}
