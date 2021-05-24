using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Items : MonoBehaviour
{

    public bool ready;
    public bool highQualityLoot;
    public bool isDeveloperBackpack;

    public bool containsWaterBottle, containsLunchBox, containsFirstAidKit, containsBandages, containsUncleanWater, containsFish, containsBlueberry, containsHurtigSnack, containsBlueOx, containsAdrenaline, containsAntibiotics, containsSportDrink, containsFishAndBait; //Only works if "isDeveloperBackpack" = true.

    private Animator anim;
    private bool opened;



    void Start()
    {
        opened = false;
        ready = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (ready && CrossPlatformInputManager.GetButtonDown("Action") && !opened && !highQualityLoot && !isDeveloperBackpack)
        {
            if (GameController.gameControllerInstance.currentCarryingCapacity < GameController.gameControllerInstance.maxTotalCarryingCapacity)
            {
                anim.SetTrigger("Open");

                int randomNumber = Random.Range(0, 13);
                GameController.gameControllerInstance.GiveItem(randomNumber);

                opened = true;
            }
            else
            {
                GameController.gameControllerInstance.carryingPanel.SetActive(true);
                Invoke("CarryingCapWarn", 3);
            }
            
            
        }

        if (ready && CrossPlatformInputManager.GetButtonDown("Action") && !opened && highQualityLoot && !isDeveloperBackpack)
        {
            if (GameController.gameControllerInstance.currentCarryingCapacity < GameController.gameControllerInstance.maxTotalCarryingCapacity)
            {
                anim.SetTrigger("Open");

                int randomNumber = Random.Range(0, 9);
                GameController.gameControllerInstance.GiveHighItem(randomNumber);

                opened = true;
            }
            else
            {
                GameController.gameControllerInstance.carryingPanel.SetActive(true);
                Invoke("CarryingCapWarn", 3);
            }
        }

        if (ready && CrossPlatformInputManager.GetButtonDown("Action") && isDeveloperBackpack)
        {
            if (GameController.gameControllerInstance.currentCarryingCapacity < GameController.gameControllerInstance.maxTotalCarryingCapacity)
            {
                if (containsFirstAidKit)
                {
                    GameController.gameControllerInstance.PickUpFirstAidKit(1);

                }
                if (containsLunchBox)
                {
                    GameController.gameControllerInstance.PickUpLunchBox(1);

                }
                if (containsWaterBottle)
                {
                    GameController.gameControllerInstance.PickUpWaterBottle(1);

                }
                if (containsBandages)
                {
                    GameController.gameControllerInstance.PickUpBandages(1);

                }
                if (containsFish)
                {
                    GameController.gameControllerInstance.PickUpFish(1);
                }
                if (containsUncleanWater)
                {
                    GameController.gameControllerInstance.PickUpUncleanWater(1);

                }
                if (containsBlueberry)
                {
                    GameController.gameControllerInstance.PickupBlueberry(1);

                }
                if (containsHurtigSnack)
                {
                    GameController.gameControllerInstance.PickUpHurtigSnack(1);

                }
                if (containsBlueOx)
                {
                    GameController.gameControllerInstance.PickUpBlueOx(1);

                }
                if (containsAdrenaline)
                {
                    GameController.gameControllerInstance.PickUpAdrenaline(1);

                }
                if (containsAntibiotics)
                {
                    GameController.gameControllerInstance.PickUpAntibiotics(1);

                }
                if (containsSportDrink)
                {
                    GameController.gameControllerInstance.PickUpSportsDrink(1);

                }
                if (containsFishAndBait)
                {
                    GameController.gameControllerInstance.hasFishingrod = 1;
                    GameController.gameControllerInstance.hasBait += 5;

                }
            }
            else
            {
                GameController.gameControllerInstance.carryingPanel.SetActive(true);
                Invoke("CarryingCapWarn", 3);
            }
        }
        if (!isDeveloperBackpack)
        {
            containsAdrenaline = false;
            containsAntibiotics = false;
            containsBandages = false;
            containsBlueberry = false;
            containsBlueOx = false;
            containsFirstAidKit = false;
            containsFish = false;
            containsHurtigSnack = false;
            containsLunchBox = false;
            containsSportDrink = false;
            containsUncleanWater = false;
            containsWaterBottle = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ready = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ready = false;
        }
    }

    private void CarryingCapWarn()
    {
        GameController.gameControllerInstance.carryingPanel.SetActive(false);
    }

}
