using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.JSessionJsonTypes;
using YogaFrameWebAdapter.Session;

public class MyUnityScript : MonoBehaviour
{
	public Text m_textStatusSignIn;
	public InputField m_inputFieldUserName;
	public InputField m_inputFieldPassword;
	
	public void SignInUI()
	{
		Text[] texts;
		texts = GetComponentsInChildren<Text>();
		foreach (Text text in texts) 
		{
			if ("textStatusSignIn" == text.name)
			{
				m_textStatusSignIn = text;
			}
		}
		InputField[] inputFields;
		inputFields = GetComponentsInChildren<InputField>();
		foreach (InputField inputField in inputFields)
		{
			if ("inputFieldUserName" == inputField.name)
			{
				m_inputFieldUserName = inputField;
			}
			if ("inputFieldPassword" == inputField.name)
			{
				m_inputFieldPassword = inputField;
			}
		}

		//
		// If sign in succeeds, load the main Framedata scene
		//
		bool fResult = false;
		fResult = SignIn(m_inputFieldUserName.text, m_inputFieldPassword.text);
		if (true == fResult)
		{
			Application.LoadLevel("SceneFrameData");
		}
	}

	private bool SignIn(string strUserName, string strPassword)
	{
		bool fResult = false;
		JSession jSessionWebResponse = null;
		jSessionWebResponse = Session.MemberSignIn(strUserName, strPassword);
		if (null != jSessionWebResponse)
		{
			const string S_OK = "S_OK";
			m_textStatusSignIn.text = jSessionWebResponse.Dispatch.Message;
			if (S_OK == jSessionWebResponse.Dispatch.Message)
			{
				fResult = Session.Instance.MemberGetGames();
				if (true == fResult)
				{
					fResult = Session.Instance.MemberGetCharacters();
				}
			}
			else
			{
				fResult = false;
			}
		}

		return fResult;
	}
}
