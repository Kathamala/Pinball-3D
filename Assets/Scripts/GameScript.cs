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
    public GameObject door;
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ball != null){
            score = ball.GetComponent<Ball>().points;
            if(ball.GetComponent<Ball>().amountOfBalls == 0 && !gameOver){
                Destroy(ball);
                Destroy(scoreText);
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
    }

    public void GameOver(){
        GameOverScreen.Setup(score);
    }
}
