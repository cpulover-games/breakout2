using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; // serialize for debugging
    SceneLoader sceneLoader; // cached ref
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed =1f;
    [SerializeField] int score=0;
    [SerializeField] int pointPerBlock=5;
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        scoreText.text = 0.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        Time.timeScale = this.gameSpeed;
        if (this.breakableBlocks == 0)
        {
            sceneLoader.loadNextScene();
        }
    }

    public void CountBreakableBlocks()
    {
        this.breakableBlocks++;
    }

    public void UpdateBlockCollision()
    {
        this.breakableBlocks--;
        score += pointPerBlock;
        scoreText.text = score.ToString();
    }
}
