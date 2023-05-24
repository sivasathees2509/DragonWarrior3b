using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadsUpDisplay : MonoBehaviour
{
    private int Fontsize;
    public GUIStyle FontStyle = new GUIStyle();

    void Start()
    {
        FontStyle.font = Resources.Load<Font>("Fonts/trebucbd");
    }

    void OnGUI()
    {
        ScaleFontSize();

        GUI.Label(new Rect(Screen.width / 85f, Screen.height / 58, Screen.width, Screen.height),
            string.Format("SCORE: {0}", WorldManager.Score.ToString()), FontStyle);

        GUI.Label(new Rect(Screen.width / 85f, Screen.height / 20, Screen.width, Screen.height),
            string.Format("LEVEL: {0}", (WorldManager.Level - 3).ToString()), FontStyle);
    }

    private void ScaleFontSize()
    {
        Fontsize = Screen.width / 64;
        FontStyle.fontSize = Fontsize;
    }
}
