using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject helpMenu;
    private void Start()
    {
        AudioController.Instance.PlayMusic(AudioController.Instance.menuMusic);

        mainMenu.SetActive(true);
        helpMenu.SetActive(false);
    }
    public void OnStartGame()
    {
        ChangeSceneController.Instance.LoadLevel(1);
    }
    public void OnExitButton()
    {
        ChangeSceneController.Instance.OnExitButton();
    }
    public void OnHelpButton()
    {
        mainMenu.SetActive(false);
        helpMenu.SetActive(true);
    }
    public void OnBackButton()
    {
        mainMenu.SetActive(true);
        helpMenu.SetActive(false);
    }
}
