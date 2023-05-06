using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;

    public void GameOver()
    {
        UnityEngine.Debug.Log("Game Over");
    }

    public void IncreaseScore()
    {
        score++;
    }
}
