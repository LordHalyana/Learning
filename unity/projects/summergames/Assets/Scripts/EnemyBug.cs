using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBug : MonoBehaviour {

    public GameObject target;
    public Transform player;
    public float targetRange = 5.0f;
    public float baseMoveSpeed = 3.2f;
    public float chargeSpeed = 6.2f;
    public int health = 3;
    public int moveRange = 10;      //How far the AI decides to walk during WANDERER mode.
    public int knockbackRange = 100;      //How far the knockback on the enemy is when hit by an attack.
    public bool wanderer;       //Makes the AI choose to walk randomly around the map as long as the TARGET is out of range.
    public bool Ambusher;
    public bool playerClose;


    private Vector3 wayPoint;
    private Animator anim;
    private Rigidbody2D rgbd;
    private AudioSource myAudioSource;
    private FindAmbushSpot ambushSpot;
    private BoxCollider2D BC2D;
    private bool dealDamage;
    private bool move;
    private bool hasCharged;



	void Start ()
    {
        dealDamage = true;
        move = true;
        hasCharged = false;

        anim = GetComponent<Animator>();
        rgbd = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
        ambushSpot = FindObjectOfType<FindAmbushSpot>();
        BC2D = GetComponent<BoxCollider2D>();

        player = GameObject.Find("Player").transform;

        if (wanderer)
        {
            Wander();
        }
        if (Ambusher)
        {
            health -= 1;
            knockbackRange += 2;
            myAudioSource.enabled = false;
        }

        if (!wanderer && !Ambusher)
        {
            Debug.Log("This Billy was not set to an AI, automatically set to Ambusher!");
            Ambusher = true;
        }
        if (wanderer && Ambusher)
        {
            wanderer = false;
        }
        
	}
	
	void Update ()
    {

        if(!move)
        {
            rgbd.bodyType = RigidbodyType2D.Static;
        }
        if(move)
        {
            rgbd.bodyType = RigidbodyType2D.Dynamic;
        }


        float distance = Vector3.Distance(transform.position, player.position);

        //Makes the AI look and walk towards the TARGET if WANDERER is turned on
        if(wanderer && distance < targetRange * 2)
        {
            transform.up = player.position - transform.position;

            if (distance < targetRange && move)
            {
                transform.position += transform.up * baseMoveSpeed * Time.deltaTime;

                anim.SetBool("playerClose", true);

                if(distance < targetRange * 0.5 && move && !hasCharged)
                {
                    move = false;
                    Invoke("Charge", 0.5f);
                }
            }
            else
            {
                anim.SetBool("playerClose", false);
            }

        }
        else
        {
            //Makes the AI wander randomly around if WANDERER is turned on.
            if(wanderer && distance > targetRange * 2)
            {
                transform.position += transform.TransformDirection(Vector2.up) * (baseMoveSpeed * 0.5f) * Time.deltaTime;
            }

            if(wanderer && (transform.position - wayPoint).magnitude < targetRange)
            {
                Wander();
            }      
        }

        //Makes the AI look and attack the TARGET if AMBUSHER is turned on
        if (Ambusher && playerClose)
        {
            BC2D.enabled = true;

        }
        if (Ambusher && !playerClose)
        {
            BC2D.enabled = false;
        }

        if (Ambusher && distance < targetRange * 5)
        {
            transform.up = player.position - transform.position;
            playerClose = true;

            if (distance < targetRange && move)
            {
                transform.position += transform.up * (baseMoveSpeed * 1.5f) * Time.deltaTime;
                ambushSpot.isChasingPlayer = true;

                anim.SetBool("playerClose", true);

                if (distance < targetRange * 0.6 && move && !hasCharged)
                {
                    move = false;
                    Invoke("Charge", 0.5f);
                }
            }
            else
            {
                anim.SetBool("playerClose", false);
            }
        }
        else
        {
            playerClose = false;
            ambushSpot.isChasingPlayer = false;

        }

        if (health <= 0)
        {
            Debug.Log("Enemy destroyed.");
            Destroy(gameObject);
        }


    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && dealDamage)
        {
            Debug.Log("Player hit");
            collision.gameObject.SendMessage("TakeDamageBug");
            dealDamage = false;
            move = false;
        }          
    }

    //The AIs attack method.
    private void Cooldown()
    {
        dealDamage = true;
        move = true;
        hasCharged = false;
    }
    private void Charge()
    {
        Debug.Log("Billy Charging");

        if (Ambusher)
        {
            chargeSpeed = 10;
        }

        move = true;
        hasCharged = true;

        baseMoveSpeed = chargeSpeed;

        Invoke("Tired", 0.5f);
    }
    private void Tired()
    {
        baseMoveSpeed = 3.2f;
        move = false;
        dealDamage = false;
        Invoke("Cooldown", 1.0f);
    }

    //Wanderer AI.
    private void Wander()
    {

        wayPoint = new Vector2(Random.Range(transform.position.x - moveRange, transform.position.x + moveRange), Random.Range(transform.position.z - moveRange, transform.position.z + moveRange));
        wayPoint.y = 1;

        transform.up = wayPoint - transform.position;
    }

    //The AIs reaction when damage is taken.
    public void Damage(int totalDamage)
    {
        Debug.Log("Enemy damage taken!");
        health -= totalDamage;
        move = false;

        transform.position -= transform.up * knockbackRange * Time.deltaTime;
        Invoke("knockback", 1.5f);
    }
    private void knockback()
    {
        move = true;
    }


}
