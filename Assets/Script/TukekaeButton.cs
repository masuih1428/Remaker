using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TukekaeButton : MonoBehaviour
{
    public GameObject humanIcon;
    public GameObject tukekaeButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //humanIcon�ɃI�u�W�F�N�g�������Ă���Ԃ̓A�N�e�B�u�ɂ�������
        if (1 < humanIcon.transform.childCount)
        {
            humanIcon.SetActive(true);
            tukekaeButton.SetActive(true);
        }
    }
}
