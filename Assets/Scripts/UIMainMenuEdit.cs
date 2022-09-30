using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIMainMenuEdit : MonoBehaviour
{
    public SaveObject savedObject;

    public Text playerMaxScore;

    public Text playerName;




    void Start()
    {
        savedObject = SaveManager.Load();

        playerMaxScore.text = "Best Score: " + savedObject.playerName + " = " + savedObject.score;
        
    }


    public void OnClickedStartGame()
    {
        savedObject.nextChalanger = playerName.text;

        SaveManager.Save(savedObject);

        SceneManager.LoadScene("main");

        
    }


    public void QuitGame()
    {
        Application.Quit();
    }

    public void UpdateScoreAmount()
    {
        Debug.Log("Ok 1");
        string scoreAmountAtual = playerName.text;
        //scoreAmountAtual = scoreAmountAtual.Replace('Score : ','');
        //string[] dividedScore = scoreAmountAtual.Split(' : ');
        Debug.Log(scoreAmountAtual);


        string[] dividedScore = scoreAmountAtual.Split("Score : ");
        Debug.Log(dividedScore[1]);
        //int tempScore = scoreAmountAtual.parseInt();
        //int tempScore = dividedScore[1];
        int tempScore;
        int.TryParse(dividedScore[1], out tempScore);
        Debug.Log(tempScore);


        if(savedObject.score <= tempScore)
        {
            savedObject.playerName = savedObject.nextChalanger;
            savedObject.score = tempScore;
            Debug.Log(savedObject.playerName);

        }

        SaveManager.Save(savedObject);

    }

    

    

    
}
