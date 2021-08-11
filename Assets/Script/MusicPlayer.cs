using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicPlayer : MonoBehaviour
{
    //ヒエラルキーからD&Dしておく
    public AudioClip BGM_title;
    public AudioClip BGM_home;
    public AudioClip BGM_map;
    public AudioClip BGM_charafor;
    public AudioClip BGM_dr;
    //使用するAudioSource
    private AudioSource source;
    
    //１つ前のシーン名
    private string beforeScene = "タイトル";
   public static string nextname;
    // Use this for initialization
    void Start()
    {
        
        //自分をシーン切り替え時も破棄しないようにする
        DontDestroyOnLoad(gameObject);



        //使用するAudioSource取得
        source = GetComponent<AudioSource>();

        //最初のBGM再生
        source.clip = BGM_title;
        source.Play();
        source.loop = true;
        //シーンが切り替わった時に呼ばれるメソッドを登録
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    //シーンが切り替わった時に呼ばれるメソッド
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        //シーンがどう変わったかで判定

        //メニューからメインへ
        if (beforeScene == "タイトル" && nextScene.name == "ホーム")
        {

            source.Stop();
            source.clip = BGM_home;    //流すクリップを切り替える
            source.Play();
            source.loop = true;
        }

        //メインからメニューへ
        if (beforeScene == "ホーム" && nextScene.name == "タイトル")
        {
            source.Stop();
            source.clip = BGM_title;    //流すクリップを切り替える
            source.Play();
            source.loop = true;
        }

        if (beforeScene == "ホーム" && nextScene.name == "マップ選択")
        {
            source.Stop();
            source.clip = BGM_map;    //流すクリップを切り替える
            source.Play();
            source.loop = true;
        }

        if (beforeScene == "マップ選択" && nextScene.name == "ホーム")
        {
            source.Stop();
            source.clip = BGM_home;    //流すクリップを切り替える
            source.Play();
            source.loop = true;
        }

        if (beforeScene == "ホーム" && nextScene.name == "キャラ編成画面")
        {
            source.Stop();
            source.clip = BGM_map;    //流すクリップを切り替える
            source.Play();
            source.loop = true;
        }

        if (beforeScene == "キャラ編成画面" && nextScene.name == "ホーム")
        {
            source.Stop();
            source.clip = BGM_home;    //流すクリップを切り替える
            source.Play();
            source.loop = true;
        }


        if (beforeScene == "ホーム" && nextScene.name == "生成・素材・付替メニュー")
        {
            source.Stop();
            source.clip = BGM_dr;    //流すクリップを切り替える
            source.Play();
            source.loop = true;
        }

        if (beforeScene == "生成・素材・付替メニュー" && nextScene.name == "ホーム")
        {
            source.Stop();
            source.clip = BGM_home;    //流すクリップを切り替える
            source.Play();
            source.loop = true;
        }


      //  if (beforeScene == "マップ選択" && nextScene.name == "キャラ選択画面")
      //  {
      //      source.Stop();
      //      source.clip = BGM_map;    //流すクリップを切り替える
       //     source.Play();
       //     source.loop = true;
       // }

      //  if (beforeScene == "キャラ選択画面" && nextScene.name == "マップ選択")
      //  {
      //      source.Stop();
       //     source.clip = BGM_map;    //流すクリップを切り替える
       //     source.Play();
       //     source.loop = true;
       // }



        nextname = beforeScene;
       
        //遷移後のシーン名を「１つ前のシーン名」として保持
        beforeScene = nextScene.name;
    }


}

