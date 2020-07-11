using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviours : MonoBehaviour
{
    public BulletType thisBulletType;
    public float moveSpeed;
    Vector3 movementVector;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        switch(thisBulletType)
        {
            case BulletType.FORWARD:
                movementVector = Vector3.up;
                break;
            case BulletType.LEFT:
                movementVector = Vector3.left;
                break;
            case BulletType.RIGHT:
                movementVector = Vector3.right;
                break;
            case BulletType.DUD:
                movementVector = Vector3.zero;
                break;
            default:
                break;
        }

        transform.position += movementVector * moveSpeed * Time.deltaTime;
    }


}

public enum BulletType
{
    FORWARD,
    LEFT,
    RIGHT,
    DUD
}
