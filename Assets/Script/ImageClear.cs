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
        //アイコン画像の初期化
        gameObject.GetComponent<Image>().sprite = image;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
