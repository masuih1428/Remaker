using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControll : MonoBehaviour
{
    public GameObject sougenn;
    public GameObject kaigan;
    public GameObject kazan;
    public SaveData saveData;
    // Start is called before the first frame update
    void Start()
    {
        saveData.stage = "ëêå¥";
        sougenn.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        kaigan.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        kazan.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
