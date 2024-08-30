using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject ballPrefab;
    
    private void Start()
    {
        SpawnBall();
    }

    private void SpawnBall()
    {
        GameObject ball = Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        ball.GetComponent<Ball>().Initiate(this.transform);
    }
}
