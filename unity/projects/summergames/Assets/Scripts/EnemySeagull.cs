using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeagull : MonoBehaviour {

    public GameObject gFX;
    public GameObject target;
    public GameObject secondaryTarget;
    public Transform player;
    public Transform secondaryPrey;
    public int Health = 5;
    public int knockbackRange = 75;
    public float baseMoveSpeed = 4;
    public float resetMovespeed = 4;
    public float diveSpeed = 10;
    public float targetRange = 6;
    public bool playerClose;

    private Rigidbody2D rgbd;
    private BoxCollider2D BC2D;
    private bool move;
    private bool diving;
    private bool dealDamage;


    void Start ()
    {
        rgbd = GetComponent<Rigidbody2D>();
        BC2D = GetComponent<BoxCollider2D>();
        move = true;

        BC2D.enabled = false;
    }
	
	void Update ()
    {
        if (diving)
        {
            BC2D.enabled = true;
        }
        else
        {
            BC2D.enabled = false;
        }

        if (!move)
        {
            rgbd.bodyType = RigidbodyType2D.Static;
        }
        if (move)
        {
            rgbd.bodyType = RigidbodyType2D.Dynamic;
        }

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < targetRange)
        {
            if (!diving)
            {
                gFX.transform.up = player.position - transform.position;
                transform.up = player.position - transform.position;
                playerClose = true;
            }

            if (distance < targetRange && move)
            {
                transform.position += transform.up * baseMoveSpeed * Time.deltaTime;


                if (distance < targetRange * 0.5 && !diving)
                {

                    baseMoveSpeed = diveSpeed;

                    diving = true;

                    Invoke("Dive", 0.5f);
                    
                }
            }

        }
        else
        {
            playerClose = false;

            Vector3 temp = transform.rotation.eulerAngles;
            temp.z = 0;
            transform.rotation = Quaternion.Euler(temp);
        }

        if (Health <= 0)
        {
            Debug.Log("Enemy destroyed.");
            Destroy(gameObject);
        }
    }


    private void Dive()
    {
        Debug.Log("Seagull Dived!");

        baseMoveSpeed = resetMovespeed;

        diving = false;
        move = false;

        Invoke("DiveComplete", 2.0f);


    }

    private void DiveComplete()
    {
        move = true;
        dealDamage = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && dealDamage)
        {
            Debug.Log("Player hit");
            collision.gameObject.SendMessage("TakeDamageSeagull");
            dealDamage = false;
        }
    }

    public void Damage(int totalDamage)
    {
        Debug.Log("Enemy damage taken!");
        Health -= totalDamage;
        move = false;

        transform.position -= transform.up * knockbackRange * Time.deltaTime;
        Invoke("knockback", 1.0f);
    }

    private void knockback()
    {
        move = true;
    }
}
