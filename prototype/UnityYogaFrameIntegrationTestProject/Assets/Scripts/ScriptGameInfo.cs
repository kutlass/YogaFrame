using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter.Session;

public class ScriptGameInfo : MonoBehaviour
{
	public Text m_textGameName;
	public Text m_textGamePublisher;
	public Text m_textGameDescription;

	// Use this for initialization
	void Start ()
	{
		int position = Session.Instance.Cache.GamesPositionLastSelected;
		m_textGameName.text = Session.Instance.Cache.Games.TblGames[position].ColName;
		m_textGamePublisher.text = Session.Instance.Cache.Games.TblGames[position].ColPublisher;
		m_textGameDescription.text = Session.Instance.Cache.Games.TblGames[position].ColDescription;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}	
}
