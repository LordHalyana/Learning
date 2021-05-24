using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

    //Public Variables.
    public Collider2D attackTrigger;
    public Collider2D attackTriggerUp;
    public Collider2D attackTriggerLeft;
    public Collider2D attackTriggerRight;
    public AudioClip meleeSound;
    public float baseMoveSpeed = 3.0f;
    public float modifiedMoveSpeed = 1.0f;
    public float thirstSprintRegen;
    public float sprintRegenMultiplier = 1.0f;
    public float attackSpeedTimer = 0;
    public float attackSpeed = 1.0f;
    public int sprintAvail = 3;    
    public int maxHealth = 10;
    public int maxSprint = 3;


    //Hidden Public Variables.
    [HideInInspector]
    public int currentHealth;
    [HideInInspector]
    public float Hunger = 100.0f;
    [HideInInspector]
    public float Thirst = 100.0f;
    [HideInInspector]
    public bool energyBuff;
    [HideInInspector]
    public bool debuffRemoval;

    //Private Variables.
    private Vector2 deltaForce;
    private Vector2 lastDirection;
    private Rigidbody2D rgbd2D;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private AudioSource myAudioSource;
    private FishingSystem fishSys;
    private CookingSystem cookSys;
    private bool sprinting = false;
    private bool SprintRegenerating = false;
    private bool canSprint = true;
    private bool isMoving;
    private bool canHeal;
    private bool hungerMoveDebuff;
    private bool ThirstSprintRegen = true;
    private bool thirstSprintDebuff = false;
    private bool BOX_BU, AD_BU, SD_BU;
    private bool BOX_DBU, AD_DBU;
    private bool attacking = false;
    private bool meleeAttackCommand;
    private float attackTimer = 0;
    private float attackCd = 0.5f;
    private int dirMelee = 3;








    void Start ()
    {
        anim = GetComponent<Animator>();
        rgbd2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        myAudioSource = GetComponent<AudioSource>();
        fishSys = FindObjectOfType<FishingSystem>();
        cookSys = FindObjectOfType<CookingSystem>();

        //Make a statement.
        currentHealth = maxHealth;
        

        //Start Functions Instantly.
        HungerSystem();
        HungerBuffs();
        ThirstSystem();
        ThirstBuffs();

        //Set something true or false.
        canHeal = true;
        attackTrigger.enabled = false;
        attackTriggerUp.enabled = false;
        attackTriggerRight.enabled = false;
        attackTriggerLeft.enabled = false;

    }

    void Update ()
    {
        CheckInput();

        //Sprint Command
        if (CrossPlatformInputManager.GetButton("Sprint") && sprintAvail >= 1 && !sprinting && canSprint && !fishSys.isFishing)
        {
            sprint();
        }

        //If functions.
        if (sprintAvail < maxSprint && !SprintRegenerating)
        {
            regenSprint();
        }
        if (currentHealth <= 0)
        {
            Debug.Log("You have died, what a shame!");
            SceneManager.LoadScene(0);
        }
        if(hungerMoveDebuff)
        {
            baseMoveSpeed = 2;
        }
        else
        {
            baseMoveSpeed = 3;
        }
        if (ThirstSprintRegen)
        {
            thirstSprintRegen = -3.0f;
        }
        else
        {
            if (thirstSprintDebuff)
            {
                thirstSprintRegen = 5.0f;
            }
            else
            {
                thirstSprintRegen = 0;
            }
        }

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (sprintAvail < 0)
        {
            sprintAvail = 0;
        }
        if (sprintAvail > maxSprint)
        {
            sprintAvail = maxSprint;
        }

        if (Hunger > 100)
        {
            Hunger = 100;
        }
        if (Thirst > 100)
        {
            Thirst = 100;
        }

        //Melee System.
        if (CrossPlatformInputManager.GetButtonDown("Fire2") && !attacking && sprintAvail >= 1 && attackSpeedTimer <= 0 && dirMelee == 3 && !fishSys.isFishing)
        {
            attacking = true;
            meleeAttackCommand = true;
            attackTrigger.enabled = true;
            attackTimer = attackCd;
            attackSpeedTimer = attackSpeed;

            Attack();

            
        }
        if (CrossPlatformInputManager.GetButtonDown("Fire2") && !attacking && sprintAvail >= 1 && attackSpeedTimer <= 0 && dirMelee == 4 && !fishSys.isFishing)
        {
            attacking = true;
            meleeAttackCommand = true;
            attackTriggerUp.enabled = true;
            attackTimer = attackCd;
            attackSpeedTimer = attackSpeed;

            Attack();


        }
        if (CrossPlatformInputManager.GetButtonDown("Fire2") && !attacking && sprintAvail >= 1 && attackSpeedTimer <= 0 && dirMelee == 1 && !fishSys.isFishing)
        {
            attacking = true;
            meleeAttackCommand = true;
            attackTriggerLeft.enabled = true;
            attackTimer = attackCd;
            attackSpeedTimer = attackSpeed;

            Attack();


        }
        if (CrossPlatformInputManager.GetButtonDown("Fire2") && !attacking && sprintAvail >= 1 && attackSpeedTimer <= 0 && dirMelee == 2 && !fishSys.isFishing)
        {
            attacking = true;
            meleeAttackCommand = true;
            attackTriggerRight.enabled = true;
            attackTimer = attackCd;
            attackSpeedTimer = attackSpeed;

            Attack();


        }

        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
                attackTriggerUp.enabled = false;
                attackTriggerLeft.enabled = false;
                attackTriggerRight.enabled = false;
            }
            


        }
        if (attackSpeedTimer > 0)
        {
            attackSpeedTimer -= Time.deltaTime;
        }

    }

    private void SendAnimInfo()
    {
        anim.SetFloat("XSpeed", rgbd2D.velocity.x);
        anim.SetFloat("YSpeed", rgbd2D.velocity.y);

        anim.SetFloat("LastX", lastDirection.x);
        anim.SetFloat("LastY", lastDirection.y);

        anim.SetBool("IsMoving", isMoving);
    }

    /// <summary>
    /// This is the function where we read in the player's input.
    /// </summary>
    private void CheckInput()
    {
        var moveH = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        var moveV = CrossPlatformInputManager.GetAxisRaw("Vertical");

        isMoving = false;

        if (moveH < 0 || moveH > 0 || moveV < 0 || moveV > 0)
        {
            isMoving = true;

            if (!boxCollider.IsTouchingLayers(Physics2D.AllLayers))
            {
                lastDirection = rgbd2D.velocity;
            }


        }



        if (moveH < 0)
        {
            dirMelee = 1;
        }
        if (moveH > 0)
        {
            dirMelee = 2;
        }
        if (moveV < -0)
        {
            dirMelee = 3;
        }
        if (moveV > 0)
        {
            dirMelee = 4;
        }

        if (fishSys.isFishing || fishSys.isFilling || cookSys.isCrafting)
        {
            baseMoveSpeed = 0;
        }
        else
        {
            baseMoveSpeed = 3.0f;
        }

        deltaForce = new Vector2(moveH, moveV);

        CalculateMovement(deltaForce * (baseMoveSpeed * modifiedMoveSpeed));


    }

    /// <summary>
    /// This is the function where we add force to the player.
    /// </summary>
    /// <param name="playerForce"></param>
    private void CalculateMovement(Vector2 playerForce)
    {
        rgbd2D.velocity = Vector2.zero;

        rgbd2D.AddForce(playerForce, ForceMode2D.Impulse);

        SendAnimInfo();
    }

    //Sprint Functions
    private void sprint()
    {
        Debug.Log("Sprint Activated");
        modifiedMoveSpeed += 0.5f;
        Hunger -= 1.0f;
        Thirst -= 2.5f;


        anim.SetFloat("runningMultiplier", 2.0f);

        sprinting = true;

        sprintAvail--;

        Invoke("disableSprint", 3.0f);
    }
    private void disableSprint()
    {
        Debug.Log("Sprint Off");
        modifiedMoveSpeed -= 0.5f;

        anim.SetFloat("runningMultiplier", 1.0f);


        sprinting = false;
    }
    private void regenSprint()
    {
        if (!AD_DBU)
        {
            Debug.Log("Sprint Regenerating");
            SprintRegenerating = true;

            Invoke("regenSprintComplete", (10.0f + thirstSprintRegen) * sprintRegenMultiplier);
        }

    }
    private void regenSprintComplete()
    {
        Debug.Log("Sprint Regenerated");
        sprintAvail++;
        SprintRegenerating = false;
    }

    //Enemy damage types.
    public void TakeDamageBug()
    {
        if (!AD_BU)
        {
            currentHealth -= 1;
        }  
        
    }

    public void TakeDamageSeagull()
    {
        if (!AD_BU)
        {
            currentHealth -= 1;
        }

    }

    //Hunger System:
    private void HungerSystem()
    {
        if (Hunger >= 0.1f)
        {
            if (Hunger == 100.0f)
            {
                Invoke("MaxHunger", 30.0f);
            }
            else
            {
                Invoke("LowHunger", 2.0f);
            }
        }
    }
    private void HungerBuffs()
    {
        if (Hunger >= 0.1f)
        {
            if (Hunger >= 20.1f)
            {
                if (Hunger >= 40.1f)
                {
                    if (Hunger >= 60.1f)
                    {
                        if (Hunger >= 75.0f && canHeal)
                        {
                            if (Hunger >= 90.0f && canHeal)
                            {
                                if (currentHealth < maxHealth)
                                {
                                    Invoke("HungerRegen", 14.0f);

                                }

                                hungerMoveDebuff = false;
                            }
                            else
                            {
                                if (currentHealth < maxHealth)
                                {
                                    Invoke("HungerRegen", 29.0f);
                                }
                            }
                            hungerMoveDebuff = false;

                        }
                        else
                        {
                            //Restarts this function.
                            hungerMoveDebuff = false;

                            Invoke("HungerBuffs", 10.0f);
                        }
                    }
                    else
                    {
                        //Restarts this function.
                        hungerMoveDebuff = false;

                        Invoke("HungerBuffs", 10.0f);
                    }
                }
                else
                {
                    //Reduces movement speed and restarts this function.
                    Debug.Log("Reduced Movement speed through low Hunger!");
                    hungerMoveDebuff = true;                   
                    
                    Invoke("HungerBuffs", 10.0f);
                }
            }
            else
            {
                //Denies all heal effects (Except First aid kits) and restarts this function.
                Debug.Log("No longer regen!");
                canHeal = false;
                hungerMoveDebuff = true;

                Invoke("HungerBuffs", 10.0f);    
            }
        }
        else
        {
            canHeal = false;
            hungerMoveDebuff = true;

            Invoke("TakeDamageHunger", 30.0f);
        }
    }
    private void MaxHunger()
    {
        Debug.Log("Hunger first reduced");
        Hunger -= 0.1f;

        Invoke("HungerSystem", 1.0f);
    }
    private void LowHunger()
    {
        if(Hunger < 100)
        {
            Hunger -= 0.1f;
        }

        Invoke("HungerSystem", 1.0f);
    }
    private void HungerRegen()
    {
        Debug.Log("Health Regenerated");
        currentHealth += 1;

        Invoke("HungerBuffs", 1.0f);

    }
    public void TakeDamageHunger()
    {
        if (!AD_BU)
        {
            Debug.Log("Hunger Pains!");
            currentHealth -= 1;
        }


        Invoke("HungerBuffs", 1.0f);
    }

   //Thirst System:
   private void ThirstSystem()
    {
        if (Thirst >= 0.1f)
        {
            if (Thirst == 100.0f)
            {
                Invoke("MaxThirst", 30.0f);
            }
            else
            {
                Invoke("LowThirst", 2.0f);
            }
        }
    }
    private void ThirstBuffs()
    {
        if (Thirst >= 0.1f)
        {
            if (Thirst >= 20.1f)
            {
                if (Thirst >= 40.1f)
                {
                    if (Thirst >= 60.1f)
                    {
                        if (Thirst >= 75.0f)
                        {
                            //Increases Sprint Regeneration and restarts this function. 
                            thirstSprintDebuff = false;
                            ThirstSprintRegen = true;
                            canSprint = true;

                            Invoke("ThirstBuffs", 10.0f);
                        }
                        else
                        {
                            //Restarts this function.
                            thirstSprintDebuff = false;
                            ThirstSprintRegen = false;
                            canSprint = true;

                            Invoke("ThirstBuffs", 10.0f);
                        }
                    }
                    else
                    {
                        //Restarts this function.
                        thirstSprintDebuff = false;
                        ThirstSprintRegen = false;
                        canSprint = true;

                        Invoke("ThirstBuffs", 10.0f);

                    }
                }
                else
                {
                    //Reduces sprint regeneration and restarts this function.
                    Debug.Log("Feeling tired...");
                    thirstSprintDebuff = true;
                    ThirstSprintRegen = false;
                    canSprint = true;

                    Invoke("ThirstBuffs", 10.0f);

                }
            }
            else
            {
                //Removes the ability to sprint and restarts this function.
                Debug.Log("Nei, nå nekter jeg å løpe, for tørst!");
                thirstSprintDebuff = true;
                ThirstSprintRegen = false;
                canSprint = false;

                Invoke("ThirstBuffs", 10.0f);

            }
        }
        else
        {
            thirstSprintDebuff = true;
            ThirstSprintRegen = false;
            canSprint = false;

            Invoke("TakeDamageThirst", 30.0f);
        }
    }
    private void MaxThirst()
    {
        Debug.Log("Thirst first reduced");
        Thirst -= 0.2f;

        Invoke("ThirstSystem", 1.0f);
    }
    private void LowThirst()
    {
        if (Thirst < 100)
        {
            Thirst -= 0.2f;
        }

        Invoke("ThirstSystem", 1.0f);
    }
    private void TakeDamageThirst()
    {
        if (!AD_BU)
        {
            Debug.Log("Dehydration levels too damn low!");
            currentHealth -= 1;
        }


        Invoke("ThirstBuffs", 1.0f);
    }
    
    //Inventory System:

    //Buffs & Debuffs.
    public void HurtigSnackBuff()
    {
        if (!energyBuff)
        {
            Debug.Log("More energy!");
            maxSprint += 1;
            energyBuff = true;

            Invoke("HurtigSnackBuffOff", 600.0f);
        }
        else
        {
            Hunger += 5.0f;
        }

    }
    private void HurtigSnackBuffOff()
    {
        Debug.Log("Less Energy...");
        maxSprint -= 1;
        energyBuff = false;
    }

    public void BlueOxBuff()
    {
        if (!BOX_BU)
        {
            modifiedMoveSpeed += 0.5f;
            attackSpeed -= 0.3f;

            BOX_BU = true;

            Invoke("BlueOxBuffOff", 30.0f);
        }
        else
        {
            sprintAvail++;
        }
    }
    private void BlueOxBuffOff()
    {
        if (Hunger <= 50)
        {
            modifiedMoveSpeed -= 0.6f;
            

            canSprint = false;
            BOX_DBU = true;


            Invoke("BlueOxDebuffOff", 10.0f);
        }
        else
        {
            modifiedMoveSpeed -= 0.5f;
        }
        attackSpeed += 0.3f;

    }
    private void BlueOxDebuffOff()
    {
        modifiedMoveSpeed += 0.1f;
        canSprint = true;
        BOX_BU = false;
        BOX_DBU = false;
    }

    public void AdrenalineBuff()
    {
        if (!AD_BU)
        {
            AD_BU = true;
            modifiedMoveSpeed += 0.5f;

            Invoke("AdrenalineBuffOff", 30.0f);

        }
        
    }
    private void AdrenalineBuffOff()
    {
        AD_BU = false;
        AD_DBU = true;

        modifiedMoveSpeed -= 0.5f;

        sprintAvail = 0;
        Invoke("AdrenalineDebuffOff", 60.0f);
    }
    private void AdrenalineDebuffOff()
    {
        AD_DBU = false;

    }

    public void SportsDrinkBuff()
    {
        SD_BU = true;

        Invoke("SportsDrinkBuffOff", 10.0f);
    }
    private void SportsDrinkBuffOff()
    {
        SD_BU = false;
    }

    //Debuff Removal system. Put in more debuffs in here!
    public void Antibiotics()
    {
        if (BOX_DBU)
        {
            Debug.Log("Phew, I managed to remove my fatigue!");
            CancelInvoke("BlueOxDebuffOff");
            BlueOxDebuffOff();
        }

        if (GameController.gameControllerInstance.UCW_DBU)
        {
            Debug.Log("Those pills sure washed away that nasty water from my system!");
            GameController.gameControllerInstance.CancelInvoke("UncleanWaterOff");
            GameController.gameControllerInstance.SendMessage("UnCleanWaterOff");
        }
        if (AD_DBU)
        {
            Debug.Log("The adrenaline was no match for my all seeing Antibiotics!");
            CancelInvoke("AdrenalineDebuffOff");
            AdrenalineDebuffOff();
        }

    }
    
    //Attacking System.
    private void Attack()
    {
        if (meleeAttackCommand)
        {
            if (!SD_BU)
            {
                sprintAvail -= 1;
            }
            

            meleeAttackCommand = false;

            //anim.setbool("Attacking", attacking);

            myAudioSource.pitch = Random.Range(0.8f, 1.2f);
            myAudioSource.PlayOneShot(meleeSound, 0.5f);
        }

    }
}
