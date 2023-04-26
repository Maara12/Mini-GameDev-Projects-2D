using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeBehaviour : MonoBehaviour
{
    //behaviours = movement,size modification
    public float snakeSpeed = 0.5f;
    public GameObject snakeHead;
    public GameObject snakeBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        snakeHead.transform.Translate(Vector2.right * snakeSpeed * Time.deltaTime, Space.Self);
        //snakeHead.transform.position = transform.forward;

        Debug.Log(transform.localEulerAngles.z);

        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Hinput = 1");
            snakeHead.transform.localRotation = Quaternion.Euler(0, 0, snakeHead.transform.localEulerAngles.z - 90f);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Hinput = -1");
            snakeHead.transform.localRotation = Quaternion.Euler(0, 0, snakeHead.transform.localEulerAngles.z + 90f);
        }

        /*
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Vinput = 1");
            snakeHead.transform.localRotation = Quaternion.Euler(0, 0, transform.localEulerAngles.z - 90f);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Hinput = -1");
            snakeHead.transform.localRotation = Quaternion.Euler(0, 0, transform.localEulerAngles.z + 90f);
        }*/

    }

    private void LateUpdate()
    {
        //snakeBody.transform.position = snakeHead.transform.position; 
    }
}
