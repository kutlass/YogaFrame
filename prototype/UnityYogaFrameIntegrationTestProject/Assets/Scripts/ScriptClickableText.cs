using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScriptClickableText : MonoBehaviour
{
	public GameObject m_panelColumnFrameData;

	public GameObject m_prefabClickableText;
	public GameObject m_prefabClickableText2;
	public GameObject m_prefabClickableText3;

	// Use this for initialization
	void Start()
	{
		//m_prefabClickableText = Instantiate(Resources.Load("Prefabs/ClickableText"), new Vector3 (200, 200, 0), Quaternion.identity) as GameObject;
		//m_prefabClickableText2 = Instantiate(Resources.Load("Prefabs/ClickableText"), new Vector3 (200, 300, 0), Quaternion.identity) as GameObject;
		//m_prefabClickableText3 = Instantiate(Resources.Load("Prefabs/ClickableText"), new Vector3 (200, 400, 0), Quaternion.identity) as GameObject;

		m_prefabClickableText = Instantiate(Resources.Load("Prefabs/ClickableText")) as GameObject;
		m_prefabClickableText2 = Instantiate(Resources.Load("Prefabs/ClickableText")) as GameObject;
		m_prefabClickableText3 = Instantiate(Resources.Load("Prefabs/ClickableText")) as GameObject;

		m_prefabClickableText.transform.SetParent(m_panelColumnFrameData.transform);
		m_prefabClickableText2.transform.SetParent(m_panelColumnFrameData.transform);
		m_prefabClickableText3.transform.SetParent(m_panelColumnFrameData.transform);
	}
}
