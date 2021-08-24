using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControll : MonoBehaviour
{
    public GameObject sougenn;
    public GameObject kaigan;
    public GameObject kazan;
    // Start is called before the first frame update
    void Start()
    {
        sougenn.SetActive(false);
        kaigan.SetActive(false);
        kazan.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
