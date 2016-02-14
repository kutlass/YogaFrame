using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using YogaFrameWebAdapter.Session;

public class ScriptSceneManager : MonoBehaviour
{
    public void SwitchToScene(string strSceneToSwitchTo)
    {
        Application.LoadLevel(strSceneToSwitchTo);
    }

    public void SetCursorGames(int cursorPostion)
    {
        Session.Instance.Cache.GamesPositionLastSelected = cursorPostion;
    }

    public void SetCursorCharacters(int cursorPosition)
    {
        Session.Instance.Cache.CharactersPositionLastSelected = cursorPosition;
    }

    public void SetCursorMoves(int cursorPosition)
    {
        Session.Instance.Cache.MovesPositionLastSelected = cursorPosition;
    }
}
