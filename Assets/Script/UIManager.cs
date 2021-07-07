using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //�R��Panel���i�[����ϐ�
    //�C���X�y�N�^�[�E�B���h�E����Q�[���I�u�W�F�N�g��ݒ肷��
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject xrHubPanel;
    


    // Start is called before the first frame update
    void Start()
    {
        //BackToMenu���\�b�h���Ăяo��
        BackToMenu();
    }


    //MenuPanel��XR-HubButton�������ꂽ�Ƃ��̏���
    //XR-HubPanel���A�N�e�B�u�ɂ���
    public void SelectXrHubDescription()
    {
        menuPanel.SetActive(false);
        xrHubPanel.SetActive(true);
    }




    //2��DescriptionPanel��BackButton�������ꂽ�Ƃ��̏���
    //MenuPanel���A�N�e�B�u�ɂ���
    public void BackToMenu()
    {
        menuPanel.SetActive(true);
        xrHubPanel.SetActive(false);
        
    }
}