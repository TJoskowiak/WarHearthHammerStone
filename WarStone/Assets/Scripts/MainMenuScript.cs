using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    public void startGame() {

    }

    public void changeResolution(Dropdown change) {
        switch (change.value) {
            case 0:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 1:
                Screen.SetResolution(1600, 900, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
        }
    }

    public void toggleFullscreen(Toggle change) {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, change.isOn);
    }

    public void changeGraphicsSettings(Dropdown change) {
        QualitySettings.SetQualityLevel(change.value);
    }
    public void newGamePressed() {
        SceneManager.LoadScene("NetworkManagerScene");
    }
    public void exitDialogBoxSetActive() {
        ExitDialogBoxWindow.SetActive(true);

    }
    public void exitDialogBoxPressYes() {
        Debug.Log("Quit Game by user");
        Application.Quit();
    }

    public void exitDialogBoxPressNo() {
        ExitDialogBoxWindow.SetActive(false);
    }

    public void settingsDialogBoxSetActive() {
        SettingsDialogBoxWindow.SetActive(true);
    }

    public void colseSettingDialogBox() {
        SettingsDialogBoxWindow.SetActive(false);
    }
}
