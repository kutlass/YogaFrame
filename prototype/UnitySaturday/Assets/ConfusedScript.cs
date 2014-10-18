using UnityEngine;
using System.Collections;

public class ConfusedScript : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {

		WWW www = new WWW ("https://www.yogaframe.net/hello.php");
		yield return www;
		Debug.Log ("ConfusedScript.Start(): Spitting something from yogaframe.net: " + www.text);
	}

	// Update is called once per frame
	void Update () {
	
	}

}
