using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerHUD playerHUD;
    [SerializeField] private BallSpawner ballSpawner;
    [SerializeField] private Line[] lines;


    private void Start()
    {
        ballSpawner.SpawnBall();
    }

    private void OnEnable()
    {
        foreach (var line in lines)
        {
            line.OnLineCollision += UpdateScore;
        }
    }
    private void OnDisable()
    {
        foreach (var line in lines)
        {
            line.OnLineCollision -= UpdateScore;
        }
    }
    
    private void UpdateScore(string player)
    {
        playerHUD.UpdateScoreText(player);
        ballSpawner.SpawnBall();
    }
    
}
