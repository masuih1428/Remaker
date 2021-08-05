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
      
        SceneManager.LoadScene(MusicPlayer.nextname);
    }
}
