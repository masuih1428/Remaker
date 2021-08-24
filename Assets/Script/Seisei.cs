using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Seisei : MonoBehaviour
{
    public GameObject headObj;//�V�[������擾���Ă����I�u�W�F�N�g������ϐ�
    public GameObject bodyObj;
    public GameObject legObj;
    public GameObject armObj;
    public GameObject wepon;
    public GameObject nameObj;
    public GameObject UnitModel;//���j�b�g�̌��v���n�u
    public SaveData saveData;
    private string assetPath = "Assets/Resources/�����L����/";//�v���n�u�{�̂̊i�[�ꏊ
    private string resorcePath = "Hero";//�L�����摜�ƃA�j���[�^�[�̊i�[�ꏊ
    private GameObject headOri;//prefab������ϐ�
    private GameObject bodyOri;
    private GameObject legOri;
    private GameObject armOri;
    private GameObject weponOri;
    private Unit unitScript;
    private GameObject unit;
    public void OnClick()
    {
        //Unit unitScript = UnitModel.GetComponent<Unit>();

        try
        {
            //�I�u�W�F�N�g�̐���
            unit = Instantiate(UnitModel);
            unitScript = unit.GetComponent<Unit>();
            //head
            headOri = PrefabUtility.GetCorrespondingObjectFromOriginalSource(headObj.transform.GetChild(1).gameObject);
            unitScript.headObj = headOri;
            unitScript.head = headOri.GetComponent<HeadDrop>();
            //body
            bodyOri = PrefabUtility.GetCorrespondingObjectFromOriginalSource(bodyObj.transform.GetChild(1).gameObject);
            unitScript.bodyObj = bodyOri;
            unitScript.body = bodyOri.GetComponent<BodyDrop>();
            //Debug.Log(bodyObj.transform.GetChild(1).gameObject.GetComponent<BodyDrop>());
            //leg
            legOri = PrefabUtility.GetCorrespondingObjectFromOriginalSource(legObj.transform.GetChild(1).gameObject);
            unitScript.legObj = legOri;
            unitScript.leg = legOri.GetComponent<LegDrop>();
            //Debug.Log(legObj.transform.GetChild(1).gameObject.GetComponent<LegDrop>());
            //arm
            armOri = PrefabUtility.GetCorrespondingObjectFromOriginalSource(armObj.transform.GetChild(1).gameObject);
            unitScript.handObj = armOri;
            unitScript.hand = armOri.GetComponent<HandDrop>();
            //Debug.Log(armObj.transform.GetChild(1).gameObject.GetComponent<HandDrop>());

            //wepon���A�N�e�B�u�̏ꍇ�̂�
            if (wepon.activeSelf)
            {
                //wepon
                weponOri = PrefabUtility.GetCorrespondingObjectFromOriginalSource(wepon.transform.GetChild(1).gameObject);
                unitScript.weponObj = weponOri;
                unitScript.wepon = weponOri.GetComponent<Wepon>();
                Debug.Log(headObj.transform.GetChild(1).gameObject.GetComponent<Wepon>());
            }

            if (nameObj.transform.GetChild(2).gameObject.GetComponent<Text>().text == null)
            {
                throw new Exception();//���O�����͂̈�
            }
            else
            {
                unitScript.charaName = nameObj.transform.GetChild(2).gameObject.GetComponent<Text>().text;
            }
            Debug.Log("�擾����");

        }
        catch (Exception e)
        {
            Debug.Log("���͂��ĂȂ�������");
        }

        try
        {
            unitScript.Start();
            //�摜������
            int ran = UnityEngine.Random.Range(1, 17);
            Debug.Log(ran);
            Sprite image = Resources.Load<Sprite>(resorcePath + "/Hero_image(" + ran + ")");
            Debug.Log(resorcePath + "/Hero_image(" + ran + ")_1");
            Debug.Log(image);
            unit.GetComponent<SpriteRenderer>().sprite = image;
            //�R���g���[���[��ς���
            Debug.Log((RuntimeAnimatorController)Resources.Load(resorcePath + "/Animation/Hero_animation " + ran + "/hero_animator " + ran));
            unit.GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load(resorcePath + "/Animation/hero_animation " + ran + "/hero_animator " + ran);
            GameObject unitPrefab = PrefabUtility.SaveAsPrefabAsset(unit, assetPath + unitScript.charaName + (saveData.HumanInt++) + ".prefab");
            saveData.humanList.Add(PrefabUtility.GetCorrespondingObjectFromOriginalSource(unitPrefab));
            //dropList����g�p�����f�ނ�����
            saveData.drops.Remove(headOri);
            saveData.drops.Remove(bodyOri);
            saveData.drops.Remove(legOri);
            saveData.drops.Remove(armOri);
            if (wepon.activeSelf)
            {
                saveData.drops.Remove(weponOri);
            }



            //�����[�h
            // ���݂�Scene���擾
            Scene loadScene = SceneManager.GetActiveScene();
            // ���݂̃V�[�����ēǂݍ��݂���
            SceneManager.LoadScene(loadScene.name);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

        Destroy(unit);
    }
}
