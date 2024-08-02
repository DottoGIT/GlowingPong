using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Controls
{
    Arrows,
    WSAD
}

public class Player : MonoBehaviour
{
    public Controls controls;
    public float movementSpeed;
    public float maxYPos;

    void FixedUpdate()
    {
        if(controls == Controls.Arrows)
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                gameObject.transform.position += new Vector3(0, movementSpeed*Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.transform.position -= new Vector3(0, movementSpeed * Time.deltaTime, 0);
            }
        }
        else if(controls == Controls.WSAD)
        {
            if (Input.GetKey(KeyCode.W))
            {
                gameObject.transform.position += new Vector3(0, movementSpeed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.position -= new Vector3(0, movementSpeed * Time.deltaTime, 0);
            }
        }

        if (gameObject.transform.position.y > maxYPos)
            gameObject.transform.position = new Vector3(gameObject.transform.position.x ,maxYPos, 0);

        if (gameObject.transform.position.y < -maxYPos)
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -maxYPos, 0);
    }
}
