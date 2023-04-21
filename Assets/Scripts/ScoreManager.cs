using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public static int gameScore;

    private void Awake()
    {
        gameScore = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = gameScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameScore.ToString();
    }

    public void UpdateAfterLevel()
    {
        // Add points for finishing level with full health
        // Assuming health max is 100, if not, then check w PlayerHealth
        if (GameManager.health == 100)
            gameScore += 30;
        // Multiplier of points for finishing level depending on level
        gameScore = (int)(gameScore * (1f + (float) GameManager.roundsSurvived/10f));
        Update();
    }

}
