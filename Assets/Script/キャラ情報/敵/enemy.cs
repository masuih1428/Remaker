using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : chara
{
    public bool stealth = false;//�X�e���X���ǂ���
    public int attribute = 0;//�L�����̑��� 0���� 1���� 2���� 3����
    public float move = 1; //�ړ����x
    public float dps = 1; //�U�����x(dps���Z�j
    public float deficult = 1; //��Փx�␳;

    public List<GameObject> dropList;

    void Start()
    {
        //�R���X�g���N�^
        this.hp = (int)(this.max_hp * this.deficult);
        this.atk = (int)(this.max_atk * this.deficult);
        this.def = (int)(this.max_def * this.deficult);
        this.mdef = (int)(this.max_mdef * this.deficult);
    }

    void Start(int dif)//��Փx�󂯎��
    {
        //�R���X�g���N�^
        this.deficult = dif;
        this.hp = (int)(this.max_hp * this.deficult);
        this.atk = (int)(this.max_atk * this.deficult);
        this.def = (int)(this.max_def * this.deficult);
        this.mdef = (int)(this.max_mdef * this.deficult);
    }
}
