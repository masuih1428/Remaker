using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageClear : MonoBehaviour
{
    public Sprite image;
    // Start is called before the first frame update
    void Start()
    {
        //�A�C�R���摜�̏�����
        gameObject.GetComponent<Image>().sprite = image;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
