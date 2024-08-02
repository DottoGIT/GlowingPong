using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public GameObject startText;
    public GameObject winWindow;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI plr1Text;
    public TextMeshProUGUI plr2Text;

    int player1Score = 0;
    int player2Score = 0;
    bool isGamePaused = true;
    bool hasGameEnded = false;

    private void Start()
    {
        hasGameEnded = false;
        isGamePaused = true;
        winWindow.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGamePaused == true && hasGameEnded == false)
        {
            isGamePaused = false;
            startText.SetActive(false);
            ball.StartGame();
        }
    }

    public void ScorePlayer(int plrIndex)
    {
        if (plrIndex == 1)
            player1Score++;
        else if (plrIndex == 2)
            player2Score++;
        
        plr1Text.text = player1Score.ToString();
        plr2Text.text = player2Score.ToString();
        
        if (player1Score >= 3)
            EndGame(1);
        else if (player2Score >= 3)
            EndGame(2);

        if(hasGameEnded == false)
            startText.SetActive(true);
            isGamePaused = true;
            ball.RestartBall();
    }

    void EndGame(int winnerIndex)
    {
        hasGameEnded = true;
        winWindow.SetActive(true);
        winText.text = "PLAYER " + winnerIndex.ToString() + " WIN";
    }

}
