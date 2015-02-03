using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScriptSceneManager : MonoBehaviour
{
	public void SwitchToScene(string strSceneToSwitchTo)
	{
		Application.LoadLevel(strSceneToSwitchTo);
	}
}
