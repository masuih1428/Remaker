using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

[DisallowMultipleComponent]
public sealed class Tensen : MonoBehaviour
{
    //==============================================================================
    // 変数(SerializeField)
    //==============================================================================
    [SerializeField] private Texture m_texture = null;
    [SerializeField] private float m_lineWidth = 0;
    [SerializeField] private float m_textureScale = 0;
    [SerializeField] private Color m_color = Color.white;
    [SerializeField] private float m_speed = 0;

    //==============================================================================
    // 変数
    //==============================================================================
    private VectorLine m_vectorLine;

    //==============================================================================
    // 関数
    //==============================================================================
    /// <summary>
    /// 開始する時に呼び出されます
    /// </summary>
    private void Start()
    {
        m_vectorLine = new VectorLine
        (
            name: name,
            points: new List<Vector3>(5),
            texture: m_texture,
            width: m_lineWidth,
            lineType: LineType.Continuous
        )
        {
            alignOddWidthToPixels = true
        };
    }

    /// <summary>
    /// 更新する時に呼び出されます
    /// </summary>
    private void Update()
    {
        var pos = transform.position;
        var scale = transform.localScale;
        var px = pos.x;
        var py = pos.y;
        var sx = scale.x;
        var sy = scale.y;
        var bottomLeft = new Vector3(px - sx / 2, py - sy / 2);
        var topRight = new Vector3(px + sx / 2, py + sy / 2);

        m_vectorLine.lineWidth = m_lineWidth;
        m_vectorLine.textureScale = m_textureScale;
        m_vectorLine.color = m_color;
        m_vectorLine.textureOffset = -Time.time * m_speed % 1;

        m_vectorLine.MakeRect(bottomLeft, topRight);
        m_vectorLine.Draw();
    }
}