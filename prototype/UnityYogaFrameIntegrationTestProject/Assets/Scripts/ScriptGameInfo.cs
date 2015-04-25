using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
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

	public GameObject m_prefabContentHost;
	public GameObject[] m_rgPrefabContentCaptionedCells;

	// Use this for initialization
	void Start()
	{
		//
		// Assign static UI names (deisgn-time values)
		//
		const string CAPTION_NAME_GAME_CHARACTERS  = "CHARACTERS:";
		const string CAPTION_NAME_GAME_PUBLISHER   = "PUBLISHER:";
		const string CAPTION_NAME_GAME_DESCRIPTION = "DESCRIPTION:";
		const int NUM_CONTENT_CAPTIONED_CELLS = 3;
		string[] rgStrCaptions = new string[NUM_CONTENT_CAPTIONED_CELLS];
		rgStrCaptions[0] = CAPTION_NAME_GAME_CHARACTERS;
		rgStrCaptions[1] = CAPTION_NAME_GAME_PUBLISHER;
		rgStrCaptions[2] = CAPTION_NAME_GAME_DESCRIPTION;
		m_rgPrefabContentCaptionedCells = new GameObject[NUM_CONTENT_CAPTIONED_CELLS];

		//
		// Initialize the ContentHost.prefab
		//
		bool fResult = false;
		fResult = ScriptGameInfo._InitializePrefabContentHost(
			ref m_prefabContentHost,
			ref m_rgPrefabContentCaptionedCells,
			ref rgStrCaptions
			);

		//
		// Copy contextual Game info from cache
		//
		int position = Session.Instance.Cache.GamesPositionLastSelected;
		m_textGameName.text = Session.Instance.Cache.Games.TblGames[position].ColName;
		m_textGamePublisher.text = Session.Instance.Cache.Games.TblGames[position].ColPublisher;
		m_textGameDescription.text = Session.Instance.Cache.Games.TblGames[position].ColDescription;

		//
		// Populate the Characters list for the Game at hand
		//
		_PopulateCharactersList();
	}

	private static bool _InitializePrefabContentHost(
		ref GameObject prefabContentHost,
		ref GameObject[] rgPrefabContentCaptionedCell,
		ref string[] rgStrCaptions
		)
	{
		bool fResult = false;
		if (null == prefabContentHost || null == rgPrefabContentCaptionedCell || null == rgStrCaptions)
		{
			fResult = false;
			throw new ArgumentNullException();
		}

		//
		// Attach children to parent
		//  - children = rgPrefabContentCaptionedCell
		//  - parent   = prefabContentHost
		//
		for (int i = 0; i < rgPrefabContentCaptionedCell.Length; i++)
		{
			rgPrefabContentCaptionedCell[i] = Instantiate(Resources.Load("Prefabs/ContentCaptionedCell")) as GameObject;
			rgPrefabContentCaptionedCell[i].transform.SetParent(prefabContentHost.transform);
			ContentCaptionedCell contentCaptionedCell = rgPrefabContentCaptionedCell[i].GetComponent<ContentCaptionedCell>();
			contentCaptionedCell.SetCaptionText(rgStrCaptions[i]);
		}

		return fResult;
	}

	private void _PopulateCharactersList()
	{
		m_characters = Session.Instance.Cache.Characters;
		
		//
		// Instantiate a ClickableText.prefab for each Character element cached from the web service
		//
		// Create a view of only Characters relevant to the Game at hand
		int GAME_POSITION_LAST_SELECTED = Session.Instance.Cache.GamesPositionLastSelected;
		string GAME_ID = Session.Instance.Cache.Games.TblGames[GAME_POSITION_LAST_SELECTED].IdtblGames;
		List<TblCharacter> listTblCharacters = new List<TblCharacter>();
		List<int> listIntPositions = new List<int>();
		for (int x = 0; x < m_characters.TblCharacters.Length; x++)
		{
			TblCharacter currentCharacter = m_characters.TblCharacters[x];
			if (GAME_ID == currentCharacter.IdtblGames)
			{
				listTblCharacters.Add(currentCharacter);
				listIntPositions.Add(x);
			}
		}
		// Allocate array count based on Game-specific Characters found
		m_rgPrefabClickableTexts = new GameObject[listTblCharacters.Count];
		TblCharacter[] rgCharacters = listTblCharacters.ToArray();
		for (int i = 0; i < m_rgPrefabClickableTexts.Length; i++)
		{
			m_rgPrefabClickableTexts[i] = Instantiate(Resources.Load("Prefabs/ClickableText")) as GameObject;
			m_rgPrefabClickableTexts[i].transform.SetParent(m_panelCharactersList.transform);
			ClickableText clickableText = m_rgPrefabClickableTexts[i].GetComponentInChildren<ClickableText>();
			clickableText.SetAssignedSceneToInvoke("SceneCharacterInfo");
			clickableText.SetEntryPointPositionCharacters(listIntPositions[i]);
			Text textClickableText = m_rgPrefabClickableTexts[i].GetComponentInChildren<Text>();
			textClickableText.text = rgCharacters[i].ColName;
		}
	}
}
