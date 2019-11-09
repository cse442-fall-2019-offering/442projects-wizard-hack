using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float speed = 1f;
    public int manaCost = 15;
    public float lifeTime = 3f;
    public Rigidbody2D rb;
    public Animator animator;
    public float topLevel;
    public float bottomLevel;
    public bool isPopped = false;
    public int direction; //direction is the clockwise direction that the wizard blows the bubble: up(0), right(1), down(2), left(3) 
    public bool movingTowardsTop; //movingTowardsTop means bubble is heading towards the topLevel from the bubbles perspective
                                //if bubble is moving left or right then top is up, bottom is down
                                //if bubble is moving up or down then top if left, bottom is right

    public bool canChangeTopBottomMovement = true;
    public bool canChangeTopBottomMovementTimerOn = false;
    public int canChangeTopBottomMovementTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetDirectionLevelsAndVelocity();
        movingTowardsTop = true;
        Invoke("popBubble", lifeTime);  
    }

    //use the player's firePoint transform rotation angel to figure out if we want to blow the bubble up, right, left, or down
    //then use the bubbles transform to set its top/bottom levels and velocity
    void SetDirectionLevelsAndVelocity()
    {
        Transform firePointTransform = GameObject.Find("Player Prefab").transform.GetChild(0);
        float angle = firePointTransform.rotation.eulerAngles.z;
        switch (angle)
        {
            case 90:    //up
                direction = 0;
                topLevel = transform.position.x - 1;
                bottomLevel = transform.position.x + 1;
                rb.velocity = new Vector3(-1, 1, 0)*speed;
                break;
            case 0:     //right
                direction = 1;
                topLevel = transform.position.y + 1;
                bottomLevel = transform.position.y - 1;
                rb.velocity = new Vector3(1, 1, 0) * speed;
                break;
            case 270:   //down
                direction = 2;
                topLevel = transform.position.x - 1;
                bottomLevel = transform.position.x + 1;
                rb.velocity = new Vector3(-1, -1, 0) * speed;
                break;
            case 180:   //left
                direction = 3;
                topLevel = transform.position.y + 1;
                bottomLevel = transform.position.y - 1;
                rb.velocity = new Vector3(-1, 1, 0) * speed;
                break;
            default:     //shouldn't happen but just incase default to left
                direction = 3;
                topLevel = transform.position.y + 1;
                bottomLevel = transform.position.y - 1;
                rb.velocity = new Vector3(-1, 1, 0) * speed;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //check if enough time has passed since last up/down change
        //if true check if bubble has exceeded top/bottom level and changeUpDown
        if (canChangeTopBottomMovement)
        {
            switch (direction)
            {
                case 0:
                    if (transform.position.x < topLevel || transform.position.x > bottomLevel)
                    {
                        changeTopBottomMovement(-1, 1, true);
                    }
                    break;
                case 1:
                    if (transform.position.y > topLevel || transform.position.y < bottomLevel)
                    {
                        changeTopBottomMovement(1, 1, false);
                    }
                    break;
                case 2:
                    if (transform.position.x < topLevel || transform.position.x > bottomLevel)
                    {
                        changeTopBottomMovement(-1, -1, true);
                    }

                    break;
                case 3:
                    if (transform.position.y > topLevel || transform.position.y < bottomLevel)
                    {
                        changeTopBottomMovement(-1, 1, false);
                    }
                    break;
            }
        }
        if (canChangeTopBottomMovementTimerOn)
        {
            updateTimer();
        }
    }

    void changeTopBottomMovement(float x, float y, bool flipX)
    { 
        if (!movingTowardsTop) {rb.velocity = new Vector3(x, y, 0) * speed; movingTowardsTop = true;}
        else if(flipX) {rb.velocity = new Vector3((x*-1), y, 0) * speed; movingTowardsTop = false;}
        else { rb.velocity = new Vector3(x, (y * -1), 0) * speed; movingTowardsTop = false; }        
        startTimer();
    }

    void startTimer()
    {
        canChangeTopBottomMovement = false;
        canChangeTopBottomMovementTimerOn = true;
    }

    void updateTimer()
    {
        canChangeTopBottomMovementTime += 1;
        if (canChangeTopBottomMovementTime >= 30)
        {
            timerGoesOff();
        }
    }

    void timerGoesOff()
    {
        canChangeTopBottomMovementTimerOn = false;
        canChangeTopBottomMovementTime = 0;
        canChangeTopBottomMovement = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
        if (enemyHealth != null && enemyHealth.isDead)
        {
            return;
        }
        if (enemyHealth != null)
        {
            popBubble();
        }

    }

    void popBubble()
    {
        isPopped = true;
        animator.SetBool("popped", true);
        Destroy(gameObject, 1);
    }

}
