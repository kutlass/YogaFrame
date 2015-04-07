using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.Session;
using YogaFrameWebAdapter.MembersJsonTypes;

public class ScriptProfile : MonoBehaviour
{
	public Text m_textProfileAlias;
	public Text m_textProfileNameFirst;
	public Text m_textProfileYearsOfService;
	public Text m_textBio;

	// Use this for initialization
	void Start()
	{
		bool fResult = false;
		fResult = ScriptProfile._GetMemberFields(
			ref m_textProfileAlias,
			ref m_textProfileNameFirst,
			ref m_textProfileYearsOfService,
			ref m_textBio
			);
	}

	private static bool _GetMemberFields(
		ref Text textProfileAlias,
		ref Text textProfileNameFirst,
		ref Text textProfileYearsOfService,
		ref Text textBio
		)
	{
		bool fResult = false;

		if (
			null == textProfileAlias ||
			null == textProfileNameFirst ||
			null == textProfileYearsOfService ||
			null == textBio
		    )
		{
			fResult = false;
			throw new ArgumentNullException();
		}

		TblMember tblMember = Session.Instance.Cache.Members.TblMembers[0];
		textProfileAlias.text = tblMember.ColNameAlias;
		textProfileNameFirst.text = tblMember.ColNameFirst;
		textProfileYearsOfService.text = "1"; // TODO: Replace hard-code with true logic
		textBio.text = tblMember.ColBio;

		return fResult;
	}
}
