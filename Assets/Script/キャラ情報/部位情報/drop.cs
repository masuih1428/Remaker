using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class drop : MonoBehaviour
{
    public string part;//�ǂ��̕��ʂ�
    public int hp;
    public int atk;
    public int def;
    public int mdef;

    public string rare = null;//���A�x

    public void Start()
    {
        if (this.rare == null)
        {
            //���A�x��null�̏ꍇ�̂݃��A�x�𗐐��ō쐬
            float r1 = Random.value;//0.0f�`1.0f�܂ł̒l
            float normal = 0.6f;//�m�[�}���̊m��
            float rare = 0.3f; //���A
            float epic = 0.1f; //�G�s�b�N

            switch (r1)
            {
                case float r2 when r2 < epic:
                    this.rare = "epic";
                    break;
                case float r2 when r2 < rare + epic:
                    this.rare = "rare";
                    break;
                default:
                    this.rare = "normal";
                    break;
            }
        }
    }

    public string Tostring()
    {

        string returnstring = "part:"+this.part +"\n"+"hp:" + this.hp+"\natk:"+ + this.atk + "\ndef:" + this.def + "\nmdef:" + this.mdef + "\n";
        return returnstring;
    } 
}
