using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;


public class FishingSystem : MonoBehaviour {

    public bool isFishing, isFilling;
    public int reelPosition = 5;
    public int baitHealth = 4;
    public GameObject fishingPanel, fishOrFillPanel;
    public GameObject obtainedNothing, obtainedHooked, obtainedHQ, obtainedLQ;
    public GameObject cannotReelMore;
    public Text reeledinPosition, baitHealthText, remainingBaitText;
    public AudioClip throwLineinWater;
    public AudioClip landInWater;
    public AudioClip reelingLine;
    public AudioClip reeledIn;
    public AudioClip fillWater;

    private AudioSource myAudioSource;
    private bool ready;
    private bool hooked, HQOBT, LQOBT;


    void Start ()
    {
        myAudioSource = GetComponent<AudioSource>();

        cannotReelMore.SetActive(false);
        obtainedHooked.SetActive(false);
        obtainedNothing.SetActive(false);
        fishingPanel.SetActive(false);
        cannotReelMore.SetActive(false);
        fishOrFillPanel.SetActive(false);
        

        ready = false;
        hooked = false;
        isFishing = false;
        isFilling = false;
	}
	
	void Update ()
    {
		if (CrossPlatformInputManager.GetButtonDown("Action") && GameController.gameControllerInstance.hasBait >= 1 && ready && GameController.gameControllerInstance.matBottle < 1)
        {
            Debug.Log("Throwing Line!");

            Invoke("ThrowingLine", 1.0f);
            reelPosition = 5;
            baitHealth = 4;

            myAudioSource.pitch = Random.Range(0.8f, 1.2f);
            myAudioSource.PlayOneShot(throwLineinWater, 0.5f);

            GameController.gameControllerInstance.hasBait -= 1;

        }
        if (CrossPlatformInputManager.GetButtonDown("Action") && GameController.gameControllerInstance.hasBait < 1 && ready && GameController.gameControllerInstance.matBottle >= 1)
        {
            myAudioSource.pitch = Random.Range(0.8f, 1.2f);
            myAudioSource.PlayOneShot(fillWater, 0.5f);

            isFilling = true;
            Invoke("FillBottle", 6.0f);

        }

        if (CrossPlatformInputManager.GetButtonDown("Action") && GameController.gameControllerInstance.hasBait >= 1 && ready && GameController.gameControllerInstance.matBottle >= 1)
        {
            fishOrFillPanel.SetActive(true);
        }

        if (isFishing)
        {
            fishingPanel.SetActive(true);
        }
        else
        {
            fishingPanel.SetActive(false);
        }

        if (baitHealth == 0)
        {
            myAudioSource.pitch = Random.Range(0.8f, 1.2f);
            myAudioSource.PlayOneShot(reeledIn, 0.5f);

            isFishing = false;
            baitHealth = 4;

        }

        reeledinPosition.text = "Snelle Posisjon: " + reelPosition;
        baitHealthText.text = "Agn Styrke: " + baitHealth;
        remainingBaitText.text = "Agn: " + GameController.gameControllerInstance.hasBait;
	}

    private void ThrowingLine()
    {
        isFishing = true;

        myAudioSource.pitch = Random.Range(0.8f, 1.2f);
        myAudioSource.PlayOneShot(landInWater, 0.5f);
    }

    public void Fish()
    {
        if (!hooked)
        {
            Debug.Log("Attempting to get a nibble...");
            int randomNumber = Random.Range(1, 100);
            ObtainedFish(randomNumber);
        }
    }

    public void Reel()
    {
        if (reelPosition == 1 && !hooked)
        {
            cannotReelMore.SetActive(true);

            Invoke("RemoveReeledInfo", 2.0f);
        }
        
        if (reelPosition >= 2 && !hooked)
        {
            Debug.Log("Reeling in a bit...");
            myAudioSource.pitch = Random.Range(0.8f, 1.2f);
            myAudioSource.PlayOneShot(reelingLine, 0.5f);

            reelPosition--;
        }

        if (hooked)
        {
            if(HQOBT)
            {
                myAudioSource.pitch = Random.Range(0.8f, 1.2f);
                myAudioSource.PlayOneShot(reeledIn, 0.5f);

                Invoke("HQOff", 3.0f);
            }

            if (LQOBT)
            {
                myAudioSource.pitch = Random.Range(0.8f, 1.2f);
                myAudioSource.PlayOneShot(reeledIn, 0.5f);

                Invoke("LQOff", 3.0f);
            }
        }
         


    }
    private void RemoveReeledInfo()
    {
        cannotReelMore.SetActive(false);
    }

    public void QuitFishing()
    {
        if (!hooked)
        {
            Debug.Log("Quit fishin'");
            myAudioSource.pitch = Random.Range(0.8f, 1.2f);
            myAudioSource.PlayOneShot(reeledIn, 0.5f);

            isFishing = false;
            reelPosition = 5;

        }

    }

    private void ObtainedFish(int fishChance)
    {
        if (reelPosition == 5)
        {
            if (fishChance < 75)
            {
                obtainedNothing.SetActive(true);

                Invoke("NothingOff", 3.0f);
            }
            if (fishChance >= 75 && fishChance < 90)
            {
                obtainedHooked.SetActive(true);

                hooked = true;
                HQOBT = true; 
            }
            if (fishChance >= 90)
            {
                obtainedHooked.SetActive(true);

                hooked = true;
                LQOBT = true;
            }
        }
        if (reelPosition == 4)
        {
            if (fishChance < 70)
            {
                obtainedNothing.SetActive(true);

                Invoke("NothingOff", 3.0f);
            }
            if (fishChance >= 70 && fishChance < 82)
            {
                obtainedHooked.SetActive(true);

                hooked = true;
                HQOBT = true;
            }
            if (fishChance >= 82)
            {
                obtainedHooked.SetActive(true);

                hooked = true;
                LQOBT = true;
            }
        }
        if (reelPosition == 3)
        {
            if (fishChance < 65)
            {
                obtainedNothing.SetActive(true);

                Invoke("NothingOff", 3.0f);
            }
            if (fishChance >= 65 && fishChance < 75)
            {
                obtainedHooked.SetActive(true);

                hooked = true;
                HQOBT = true;
            }
            if (fishChance >= 75)
            {
                obtainedHooked.SetActive(true);

                hooked = true;
                LQOBT = true;
            }
        }
        if (reelPosition == 2)
        {
            if (fishChance < 60)
            {
                obtainedNothing.SetActive(true);

                Invoke("NothingOff", 3.0f);
            }
            if (fishChance >= 60 && fishChance < 65)
            {
                obtainedHooked.SetActive(true);

                hooked = true;
                HQOBT = true;
            }
            if (fishChance >= 65)
            {
                obtainedHooked.SetActive(true);

                hooked = true;
                LQOBT = true;
            }
        }
        if (reelPosition == 1)
        {
            if (fishChance < 50)
            {
                obtainedNothing.SetActive(true);

                Invoke("NothingOff", 3.0f);
            }
            if (fishChance >= 50)
            {
                obtainedHooked.SetActive(true);

                hooked = true;
                LQOBT = true;
            }
        }
    }

    private void NothingOff()
    {
        obtainedNothing.SetActive(false);

        baitHealth--;
    }

    private void HQOff()
    {
        Debug.Log("Turned off");
        obtainedHooked.SetActive(false);
        obtainedHQ.SetActive(true);

        isFishing = false;
        hooked = false;
        HQOBT = false;
        reelPosition = 5;

        Invoke("TurnoffHQLQ", 3.0f);

        GameController.gameControllerInstance.matRawHQFish++;
    }

    private void LQOff()
    {
        Debug.Log("Turned off");

        obtainedHooked.SetActive(false);
        obtainedLQ.SetActive(true);

        isFishing = false;
        hooked = false;
        LQOBT = false;
        reelPosition = 5;

        Invoke("TurnoffHQLQ", 3.0f);

        GameController.gameControllerInstance.matRawLQFish++;
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

    private void TurnoffHQLQ()
    {
        obtainedLQ.SetActive(false);
        obtainedHQ.SetActive(false);


    }

    private void FillBottle()
    {
        GameController.gameControllerInstance.matBottle--;
        GameController.gameControllerInstance.hasuncleanWater++;

        isFilling = false;
    }

    public void StartFishing()
    {
        Debug.Log("Throwing Line!");

        Invoke("ThrowingLine", 1.0f);
        reelPosition = 5;
        baitHealth = 4;

        fishOrFillPanel.SetActive(false);


        myAudioSource.pitch = Random.Range(0.8f, 1.2f);
        myAudioSource.PlayOneShot(throwLineinWater, 0.5f);

        GameController.gameControllerInstance.hasBait -= 1;
    }

    public void StartFillingBottle()
    {
        myAudioSource.pitch = Random.Range(0.8f, 1.2f);
        myAudioSource.PlayOneShot(fillWater, 0.5f);

        fishOrFillPanel.SetActive(false);

        isFilling = true;
        Invoke("FillBottle", 6.0f);
    }

    public void QuitMenu()
    {
        fishOrFillPanel.SetActive(false);
    }
}
