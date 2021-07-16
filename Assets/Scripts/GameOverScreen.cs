using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    public Text rankingText;
    public GameObject ball;
    public GameObject game;
    [HideInInspector] public bool restart = false;
    public Canvas canvas;

    
    public void Setup(int score){
        gameObject.SetActive(true);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        pointsText.text = score.ToString() + " PONTOS";

        rankingText.text = rankingToString(game.GetComponent<GameScript>().ranking);
    }

    public void RestartButton(){
        restart = true;
        gameObject.SetActive(false);
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
    }

    public void QuitButton(){
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    private string rankingToString(int[] array){
        string final = "RANKING\n\n";
        
        for(int i=0; i < array.Length; i++){
            if(array[i] != 0){
                final += (i+1) + "- " + array[i].ToString() + " pontos\n";
            }
        }

        return final;
    }
}
