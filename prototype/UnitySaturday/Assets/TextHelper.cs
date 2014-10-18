using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextHelper : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
	
		WWW www = new WWW ("https://www.yogaframe.net/hello.php");
		yield return www;
		Debug.Log ("TextHelper.Start(): Spitting something from yogaframe.net: " + www.text);
		Text text = GetComponent<Text> ();
		text.text = www.text;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
