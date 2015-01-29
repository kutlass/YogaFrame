using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.JSessionJsonTypes;
using YogaFrameWebAdapter.Session;

public class MyUnityScript : MonoBehaviour
{
	public Text textStatusSignIn;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void SignIn()
	{
		textStatusSignIn = GetComponent<Text>();

		JSession jSessionWebResponse = null;
		jSessionWebResponse = Session.MemberSignIn("kutlass", "PoweredBy#FGC8675309");
		if (null != jSessionWebResponse)
		{
			textStatusSignIn.text = jSessionWebResponse.Dispatch.Message;
		}
	}
}
