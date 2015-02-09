using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.JSessionJsonTypes;
using YogaFrameWebAdapter.GamesJsonTypes;

public class ScriptSubmitGame : MonoBehaviour
{
	public InputField m_inputFieldGameName;
	public InputField m_inputFieldPublisher;
	public InputField m_inputFieldPublisherURL;
	public InputField m_inputFieldDeveloper;
	public InputField m_inputFieldDeveloperURL;
	public InputField m_inputFieldDescription;

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	public void SubmitGameUI()
	{
		bool fResult = false;
		fResult = ScriptSubmitGame._SubmitGameWeb(
			m_inputFieldGameName.text,
			m_inputFieldPublisher.text,
			m_inputFieldPublisherURL.text,
			m_inputFieldDeveloper.text,
			m_inputFieldDeveloperURL.text,
			m_inputFieldDescription.text
			);
	}

	private static bool _SubmitGameWeb(
		string strGameName,
		string strPublisher,
		string strPublisherURL,
		string strDeveloper,
		string strDeveloperURL,
		string strDescription
		)
	{
		bool fResult = false;
		JSession jSessionWebResponse = null;
		List<TblGame> listTblGames = new List<TblGame>
		{
			new TblGame()
			{
				ColName         = strGameName,
				ColDeveloper    = strDeveloper,
				ColDeveloperURL = strDeveloperURL,
				ColPublisher    = strPublisher,
				ColPublisherURL = strPublisherURL,
				ColDescription  = strDescription
			}
		};
		Games games = new Games();
		games.TblGames = listTblGames.ToArray();
		jSessionWebResponse = WebAdapter.WebPostGame(ref games);
		const string S_OK = "S_OK";
		if (S_OK == jSessionWebResponse.Dispatch.Message)
		{
			fResult = true;
		}

		return fResult;
	}
}
