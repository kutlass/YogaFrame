using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.JSessionJsonTypes;
using YogaFrameWebAdapter.Session;

public class MyUnityScript : MonoBehaviour
{
	public YogaFrameUnityAdapter yogaFrameUnityAdapter;
	
	// Use this for initialization
	void Start()
	{
		yogaFrameUnityAdapter = new YogaFrameUnityAdapter();
		Text text = GetComponent<Text>();
		text.text = yogaFrameUnityAdapter.GetInstance();
		JSession jSessionWebResponse = null;
		jSessionWebResponse = Session.MemberSignIn("kutlass", "PoweredBy#FGC8675309");
		if (null != jSessionWebResponse)
		{
			text.text = jSessionWebResponse.Dispatch.Message;
		}
	}

	// Update is called once per frame
	void Update ()
	{
	
	}
}
