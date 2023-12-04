using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int points = 0;
    private int pointsPerBlock = 100;
    private int pointsPerBall = 50;
    private int numberOfBalls = 0;
    private int numberOfBlocks;
    private int blocksFinished = 0;

    //Singletone
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        numberOfBlocks = GameObject.FindGameObjectsWithTag("Blocks").Length;
    }

    private void printPoints()
    {
        Debug.Log("Points: " + points);
    }

    public void blockEnter()
    {
        blocksFinished++;
        points += pointsPerBlock;
        printPoints();
        if (blocksFinished == numberOfBlocks)
        {
            Debug.Log("Win!");
            Time.timeScale = 0;
        }
    }

    public void ballThrow()
    {
        numberOfBalls++;
        if(numberOfBalls > 1)
        {
            points -= pointsPerBall;
        }
        printPoints();
    }
}
