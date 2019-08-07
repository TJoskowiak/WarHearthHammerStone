using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject ExitDialogBoxWindow;
<<<<<<< HEAD
    public GameObject SettingsDialogBoxWindow;

=======
    
>>>>>>> f4c24fb00633300c52fc91e16ca50cd79b7ae513
    public void startGame()
    {

    }

    public void exitDialogBoxSetActive()
    {
        ExitDialogBoxWindow.SetActive(true);
<<<<<<< HEAD

    }
=======
    }

>>>>>>> f4c24fb00633300c52fc91e16ca50cd79b7ae513
    public void exitDialogBoxPressYes()
    {
        Debug.Log("Quit Game by user");
        Application.Quit();
    }

    public void exitDialogBoxPressNo()
    {
        ExitDialogBoxWindow.SetActive(false);
    }

<<<<<<< HEAD
    public void settingsDialogBoxSetActive()
    {
        SettingsDialogBoxWindow.SetActive(true);
    }

    public void colseSettingDialogBox()
    {
        SettingsDialogBoxWindow.SetActive(false);
    }
=======
>>>>>>> f4c24fb00633300c52fc91e16ca50cd79b7ae513
}
