using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ボタンを使用するためUIとSceneManagerを使用ためSceneManagementを追加
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Totitle : MonoBehaviour
{
    // Start is called before the first frame update
 // public GameObject  gameobject = GameObject.Find("GameObject");
   
    void Start()
    {
       // gameobject = GameObject.Find("GameObject");
     string   name = MusicPlayer.nextname;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ボタンをクリックするとBattleSceneに移動します
    public void ButtonClicked()
    {
        //エラーを吐いていたので修正しましたが他の場所で副次的エラーが起きている場合は直してください
        //SceneManager.LoadScene(MusicPlayer.nextname);

        //修正部分
        SceneManager.LoadScene("タイトル");
    }
}
