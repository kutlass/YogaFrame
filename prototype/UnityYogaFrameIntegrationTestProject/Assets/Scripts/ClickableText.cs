using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter.Session;

public class ClickableText : MonoBehaviour
{
	public Text m_textClickableText;
	public int m_entryPointPosition;
	public string m_strAssignedSceneToInvoke;

	// Use this for initialization
	void Start()
	{
		//m_textClickableText.text = "Dynamically generated text.";
	}

	public void SetAssignedSceneToInvoke(string strAssignedSceneToInvoke)
	{
		m_strAssignedSceneToInvoke = strAssignedSceneToInvoke;
	}

	public void InvokeAssignedScene()
	{
		Application.LoadLevel(m_strAssignedSceneToInvoke);
	}

	public void SetEntryPointPositionGames(int entryPointPosition)
	{
		Session.Instance.Cache.GamesPositionLastSelected = m_entryPointPosition;
	}

	public void SetEntryPointPositionCharacters(int entryPointPosition)
	{
		Session.Instance.Cache.CharactersPositionLastSelected = m_entryPointPosition;
	}

	public int GetEntryPointPosition(int entryPointPosition)
	{
		return m_entryPointPosition;
	}
}
