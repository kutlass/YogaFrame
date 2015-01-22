using UnityEngine;
using System.Collections;

public class MyUnityScript : MonoBehaviour {
	public YogaFrameUnityAdapter yogaFrameUnityAdapter;

	// Use this for initialization
	void Start () {
		yogaFrameUnityAdapter = new YogaFrameUnityAdapter ();
		print (yogaFrameUnityAdapter.GetInstance ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
