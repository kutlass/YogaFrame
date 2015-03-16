using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter.Session;

public class ScriptGameInfo : MonoBehaviour
{
	public Text m_textGameName;

	// Use this for initialization
	void Start ()
	{
		int position = Session.Instance.Cache.GamesPositionLastSelected;
		m_textGameName.text = Session.Instance.Cache.Games.TblGames[position].ColName;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}	
}
