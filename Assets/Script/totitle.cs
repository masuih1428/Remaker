using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�{�^�����g�p���邽��UI��SceneManager���g�p����SceneManagement��ǉ�
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

    // �{�^�����N���b�N�����BattleScene�Ɉړ����܂�
    public void ButtonClicked()
    {
        //�G���[��f���Ă����̂ŏC�����܂��������̏ꏊ�ŕ����I�G���[���N���Ă���ꍇ�͒����Ă�������
        //SceneManager.LoadScene(MusicPlayer.nextname);

        //�C������
        SceneManager.LoadScene("�^�C�g��");
    }
}
