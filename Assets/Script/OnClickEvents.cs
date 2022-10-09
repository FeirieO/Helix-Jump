using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickEvents : MonoBehaviour
{
    public TextMeshProUGUI soundsText;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.mute)
        {
            soundsText.text = "/";
        }
        else
        {
            soundsText.text = "";
        }
    }
    public void ToggleMute()
    {
        if (GameManager.mute)
        {
            GameManager.mute = false;
            soundsText.text = "";
        }
        else
        {
            GameManager.mute = true;
            soundsText.text = "/";
        }
    }
    public static void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
