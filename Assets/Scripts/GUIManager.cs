using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    TimeManager time;
    GUIStyle guiStyle = new GUIStyle();
    ApplicationModel app;

    void OnGUI()
    {
        SetGuiStyle();
        GUI.Label(new Rect(10, 10, 100, 20), time.GetTimeString(), guiStyle);
        if(GUI.Button(new Rect(20, 45, 100, 20), "Slow Down"))
        {
            time.DoSlowDown();
        }

        if(GUI.Button(new Rect(130, 45, 100, 20), "Speed Up"))
        {
            time.DoSpeedUp();
        }

        if (GUI.Button(new Rect(20, 75, 210, 20), "Menu"))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            Time.timeScale = 1;
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        time = this.GetComponent<TimeManager>();
    }

    void SetGuiStyle()
    {
        guiStyle.fontSize = 30;
        guiStyle.normal.textColor = Color.white;
    }

}
