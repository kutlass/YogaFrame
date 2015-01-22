using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MyUnityScript : MonoBehaviour
{
	public YogaFrameUnityAdapter yogaFrameUnityAdapter;
	
	// Use this for initialization
	void Start ()
	{
		yogaFrameUnityAdapter = new YogaFrameUnityAdapter ();
		Text text = GetComponent<Text>();
		text.text = yogaFrameUnityAdapter.GetInstance();
	}

	// Update is called once per frame
	void Update ()
	{
	
	}
}
