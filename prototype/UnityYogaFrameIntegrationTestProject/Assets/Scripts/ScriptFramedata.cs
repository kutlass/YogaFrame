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
	// Use this for initialization
	void Start()
	{
		m_textListGames.text = "Successful bind!";
		JSession jSessionWebResponse = WebAdapter.WebGetGames();
		if (null != jSessionWebResponse)
		{
			const string S_OK = "S_OK";
			m_textListGames.text = jSessionWebResponse.Dispatch.Message;
			if (S_OK == jSessionWebResponse.Dispatch.Message)
			{
				Games games = jSessionWebResponse.Games;
				foreach (TblGame tblGame in games.TblGames)
				{
					m_textListGames.text = tblGame.ColName;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}
}
