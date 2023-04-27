using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class snakeBehaviour : MonoBehaviour
{
    //behaviours = movement,size modification, death

    public Text scoreText;
    public Text finalScoreText;
    public GameObject replayButton;
    
    public Transform snakeBodyPart;
    public GameObject fullSnake;
    
    private int score = 0;

    Rigidbody2D rb;
    Vector2 direction = Vector2.right;
    List<Transform> totalSnake = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        rb = gameObject.GetComponent<Rigidbody2D>();
        scoreText.text = score.ToString();
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
        FollowThefrontSnakeBodyParts();

        transform.position = new Vector2((transform.position.x) +
            direction.x, (transform.position.y) + direction.y);
    }

    private void FollowThefrontSnakeBodyParts()
    {
        for (int i = totalSnake.Count - 1; i > 0; i--)
        {
            totalSnake[i].transform.position = totalSnake[i - 1].transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "SnakeBody" || collision.tag == "Wall")
        {
            Debug.Log("Game Over");
            fullSnake.SetActive(false);
            replayButton.SetActive(true);
        }

        if(collision.tag == "Food")
        {
            score++;
            scoreText.text = score.ToString();
            ExtendBody();
        }

    }

    private void Reset()
    {
        for(int i = 1; i<totalSnake.Count; i++)
        {
            Destroy(totalSnake[i].gameObject);
        }
        totalSnake.Clear();

        fullSnake.SetActive(true);
        transform.position = Vector3.zero;

        totalSnake.Add(this.transform);

        score = 0;
        scoreText.text = score.ToString();
        replayButton.SetActive(false);

    }

    public void OnReplayButtonClicked()
    {
        Reset();
    }

}
