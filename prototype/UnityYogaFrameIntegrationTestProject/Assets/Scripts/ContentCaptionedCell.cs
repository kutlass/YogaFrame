using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContentCaptionedCell : MonoBehaviour
{
    public Text m_CaptionText;
    public GameObject m_panelContent;

    // Use this for initialization
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {
    
    }

    public void SetCaptionText(string strCaptionText)
    {
        m_CaptionText.text = strCaptionText;
    }

    public void SetContent(GameObject content)
    {
        content.transform.SetParent(m_panelContent.transform);
    }
}
