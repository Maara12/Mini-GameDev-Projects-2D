using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeBehaviour : MonoBehaviour
{
    //behaviours = movement,size modification

    public float snakeSpeed = 2f;
    public GameObject snakeHead;
    //public GameObject snakeBody;
    Rigidbody2D rb;
    Vector2 direction = Vector2.right;
    List<GameObject> totalSnake;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        totalSnake = new List<GameObject>();
        totalSnake.Add(snakeHead);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Hinput = 1");
            direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Hinput = -1");
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Vinput = 1");
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Vinput = -1");
            direction = Vector2.down;
        }

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        snakeHead.transform.position = new Vector2((snakeHead.transform.position.x + 
            direction.x * snakeSpeed * Time.fixedDeltaTime)
            ,(snakeHead.transform.position.y+ direction.y* snakeSpeed * Time.fixedDeltaTime));
    }
}
