using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ボタンを使用するためUIとSceneManagerを使用ためSceneManagementを追加
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class toMain : MonoBehaviour
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
    public void Onclick1()
    {

        SceneManager.LoadScene("ステージ選択画面");
    }
    public void Onclick2()
    {
        SceneManager.LoadScene("score");
    }
    public void Onclick3()
    {
        SceneManager.LoadScene("キャラ選択画面");
    }
    public void Onclick4()
    {
        SceneManager.LoadScene("生成・素材・付替");
    }
    public void Onclick5()
    {
        SceneManager.LoadScene("shop");
    }
    public void Onclick6()
    {
        SceneManager.LoadScene("タイトル");
    }
}
