using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScriptClickableText : MonoBehaviour
{
	public GameObject m_panelColumnFrameData;
	public GameObject m_prefabClickableText;

	// Use this for initialization
	void Start()
	{
		m_prefabClickableText = Instantiate(Resources.Load("Prefabs/ClickableText"), new Vector3 (200, 200, 0), Quaternion.identity) as GameObject;
		m_prefabClickableText.transform.SetParent(m_panelColumnFrameData.transform);
	}
}
