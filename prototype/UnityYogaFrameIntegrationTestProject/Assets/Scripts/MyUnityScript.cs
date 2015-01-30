using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.JSessionJsonTypes;
using YogaFrameWebAdapter.Session;

public class MyUnityScript : MonoBehaviour
{
	public Text textStatusSignIn;
	public InputField inputFieldUserName;
	public InputField inputFieldPassword;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void SignIn(string text)
	{
		textStatusSignIn = GetComponent<Text>();
		inputFieldUserName = GetComponent<InputField>();
		inputFieldPassword = GetComponent<InputField>();

		JSession jSessionWebResponse = null;
		jSessionWebResponse = Session.MemberSignIn(inputFieldUserName.text, inputFieldPassword.text);
		//jSessionWebResponse = Session.MemberSignIn("kutlass", "PoweredBy#FGC8675309");
		if (null != jSessionWebResponse)
		{
			textStatusSignIn.text = jSessionWebResponse.Dispatch.Message;
		}
	}
}
