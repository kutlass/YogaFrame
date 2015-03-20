using UnityEngine;
using UnityEngine.UI;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.Session;
using YogaFrameWebAdapter.CharactersJsonTypes;
using YogaFrameWebAdapter.MovesJsonTypes;
using System.Collections;

public class ScriptCharacterInfo : MonoBehaviour
{
	public Text m_characterName;
	public Text m_characterDescription;
	public GameObject m_panelMovesList;
	public GameObject[] m_rgPrefabClickableTexts;

	// Use this for initialization
	void Start()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	// TODO: Refactor _PopulateCharactersList() into _PopulateMovesList()
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
		for (int x = 0; x < m_characters.TblCharacters.Length; x++)
		{
			TblCharacter currentCharacter = m_characters.TblCharacters[x];
			if (GAME_ID == currentCharacter.IdtblGames)
			{
				listTblCharacters.Add(currentCharacter);
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
			clickableText.m_entryPointPosition = i;
			Text textClickableText = m_rgPrefabClickableTexts[i].GetComponentInChildren<Text>();
			textClickableText.text = rgCharacters[i].ColName;
		}
	}
}
