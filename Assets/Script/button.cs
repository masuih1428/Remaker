using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ボタンが押された時の処理
    public void ButtonClick()
    {
        EditorApplication.Beep();
    }
}
