using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    Dropdown dayDropdown;
    Dropdown timeDropdown;

    public void Start()
    {  
        timeDropdown = GameObject.Find("TimeSelector").GetComponent<Dropdown>();
        dayDropdown = GameObject.Find("DaySelector").GetComponent<Dropdown>();
    }

    public void RunScene(int number)
    {
        ApplicationModel.numOfDay = dayDropdown.value;
        ApplicationModel.hhmmss = timeValueToHHMMSS(timeDropdown.value);
        ApplicationModel.sceneNumber = timeDropdown.value;
        SceneManager.LoadScene(number);
    }

    /*
      Zamienia wartość z timeDropdown na string z godziną, przekazywany potem do ApplicationModel
         */
    public string timeValueToHHMMSS(int val)
    {
        if (val == 0)
            return "08:00:00";
        else if (val == 1)
            return "10:30:00";
        else if (val == 2)
            return "15:00:00";
        else if (val == 3)
            return "17:00:00";
        else
            return "20:00:00";
    }

    public void Quit()
    {
        Application.Quit();
    }
}
