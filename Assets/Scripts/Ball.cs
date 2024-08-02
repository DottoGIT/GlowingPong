using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isSimulated = false;
    public float initialSpeed;
    public float speedIncrement;
    public GameManager gameManager;
    public AudioSource hitSound;
    public AudioSource scoreSound;
    Rigidbody2D myRig;
    float extraSpeed = 0;

    void Start()
    {
        myRig = GetComponent<Rigidbody2D>();
        if (isSimulated)
            StartGame();
    }

    public void StartGame()
    {
        int rngHorizontal = Random.Range(0, 2);
        rngHorizontal = (rngHorizontal == 0) ? -1 : 1;
        int rngVertical = Random.Range(0, 2);
        rngVertical = (rngVertical == 0) ? -1 : 1;
        if(isSimulated == false)
            transform.position = Vector3.zero;
        myRig.velocity = new Vector2(rngHorizontal, rngVertical).normalized * initialSpeed;
    }

    public void RestartBall()
    {
        transform.position = Vector3.zero;
        myRig.velocity = Vector3.zero;
        extraSpeed = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Player"))
        {
            Vector2 bounceVector = transform.position - collision.gameObject.transform.position;
            extraSpeed += speedIncrement;
            myRig.velocity = bounceVector.normalized * (initialSpeed + extraSpeed);
        }

        if (collision.gameObject.CompareTag("leftBorder"))
        {
            gameManager.ScorePlayer(2);
            if (isSimulated == false)
                scoreSound.Play();
        }
        else if (collision.gameObject.CompareTag("rightBorder"))
        {
            gameManager.ScorePlayer(1);
            if (isSimulated == false)
                scoreSound.Play();
        }
        else
        {
            if (isSimulated == false)
                hitSound.Play();
        }
    }
}
