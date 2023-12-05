using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneController : MonoBehaviour
{
    public static ChangeSceneController Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }
    public void OnExitButton()
    {
        Application.Quit();
    }
    public void OnMainMenuButton()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
