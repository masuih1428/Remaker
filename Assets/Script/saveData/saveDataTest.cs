using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveDataTest : MonoBehaviour
{
    public SaveData saveData;
    public GameObject game;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(saveData.drops.Count);
        saveData.drops.Add(game);
        Debug.Log(saveData.drops.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
