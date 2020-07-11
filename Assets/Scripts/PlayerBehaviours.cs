using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*  Player actions to include:
 *  Strafing with L-ctrl / R-ctrl
 *  Firing with CD
 *  Taking Damage
 * 
 * 
 * 
 */

public class PlayerBehaviours : MonoBehaviour
{
    public KeyCode leftControl;
    public KeyCode rightControl;
    public float moveSpeed;
    //public MovementModes currentMovementMode;




    // Start is called before the first frame update
    void Start()
    {
        leftControl = KeyCode.LeftControl;
        rightControl = KeyCode.RightControl;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(leftControl) == true)
        {
            MoveLeft();
        }
        else if(Input.GetKey(rightControl) == true)
        {
            MoveRight();
        }
        


    }

    void MoveLeft()
    {
        Vector3 movementVector = Vector3.left * moveSpeed * Time.deltaTime;
        transform.position += movementVector;
    }

    void MoveRight()
    {

    }

    void Shoot()
    {

    }



}
    public enum MovementModes
    {
        STRAFING,
        ROTATING
    }