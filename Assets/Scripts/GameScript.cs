using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public GameObject ball;
    public int score = 0;
    public GameOverScreen GameOverScreen;
    public Text scoreText;
    public Text ballsText;
    public GameObject door;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RESTART
        if(GameOverScreen.restart){
            GameOverScreen.restart = false;
            ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            ball.GetComponent<Ball>().amountOfBalls = 3;
            ball.GetComponent<Ball>().points = 0;
            scoreText.gameObject.SetActive(true);
            ballsText.gameObject.SetActive(true);
            gameOver = false;
        }

        if(ball != null){
            score = ball.GetComponent<Ball>().points;

            //GAME OVER
            if(ball.GetComponent<Ball>().amountOfBalls == 0 && !gameOver){
                ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                scoreText.gameObject.SetActive(false);
                ballsText.gameObject.SetActive(false);
                gameOver = true;
                GameOver();
            }

            if(ball.GetComponent<Ball>().isOnGame){
                door.GetComponent<BoxCollider>().enabled = true;
                door.GetComponent<MeshRenderer>().enabled = true;
            } else{
                door.GetComponent<BoxCollider>().enabled = false;
                door.GetComponent<MeshRenderer>().enabled = false;
            }
        }
        
        if(scoreText != null){
            scoreText.text = "Points: " + score;
        }

        ballsText.text = "Amount of balls: " + ball.GetComponent<Ball>().amountOfBalls;
    }

    public void GameOver(){
        GameOverScreen.Setup(score);
    }
}
