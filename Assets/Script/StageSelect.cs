using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{

    //��������Q�[���I�u�W�F�N�g
    public GameObject target;
    public Image image;
    private Sprite sprite;
    [SerializeField] Image mapimg = null;

    
    public void OnclickButton()
    {
        
        mapimg.sprite = Resources.Load<Sprite>("Image/�ΎR");
    }
    public void Onclick2()
    {
       
        mapimg.sprite = Resources.Load<Sprite>("Image/�܂��ՂP�摜");
    }
    public void Onclick3()
    {
        Debug.Log("3�������ꂽ");
    }
    public void Onclick4()
    {
        Debug.Log("4�������ꂽ");
    }
}