using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.Session;
using YogaFrameWebAdapter.CharactersJsonTypes;

public class SubmitCharacter : MonoBehaviour
{
	public string m_strIdtblGame;

	//
	// Field mappings for SubmitCharacter.prefab
	//
	public Text m_textCharacterGame;
	public InputField m_inputFieldCharacterName;
	public InputField m_inputFieldCharacterDescription;

	// Use this for initialization
	void Start()
	{
		//
		// Copy Game Name and ID
		// 
		int gamesPositionLastSelected = Session.Instance.Cache.GamesPositionLastSelected;
		m_textCharacterGame.text = Session.Instance.Cache.Games.TblGames[gamesPositionLastSelected].ColName;
		m_strIdtblGame = Session.Instance.Cache.Games.TblGames[gamesPositionLastSelected].IdtblGames;
	}

	public void SaveUI()
	{
		bool fResult = false;
		fResult = SubmitCharacter._MemberPostCharacter(
			m_inputFieldCharacterName.text,
			m_inputFieldCharacterDescription.text,
			m_strIdtblGame
			);
	}

	private static bool _MemberPostCharacter(
		string strCharacterName,
		string strCharacterDescription,
		string strIdtblGames
		)
	{
		bool fResult = false;

		//
		// Prep web form data for submit
		//
		TblCharacter tblCharacter = new TblCharacter();
		tblCharacter.ColName = strCharacterName;
		tblCharacter.ColDescription = strCharacterDescription;
		tblCharacter.IdtblGames = strIdtblGames;
		Characters characters = new Characters();
		characters.TblCharacters = new TblCharacter[1];
		characters.TblCharacters[0] = tblCharacter;

		//
		// Make web POST call to YogaFrame web service
		//
		fResult = Session.Instance.MemberPostCharacter(ref characters);

		return fResult;
	}
}
