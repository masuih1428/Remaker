using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimationController : MonoBehaviour
{
    private Animator anim = null;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal�̓J�[�\���L�[�̍��E���������Ƃ��̃p�����[�^
        // (Vertical�͏㉺)
        float horizontalkey = Input.GetAxis("Horizontal");
        float Verticalkey = Input.GetAxis("Vertical");


        // �e�X�g�i�K�ł̓J�[�\���L�[�̉����ɂ���ăA�j���[�V�����J�ڂ̏������쐬���Ă��܂����A
        // ���L�̏�������̓��e�������őJ�ڂ���悤�ɒ������Ă��炢�����ł��B

        if (horizontalkey > 0)   // �E����
        {
            //transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("right", true);
        }
        else                     // �O�����ɖ߂�
        {
            anim.SetBool("right", false);
        }


        if(horizontalkey < 0)  // ������
        {
            //transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("left", true);
        }
        else                     // �O�����ɖ߂�
        {
            anim.SetBool("left", false);
        }


        if (Verticalkey > 0)   // ������
        {
            anim.SetBool("back", true);
        }
        else�@                // �O�����ɖ߂�
        {
            anim.SetBool("back", false);
        }
    }
}
