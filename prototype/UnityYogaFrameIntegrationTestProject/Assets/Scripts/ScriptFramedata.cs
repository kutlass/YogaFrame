using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.JSessionJsonTypes;
using YogaFrameWebAdapter.GamesJsonTypes;
using YogaFrameWebAdapter.Session;

public class ScriptFramedata : MonoBehaviour
{
	public GameObject m_panelGamesList;
	public GameObject[] m_rgPrefabClickableTexts;

	// Use this for initialization
	void Start()
	{
		GetGames();
	}

	public void GetGames()
	{
		print ("ScriptFrameData::GetGames(): Calling WebAdapter.WebGetGames()...");
		JSession jSessionWebResponse = WebAdapter.WebGetGames();
		if (null != jSessionWebResponse)
		{
			print ("ScriptFrameData::GetGames(): Non-null jSessionWebResponse returned from WebAdapter.WebGetGames().");
            const string S_OK = "S_OK";
			if (S_OK == jSessionWebResponse.Dispatch.Message)
			{
				print ("ScriptFrameData::GetGames(): WebAdapter.WebGetGames() succeeded with S_OK.");
				Games games = jSessionWebResponse.Games;
				
				//
				// Instantiate a ClickableText.prefab for each game element returned from the web service
				//
				m_rgPrefabClickableTexts = new GameObject[games.TblGames.Length];
				for (int i = 0; i < games.TblGames.Length; i++)
				{
					m_rgPrefabClickableTexts[i] = Instantiate(Resources.Load("Prefabs/ClickableText")) as GameObject;
					m_rgPrefabClickableTexts[i].transform.SetParent(m_panelGamesList.transform);
					Text textClickableText = m_rgPrefabClickableTexts[i].GetComponentInChildren<Text>();
					textClickableText.text = games.TblGames[i].ColName;
				}
			}
		}
	}
}
