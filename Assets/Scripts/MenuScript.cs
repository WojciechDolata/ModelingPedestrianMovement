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
    // Start is called before the first frame update
    public void RunScene(int number)
    {
        ApplicationModel.numOfDay = dayDropdown.value;
        ApplicationModel.hhmmss = timeValueToHHMMSS(timeDropdown.value); 
        SceneManager.LoadScene(number);
        
    }

    public string timeValueToHHMMSS(int val)
    {
        if (val == 0)
            return "07:00:00";
        else if (val == 1)
            return "11:00:00";
        else if (val == 2)
            return "15:00:00";
        else if (val == 3)
            return "17:00:00";
        else
            return "21:00:00";
    }

    public void Quit()
    {
        Application.Quit();
    }
}
