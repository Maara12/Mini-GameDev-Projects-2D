using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTest : MonoBehaviour
{

    //Must Use state machine for the specific  movement behaviour

    public float moveSpeed = 5f;
    public Vector2 additivePosition = Vector3.right;

    Rigidbody2D rb2d;

    bool canMoveRight = false;

    float posBeforeMovementX;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        canMoveRight = true;
        posBeforeMovementX = rb2d.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb2d.position.x >= posBeforeMovementX + 3f)
        {
            canMoveRight = false;
        }
    }

    private void FixedUpdate()
    {
        if (canMoveRight)
        {  
            MovementByMovePositionMethod();
        }
        
    }

    void MovementByMovePositionMethod()
    {
        rb2d.MovePosition(rb2d.position + additivePosition  * Time.fixedDeltaTime);
    }
}
