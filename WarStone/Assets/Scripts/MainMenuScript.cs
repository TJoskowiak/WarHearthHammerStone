using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MainMenuScript : NetworkBehaviour
{
    public GameObject ExitDialogBoxWindow;
    public GameObject SettingsDialogBoxWindow;

    public void Start() {
        var netHandler = GameObject.Find("NetworkHandler");
        if (netHandler) {
            Destroy(netHandler);
        }
    }
    public void startGame()
    {

    }

    public void newGamePressed() {
        SceneManager.LoadScene("NetworkManagerScene");
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

    public void settingsDialogBoxSetActive()
    {
        SettingsDialogBoxWindow.SetActive(true);
    }

    public void colseSettingDialogBox()
    {
        SettingsDialogBoxWindow.SetActive(false);
    }
}
