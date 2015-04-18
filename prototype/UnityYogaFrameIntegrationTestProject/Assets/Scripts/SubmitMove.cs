using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.Session;
using YogaFrameWebAdapter.MovesJsonTypes;

public class SubmitMove : MonoBehaviour
{
	public string m_strIdtblCharacters;
	
	//
	// Field mappings for SubmitMove.prefab
	//
	public Text m_textMoveCharacter;
	public InputField m_inputFieldMoveName;

	// Use this for initialization
	void Start()
	{
		//
		// Copy Character Name and ID
		// 
		int charactersPositionLastSelected = Session.Instance.Cache.CharactersPositionLastSelected;
		m_textMoveCharacter.text = Session.Instance.Cache.Characters.TblCharacters[charactersPositionLastSelected].ColName;
		m_strIdtblCharacters = Session.Instance.Cache.Characters.TblCharacters[charactersPositionLastSelected].IdtblCharacters;	
	}

	public void SaveUI()
	{
		bool fResult = false;
		fResult = SubmitMove._MemberPostMove(
			m_inputFieldMoveName.text,
			m_strIdtblCharacters
			);
	}

	private static bool _MemberPostMove(
		string strMoveName,
		string strIdtblCharacters
		)
	{
		bool fResult = false;

		//
		// Prep web form data for submit
		//
		TblMove tblMove = new TblMove();
		tblMove.ColName = strMoveName;
		tblMove.IdtblCharacters = strIdtblCharacters;
		Moves moves = new Moves();
		moves.TblMoves = new TblMove[1];
		moves.TblMoves[0] = tblMove;
		
		//
		// Make web POST call to YogaFrame web service
		//	
		fResult = Session.Instance.MemberPostMove(ref moves);

		return fResult;
	}
}
