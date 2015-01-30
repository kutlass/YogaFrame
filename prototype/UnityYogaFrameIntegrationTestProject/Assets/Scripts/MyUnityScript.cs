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

		SignIn(m_inputFieldUserName.text, m_inputFieldPassword.text);
	}

	public void SignIn(string strUserName, string strPassword)
	{
		JSession jSessionWebResponse = null;
		jSessionWebResponse = Session.MemberSignIn(strUserName, strPassword);
		//jSessionWebResponse = Session.MemberSignIn("kutlass", "PoweredBy#FGC8675309");
		if (null != jSessionWebResponse)
		{
			m_textStatusSignIn.text = jSessionWebResponse.Dispatch.Message;
		}
	}
}
