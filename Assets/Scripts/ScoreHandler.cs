using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject.SpaceFighter;

public class ScoreHandler
{
    public int playerScore { get; private set; }

    public ScoreHandler()
    {
        if (PlayerPrefs.HasKey("Best score"))
        {
            playerScore = PlayerPrefs.GetInt("Base score");
        }
        else
        {
            playerScore = 0;
        } 
    }
}
