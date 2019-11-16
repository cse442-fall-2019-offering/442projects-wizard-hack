using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
	public float speed;
	public float distanceToStartAttack;
	public Animator animator;
    public float x;
    public float y;
    public float z;
	private Transform player, chase;
    private ArrayList bubbles;
    private bool chasingBubble;
    private bool chasingPlayer;
    public int damageAmount;
    private bool defenseActive;
    public float attackDistance;

	public GameObject my_player;
	PlayerHealth ph;

    private double count = 0.5;
    private bool canAttack = true;

    // Start is called before the first frame update
    void Start() {
    	ph = my_player.GetComponent<PlayerHealth>();
        transform.localScale = new Vector3(x, y, z);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        chase = player;
        bubbles = new ArrayList();
        defenseActive = false;
        attackDistance = 1.5f;
        chasingPlayer = true;
    }

    // Update is called once per frame
    void Update() {
        if (!gameObject.GetComponent<EnemyHealth>().isDead && chase!=null)
        {          
            float distanceToChaseTransform = Vector2.Distance(transform.position, chase.position);
            // Debug.Log("distance to player: " + distanceToPlayer);
            if (distanceToChaseTransform < distanceToStartAttack && distanceToChaseTransform > 1)
            {
                // ** LOOK AT PLAYER **
                Vector3 distanceVector = chase.position - transform.position;
                // Debug.Log(direction[0]);

                if (distanceVector[0] >= 0)
                {
                    transform.localScale = new Vector3(x, y, z);
                }
                else
                {
                    transform.localScale = new Vector3(-x, y, z);
                }
                // ** End **

                // ** CHASE PLAYER **
                transform.position = Vector2.MoveTowards(transform.position, chase.position, speed * Time.deltaTime);
                animator.SetFloat("Speed", 1);

                // ** CATCH PLAYER ** 

            }
            else
            {
                animator.SetFloat("Speed", 0);
            }

            if (canAttack)
            {
                if (chasingPlayer && distanceToChaseTransform <= attackDistance)
                {
                    attack();
                }
                else
                {
                    animator.SetBool("Should_Attack", false);
                }
            }
            checkTime();
            // ** End **
        }
    }

    void checkTime(){
        if (Time.time > count){
            count +=1.0;
            canAttack = true;
        }
    }

    void attack()
    {
        animator.SetBool("Should_Attack", true);
        if (ph.defenseActive)
        {
            ph.damagePlayer(damageAmount / 2);
        }
        else
        {
            ph.damagePlayer(damageAmount);
        }
        canAttack = false;
        // animator.SetBool("Should_Attack", false);
    }

    public void addNewBubble(Bubble bubble)
    {
        bubbles.Add(bubble);
        findClosestBubble();
    }

    public void removePoppedBubble(Bubble bubble)
    {
        bubbles.Remove(bubble);
        if (bubbles.Count == 0)
        {
            chasePlayer();
        }
        else
        {
            findClosestBubble();
        }
    }

    public void findClosestBubble()
    {
        float minDistance = 100000f;
        foreach(Bubble bubble in bubbles)
        {
            if (bubble != null)
            {
                float currDist = Vector2.Distance(transform.position, bubble.transform.position);
                if (currDist < minDistance)
                {
                    minDistance = currDist;
                    chase = bubble.transform;
                }
            }
        }
        chasingPlayer = false;
    }

    public void chasePlayer()
    {
        chase = player;
        chasingPlayer = true;
    }
}
