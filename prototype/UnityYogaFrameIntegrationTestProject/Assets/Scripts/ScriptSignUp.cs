using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter.JSessionJsonTypes;
using YogaFrameWebAdapter.Session;

public class ScriptSignUp : MonoBehaviour
{
	public Text m_textOperationStatus;
	public InputField m_inputFieldUserName;
	public InputField m_inputFieldEmailAddress;
	public InputField m_inputFieldPassword1;
	public InputField m_inputFieldPassword2;

	// Use this for initialization
	void Start()
	{
		m_textOperationStatus.text = "ScriptSignUp::Start() loaded successfully.";
	}

	public void SignUpUI()
	{
		//
		// If the SignUp web operation succeeds, load the Framedata (home) scene:
		//
		bool fResult = false;
		string strOperationStatus = string.Empty;
		fResult = SignUpWeb(
			out strOperationStatus,
			m_inputFieldUserName.text,
			m_inputFieldEmailAddress.text,
			m_inputFieldPassword1.text,
			m_inputFieldPassword2.text
			);
		m_textOperationStatus.text = strOperationStatus;
		if (true == fResult)
		{
			Application.LoadLevel("SceneFrameData");
		}
	}

	private bool SignUpWeb(
		out string outStrOperationStatus,
		string strUserName,
		string strEmailAddress,
		string strPassword1,
		string strPassword2
		)
	{
		bool fResult = false;
		const string S_OK = "S_OK";
		Session sessionOut = null;
		JSession jSession = Session.MemberSignUp(
			out sessionOut,
			strUserName,
			"Not provided.",
			"Not provided.",
			strEmailAddress,
			strPassword1,
			strPassword2
			);
		outStrOperationStatus = jSession.Dispatch.Message;
		if (S_OK == outStrOperationStatus)
		{
			fResult = true;
		}

		return fResult;
	}

	public void SwitchToScene(string strSceneToSwitchTo)
	{
		Application.LoadLevel(strSceneToSwitchTo);
	}
}
