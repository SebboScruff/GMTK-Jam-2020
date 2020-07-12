using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/*  Player actions to include:
 *  Strafing/rotating with L-ctrl / R-ctrl
 *  Firing with CD
 *  Taking Damage
 */

public class PlayerBehaviours : MonoBehaviour
{
    public KeyCode leftControl;
    public KeyCode rightControl;
    public float moveSpeed, turnSpeed;
    public MovementModes currentMovementMode;


    public GameObject[] bullets = new GameObject[2];
    [Range(0, 1)]
    public float maxShootingCD = 0.3f;
    private float shootingCD;
    public Transform firingPoint;

    public float maxHealth = 100;
    float currentHealth;

    public int score;

    bool gameOver = false;
    public Image gameOverBG;
    public Image healthBar;
    public TextMeshProUGUI scoreText;
    

    // Start is called before the first frame update
    void Start()
    {
        leftControl = KeyCode.LeftControl;
        rightControl = KeyCode.RightControl;

        moveSpeed = 5f;
        turnSpeed = 100f;

        currentMovementMode = MovementModes.STRAFING;

        shootingCD = 0f;

        currentHealth = maxHealth;

        score = 0;
        gameOverBG.gameObject.SetActive(false);
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
        else if(Input.GetKey(rightControl) == true && Input.GetKey(leftControl) == true && shootingCD <= 0)
        {
            Shoot();
        }

        healthBar.fillAmount = currentHealth / maxHealth;
        scoreText.text = "Score: " + score.ToString();

        if(currentHealth <= 0)
        {
            gameOver = true;
        }

        if (gameOver == true)
        {
            gameOverBG.gameObject.SetActive(true);
            Time.timeScale = 0f;
            if(Input.GetKey(KeyCode.R))
            {
                Restart();
            }
            if(Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
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
        //Debug.Log("Bang");
        int chosenBulletIndex = Random.Range(0, bullets.Length);
        //Debug.Log(chosenBulletIndex);

        Instantiate(bullets[chosenBulletIndex], firingPoint.position, firingPoint.rotation);
        shootingCD = maxShootingCD;
        InvokeRepeating("ShootingCooldown", 0f, 0.1f);
    }

    void ShootingCooldown()
    {
        if(shootingCD>0)
        {
            shootingCD -= 0.1f;
        }
        else { CancelInvoke(); }
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
    void TakeDamage(float damageAmount)
    {
        Debug.Log("Current Health: " + currentHealth);
        currentHealth -= damageAmount;
        SwitchMovementMode();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            TakeDamage(5);
        }
    }

    void Restart()
    {
        score = 0;
        currentHealth = maxHealth;
        gameOver = false;
        gameOverBG.gameObject.SetActive(false);

        GameObject[] enemiesOnScreen = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemiesOnScreen)
        {
            Destroy(enemy.gameObject);
        }

        Time.timeScale = 1f;       
    }

}
    public enum MovementModes
    {
        STRAFING,
        ROTATING
    }