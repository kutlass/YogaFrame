using UnityEngine;
using UnityEngine.UI;
using System;
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
			m_pulses = jSessionWebResponse.Pulses;
			fResult = ScriptPulse._PopulatePulsesList(ref m_pulses, ref m_panelPulsesList, ref m_rgPrefabClickableTexts);
			if (true == fResult)
			{
				//
				// Resize content panel height
				//
				fResult = ScriptPulse._ResizePanelHeight(ref m_panelPulsesList, ref m_rgPrefabClickableTexts);
			}
		}
		else
		{
			fResult = false;
		}

		return fResult;
	}

	private static bool _ResizePanelHeight(
		ref GameObject panelPulsesList,
		ref GameObject[] rgPrefabClickableTexts
		)
	{
		bool fResult = false;
		if (null == panelPulsesList || null == rgPrefabClickableTexts)
		{
			fResult = false;

			throw new ArgumentNullException();
		}
		
		//
		// Get the height of only 1 of the ClickableText rects.
		// (We know that height of sibling elements will be identical)
		//
		if (rgPrefabClickableTexts.Length > 0)
		{
			ClickableText clickableText = null;
			clickableText = rgPrefabClickableTexts[0].GetComponentInChildren<ClickableText>();
			if (null != clickableText)
			{
				Text text = null;
				text = clickableText.GetComponentInChildren<Text>();
				if (null != text)
				{
					float height = text.rectTransform.rect.height;

					//
					// Multiply height of element by its array count.
					// This gives us the final height of what our content
					// panel ought to be.
					//
					float totalHeight = height * rgPrefabClickableTexts.Length;

					RectTransform rectTransform = null;
					rectTransform =	panelPulsesList.GetComponent<RectTransform>();
					if (null != rectTransform)
					{
						rectTransform.rect.height = totalHeight;

						fResult = true;
					}
					else
					{
						fResult = false;
					}

				}
				else
				{
					fResult = false;
				}
			}
			else
			{
				fResult = false;
			}
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
		if (null == pulses)
		{
			throw new ArgumentNullException();
		}
		
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
					//clickableText.SetEntryPointPositionPulses(i);
					Text textClickableText = null;
					textClickableText = rgPrefabClickableTexts[i].GetComponentInChildren<Text>();
					if (null != textClickableText)
					{
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
			else
			{
				fResult = false;
				break;
			}
		}

		return fResult;
	}
}
