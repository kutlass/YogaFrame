using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter.Session;

public class ClickableText : MonoBehaviour
{
	public Text m_textClickableText;
	public int m_entryPointPosition;

	// Use this for initialization
	void Start()
	{
		//m_textClickableText.text = "Dynamically generated text.";
	}

	public void SetEntryPointPosition(int entryPointPosition)
	{
		Session.Instance.Cache.GamesPositionLastSelected = m_entryPointPosition;
	}

	public int GetEntryPointPosition(int entryPointPosition)
	{
		return m_entryPointPosition;
	}
}
