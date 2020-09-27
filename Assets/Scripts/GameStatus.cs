using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] int pointPerBlock = 5;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        /* SINGLETON PATTERN */
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = 0.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBlockCollision()
    {
        score += pointPerBlock;
        scoreText.text = score.ToString();
    }
}
