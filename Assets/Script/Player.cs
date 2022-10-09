using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody playerRb;
    public float bounceForce = 6;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScore;

    private int ScoreNum;

    //public ParticleSystem fireworkParticle;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        ScoreNum = 0;
        scoreText.text = "Score: " + ScoreNum;
        highScore.text = "Best Score\n" + PlayerPrefs.GetInt("Highscore", 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("bounce");
        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce, playerRb.velocity.z);// bounces the ball on collision with the ring
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if(materialName == "Safe (Instance)")
        {
            //when the ball hits the safe material

        }
        else if(materialName == "UnSafe (Instance)")
        {
            //when the ball hits the unsafe material
            GameManager.gameOver = true;
            if (ScoreNum > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", ScoreNum);
            }
            audioManager.Play("gameover");
        }
        else if(materialName == "LastRing (Instance)")
        {
            //when ball hits the laststring
            GameManager.levelCompleted = true;
            audioManager.Play("levelcompleted");
        }
        else if (collision.gameObject.CompareTag("Reward"))
        {
            //fireworkParticle.Play();
            ScoreNum += 1;
            Destroy(collision.gameObject);
            Debug.Log("mine");
            scoreText.text = "Score: " + ScoreNum;
        }
    }
}
