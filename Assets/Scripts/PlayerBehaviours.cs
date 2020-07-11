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
    public float moveSpeed, turnSpeed;
    public MovementModes currentMovementMode;
    
    public struct bulletTypes
    {
        public string name;
        public GameObject prefab;
    }

    public bulletTypes[] bullets = new bulletTypes[2];

    // Start is called before the first frame update
    void Start()
    {
        leftControl = KeyCode.LeftControl;
        rightControl = KeyCode.RightControl;

        moveSpeed = 5f;
        turnSpeed = 100f;

        currentMovementMode = MovementModes.STRAFING;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(leftControl) == true && Input.GetKey(rightControl) == false)
        {
            MoveLeft();
        }
        else if(Input.GetKey(rightControl) == true && Input.GetKey(leftControl) == false)
        {
            MoveRight();
        }
        else if(Input.GetKey(rightControl) == true && Input.GetKey(leftControl) == true)
        {
            Shoot();
        }

        // TEMPORARY FIX
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SwitchMovementMode();
        }

    }

    void MoveLeft()
    {
        if(currentMovementMode == MovementModes.STRAFING)
        {
            Vector3 movementVector = Vector3.left * moveSpeed * Time.deltaTime;
            //transform.position += movementVector;
            transform.Translate(movementVector);
        }
        else if(currentMovementMode == MovementModes.ROTATING)
        {
            Vector3 rotationVector = Vector3.forward * turnSpeed * Time.deltaTime;
            transform.eulerAngles += rotationVector;
        }
    }

    void MoveRight()
    {
        if (currentMovementMode == MovementModes.STRAFING)
        {
            Vector3 movementVector = Vector3.right * moveSpeed * Time.deltaTime;
            //transform.position += movementVector;
            transform.Translate(movementVector);
        }
        else if (currentMovementMode == MovementModes.ROTATING)
        {
            Vector3 rotationVector = Vector3.back * turnSpeed * Time.deltaTime;
            transform.eulerAngles += rotationVector;
        }
    }

    void Shoot()
    {
        Debug.Log("Bang");
    }

    void SwitchMovementMode()
    {
        if(currentMovementMode == MovementModes.ROTATING)
        {
            currentMovementMode = MovementModes.STRAFING;
        }
        else if(currentMovementMode == MovementModes.STRAFING)
        {
            currentMovementMode = MovementModes.ROTATING;
        }
    }



}
    public enum MovementModes
    {
        STRAFING,
        ROTATING
    }