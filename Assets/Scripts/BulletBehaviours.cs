using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviours : MonoBehaviour
{
    public BulletType thisBulletType;
    public float moveSpeed;
    [SerializeField]Vector3 movementVector;

    // Start is called before the first frame update
    void Start()
    {
        if(thisBulletType != BulletType.DUD)
        {
            moveSpeed = 15f;
        }
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
                movementVector = new Vector3(0,0,0);
                break;
            default:
                break;
        }

        transform.Translate(movementVector * moveSpeed * Time.deltaTime);
    }


}

public enum BulletType
{
    FORWARD,
    LEFT,
    RIGHT,
    DUD
}
