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
        // Horizontalはカーソルキーの左右を押したときのパラメータ
        // (Verticalは上下)
        float horizontalkey = Input.GetAxis("Horizontal");
        float Verticalkey = Input.GetAxis("Vertical");


        // テスト段階ではカーソルキーの押下によってアニメーション遷移の条件を作成していますが、
        // 下記の条件分岐の内容を自動で遷移するように調整してもらいたいです。

        if (horizontalkey > 0)   // 右方向
        {
            //transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("right", true);
        }
        else                     // 前方向に戻る
        {
            anim.SetBool("right", false);
        }


        if(horizontalkey < 0)  // 左方向
        {
            //transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("left", true);
        }
        else                     // 前方向に戻る
        {
            anim.SetBool("left", false);
        }


        if (Verticalkey > 0)   // 後ろ方向
        {
            anim.SetBool("back", true);
        }
        else　                // 前方向に戻る
        {
            anim.SetBool("back", false);
        }
    }
}
