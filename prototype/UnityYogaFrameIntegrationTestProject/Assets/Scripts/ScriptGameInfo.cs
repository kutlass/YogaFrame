using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.Session;
using YogaFrameWebAdapter.JSessionJsonTypes;
using YogaFrameWebAdapter.CharactersJsonTypes;

public class ScriptGameInfo : MonoBehaviour
{
	public Text m_textGameName;
	public Text m_textGamePublisher;
	public Text m_textGameDescription;

	public Characters m_characters;
	public GameObject m_panelCharactersList;
	public GameObject[] m_rgPrefabClickableTexts;

	// Use this for initialization
	void Start ()
	{
		int position = Session.Instance.Cache.GamesPositionLastSelected;
		m_textGameName.text = Session.Instance.Cache.Games.TblGames[position].ColName;
		m_textGamePublisher.text = Session.Instance.Cache.Games.TblGames[position].ColPublisher;
		m_textGameDescription.text = Session.Instance.Cache.Games.TblGames[position].ColDescription;

		_PopulateCharactersList();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	private void _PopulateCharactersList()
	{
		m_characters = Session.Instance.Cache.Characters;
		
		//
		// Instantiate a ClickableText.prefab for each Character element cached from the web service
		//
		m_rgPrefabClickableTexts = new GameObject[m_characters.TblCharacters.Length];
		for (int i = 0; i < m_characters.TblCharacters.Length; i++)
		{
			m_rgPrefabClickableTexts[i] = Instantiate(Resources.Load("Prefabs/ClickableText")) as GameObject;
			m_rgPrefabClickableTexts[i].transform.SetParent(m_panelCharactersList.transform);
			Text textClickableText = m_rgPrefabClickableTexts[i].GetComponentInChildren<Text>();
			ClickableText clickableText = m_rgPrefabClickableTexts[i].GetComponentInChildren<ClickableText>();
			clickableText.m_entryPointPosition = i;
			textClickableText.text = m_characters.TblCharacters[i].ColName;
		}
	}
}
