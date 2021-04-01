using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FlexibleGrid : MonoBehaviour
{ 
    [SerializeField, Tooltip("")]
    private Vector2 m_preferedItemSize = default;
    [SerializeField, Tooltip("")]
    private Vector2 m_preferedItemSpacing = default;
    private RectTransform m_rectTransform = null;

    private void Start()
    {
        UpdateGrid();
    }

    public void UpdateGrid()
    {
        if(m_rectTransform == null)
        {
            m_rectTransform = transform as RectTransform;
        }

        List<RectTransform> l_childTransforms = new List<RectTransform>();
        for(int i = 0; i < transform.childCount; ++i)
        {
            l_childTransforms.Add(transform.GetChild(i) as RectTransform);
        }

        int l_itemsPerLine = (int) (m_rectTransform.rect.width / (m_preferedItemSize.x + m_preferedItemSpacing.x));
        int l_itemPerColumn = (int) (m_rectTransform.rect.height / (m_preferedItemSize.y + m_preferedItemSpacing.y));

        float reductionFactor = 1f;
        if(l_childTransforms.Count > l_itemPerColumn * l_itemsPerLine)
        {
            reductionFactor = Mathf.Sqrt((float) (l_itemPerColumn * l_itemsPerLine) / (float) l_childTransforms.Count);
        }

        l_itemsPerLine = (int)(m_rectTransform.rect.width / ((m_preferedItemSize.x + m_preferedItemSpacing.x) * reductionFactor));
        l_itemPerColumn = (int)(m_rectTransform.rect.height / ((m_preferedItemSize.y + m_preferedItemSpacing.y) * reductionFactor));

        int currXIndex = 0;
        int currYIndex = 0;
        float borderOffset = (l_itemsPerLine * (m_preferedItemSize.x + m_preferedItemSpacing.x) * reductionFactor) - m_rectTransform.rect.width;
        borderOffset /= 2;
        for (int i = 0; i < l_childTransforms.Count; ++i)
        {
            l_childTransforms[i].sizeDelta = m_preferedItemSize * reductionFactor;

            currXIndex = i % l_itemsPerLine;
            currYIndex = (int) (i / (l_itemsPerLine));
            l_childTransforms[i].localPosition = new Vector2
                ((m_preferedItemSize.x + m_preferedItemSpacing.x) * reductionFactor * currXIndex + m_preferedItemSize.x / 2 - borderOffset,
                -(m_preferedItemSize.y + m_preferedItemSpacing.y) * reductionFactor * currYIndex - m_preferedItemSize.y / 2 + borderOffset)
                - (new Vector2(m_rectTransform.rect.size.x, -m_rectTransform.rect.size.y) / 2) ;
            l_childTransforms[i].ForceUpdateRectTransforms();
        }
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(FlexibleGrid))]
public class FlexibleGridEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Build Grid"))
        {
            FlexibleGrid gridTarget = (FlexibleGrid)target;
            gridTarget.UpdateGrid();
        }
    }
}
#endif