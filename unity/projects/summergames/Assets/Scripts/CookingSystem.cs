using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;


public class CookingSystem : MonoBehaviour {

    public GameObject cookingUI, boiledWaterPanel, cookLQFishPanel, cookHQFishPanel, cookingTimerUI, failedTheCook, notEnoughMats;
    public AudioClip boilingWater;
    public AudioClip cookingFish;
    public Text dirtyWaterNumberText, LQFishNumberText, HQFishNumberText, cookingTimerText;
    public bool isCrafting;

    private AudioSource myAudioSource;
    private float timeCounter;
    private bool ready;

    void Start ()
    {
        myAudioSource = GetComponent<AudioSource>();


        cookingUI.SetActive(false);
        cookingTimerUI.SetActive(false);
        boiledWaterPanel.SetActive(false);
        cookLQFishPanel.SetActive(false);
        cookHQFishPanel.SetActive(false);
        failedTheCook.SetActive(false);
        notEnoughMats.SetActive(false);

        isCrafting = false;
        ready = false;
	}
	
	void Update ()
    {
		if (CrossPlatformInputManager.GetButtonDown("Action") && ready)
        {
            cookingUI.SetActive(true);
            isCrafting = true;
        }

        dirtyWaterNumberText.text = "Skittent Vann: " + GameController.gameControllerInstance.hasuncleanWater;
        LQFishNumberText.text = "Rå Fisk: " + GameController.gameControllerInstance.matRawLQFish;
        HQFishNumberText.text = "Fin Rå Fisk: " + GameController.gameControllerInstance.matRawHQFish;

        timeCounter -= Time.deltaTime;
        cookingTimerText.text = timeCounter.ToString("F2");
        if (timeCounter < 0)
        {
            timeCounter = 0;

            cookingTimerUI.SetActive(false);
        }
	}

    public void QuitFunction()
    {
        cookingUI.SetActive(false);
        isCrafting = false;

    }

    public void CookUncleanWater()
    {
        if (GameController.gameControllerInstance.hasuncleanWater >= 3)
        {
            Debug.Log("Boiling Water...");
            myAudioSource.pitch = Random.Range(0.8f, 1.2f);
            myAudioSource.PlayOneShot(boilingWater, 0.5f);

            timeCounter = 4;
            cookingTimerUI.SetActive(true);

            CookChanceUnclean();
        }
        else
        {
            notEnoughMats.SetActive(true);

            Invoke("notEnoughMaterials", 1.0f);
        }
    }

    private void CookChanceUnclean()
    {
        Invoke("CookWaterComplete", 4.0f);
    }

    private void CookWaterComplete()
    {
        cookingTimerUI.SetActive(false);
        boiledWaterPanel.SetActive(true);

        GameController.gameControllerInstance.hasuncleanWater -=3;
        GameController.gameControllerInstance.hasWaterBottle++;
        GameController.gameControllerInstance.matBottle += 2;

        Invoke("TurnOffCookPanels", 2.0f);
    }

    public void CookLQFish()
    {
        if (GameController.gameControllerInstance.matRawLQFish >= 1)
        {
            Debug.Log("Cooking the Fish...");
            myAudioSource.pitch = Random.Range(0.8f, 1.2f);
            myAudioSource.PlayOneShot(cookingFish, 0.5f);

            timeCounter = 4;
            cookingTimerUI.SetActive(true);

            int randomNumber = Random.Range(1, 10);
            CookChanceLQFish(randomNumber);
        }
        else
        {
            notEnoughMats.SetActive(true);

            Invoke("notEnoughMaterials", 1.0f);
        }
    }

    private void CookChanceLQFish(int chance)
    {
        if (chance <6)
        {
            Invoke("CookLQFishComplete", 4.0f);
        }
        else
        {
            Invoke("FailedLQCook", 4.0f);
        }
    }

    private void CookLQFishComplete()
    {
        cookingTimerUI.SetActive(false);
        cookLQFishPanel.SetActive(true);


        GameController.gameControllerInstance.matRawLQFish--;
        GameController.gameControllerInstance.hasFish++;

        Invoke("TurnOffCookPanels", 2.0f);
    }

    private void FailedLQCook()
    {
        failedTheCook.SetActive(true);
        cookingTimerUI.SetActive(false);

        GameController.gameControllerInstance.matRawLQFish--;

        Invoke("TurnOffCookPanels", 2.0f);
    }

    public void CookHQFish()
    {
        if (GameController.gameControllerInstance.matRawHQFish >= 1)
        {
            Debug.Log("Cooking the Fish...");
            myAudioSource.pitch = Random.Range(0.8f, 1.2f);
            myAudioSource.PlayOneShot(cookingFish, 0.5f);

            timeCounter = 4;
            cookingTimerUI.SetActive(true);

            int randomNumber = Random.Range(1, 10);
            CookChanceHQFish(randomNumber);
        }
        else
        {
            notEnoughMats.SetActive(true);

            Invoke("notEnoughMaterials", 1.0f);
        }
    }

    private void CookChanceHQFish(int chance)
    {
        if (chance < 9)
        {
            Invoke("CookHQFishComplete", 4.0f);
        }
        else
        {
            Invoke("FailedHQCook", 4.0f);
        }
    }

    private void CookHQFishComplete()
    {
        cookingTimerUI.SetActive(false);
        cookHQFishPanel.SetActive(true);

        GameController.gameControllerInstance.matRawHQFish--;
        GameController.gameControllerInstance.hasFish++;

        Invoke("TurnOffCookPanels", 2.0f);
    }

    private void FailedHQCook()
    {
        failedTheCook.SetActive(true);
        cookingTimerUI.SetActive(false);

        GameController.gameControllerInstance.matRawHQFish--;

        Invoke("TurnOffCookPanels", 2.0f);
    }

    private void TurnOffCookPanels()
    {
        failedTheCook.SetActive(false);
        cookLQFishPanel.SetActive(false);
        cookHQFishPanel.SetActive(false);
        boiledWaterPanel.SetActive(false);


    }

    private void notEnoughMaterials()
    {
        notEnoughMats.SetActive(false);
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
}
