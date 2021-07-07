using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LineRenderer renderer = gameObject.GetComponent<LineRenderer>();
        // ���̕�
        renderer.SetWidth(0.1f, 0.1f);
        // ���_�̐�
        renderer.SetVertexCount(2);
        // ���_��ݒ�
        renderer.SetPosition(0, Vector3.zero);
        renderer.SetPosition(1, new Vector3(1f, 1f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
