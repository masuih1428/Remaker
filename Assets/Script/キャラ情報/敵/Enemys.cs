using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemys : CharaScript
{
    public bool stealth = false;//�X�e���X���ǂ���
    public int attribute = 0;//�L�����̑��� 0���� 1���� 2���� 3����
    public float move = 1; //�ړ����x
    public float dps = 1; //�U�����x(dps���Z�j
    public SaveData savedata;

    public List<GameObject> dropList;

    public Route route;//���[�g���߂���
    private int pointIndex;//�ǉ������Q��

    void Start()
    {
        //�R���X�g���N�^
        this.hp = (int)(this.max_hp * savedata.dificult);
        this.atk = (int)(this.max_atk * savedata.dificult);
        this.def = (int)(this.max_def * savedata.dificult);
        this.mdef = (int)(this.max_mdef * savedata.dificult);
    }
    void Update()//�ǉ�������
    {
        var v = route.points[pointIndex + 1].transform.position - route.points[pointIndex].transform.position;
        transform.position += v.normalized * move * Time.deltaTime;

        var pv = transform.position - route.points[pointIndex].transform.position;
        if (pv.magnitude >= v.magnitude)
        {
            pointIndex++;

            if (pointIndex >= route.points.Length - 1)//�Ō�܂œ��B����
            {
                Destroy(gameObject);
                //TODO �v���C���[�Ƀ_���[�W
            }
        }
    }
}
