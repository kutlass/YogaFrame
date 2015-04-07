using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.Session;

public class ScriptProfile : MonoBehaviour
{
	public Text m_textProfileAlias;
	public Text m_textProfileNameFirst;
	public Text m_textProfileYearsOfService;
	public Text m_textBio;

	// Use this for initialization
	void Start()
	{
		m_textProfileAlias = null;
		m_textProfileNameFirst = null;
		m_textProfileYearsOfService = null;
		m_textBio = null;

		bool fResult = false;
		fResult = ScriptProfile._GetMemberFields ();
	}

	private static bool _GetMemberFields()
	{
		bool fResult = false;
		return fResult;
	}
}
