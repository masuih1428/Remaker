using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�{�^�����g�p���邽��UI��SceneManager���g�p����SceneManagement��ǉ�
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }



    // �{�^�����N���b�N�����BattleScene�Ɉړ����܂�
    public void ButtonClicked()
    {

        SceneManager.LoadScene("�z�[��");
    }
}    
