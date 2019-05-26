using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void RunScene(int number)
    {
        SceneManager.LoadScene(number);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
