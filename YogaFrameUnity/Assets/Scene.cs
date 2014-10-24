using UnityEngine;
using UnityEngine.UI;
using System.Collections;
    
public class Scene : MonoBehaviour
{
    // Use this for initialization
    IEnumerator Start ()
    {
        Panel panelLogin = GetComponent<Panel>();
        panelLogin.enabled = false;
        
    }
    // Update is called once per frame
    void Update ()
    {
        
    }
}
