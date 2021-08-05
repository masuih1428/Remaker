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
        SceneManager.LoadScene("マップ選択");
    }
    public void Onclick4()
    {
        SceneManager.LoadScene("生成・素材・付替メニュー");
    }
    public void Onclick5()
    {
        SceneManager.LoadScene("shop");
    }
    public void Onclick6()
    {
        SceneManager.LoadScene("タイトル");
    }
    public void Onclick7()
    {
        SceneManager.LoadScene("ホーム");
    }
    public void Onclick8()
    {
        SceneManager.LoadScene("キャラ選択画面");
    }
    public void Onclick9()
    {
        SceneManager.LoadScene("生成・付替画面");
    }
    public void Onclick10()
    {
        SceneManager.LoadScene("キャラ編成画面");
    }
    public void Onclick11()
    {
        SceneManager.LoadScene("出撃画面");
    }
    public void Onclick12()
    {
        SceneManager.LoadScene("素材一覧");
    }

    public void Onclick13()
    {
        SceneManager.LoadScene("設定");
    }



}
