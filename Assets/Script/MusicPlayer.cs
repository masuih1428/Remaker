using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MusicPlayer : MonoBehaviour
{
    //�q�G�����L�[����D&D���Ă���
    public AudioClip BGM_title;
    public AudioClip BGM_home;
    public AudioClip BGM_map;
    public AudioClip BGM_charafor;
    public AudioClip BGM_dr;
    //�g�p����AudioSource
    private AudioSource source;
    
    //�P�O�̃V�[����
    private string beforeScene = "�^�C�g��";
   public static string nextname;
    // Use this for initialization
    void Start()
    {
        
        //�������V�[���؂�ւ������j�����Ȃ��悤�ɂ���
        DontDestroyOnLoad(gameObject);



        //�g�p����AudioSource�擾
        source = GetComponent<AudioSource>();

        //�ŏ���BGM�Đ�
        source.clip = BGM_title;
        source.Play();
        source.loop = true;
        //�V�[�����؂�ւ�������ɌĂ΂�郁�\�b�h��o�^
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    //�V�[�����؂�ւ�������ɌĂ΂�郁�\�b�h
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        //�V�[�����ǂ��ς�������Ŕ���

        //���j���[���烁�C����
        if (beforeScene == "�^�C�g��" && nextScene.name == "�z�[��")
        {

            source.Stop();
            source.clip = BGM_home;    //�����N���b�v��؂�ւ���
            source.Play();
            source.loop = true;
        }

        //���C�����烁�j���[��
        if (beforeScene == "�z�[��" && nextScene.name == "�^�C�g��")
        {
            source.Stop();
            source.clip = BGM_title;    //�����N���b�v��؂�ւ���
            source.Play();
            source.loop = true;
        }

        if (beforeScene == "�z�[��" && nextScene.name == "�}�b�v�I��")
        {
            source.Stop();
            source.clip = BGM_map;    //�����N���b�v��؂�ւ���
            source.Play();
            source.loop = true;
        }

        if (beforeScene == "�}�b�v�I��" && nextScene.name == "�z�[��")
        {
            source.Stop();
            source.clip = BGM_home;    //�����N���b�v��؂�ւ���
            source.Play();
            source.loop = true;
        }

        if (beforeScene == "�z�[��" && nextScene.name == "�L�����Ґ����")
        {
            source.Stop();
            source.clip = BGM_map;    //�����N���b�v��؂�ւ���
            source.Play();
            source.loop = true;
        }

        if (beforeScene == "�L�����Ґ����" && nextScene.name == "�z�[��")
        {
            source.Stop();
            source.clip = BGM_home;    //�����N���b�v��؂�ւ���
            source.Play();
            source.loop = true;
        }


        if (beforeScene == "�z�[��" && nextScene.name == "�����E�f�ށE�t�փ��j���[")
        {
            source.Stop();
            source.clip = BGM_dr;    //�����N���b�v��؂�ւ���
            source.Play();
            source.loop = true;
        }

        if (beforeScene == "�����E�f�ށE�t�փ��j���[" && nextScene.name == "�z�[��")
        {
            source.Stop();
            source.clip = BGM_home;    //�����N���b�v��؂�ւ���
            source.Play();
            source.loop = true;
        }


      //  if (beforeScene == "�}�b�v�I��" && nextScene.name == "�L�����I�����")
      //  {
      //      source.Stop();
      //      source.clip = BGM_map;    //�����N���b�v��؂�ւ���
       //     source.Play();
       //     source.loop = true;
       // }

      //  if (beforeScene == "�L�����I�����" && nextScene.name == "�}�b�v�I��")
      //  {
      //      source.Stop();
       //     source.clip = BGM_map;    //�����N���b�v��؂�ւ���
       //     source.Play();
       //     source.loop = true;
       // }



        nextname = beforeScene;
       
        //�J�ڌ�̃V�[�������u�P�O�̃V�[�����v�Ƃ��ĕێ�
        beforeScene = nextScene.name;
    }


}

