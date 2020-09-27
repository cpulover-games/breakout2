﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; // serialize for debugging
    SceneLoader sceneLoader; // cached ref
    GameStatus gameStatus;
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed =1f;

    

    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }


    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        if (breakableBlocks == 0)
        {
            sceneLoader.loadNextScene();
        }
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void UpdateBlockCollision()
    {
        breakableBlocks--;
        gameStatus.UpdateBlockCollision();
    }
}
