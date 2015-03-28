using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using YogaFrameWebAdapter;
using YogaFrameWebAdapter.JSessionJsonTypes;
using YogaFrameWebAdapter.Session;
using YogaFrameWebAdapter.PulsesJsonTypes;

public class ScriptPulse : MonoBehaviour
{
	public Pulses m_pulses;
	public GameObject m_panelPulsesList;
	public GameObject[] m_rgPrefabClickableTexts;

	// Use this for initialization
	void Start()
	{
		m_pulses = null;
		m_panelPulsesList = null;
		m_rgPrefabClickableTexts = null;

		bool fResult = false;
		fResult = this._GetPulses();
	}

	private bool _GetPulses()
	{
		//
		// Make the web service FETCH call for Pulses
		//
		bool fResult = false;
		JSession jSessionWebResponse = null;
		jSessionWebResponse = WebAdapter.WebGetPulses();
		const string S_OK = "S_OK";
		if (S_OK == jSessionWebResponse.Dispatch.Message)
		{
			fResult = ScriptPulse._PopulatePulsesList(ref m_pulses, ref m_panelPulsesList, ref m_rgPrefabClickableTexts);
		}
		else
		{
			fResult = false;
		}

		return fResult;
	}

	private static bool _PopulatePulsesList(
		ref Pulses pulses,
		ref GameObject panelPulsesList,
		ref GameObject[] rgPrefabClickableTexts
		)
	{
		bool fResult = true;

		//
		// Instantiate prefabs "ClickableText" based on count of param:(ref Pulse pulses)
		//
		rgPrefabClickableTexts = new GameObject[pulses.TblPulses.Length];
		for (int i = 0; i < rgPrefabClickableTexts.Length; i++)
		{
			rgPrefabClickableTexts[i] = Instantiate(Resources.Load("Prefabs/ClickableText")) as GameObject;
			if (null != rgPrefabClickableTexts[i])
			{
				rgPrefabClickableTexts[i].transform.SetParent(panelPulsesList.transform);
				ClickableText clickableText = null;
				clickableText = rgPrefabClickableTexts[i].GetComponentInChildren<ClickableText>();
				if (null != clickableText)
				{
					clickableText.m_entryPointPosition = i;
					Text textClickableText = rgPrefabClickableTexts[i].GetComponentInChildren<Text>();
					textClickableText.text = pulses.TblPulses[i].ColDescription;
				}
				else
				{
					fResult = false;
					break;
				}
			}
			else
			{
				fResult = false;
				break;
			}
		}

		return fResult;
	}
}
