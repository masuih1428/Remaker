using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemys : CharaScript
{
    public int grade;
    public int id;
    public bool stealth = false;//�X�e���X���ǂ���
    public int attribute = 0;//�L�����̑��� 0���� 1���� 2���� 3����
    public float move = 1; //�ړ����x
    public float dps = 1; //�U�����x(dps���Z)
    public SaveData savedata;

    public List<GameObject> dropList;

    void Start()
    {
        //�R���X�g���N�^
        this.hp = (int)(this.max_hp * savedata.dificult);
        this.atk = (int)(this.max_atk * savedata.dificult);
        this.def = (int)(this.max_def * savedata.dificult);
        this.mdef = (int)(this.max_mdef * savedata.dificult);
    }
}
