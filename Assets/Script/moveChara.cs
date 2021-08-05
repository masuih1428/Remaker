using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChara : MonoBehaviour
{
    // 2Dリジッドボディを受け取る変数
    Rigidbody2D rb2D;
    // アニメーション制御のやつ
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // アニメーター（アニメーション制御のやつ）を受け取る
        anim = GetComponent("Animator") as Animator;
        // ここで2Dリジッドボディを受け取る。
        rb2D = GetComponent("Rigidbody2D") as Rigidbody2D;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb2D.velocity.x);
        Debug.Log(rb2D.velocity.y);
        if (rb2D.velocity.x > 1)
        {
            /* 右方向に動いている */
            this.anim.SetFloat("x", 1.0f);
        }
        else if (rb2D.velocity.x < -1)
        {
            /* 左方向に動いている */
            this.anim.SetFloat("x", -1.0f);
        }
        else
        {    /* そんなに動いてない */   }



        if (rb2D.velocity.y > 1)
        {
            /* 上方向に動いている */
            this.anim.SetFloat("y", 1.0f);
        }
        else if (rb2D.velocity.x < -1)
        {
            /* 下方向に動いている */
            this.anim.SetFloat("y", -1.0f);
        }
        else
        {    /* そんなに動いてない */   }
    }
}