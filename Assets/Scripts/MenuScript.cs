using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    Dropdown dropdown;
    InputField inputfield;

    public void Start()
    {
        dropdown = GetComponent<Dropdown>();
        inputfield = GetComponent<InputField>();
    }
    // Start is called before the first frame update
    public void RunScene(int number)
    {
        SceneManager.LoadScene(number);
        ApplicationModel.numOfDay = dropdown.value;
        ApplicationModel.hhmmss = inputfield.text;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
