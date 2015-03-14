using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.JSessionJsonTypes;
using YogaFrameWebAdapter.GamesJsonTypes;
using YogaFrameWebAdapter.Session;

public class ScriptFramedata : MonoBehaviour
{
	public Games m_games;
	public GameObject m_panelGamesList;
	public GameObject[] m_rgPrefabClickableTexts;

	// Use this for initialization
	void Start()
	{
		GetGames();
	}

	public void GetGames()
	{
		m_games = Session.Instance.Cache.Games;

		//
		// Instantiate a ClickableText.prefab for each game element cached from the web service
		//
		m_rgPrefabClickableTexts = new GameObject[m_games.TblGames.Length];
		for (int i = 0; i < m_games.TblGames.Length; i++)
		{
			m_rgPrefabClickableTexts[i] = Instantiate(Resources.Load("Prefabs/ClickableText")) as GameObject;
			m_rgPrefabClickableTexts[i].transform.SetParent(m_panelGamesList.transform);
			Text textClickableText = m_rgPrefabClickableTexts[i].GetComponentInChildren<Text>();
			textClickableText.text = m_games.TblGames[i].ColName;
		}
	}
}
