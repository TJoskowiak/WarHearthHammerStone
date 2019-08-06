using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public GameObject ExitDialogBoxWindow;
    
    public void startGame()
    {

    }

    public void exitDialogBoxSetActive()
    {
        ExitDialogBoxWindow.SetActive(true);
    }

    public void exitDialogBoxPressYes()
    {
        Debug.Log("Quit Game by user");
        Application.Quit();
    }

    public void exitDialogBoxPressNo()
    {
        ExitDialogBoxWindow.SetActive(false);
    }

}
