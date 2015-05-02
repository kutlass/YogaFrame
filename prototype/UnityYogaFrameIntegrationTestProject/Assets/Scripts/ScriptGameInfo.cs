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
		const int KEY_CHARACTERS  = 0;
		const int KEY_PUBLISHER   = 1;
		const int KEY_DESCRIPTION = 2;
		const int NUM_CONTENT_CAPTIONED_CELLS = 3;
		string[] rgStrCaptions = new string[NUM_CONTENT_CAPTIONED_CELLS];
		rgStrCaptions[KEY_CHARACTERS]  = CAPTION_NAME_GAME_CHARACTERS;
		rgStrCaptions[KEY_PUBLISHER]   = CAPTION_NAME_GAME_PUBLISHER;
		rgStrCaptions[KEY_DESCRIPTION] = CAPTION_NAME_GAME_DESCRIPTION;
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
			const int KEY_CHARACTERS  = 0;
			const int KEY_PUBLISHER   = 1;
			const int KEY_DESCRIPTION = 2;
			for (int i = 0; i < rgPrefabContentCaptionedCell.Length; i++)
			{
				rgPrefabContentCaptionedCell[i] = Instantiate(Resources.Load("Prefabs/ContentCaptionedCell")) as GameObject;
				if (null != rgPrefabContentCaptionedCell[i])
				{
					ContentCaptionedCell contentCaptionedCell = rgPrefabContentCaptionedCell[i].GetComponent<ContentCaptionedCell>();
					if (null != contentCaptionedCell)
					{
						contentCaptionedCell.SetCaptionText(rgStrCaptions[i]);
						switch (i)
						{
						case KEY_CHARACTERS:
							fResult = ScriptGameInfo._PopulateCharactersList(ref rgPrefabContentCaptionedCell[KEY_CHARACTERS]);
							break;
						case KEY_PUBLISHER:
							fResult = ScriptGameInfo._PopulateGamePublisher(ref rgPrefabContentCaptionedCell[KEY_PUBLISHER]);
							break;
						case KEY_DESCRIPTION:
							fResult = ScriptGameInfo._PopulateGameDescription(ref rgPrefabContentCaptionedCell[KEY_DESCRIPTION]);
							break;
						default:
							fResult = false;
							break;
						}

						if (true == fResult)
						{
							//
							// All required prefab instantiations have occurred.
							// With that, attach freshly-dynamically-sized 
							// children to parent content panel:
							//
							rgPrefabContentCaptionedCell[i].transform.SetParent(contentHost.GetPanelContentLayout().transform);
						}
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

	private static bool _PopulateGamePublisher(ref GameObject gameObject)
	{
		bool fResult = false;
		if (null == gameObject)
		{
			fResult = false;
			throw new ArgumentNullException();
		}

		int GAME_POSITION_LAST_SELECTED = Session.Instance.Cache.GamesPositionLastSelected;
		string GAME_PUBLISHER = Session.Instance.Cache.Games.TblGames[GAME_POSITION_LAST_SELECTED].ColPublisher;
		ContentCaptionedCell contentCaptionedCell = null;
		contentCaptionedCell = gameObject.GetComponent<ContentCaptionedCell>();
		if (null != contentCaptionedCell)
		{
			GameObject gameObjectClickableText = null;
			gameObjectClickableText = Instantiate(Resources.Load("Prefabs/ClickableText")) as GameObject;
			if (null != gameObjectClickableText)
			{
				ClickableText clickableText = null;
				clickableText = gameObjectClickableText.GetComponent<ClickableText>();
				if (null != clickableText)
				{
					Text text = null;
					text = clickableText.GetComponentInChildren<Text>();
					if (null != text)
					{
						text.text = GAME_PUBLISHER;
						contentCaptionedCell.SetContent(gameObjectClickableText);
						
						fResult = true;
					}
					else
					{
						fResult = false;
					}
				}
				else
				{
					fResult = false;
				}
			}
			else
			{
				fResult = false;
			}
		}
		else
		{
			fResult = false;
		}

		return fResult;
	}

	private static bool _PopulateGameDescription(ref GameObject gameObject)
	{
		bool fResult = false;
		if (null == gameObject)
		{
			fResult = false;
			throw new ArgumentNullException();
		}

		int GAME_POSITION_LAST_SELECTED = Session.Instance.Cache.GamesPositionLastSelected;
		string GAME_DESCRIPTION = Session.Instance.Cache.Games.TblGames[GAME_POSITION_LAST_SELECTED].ColDescription;
		ContentCaptionedCell contentCaptionedCell = null;
		contentCaptionedCell = gameObject.GetComponent<ContentCaptionedCell>();
		if (null != contentCaptionedCell)
		{
			GameObject gameObjectClickableText = null;
			gameObjectClickableText = Instantiate(Resources.Load("Prefabs/ClickableText")) as GameObject;
			if (null != gameObjectClickableText)
			{
				ClickableText clickableText = null;
				clickableText = gameObjectClickableText.GetComponent<ClickableText>();
				if (null != clickableText)
				{
					Text text = null;
					text = clickableText.GetComponentInChildren<Text>();
					if (null != text)
					{
						text.text = GAME_DESCRIPTION;
						contentCaptionedCell.SetContent(gameObjectClickableText);

						fResult = true;
					}
					else
					{
						fResult = false;
					}
				}
				else
				{
					fResult = false;
				}
			}
			else
			{
				fResult = false;
			}
		}
		else
		{
			fResult = false;
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
		// Establish a ContentCaptionedCell.prefab as our parent
		// for the ClickableText.prefabs that we're about to instantiate
		//
		ContentCaptionedCell contentCaptionedCell = null;
		contentCaptionedCell = parent.GetComponent<ContentCaptionedCell>();
		if (null != contentCaptionedCell)
		{
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
					contentCaptionedCell.SetContent( rgPrefabClickableTexts[i] );
					ClickableText clickableText = rgPrefabClickableTexts[i].GetComponentInChildren<ClickableText>();
					if (null != clickableText)
					{
						clickableText.SetAssignedSceneToInvoke("SceneCharacterInfo");
						clickableText.SetEntryPointPositionCharacters(listIntPositions[i]);
						Text text = rgPrefabClickableTexts[i].GetComponentInChildren<Text>();
						if (null != text)
						{
							text.text = rgCharacters[i].ColName;
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
}
