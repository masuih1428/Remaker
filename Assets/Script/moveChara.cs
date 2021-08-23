using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChara : MonoBehaviour
{
    // 2D���W�b�h�{�f�B���󂯎��ϐ�
    Rigidbody2D rb2D;
    // �A�j���[�V��������̂��
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // �A�j���[�^�[�i�A�j���[�V��������̂�j���󂯎��
        anim = GetComponent("Animator") as Animator;
        // ������2D���W�b�h�{�f�B���󂯎��B
        rb2D = GetComponent("Rigidbody2D") as Rigidbody2D;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb2D.velocity.x);
        Debug.Log(rb2D.velocity.y);
        if (rb2D.velocity.x > 1)
        {
            /* �E�����ɓ����Ă��� */
            this.anim.SetFloat("x", 1.0f);
        }
        else if (rb2D.velocity.x < -1)
        {
            /* �������ɓ����Ă��� */
            this.anim.SetFloat("x", -1.0f);
        }
        else
        {    /* ����Ȃɓ����ĂȂ� */   }



        if (rb2D.velocity.y > 1)
        {
            /* ������ɓ����Ă��� */
            this.anim.SetFloat("y", 1.0f);
        }
        else if (rb2D.velocity.x < -1)
        {
            /* �������ɓ����Ă��� */
            this.anim.SetFloat("y", -1.0f);
        }
        else
        {    /* ����Ȃɓ����ĂȂ� */   }
    }
}