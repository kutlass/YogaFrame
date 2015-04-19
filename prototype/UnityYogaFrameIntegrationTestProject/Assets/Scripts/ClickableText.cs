using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter.Session;

public class ClickableText : MonoBehaviour
{
	public Text m_textClickableText;
	private int m_entryPointPosition;
	public string m_strAssignedSceneToInvoke;

	// Use this for initialization
	void Start()
	{
	}

	/////////////////////////
	// OnClick prefab methods
	//
	public void InvokeAssignedScene()
	{
		//
		// Set dappler cursor relative to user-clicked position:
		//
		int position;
		switch (m_strAssignedSceneToInvoke)
		{
		case "SceneGameInfo":
			position = this.GetEntryPointPosition();
			Session.Instance.Cache.GamesPositionLastSelected = position;
			break;
		case "SceneCharacterInfo":
			position = this.GetEntryPointPosition();
			Session.Instance.Cache.CharactersPositionLastSelected = position;
			break;
		default:
			break;
		}

		//
		// Load scene assigned to this prefab instance:
		//
		Application.LoadLevel(m_strAssignedSceneToInvoke);
	}
	
	public int GetEntryPointPosition()
	{
		return m_entryPointPosition;
	}

	////////////////////////////////
	// Initialization prefab methods
	//
	public void SetAssignedSceneToInvoke(string strAssignedSceneToInvoke)
	{
		m_strAssignedSceneToInvoke = strAssignedSceneToInvoke;
	}

	public void SetEntryPointPositionGames(int entryPointPosition)
	{
		m_entryPointPosition = entryPointPosition;
	}

	public void SetEntryPointPositionCharacters(int entryPointPosition)
	{
		m_entryPointPosition = entryPointPosition;
	}
}
