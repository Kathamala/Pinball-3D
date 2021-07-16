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
    public GameObject catalog;
    private bool gameOver = false;
    const int RANKING_SIZE = 5;
    [HideInInspector] public int[] ranking = new int[RANKING_SIZE];
    public GameObject ballImage;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<RANKING_SIZE; i++){
            ranking[i] = 0;
        }
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
            catalog.gameObject.SetActive(true);
            ballImage.gameObject.SetActive(true);
            gameOver = false;
        }

        if(ball != null){
            score = ball.GetComponent<Ball>().points;

            //GAME OVER
            if(ball.GetComponent<Ball>().amountOfBalls == 0 && !gameOver){
                ball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
                scoreText.gameObject.SetActive(false);
                ballsText.gameObject.SetActive(false);
                catalog.gameObject.SetActive(false);
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
            scoreText.text = "Pontos: " + score;
        }

        ballsText.text = "Bolas:         x" + ball.GetComponent<Ball>().amountOfBalls;
    }

    public void GameOver(){
        if(ranking[RANKING_SIZE-1] < score){
            ranking[RANKING_SIZE-1] = score;
            orderRanking();
        }
        ballImage.gameObject.SetActive(false);
        GameOverScreen.Setup(score);
    }

    private void orderRanking(){
        int temp;

        for(int i=0; i < ranking.Length; i++){
            for(int j=0; j < ranking.Length; j++){
                if(ranking[i] > ranking[j]){
                    temp = ranking[i];
                    ranking[i] = ranking[j];
                    ranking[j] = temp;
                }
            }
        }
    }
}
