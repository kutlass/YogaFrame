using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class ContentHost : MonoBehaviour
{
    //
    // Editor bindings
    //
    public GameObject m_scrollView;
    public GameObject m_panelContentLayout;

    //
    // Runtime bindings
    //
    public GameObject[] m_rgPrefabContentCaptionedCell;

    // Use this for initialization
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }

    public void AttachPrefabArray(ref GameObject[] rgPrefabs)
    {
        if (null == rgPrefabs)
        {
            throw new ArgumentNullException();
        }

        m_rgPrefabContentCaptionedCell = rgPrefabs;
    }

    public GameObject GetPanelContentLayout()
    {
        return m_panelContentLayout;
    }
}
