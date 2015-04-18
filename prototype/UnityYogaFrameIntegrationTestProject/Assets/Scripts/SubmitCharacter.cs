using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.Session;
using YogaFrameWebAdapter.CharactersJsonTypes;

public class SubmitCharacter : MonoBehaviour
{
	public int m_idtblGame;

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
		m_idtblGame = int.Parse(Session.Instance.Cache.Games.TblGames[gamesPositionLastSelected].IdtblGames);
	}

	public void SaveUI()
	{
		bool fResult = false;
		fResult = SubmitCharacter._MemberPostCharacter(
			m_inputFieldCharacterName.text,
			m_inputFieldCharacterDescription.text
			);
	}

	private static bool _MemberPostCharacter(
		string strCharacterName,
		string strCharacterDescription
		)
	{
		bool fResult = false;
		Characters characters = new Characters();
		fResult = Session.Instance.MemberPostCharacter(ref characters);

		return fResult;
	}
}
