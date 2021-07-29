using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{

    //生成するゲームオブジェクト
    public GameObject target;
    public Image image;
    private Sprite sprite;
    [SerializeField] Image mapimg = null;

    
    public void OnclickButton()
    {
        
        mapimg.sprite = Resources.Load<Sprite>("Image/火山");
    }
    public void Onclick2()
    {
       
        mapimg.sprite = Resources.Load<Sprite>("Image/まっぷ１画像");
    }
    public void Onclick3()
    {
        Debug.Log("3が押された");
    }
    public void Onclick4()
    {
        Debug.Log("4が押された");
    }
}