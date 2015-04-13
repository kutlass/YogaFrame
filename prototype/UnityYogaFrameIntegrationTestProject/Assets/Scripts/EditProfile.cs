using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.Session;

public class EditProfile : MonoBehaviour
{
	public InputField m_inputFieldBio;

	// Use this for initialization
	void Start()
	{
	
	}

	public void UpdateProfileUI()
	{
		bool fResult = false;
		fResult = EditProfile._WebUpdateProfile();
		if (true == fResult)
		{
			m_inputFieldBio.text = Session.Instance.Cache.Members.TblMembers[0].ColBio;
		}
	}

	private static bool _WebUpdateProfile()
	{
		bool fResult = false;
		fResult = Session.Instance.MemberUpdateProfile(
			null,
			null,
			null
			);

		return fResult;
	}
}
