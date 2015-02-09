using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.JSessionJsonTypes;
using YogaFrameWebAdapter.GamesJsonTypes;
using YogaFrameWebAdapter.Session;

public class ScriptFramedata : MonoBehaviour
{
	public Text m_textListGames;
	public Toggle m_toggleSubmitGame;
	public GameObject m_prefabSubmitGame;

	// Use this for initialization
	void Start()
	{
		m_textListGames.text = "ScriptFrameData::Start(): Successful bind!";
	}

	public void HandleToggleEvent()
	{
		if (true == m_toggleSubmitGame.isOn)
		{
			m_prefabSubmitGame.SetActive(true);
		}
		else
		{
			m_prefabSubmitGame.SetActive(false);
		}
	}

	public void GetGames()
	{
		print ("ScriptFrameData::GetGames(): Calling WebAdapter.WebGetGames()...");
		JSession jSessionWebResponse = WebAdapter.WebGetGames();
		if (null != jSessionWebResponse)
		{
			print ("ScriptFrameData::GetGames(): Non-null jSessionWebResponse returned from WebAdapter.WebGetGames().");
            const string S_OK = "S_OK";
			m_textListGames.text = jSessionWebResponse.Dispatch.Message;
			if (S_OK == jSessionWebResponse.Dispatch.Message)
			{
				m_textListGames.text = "";
				print ("ScriptFrameData::GetGames(): WebAdapter.WebGetGames() succeeded with S_OK.");
				Games games = jSessionWebResponse.Games;
				foreach (TblGame tblGame in games.TblGames)
				{
					m_textListGames.text += tblGame.ColName + "\n";
				}
			}
		}
	}
}
