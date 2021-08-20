using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{

    //生成するゲームオブジェクト
    public GameObject target;
    public Image image;
    private Sprite sprite;
    [SerializeField] Image mapimg = null;
    public static string stagecount = "0";

    GameObject ToMains; 

    ToMain script;
    void Start()
    {

    }
    public void OnclickButton()
    {

        mapimg.sprite = Resources.Load<Sprite>("Image/火山");
        stagecount = "まっぷ３";
    }
    public void Onclick2()
    {
       
        mapimg.sprite = Resources.Load<Sprite>("Image/まっぷ１画像");
        stagecount = "まっぷ１";
    }
    public void Onclick3()
    {
        mapimg.sprite = Resources.Load<Sprite>("Image/まっぷ１画像");
        stagecount = "まっぷ2";
    }
    public void Onclick4()
    {
        Debug.Log("4が押された");
    }

    public void Onclick5()
    {
        if (stagecount == "0")
        {
            mapimg.sprite = Resources.Load<Sprite>("Image/選ぶ");
            Debug.Log("選択されてないよ");
        }
        else
        {
           ToMains = GameObject.Find("tomain");
            script = ToMains.GetComponent<ToMain>();

           script.Onclick8();
        }
    }

    public void Game()
    {
        SceneManager.LoadScene(stagecount);
    }
}