using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TukekaeScript : MonoBehaviour
{
    public GameObject headObj;//�V�[������擾���Ă����I�u�W�F�N�g������ϐ�
    public GameObject bodyObj;
    public GameObject legObj;
    public GameObject armObj;
    public GameObject wepon;
    public GameObject nameObj;
    public GameObject UnitModel;//���j�b�g�̌��v���n�u
    public SaveData saveData;
    private string assetPath = "Assets/Resources/�����L����/";
    private GameObject headOri;//prefab������ϐ�
    private GameObject bodyOri;
    private GameObject legOri;
    private GameObject armOri;
    private GameObject weponOri;
    private Unit unitScript;
    private GameObject unit;
    public GameObject humanIcon;
    public void OnClick()
    {
        //Unit unitScript = UnitModel.GetComponent<Unit>();

        try
        {
            //�I�u�W�F�N�g�̐���
            unit = PrefabUtility.GetCorrespondingObjectFromOriginalSource(humanIcon.transform.GetChild(1).gameObject);
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
            }�@else
            {
                unitScript.charaName = nameObj.transform.GetChild(2).gameObject.GetComponent<Text>().text;
            }
            Debug.Log("�擾����");

        } catch (Exception e)
        {
            Debug.Log("���͂��ĂȂ�������");
        }

        try
        {
            unitScript.setStatus();
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
        } catch(Exception e)
        {
            Debug.Log(e);
        }
    }
}