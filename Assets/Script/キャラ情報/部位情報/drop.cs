using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Drop : MonoBehaviour
{
    public int cost;
    public string partName;
    public string part;//�ǂ��̕��ʂ�
    public int hp;
    public int atk;
    public int def;
    public int mdef;
    public float rareFloat = 1;
    public string rare = "";//���A�x

    public void Start()
    {
    }

    public string Tostring()
    {

        string returnstring = "part:"+this.part +"\n"+"hp:" + this.hp + "\natk:"+ this.atk + "\ndef:" + this.def + "\nmdef:" + this.mdef  + "\n";
        return returnstring;
    } 

    public void rareStart()
    {
        //rare��null�̎��̂ݍŏ��Ƀ��A���e�B�����߂�
        Debug.Log("Start");
        if (this.rare == "")
        {
            //���A�x��null�̏ꍇ�̂݃��A�x�𗐐��ō쐬
            float r1 = Random.value;//0.0f�`1.0f�܂ł̒l
            float rare = 0.3f; //���A
            float epic = 0.1f; //�G�s�b�N

            switch (r1)
            {
                case float r2 when r2 < epic:
                    this.rare = "epic";
                    this.rareFloat = 1.1f;
                    break;
                case float r2 when r2 < rare + epic:
                    this.rare = "rare";
                    this.rareFloat = 1.05f;
                    break;
                default:
                    this.rare = "normal";
                    break;
            }
            //�X�e�[�^�X�̏㏸
            this.hp = (int)(this.hp * rareFloat);
            this.atk = (int)(this.atk * rareFloat);
            this.def = (int)(this.def * rareFloat);
            this.mdef = (int)(this.mdef * rareFloat);
        }
    }
}
