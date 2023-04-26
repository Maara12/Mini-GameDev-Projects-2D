using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeBehaviour : MonoBehaviour
{
    //behaviours = movement,size modification, death

    
    public Transform snakeBodyPart;
    public GameObject fullSnake;
    
    Rigidbody2D rb;
    Vector2 direction = Vector2.right;
    List<Transform> totalSnake;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        totalSnake = new List<Transform>();
        totalSnake.Add(this.transform);
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

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            ExtendBody();
        }
    }

    private void ExtendBody()
    {
        Transform newBodyPart =  Instantiate(snakeBodyPart);
        newBodyPart.position = totalSnake[totalSnake.Count - 1].position;
        totalSnake.Add(newBodyPart);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        for (int i = totalSnake.Count - 1; i > 0; i--)
        {
            totalSnake[i].transform.position = totalSnake[i - 1].transform.position;
        }

        transform.position = new Vector2((transform.position.x)+ 
            direction.x ,(transform.position.y)+ direction.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "SnakeBody" || collision.tag == "Wall")
        {
            Debug.Log("Game Over");
            Destroy(fullSnake);
        }

        

    }
    
}
