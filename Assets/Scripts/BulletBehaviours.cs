using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviours : MonoBehaviour
{
    public BulletType thisBulletType;
    public float moveSpeed;
    [SerializeField]Vector3 movementVector;

    BoxCollider2D coll;
    public float collDisableTimer = 0.2f;

    public float bulletDuration = 3f;

    // Start is called before the first frame update
    void Start()
    {
        if(thisBulletType != BulletType.DUD)
        {
            moveSpeed = 15f;
        }

        coll = GetComponent<BoxCollider2D>();
        InvokeRepeating("CollDisableTimer", 0.1f, 0.1f);
        coll.gameObject.SetActive(false);

        InvokeRepeating("BulletTimeout", 1f, 1f);
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

        if(bulletDuration <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void CollDisableTimer()
    {
        collDisableTimer -= 0.1f;
        if(collDisableTimer <= 0)
        {
            CancelInvoke();
            coll.gameObject.SetActive(true);
        }
    }

    void BulletTimeout()
    {
        bulletDuration -= 1f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}

public enum BulletType
{
    FORWARD,
    LEFT,
    RIGHT,
    DUD
}
