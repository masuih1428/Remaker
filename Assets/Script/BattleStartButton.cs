using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.SceneManagement;

public class BattleStartButton : MonoBehaviour
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

            //XVˆ—
            try
            {
                GameObject gameChild1 = game.transform.GetChild(j).gameObject;
                GameObject gameChild2 = gameChild1.transform.GetChild(1).gameObject;
                Debug.Log((GameObject)PrefabUtility.GetCorrespondingObjectFromOriginalSource(gameChild2));
                party[j] = ((GameObject)PrefabUtility.GetCorrespondingObjectFromOriginalSource(gameChild2));
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }

        
        switch (saveData.stage)
        {
            case "‘Œ´":
                SceneManager.LoadScene("‚Ü‚Á‚Õ‚P");
                break;
            case "ŠCŠÝ":
                SceneManager.LoadScene("‚Ü‚Á‚Õ2");
                break;
            case "‰ÎŽR":
                SceneManager.LoadScene("‚Ü‚Á‚Õ‚R");
                break;
        }
    }
}
