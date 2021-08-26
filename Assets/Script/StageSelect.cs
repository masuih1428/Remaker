using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{

    //��������Q�[���I�u�W�F�N�g
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

        mapimg.sprite = Resources.Load<Sprite>("Image/�ΎR");
        stagecount = "�܂��ՂR";
    }
    public void Onclick2()
    {
       
        mapimg.sprite = Resources.Load<Sprite>("Image/�܂��ՂP�摜");
        stagecount = "�܂��ՂP";
    }
    public void Onclick3()
    {
        mapimg.sprite = Resources.Load<Sprite>("Image/�܂��ՂP�摜");
        stagecount = "�܂���2";
    }
    public void Onclick4()
    {
        Debug.Log("4�������ꂽ");
    }

    public void Onclick5()
    {
        if (stagecount == "0")
        {
            mapimg.sprite = Resources.Load<Sprite>("Image/�I��");
            Debug.Log("�I������ĂȂ���");
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