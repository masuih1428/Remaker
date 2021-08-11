using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PartyControl : MonoBehaviour
{
    public SaveData saveData;
    public GameObject content1;
    public GameObject content2;
    public GameObject content3;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            switch(i)
            {
                case 0:
                    partySet(saveData.humanParty1, 1);
                    break;
                case 1:
                    partySet(saveData.humanParty2, 2);
                    break;
                case 2:
                    partySet(saveData.humanParty3, 3);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void partySet(List<GameObject> party,int partyNum)
    {
        GameObject game = null;
        for (int j = 0; j < party.Count; j++)
        {
            if (party[j] == null)
            {
                continue;
            }

            switch(partyNum)
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
            GameObject gameChild1 = game.transform.GetChild(j).gameObject;
            GameObject gameChild2 = gameChild1.transform.GetChild(0).gameObject;
            gameChild2.GetComponent<Image>().sprite = party[j].GetComponent<SpriteRenderer>().sprite;
            GameObject humanObj = (GameObject)PrefabUtility.InstantiatePrefab(party[j]);
            humanObj.transform.SetParent(gameChild1.transform, false);
            humanObj.SetActive(false);
        }
    }
}