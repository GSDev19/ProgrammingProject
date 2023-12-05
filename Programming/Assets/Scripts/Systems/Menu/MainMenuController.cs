using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    private void Start()
    {
        AudioController.Instance.PlayMusic(AudioController.Instance.menuMusic);
    }
    public void OnStartGame()
    {
        ChangeSceneController.Instance.LoadLevel(1);
    }
    public void OnExitButton()
    {
        ChangeSceneController.Instance.OnExitButton();
    }
}
