using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ボタンを使用するためUIとSceneManagerを使用ためSceneManagementを追加
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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



    // ボタンをクリックするとBattleSceneに移動します
    public void ButtonClicked()
    {

        SceneManager.LoadScene("ホーム");
    }
}    
