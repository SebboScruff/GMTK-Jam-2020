using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Pretty simple arcade-style
 * enemy behaviours, downwards
 * movement and then despawn
 */

public class EnemyBehaviour : MonoBehaviour
{
    public float moveSpeed;
    public float shootingFrequency, shootingCooldown;

    public Transform firingPoint;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        shootingFrequency = 2f;
    }

    // Update is called once per frame
    void Update()
    {


    }

    void Shoot()
    {
        Instantiate(bullet, firingPoint.position, firingPoint.rotation);
        shootingCooldown = shootingFrequency;
        InvokeRepeating("ShootingCooldown", 1f, 1f);
    }

    void ShootingCooldown()
    {
        if(shootingCooldown > 0)
        {
            shootingCooldown -= 1f;
        }
        else { CancelInvoke(); }
    }
}
