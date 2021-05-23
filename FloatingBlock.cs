using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBlock : MonoBehaviour
{
    float blockSpeed = 10;   //How fast the block moves
    float rightLimit = 8f;   //How far the block can move the right limit
    float leftLimit = -23.0f; //How far the block can move the left limit
    int blockDirection = 1; //Are we going left(-1) or right(1) - block direction 
    Vector3 blockMovement; //The blocks movement stored in a vector

    void Update()
    {
       if(transform.position.x < leftLimit)  //If we have reached left limit
        {
            blockDirection = 1; //Go right
        } else if (transform.position.x > rightLimit)  //If we have reached right limit
        {
            blockDirection = -1; //Go left
        }
        blockMovement = Vector3.Right * blockDirection * blockSpeed * Time.deltaTime; //Formula for moving a transform in a direction
        transform.Translate(blockMovement); //Move to desired direction
    }
}
