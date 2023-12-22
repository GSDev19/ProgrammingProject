using System;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public static Action<Music> OnMainMenuStart;

    public GameObject mainMenu;
    public GameObject helpMenu;
    private void Start()
    {
        OnMainMenuStart?.Invoke(Music.MenuMusic);

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
