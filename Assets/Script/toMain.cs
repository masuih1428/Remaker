using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�{�^�����g�p���邽��UI��SceneManager���g�p����SceneManagement��ǉ�
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

    // �{�^�����N���b�N�����BattleScene�Ɉړ����܂�
    public void Onclick1()
    {

        SceneManager.LoadScene("�X�e�[�W�I�����");
    }
    public void Onclick2()
    {
        SceneManager.LoadScene("score");
    }
    public void Onclick3()
    {
        SceneManager.LoadScene("�L�����I�����");
    }
    public void Onclick4()
    {
        SceneManager.LoadScene("�����E�f�ށE�t��");
    }
    public void Onclick5()
    {
        SceneManager.LoadScene("shop");
    }
    public void Onclick6()
    {
        SceneManager.LoadScene("�^�C�g��");
    }
}
