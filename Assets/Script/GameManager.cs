using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelCompleted;
    public static bool isGameStarted;
    public static bool mute;

    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;
    public GameObject gamePlayPanel;
    public GameObject startMenuPanel;

    public static int currentlevelIndex;
    public Slider gameProgressSlider;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;

    public static int numberOfPassedRings;

    private void Awake()
    {
        currentlevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1); //sets the level when the game starts
    }

    void Start()
    {
        Time.timeScale = 1;
        numberOfPassedRings = 0;
        isGameStarted = gameOver = levelCompleted = false;
    }

    void Update()
    {
        //Update the UI
        currentLevelText.text = currentlevelIndex.ToString();
        nextLevelText.text = (currentlevelIndex + 1).ToString();

        int progress = numberOfPassedRings * 100 / FindObjectOfType<HelixController>().numberOfRings;
        gameProgressSlider.value = progress;


        if (Input.GetMouseButtonDown(0) && !isGameStarted)//Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isGameStarted
        {
            if (EventSystem.current.IsPointerOverGameObject())//Input.GetTouch(0).fingerId
            {
                return;
            }
            else 
            {
                isGameStarted = true;
                gamePlayPanel.SetActive(true);
                startMenuPanel.SetActive(false);
            }
            
        }

        //Game Over
        if (gameOver)
        {
            Time.timeScale = 0; //stops the game
            gameOverPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("Level 1");
            }
        }

        if (levelCompleted)
        {
            Time.timeScale = 0; //stops the game
            levelCompletedPanel.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                PlayerPrefs.SetInt("CurrentLevelIndex", currentlevelIndex + 1);//updates the level number after the level is completed
                SceneManager.LoadScene("Level 1");
            }
        }
    }
}
