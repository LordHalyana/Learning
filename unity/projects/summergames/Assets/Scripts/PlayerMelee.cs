//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerMelee : MonoBehaviour {

//    public Collider2D attackTrigger;
//    public AudioClip meleeSound;


//    private Animator anim;
//    private bool attacking = false;
//    private float attackTimer = 0;
//    private float attackCd = 0.5f;
//    private Player myPlayer;
//    private AudioSource myAudioSource;

//	void Start ()
//    {
//        myAudioSource = GetComponent<AudioSource>();
//	}
	
//	void Update ()
//    {
//        if (Input.GetButtonDown("Fire1") && !attacking && myPlayer.sprintAvail >= 1)
//        {
//            attacking = true;
//            attackTimer = attackCd;

//            attackTrigger.enabled = true;
//        }

//        if (attacking)
//        {
//            if (attackTimer > 0)
//            {
//                attackTimer -= Time.deltaTime;
//            }
//            else
//            {
//                attacking = false;
//                attackTrigger.enabled = false;
//            }

//            //anim.setbool("Attacking", attacking);
//            myAudioSource.pitch = Random.Range(0.8f, 1.2f);
//            myAudioSource.PlayOneShot(meleeSound, 0.5f);
//        }

//    }
//}
