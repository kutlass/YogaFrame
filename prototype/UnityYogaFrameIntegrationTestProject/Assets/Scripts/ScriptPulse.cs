using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.Session;
using YogaFrameWebAdapter.PulsesJsonTypes;

public class ScriptPulse : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
		// No-op call. Merely testing export for now. TODO: Remove.
		WebAdapter.WebGetPulses();
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}
}
