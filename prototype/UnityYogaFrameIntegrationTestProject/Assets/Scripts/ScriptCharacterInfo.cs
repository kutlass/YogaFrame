using UnityEngine;
using UnityEngine.UI;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.Session;
using YogaFrameWebAdapter.CharactersJsonTypes;
using YogaFrameWebAdapter.MovesJsonTypes;
using System.Collections;
using System.Collections.Generic;

public class ScriptCharacterInfo : MonoBehaviour
{
	public Text m_characterName;
	public Text m_characterDescription;
	public Moves m_moves;
	public GameObject m_panelMovesList;
	public GameObject[] m_rgPrefabClickableTexts;

	// Use this for initialization
	void Start()
	{
		_PopulateMovesList();
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	private void _PopulateMovesList()
	{
		m_moves = Session.Instance.Cache.Moves;
		
		//
		// Instantiate a ClickableText.prefab for each Moves element cached from the web service
		//
		// Create a view of only Moves relevant to the Character at hand
		int CHARACTERS_POSITION_LAST_SELECTED = Session.Instance.Cache.CharactersPositionLastSelected;
		string CHARACTER_ID = Session.Instance.Cache.Characters.TblCharacters[CHARACTERS_POSITION_LAST_SELECTED].IdtblCharacters;
		List<TblMove> listTblMoves = new List<TblMove>();
		for (int x = 0; x < m_moves.TblMoves.Length; x++)
		{
			TblMove currentMove = m_moves.TblMoves[x];
			if (CHARACTER_ID == currentMove.IdtblCharacters)
			{
				listTblMoves.Add(currentMove);
			}
		}
		// Allocate array count based on Character-specific Moves found
		m_rgPrefabClickableTexts = new GameObject[listTblMoves.Count];
		TblMove[] rgMoves = listTblMoves.ToArray();
		for (int i = 0; i < m_rgPrefabClickableTexts.Length; i++)
		{
			m_rgPrefabClickableTexts[i] = Instantiate(Resources.Load("Prefabs/ClickableText")) as GameObject;
			m_rgPrefabClickableTexts[i].transform.SetParent(m_panelMovesList.transform);
			ClickableText clickableText = m_rgPrefabClickableTexts[i].GetComponentInChildren<ClickableText>();
			clickableText.m_entryPointPosition = i;
			clickableText.SetAssignedSceneToInvoke("SceneCharacterInfo");
			Text textClickableText = m_rgPrefabClickableTexts[i].GetComponentInChildren<Text>();
			textClickableText.text = rgMoves[i].ColName;
		}
	}
}
