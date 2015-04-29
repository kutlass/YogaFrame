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
	public Text m_textGiantHeader;
	public GameObject m_prefabContentHost;
	public GameObject[] m_rgPrefabContentCaptionedCells;

	// Use this for initialization
	void Start()
	{
		//
		// Copy contextual Game info from cache
		//
		int position = Session.Instance.Cache.GamesPositionLastSelected;
		m_textGiantHeader.text = Session.Instance.Cache.Games.TblGames[position].ColName;

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
		if (true == fResult)
		{
			//
			// Populate the Characters list for the Game at hand
			//
			fResult = ScriptGameInfo._PopulateCharactersList(ref m_rgPrefabContentCaptionedCells[0]);
		}
	}

	private static bool _InitializePrefabContentHost(
		ref GameObject prefabContentHost,
		ref GameObject[] rgPrefabContentCaptionedCell,
		ref string[] rgStrCaptions
		)
	{
		bool fResult = true;
		if (null == prefabContentHost ||
		    null == rgPrefabContentCaptionedCell ||
		    null == rgStrCaptions
		    )
		{
			fResult = false;
			throw new ArgumentNullException();
		}

		ContentHost contentHost = null;
		contentHost = prefabContentHost.GetComponent<ContentHost>();
		if (null != contentHost)
		{
			//
			// Attach children to parent
			//  - children = rgPrefabContentCaptionedCell
			//  - parent   = prefabContentHost
			//
			for (int i = 0; i < rgPrefabContentCaptionedCell.Length; i++)
			{
				rgPrefabContentCaptionedCell[i] = Instantiate(Resources.Load("Prefabs/ContentCaptionedCell")) as GameObject;
				if (null != rgPrefabContentCaptionedCell[i])
				{
					rgPrefabContentCaptionedCell[i].transform.SetParent(contentHost.GetPanelContentLayout().transform);
					ContentCaptionedCell contentCaptionedCell = rgPrefabContentCaptionedCell[i].GetComponent<ContentCaptionedCell>();
					if (null != contentCaptionedCell)
					{
						contentCaptionedCell.SetCaptionText(rgStrCaptions[i]);
					}
					else
					{
						fResult = false;
						break;
					}
				}
				else
				{
					fResult = false;
					break;
				}
			}
		}
		else
		{
			fResult = false;
		}

		return fResult;
	}

	private static bool _PopulateGamePublisher(ref ContentCaptionedCell contentCaptionedCell)
	{
		bool fResult = false;
		if (null == contentCaptionedCell)
		{
			fResult = false;
			throw new ArgumentNullException();
		}

		return fResult;
	}

	private static bool _PopulateGameDescription(ref ContentCaptionedCell contentCaptionedCell)
	{
		bool fResult = false;
		if (null == contentCaptionedCell)
		{
			fResult = false;
			throw new ArgumentNullException();
		}

		return fResult;
	}

	private static bool _PopulateCharactersList(ref GameObject parent)
	{
		bool fResult = true;
		if (null == parent)
		{
			fResult = false;
			throw new ArgumentNullException();
		}

		Characters characters = Session.Instance.Cache.Characters;
		
		//
		// Instantiate a ClickableText.prefab for each Character element cached from the web service
		//
		// Create a view of only Characters relevant to the Game at hand
		int GAME_POSITION_LAST_SELECTED = Session.Instance.Cache.GamesPositionLastSelected;
		string GAME_ID = Session.Instance.Cache.Games.TblGames[GAME_POSITION_LAST_SELECTED].IdtblGames;
		List<TblCharacter> listTblCharacters = new List<TblCharacter>();
		List<int> listIntPositions = new List<int>();
		for (int x = 0; x < characters.TblCharacters.Length; x++)
		{
			TblCharacter currentCharacter = characters.TblCharacters[x];
			if (GAME_ID == currentCharacter.IdtblGames)
			{
				listTblCharacters.Add(currentCharacter);
				listIntPositions.Add(x);
			}
		}

		//
		// Allocate array count based on Game-specific Characters found
		//
		GameObject[] rgPrefabClickableTexts = new GameObject[listTblCharacters.Count];
		TblCharacter[] rgCharacters = listTblCharacters.ToArray();
		for (int i = 0; i < rgPrefabClickableTexts.Length; i++)
		{
			rgPrefabClickableTexts[i] = Instantiate(Resources.Load("Prefabs/ClickableText")) as GameObject;
			if (null != rgPrefabClickableTexts[i])
			{
				rgPrefabClickableTexts[i].transform.SetParent(parent.transform);
				ClickableText clickableText = rgPrefabClickableTexts[i].GetComponentInChildren<ClickableText>();
				clickableText.SetAssignedSceneToInvoke("SceneCharacterInfo");
				clickableText.SetEntryPointPositionCharacters(listIntPositions[i]);
				Text textClickableText = rgPrefabClickableTexts[i].GetComponentInChildren<Text>();
				if (null != textClickableText)
				{
					textClickableText.text = rgCharacters[i].ColName;
				}
				else
				{
					fResult = false;
					break;
				}
			}
			else
			{
				fResult = false;
				break;
			}
		}

		return fResult;
	}
}
