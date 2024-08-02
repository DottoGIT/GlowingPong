using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    public Ball ball;
    public float movementSpeed;
    public float maxYPos;

    private void Update()
    {
        if(ball.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            if (ball.transform.position.y > transform.position.y)
            {
                gameObject.transform.position += new Vector3(0, movementSpeed * Time.deltaTime, 0);
            }
            if (ball.transform.position.y < transform.position.y)
            {
                gameObject.transform.position -= new Vector3(0, movementSpeed * Time.deltaTime, 0);
            }
        }

        if (gameObject.transform.position.y > maxYPos)
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, maxYPos, 0);

        if (gameObject.transform.position.y < -maxYPos)
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -maxYPos, 0);
    }
}
