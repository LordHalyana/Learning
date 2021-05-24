using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    //Public Variables.
    public static GameController gameControllerInstance;
    public GameObject Energy01, Energy02, Energy03, Energy04, Energy04BG;
    public GameObject Health01, Health02, Health03, Health04, Health05, Health06, Health07, Health08, Health09, Health10;  
    public GameObject pausePanel, optionsPanel, carryingPanel, equipmentPanel, materialPanel;
    public GameObject ObtainedFirstAid, ObtainedBandage, ObtainedAntibiotics, ObtainedAdrenaline, ObtainedLunchBox, ObtainedFish, ObtainedBlueberry, ObtainedHurtigSnack, ObtainedWaterBottle, ObtainedUncleanWater, ObtainedFastorade, ObtainedblueOx, ObtainedFishingRod, ObtainedBait;
    public Slider playerHungerSlider;
    public Slider playerThirstSlider;
    public Image sliderHungerFill;
    public Image sliderThirstFill;
    public Text carryingCapText;
    public int carryingCapacity = 30;
    public int increasedCarryingCapacity = 0;
    public int maxTotalCarryingCapacity;
    public int currentCarryingCapacity;
    


    //Hidden Public Variables.
    [HideInInspector]
    public bool isPaused;
    [HideInInspector]
    public bool openFirstAidKitTab, openFirstAidKitDescription, openLunchBoxTab, openLunchBoxDescription, openWaterBottleTab, OpenWaterBottleDescription, openBandagesTab, openBandagesDescription, openUncleanWaterTab, openUncleanWaterDescription, openFishtab, openFishDescription, openBlueBerryTab, openBlueberryDescription, openHurtigSnackTab, openHurtigSnackDescription, openBlueOxTab, openBlueOxDescription, openAdrenalineTab, openAdrenalineDescription, openAntibioticsTab, openAntibioticsDescription, openSportDrinkTab, openSportDrinkDescription, openFishingrodDescription, openMaterialTab;
    [HideInInspector]
    public bool UCW_DBU;

    //Public Variables Items.
    public GameObject firstAidKitPanel, firstAidKitDescriptionPanel, LunchBoxPanel, LunchBoxDescriptionPanel, WaterBottlePanel, WaterBottleDescriptionPanel, bandagesPanel, bandagesDescriptionPanel, uncleanWaterPanel, uncleanWaterDescriptionPanel, fishPanel, fishDescriptionPanel, blueberryPanel, blueberryDescriptionPanel, HurtigSnackPanel, HurtigSnackDescriptionPanel, blueOxPanel, blueOxDescriptionPanel, adrenalinePanel, adrenalineDescriptionPanel, antibioticsPanel, antibioticsDescriptionPanel, sportDrinkPanel, sportDrinkDescriptionPanel, fishingrodDescriptionPanel;
    public GameObject firstAidKitImage, LunchBoxImage, WaterBottleImage, bandagesImage, uncleanWaterImage, fishImage, blueberryImage, HurtigSnackImage, blueOxImage, adrenalineImage, antibioticsImage, sportDrinkImage, fishingrodImage;
    public Text firstAidText, LunchBoxText, WaterBottleText, bandagesText, uncleanWaterText, fishText, blueberryText, HurtigSnackText, blueOxText, adrenalineText, antibioticsText, sportDrinkText;
    public Text matBottleText, matRawLQFishText, matRawHQFishText, baitText, fishingrodText;
    [HideInInspector]
    public int hasFirstAidKit, hasLunchBox, hasWaterBottle, hasBandages, hasuncleanWater, hasFish, hasBlueberry, hasHurtigSnack, hasBlueOx, hasAdrenaline, hasAntibiotics, hasSportDrink;
    [HideInInspector]
    public int hasFishingrod, hasBait ,matBottle, matRawLQFish, matRawHQFish;

    //Private Variables.
    private Player myPlayer;
    
    

    void Start ()
    {
        isPaused = false;

        myPlayer = FindObjectOfType<Player>();

        gameControllerInstance = this;

        maxTotalCarryingCapacity = carryingCapacity + increasedCarryingCapacity;

        //Inventory and Options.
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        carryingPanel.SetActive(false);
        equipmentPanel.SetActive(false);
        materialPanel.SetActive(false);

        //Obtained text.
        ObtainedAdrenaline.SetActive(false);
        ObtainedAntibiotics.SetActive(false);
        ObtainedBandage.SetActive(false);
        ObtainedBlueberry.SetActive(false);
        ObtainedblueOx.SetActive(false);
        ObtainedFastorade.SetActive(false);
        ObtainedFirstAid.SetActive(false);
        ObtainedFish.SetActive(false); ;
        ObtainedHurtigSnack.SetActive(false);
        ObtainedLunchBox.SetActive(false);
        ObtainedUncleanWater.SetActive(false);
        ObtainedWaterBottle.SetActive(false);



        //Sets all Stamina bolts to be turned on.
        Energy01.SetActive(true);
        Energy02.SetActive(true);
        Energy03.SetActive(true);
        Energy04BG.SetActive(false);
        Energy04.SetActive(false);

        //Sets all Health Hearts to be turned on.
        Health01.SetActive(true);
        Health02.SetActive(true);
        Health03.SetActive(true);
        Health04.SetActive(true);
        Health05.SetActive(true);
        Health06.SetActive(true);
        Health07.SetActive(true);
        Health08.SetActive(true);
        Health09.SetActive(true);
        Health10.SetActive(true);
    }
	
	void Update ()
    {
        carryingCapText.text = "Bærekapasitet: " + currentCarryingCapacity + "/" + maxTotalCarryingCapacity;
        currentCarryingCapacity = hasBandages + hasFirstAidKit + hasLunchBox + hasWaterBottle + hasuncleanWater + hasFish + hasHurtigSnack + hasBlueOx + hasAdrenaline + hasAntibiotics + hasSportDrink;

        //HealthBar.
        if (myPlayer.currentHealth == 10)
        {
            Health10.SetActive(true);
            Health09.SetActive(true);
            Health08.SetActive(true);
            Health07.SetActive(true);
            Health06.SetActive(true);
            Health05.SetActive(true);
            Health04.SetActive(true);    
            Health03.SetActive(true);
            Health02.SetActive(true);
            Health01.SetActive(true);
        }
        if (myPlayer.currentHealth == 9)
        {
            Health10.SetActive(false);
            Health09.SetActive(true);
            Health08.SetActive(true);
            Health07.SetActive(true);
            Health06.SetActive(true);
            Health05.SetActive(true);
            Health04.SetActive(true);
            Health03.SetActive(true);
            Health02.SetActive(true);
            Health01.SetActive(true);
        }
        if (myPlayer.currentHealth == 8)
        {
            Health10.SetActive(false);
            Health09.SetActive(false);
            Health08.SetActive(true);
            Health07.SetActive(true);
            Health06.SetActive(true);
            Health05.SetActive(true);
            Health04.SetActive(true);
            Health03.SetActive(true);
            Health02.SetActive(true);
            Health01.SetActive(true);
        }
        if (myPlayer.currentHealth == 7)
        {
            Health10.SetActive(false);
            Health09.SetActive(false);
            Health08.SetActive(false);
            Health07.SetActive(true);
            Health06.SetActive(true);
            Health05.SetActive(true);
            Health04.SetActive(true);
            Health03.SetActive(true);
            Health02.SetActive(true);
            Health01.SetActive(true);
        }
        if (myPlayer.currentHealth == 6)
        {
            Health10.SetActive(false);
            Health09.SetActive(false);
            Health08.SetActive(false);
            Health07.SetActive(false);
            Health06.SetActive(true);
            Health05.SetActive(true);
            Health04.SetActive(true);
            Health03.SetActive(true);
            Health02.SetActive(true);
            Health01.SetActive(true);
        }
        if (myPlayer.currentHealth == 5)
        {
            Health10.SetActive(false);
            Health09.SetActive(false);
            Health08.SetActive(false);
            Health07.SetActive(false);
            Health06.SetActive(false);
            Health05.SetActive(true);
            Health04.SetActive(true);
            Health03.SetActive(true);
            Health02.SetActive(true);
            Health01.SetActive(true);
        }
        if (myPlayer.currentHealth == 4)
        {
            Health10.SetActive(false);
            Health09.SetActive(false);
            Health08.SetActive(false);
            Health07.SetActive(false);
            Health06.SetActive(false);
            Health05.SetActive(false);
            Health04.SetActive(true);
            Health03.SetActive(true);
            Health02.SetActive(true);
            Health01.SetActive(true);
        }
        if (myPlayer.currentHealth == 3)
        {
            Health10.SetActive(false);
            Health09.SetActive(false);
            Health08.SetActive(false);
            Health07.SetActive(false);
            Health06.SetActive(false);
            Health05.SetActive(false);
            Health04.SetActive(false);
            Health03.SetActive(true);
            Health02.SetActive(true);
            Health01.SetActive(true);
        }
        if (myPlayer.currentHealth == 2)
        {
            Health10.SetActive(false);
            Health09.SetActive(false);
            Health08.SetActive(false);
            Health07.SetActive(false);
            Health06.SetActive(false);
            Health05.SetActive(false);
            Health04.SetActive(false);
            Health03.SetActive(false);
            Health02.SetActive(true);
            Health01.SetActive(true);
        }
        if (myPlayer.currentHealth == 1)
        {
            Health10.SetActive(false);
            Health09.SetActive(false);
            Health08.SetActive(false);
            Health07.SetActive(false);
            Health06.SetActive(false);
            Health05.SetActive(false);
            Health04.SetActive(false);
            Health03.SetActive(false);
            Health02.SetActive(false);
            Health01.SetActive(true);
        }
        if (myPlayer.currentHealth <= 0)
        {
            Health10.SetActive(false);
            Health09.SetActive(false);
            Health08.SetActive(false);
            Health07.SetActive(false);
            Health06.SetActive(false);
            Health05.SetActive(false);
            Health04.SetActive(false);
            Health03.SetActive(false);
            Health02.SetActive(false);
            Health01.SetActive(false);
        }

        //StaminaBar.
        if (myPlayer.sprintAvail == 4)
        {
            Energy04.SetActive(true);
            Energy03.SetActive(true);
            Energy02.SetActive(true);
            Energy01.SetActive(true);
        }
        if (myPlayer.maxSprint == 4)
        {
            Energy04BG.SetActive(true);
        }
        else
        {
            Energy04BG.SetActive(false);
        }
        if (myPlayer.sprintAvail == 3)
        {
            Energy04.SetActive(false);
            Energy03.SetActive(true);
            Energy02.SetActive(true);
            Energy01.SetActive(true);
        }
        if (myPlayer.sprintAvail == 2)
        {
            Energy03.SetActive(false);
            Energy02.SetActive(true);
            Energy04.SetActive(false);
            Energy01.SetActive(true);
        }
        if (myPlayer.sprintAvail == 1)
        {
            Energy02.SetActive(false);
            Energy01.SetActive(true);
            Energy03.SetActive(false);
            Energy04.SetActive(false);
        }
        if (myPlayer.sprintAvail == 0)
        {
            Energy01.SetActive(false);
            Energy02.SetActive(false);
            Energy03.SetActive(false);
            Energy04.SetActive(false);
        }

        //HungerBar.
        playerHungerSlider.value = myPlayer.Hunger;

        if(myPlayer.Hunger >= 1)
        {
            sliderHungerFill.color = Color.yellow;
        }
        else
        {
            sliderHungerFill.color = Color.clear;
        }

        //ThirstBar.
        playerThirstSlider.value = myPlayer.Thirst;

        if(myPlayer.Thirst >= 1)
        {
            sliderThirstFill.color = Color.blue;
        }
        else
        {
            sliderThirstFill.color = Color.clear;
        }

        //Inventory.
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0.5f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }

        //First Aid Kit Stuff.
        if (hasFirstAidKit <= 0)
        {
            firstAidKitImage.SetActive(false);
        }
        else
        {
            firstAidKitImage.SetActive(true);
        }
        if (openFirstAidKitTab)
        {
            firstAidKitPanel.SetActive(true);
        } 
        else
        {
            firstAidKitPanel.SetActive(false);
        }
        if (openFirstAidKitDescription)
        {
            firstAidKitDescriptionPanel.SetActive(true);
        } 
        else
        {
            firstAidKitDescriptionPanel.SetActive(false);

        }
        firstAidText.text = "Førstehjelpsskrin: " + hasFirstAidKit;


        //Lunch Box Stuff.
        if (hasLunchBox <= 0)
        {
            LunchBoxImage.SetActive(false);
        }
        else
        {
            LunchBoxImage.SetActive(true);
        }
        if (openLunchBoxTab)
        {
            LunchBoxPanel.SetActive(true);
        }
        else
        {
            LunchBoxPanel.SetActive(false);
        }
        if (openLunchBoxDescription)
        {
            LunchBoxDescriptionPanel.SetActive(true);
        }
        else
        {
            LunchBoxDescriptionPanel.SetActive(false);

        }
        LunchBoxText.text = "Matpakke: " + hasLunchBox;

        //WaterBottle Stuff.
        if (hasWaterBottle <= 0)
        {
            WaterBottleImage.SetActive(false);
        }
        else
        {
            WaterBottleImage.SetActive(true);
        }
        if (openWaterBottleTab)
        {
            WaterBottlePanel.SetActive(true);
        }
        else
        {
            WaterBottlePanel.SetActive(false);
        }
        if (OpenWaterBottleDescription)
        {
            WaterBottleDescriptionPanel.SetActive(true);
        }
        else
        {
            WaterBottleDescriptionPanel.SetActive(false);

        }
        WaterBottleText.text = "Flaske Vann: " + hasWaterBottle;

        //Bandages Stuff.
        if (hasBandages <= 0)
        {
            bandagesImage.SetActive(false);
        }
        else
        {
            bandagesImage.SetActive(true);
        }
        if (openBandagesTab)
        {
            bandagesPanel.SetActive(true);
        }
        else
        {
            bandagesPanel.SetActive(false);
        }
        if (openBandagesDescription)
        {
            bandagesDescriptionPanel.SetActive(true);
        }
        else
        {
            bandagesDescriptionPanel.SetActive(false);

        }
        bandagesText.text = "Bandasje: " + hasBandages;

        //Unclean Water Stuff.
        if (hasuncleanWater <= 0)
        {
            uncleanWaterImage.SetActive(false);
        }
        else
        {
            uncleanWaterImage.SetActive(true);
        }
        if (openUncleanWaterTab)
        {
            uncleanWaterPanel.SetActive(true);
        }
        else
        {
            uncleanWaterPanel.SetActive(false);
        }
        if (openUncleanWaterDescription)
        {
            uncleanWaterDescriptionPanel.SetActive(true);
        }
        else
        {
            uncleanWaterDescriptionPanel.SetActive(false);

        }
        uncleanWaterText.text = "Skittent Vann: " + hasuncleanWater;

        //Fish Stuff.
        if (hasFish <= 0)
        {
            fishImage.SetActive(false);
        }
        else
        {
            fishImage.SetActive(true);
        }
        if (openFishtab)
        {
            fishPanel.SetActive(true);
        }
        else
        {
            fishPanel.SetActive(false);
        }
        if (openFishDescription)
        {
            fishDescriptionPanel.SetActive(true);
        }
        else
        {
            fishDescriptionPanel.SetActive(false);

        }
        fishText.text = "Stekt Fisk: " + hasFish;

        //Blueberry Stuff.
        if (hasBlueberry <= 0)
        {
            blueberryImage.SetActive(false);
        }
        else
        {
            blueberryImage.SetActive(true);
        }
        if (openBlueBerryTab)
        {
            blueberryPanel.SetActive(true);
        }
        else
        {
            blueberryPanel.SetActive(false);
        }
        if (openBlueberryDescription)
        {
            blueberryDescriptionPanel.SetActive(true);
        }
        else
        {
            blueberryDescriptionPanel.SetActive(false);

        }
        blueberryText.text = "Blåbær: " + hasBlueberry;

        //HurtigSnack Stuff.
        if (hasHurtigSnack <= 0)
        {
            HurtigSnackImage.SetActive(false);
        }
        else
        {
            HurtigSnackImage.SetActive(true);
        }
        if (openHurtigSnackTab)
        {
            HurtigSnackPanel.SetActive(true);
        }
        else
        {
            HurtigSnackPanel.SetActive(false);
        }
        if (openHurtigSnackDescription)
        {
            HurtigSnackDescriptionPanel.SetActive(true);
        }
        else
        {
            HurtigSnackDescriptionPanel.SetActive(false);

        }
        HurtigSnackText.text = "Hurtig Snack: " + hasHurtigSnack;

        //BlueOx Stuff.
        if (hasBlueOx <= 0)
        {
            blueOxImage.SetActive(false);
        }
        else
        {
            blueOxImage.SetActive(true);
        }
        if (openBlueOxTab)
        {
            blueOxPanel.SetActive(true);
        }
        else
        {
            blueOxPanel.SetActive(false);
        }
        if (openBlueOxDescription)
        {
            blueOxDescriptionPanel.SetActive(true);
        }
        else
        {
            blueOxDescriptionPanel.SetActive(false);

        }
        blueOxText.text = "Blue Oxen: " + hasBlueOx;

        //Adrenaline Stuff.
        if (hasAdrenaline <= 0)
        {
            adrenalineImage.SetActive(false);
        }
        else
        {
            adrenalineImage.SetActive(true);
        }
        if (openAdrenalineTab)
        {
            adrenalinePanel.SetActive(true);
        }
        else
        {
            adrenalinePanel.SetActive(false);
        }
        if (openAdrenalineDescription)
        {
            adrenalineDescriptionPanel.SetActive(true);
        }
        else
        {
            adrenalineDescriptionPanel.SetActive(false);

        }
        adrenalineText.text = "Adrenalin Sprøyte: " + hasAdrenaline;

        //Antibiotics Stuff.
        if (hasAntibiotics <= 0)
        {
            antibioticsImage.SetActive(false);
        }
        else
        {
            antibioticsImage.SetActive(true);
        }
        if (openAntibioticsTab)
        {
            antibioticsPanel.SetActive(true);
        }
        else
        {
            antibioticsPanel.SetActive(false);
        }
        if (openAntibioticsDescription)
        {
            antibioticsDescriptionPanel.SetActive(true);
        }
        else
        {
            antibioticsDescriptionPanel.SetActive(false);

        }
        antibioticsText.text = "Antibiotika: " + hasAntibiotics;

        //SportDrink Stuff.
        if (hasSportDrink <= 0)
        {
            sportDrinkImage.SetActive(false);
        }
        else
        {
            sportDrinkImage.SetActive(true);
        }
        if (openSportDrinkTab)
        {
            sportDrinkPanel.SetActive(true);
        }
        else
        {
            sportDrinkPanel.SetActive(false);
        }
        if (openSportDrinkDescription)
        {
            sportDrinkDescriptionPanel.SetActive(true);
        }
        else
        {
            sportDrinkDescriptionPanel.SetActive(false);

        }
        sportDrinkText.text = "Sports Drikke: " + hasSportDrink;

        //FishingRod Stuff
        if (hasFishingrod <= 0)
        {
            fishingrodImage.SetActive(false);
        }
        else
        {
            fishingrodImage.SetActive(true);
        }
        if (openFishingrodDescription)
        {
            fishingrodDescriptionPanel.SetActive(true);
        }
        else
        {
            fishingrodDescriptionPanel.SetActive(false);
        }
        baitText.text = "Antall Agn: " + hasBait;

        //Material Stuff
        if (openMaterialTab)
        {
            materialPanel.SetActive(true);
        }
        else
        {
            materialPanel.SetActive(false);
        }

        matBottleText.text = "Tom Flaske: " + matBottle;
        matRawLQFishText.text = "Rå Fisk: " + matRawLQFish;
        matRawHQFishText.text = "Fin Rå Fisk: " + matRawHQFish;



    }

    //Inventory and Options Menu.
    public void PauseSwitch()
    {
        isPaused = !isPaused;
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void OptionsMenu()
    {
        optionsPanel.SetActive(true);
    }
    public void ExitOptionsMenu()
    {
        optionsPanel.SetActive(false);
    }
    public void EquipmentMenu()
    {
        equipmentPanel.SetActive(true);
    }
    public void CloseEquipmentMenu()
    {
        equipmentPanel.SetActive(false);
    }
    public void MaterialMenu()
    {
        openMaterialTab = !openMaterialTab;
    }
    public void OpenFishingDescriptionMenu()
    {
        openFishingrodDescription = !openFishingrodDescription;
    }

    //Item RNG System.
    public void GiveItem(int itemToGive)
    {
        //Includes White - Green - Blue Quality items ONLY.
        if (itemToGive == 0)
        {
            hasFirstAidKit++;
            ObtainedFirstAid.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 1)
        {
            hasLunchBox++;
            ObtainedLunchBox.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 2)
        {
            hasWaterBottle++;
            ObtainedWaterBottle.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 3)
        {
            hasBandages++;
            ObtainedBandage.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 4)
        {
            if (GameController.gameControllerInstance.currentCarryingCapacity <= (GameController.gameControllerInstance.currentCarryingCapacity - 2))
            {
                hasBandages += 2;
            }
            else
            {
                hasBandages++;
            }
            ObtainedBandage.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 5)
        {
            hasuncleanWater++;
            ObtainedUncleanWater.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 6)
        {
            hasFish++;
            ObtainedFish.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 7)
        {
            hasBlueberry += 5;
            ObtainedBlueberry.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 8)
        {
            hasBlueberry += 10;
            ObtainedBlueberry.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 9)
        {
            hasHurtigSnack++;
            ObtainedHurtigSnack.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 10)
        {
            hasBlueOx++;
            ObtainedblueOx.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 11)
        {
            hasAntibiotics++;
            ObtainedAntibiotics.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 12)
        {
            hasSportDrink++;
            ObtainedFastorade.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 13)
        {
            if (hasFishingrod == 0)
            {
                hasFishingrod++;
                hasBait += 5;
                ObtainedFishingRod.SetActive(true);
                Invoke("HideObtainedText", 3);
            }
            else
            {
                hasBait += 10;
                ObtainedBait.SetActive(true);
                Invoke("HideObtainedText", 3);
            }

        }
    }

    public void GiveHighItem(int itemToGive)
    {
        //Includes Green - Blue - Purple Quality items ONLY.
        if (itemToGive == 0)
        {
            hasFirstAidKit++;
            ObtainedFirstAid.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 1)
        {
            hasLunchBox++;
            ObtainedLunchBox.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 2)
        {
            hasWaterBottle++;
            ObtainedWaterBottle.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 3)
        {
            if (currentCarryingCapacity >= (maxTotalCarryingCapacity - 2))
            {
                hasWaterBottle += 2;
            }
            else
            {
                hasWaterBottle += 1;
            }
            ObtainedWaterBottle.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 4)
        {
            hasHurtigSnack++;
            ObtainedHurtigSnack.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 5)
        {
            hasBlueOx++;
            ObtainedblueOx.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 6)
        {
            hasAdrenaline++;
            ObtainedAdrenaline.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 7)
        {
            hasAntibiotics++;
            ObtainedAntibiotics.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 8)
        {
            hasSportDrink++;
            ObtainedFastorade.SetActive(true);
            Invoke("HideObtainedText", 3);
        }
        if (itemToGive == 9)
        {
            if (hasFishingrod == 0)
            {
                hasFishingrod++;
                hasBait += 5;
                ObtainedFishingRod.SetActive(true);
                Invoke("HideObtainedText", 3);
            }
            else
            {
                hasBait += 10;
                ObtainedBait.SetActive(true);
                Invoke("HideObtainedText", 3);
            }

        }
    }

    private void HideObtainedText()
    {
        ObtainedAdrenaline.SetActive(false);
        ObtainedAntibiotics.SetActive(false);
        ObtainedBandage.SetActive(false);
        ObtainedBlueberry.SetActive(false);
        ObtainedblueOx.SetActive(false);
        ObtainedFastorade.SetActive(false);
        ObtainedFirstAid.SetActive(false);
        ObtainedFish.SetActive(false);
        ObtainedHurtigSnack.SetActive(false);
        ObtainedLunchBox.SetActive(false);
        ObtainedUncleanWater.SetActive(false);
        ObtainedWaterBottle.SetActive(false);
        ObtainedBait.SetActive(false);
        ObtainedFishingRod.SetActive(false);
    }
    //Inventory System.

    //First Aid kit Functions.
    public void OpenFirstAidKit()
    {
        openFirstAidKitTab = !openFirstAidKitTab;

        if (openAdrenalineTab || openAntibioticsTab || openBandagesTab || openBlueBerryTab || openBlueOxTab ||  openFishtab || openHurtigSnackTab || openLunchBoxTab || openSportDrinkTab || openUncleanWaterTab || openWaterBottleTab)
        {
            if (openAdrenalineTab)
            {
                openAdrenalineTab = !openAdrenalineTab;
            }
            if (openAntibioticsTab)
            {
                openAntibioticsTab = !openAntibioticsTab;
            }
            if (openBandagesTab)
            {
                openBandagesTab = !openBandagesTab;
            }
            if (openBlueBerryTab)
            {
                openBlueBerryTab = !openBlueBerryTab;
            }
            if (openWaterBottleTab)
            {
                openWaterBottleTab = !openWaterBottleTab;
            }
            if (openBlueOxTab)
            {
                openBlueOxTab = !openBlueOxTab;
            }
            if (openFishtab)
            {
                openFishtab = !openFishtab;
            }
            if (openHurtigSnackTab)
            {
                openHurtigSnackTab = !openHurtigSnackTab;
            }
            if (openLunchBoxTab)
            {
                openLunchBoxTab = !openLunchBoxTab;
            }
            if (openSportDrinkTab)
            {
                openSportDrinkTab = !openSportDrinkTab;
            }
            if (openUncleanWaterTab)
            {
                openUncleanWaterTab = !openUncleanWaterTab;
            }
        }



    }
    public void UseFirstAidKit()
    {
        if (hasFirstAidKit >= 1 && myPlayer.currentHealth < myPlayer.maxHealth)
        {
            myPlayer.currentHealth += 10;

            hasFirstAidKit -= 1;

        }
        
    }
    public void DropFirstAidKit()
    {
        if (hasFirstAidKit >= 1)
        {
            hasFirstAidKit -= 1;

        }
    }
    public void DescriptionFirstAidKit()
    {
        openFirstAidKitDescription = !openFirstAidKitDescription;
    }
    public void PickUpFirstAidKit(int numberOfFirstAidKits)
    {
        hasFirstAidKit += numberOfFirstAidKits;
    }

    //LunchBox Functions.
    public void OpenLunchBox()
    {
        openLunchBoxTab = !openLunchBoxTab;

        if (openAdrenalineTab || openAntibioticsTab || openBandagesTab || openBlueBerryTab || openBlueOxTab || openFirstAidKitTab || openFishtab || openHurtigSnackTab ||  openSportDrinkTab || openUncleanWaterTab || openWaterBottleTab)
        {
            if (openAdrenalineTab)
            {
                openAdrenalineTab = !openAdrenalineTab;
            }
            if (openAntibioticsTab)
            {
                openAntibioticsTab = !openAntibioticsTab;
            }
            if (openBandagesTab)
            {
                openBandagesTab = !openBandagesTab;
            }
            if (openBlueBerryTab)
            {
                openBlueBerryTab = !openBlueBerryTab;
            }
            if (openWaterBottleTab)
            {
                openWaterBottleTab = !openWaterBottleTab;
            }
            if (openBlueOxTab)
            {
                openBlueOxTab = !openBlueOxTab;
            }
            if (openFirstAidKitTab)
            {
                openFirstAidKitTab = !openFirstAidKitTab;
            }
            if (openFishtab)
            {
                openFishtab = !openFishtab;
            }
            if (openHurtigSnackTab)
            {
                openHurtigSnackTab = !openHurtigSnackTab;
            }
            if (openSportDrinkTab)
            {
                openSportDrinkTab = !openSportDrinkTab;
            }
            if (openUncleanWaterTab)
            {
                openUncleanWaterTab = !openUncleanWaterTab;
            }
        }
    }
    public void UseLunchBox()
    {
        if (hasLunchBox >= 1 && myPlayer.Hunger < 100.0f)
        {
            myPlayer.Hunger += 100.0f;

            hasLunchBox -= 1;

        }

    }
    public void DropLunchBox()
    {
        if (hasLunchBox >= 1)
        {
            hasLunchBox -= 1;

        }
    }
    public void DescriptionLunchBox()
    {
        openLunchBoxDescription = !openLunchBoxDescription;
    }
    public void PickUpLunchBox(int numberOfLunchBoxes)
    {
        hasLunchBox += numberOfLunchBoxes;
    }

    //WaterBottle Functions.
    public void OpenWaterBottle()
    {
        openWaterBottleTab = !openWaterBottleTab;

        if (openAdrenalineTab || openAntibioticsTab || openBandagesTab || openBlueBerryTab || openBlueOxTab || openFirstAidKitTab || openFishtab || openHurtigSnackTab || openLunchBoxTab || openSportDrinkTab || openUncleanWaterTab)
        {
            if (openAdrenalineTab)
            {
                openAdrenalineTab = !openAdrenalineTab;
            }
            if (openAntibioticsTab)
            {
                openAntibioticsTab = !openAntibioticsTab;
            }
            if (openBandagesTab)
            {
                openBandagesTab = !openBandagesTab;
            }
            if (openBlueBerryTab)
            {
                openBlueBerryTab = !openBlueBerryTab;
            }
            if (openBlueOxTab)
            {
                openBlueOxTab = !openBlueOxTab;
            }
            if (openFirstAidKitTab)
            {
                openFirstAidKitTab = !openFirstAidKitTab;
            }
            if (openFishtab)
            {
                openFishtab = !openFishtab;
            }
            if (openHurtigSnackTab)
            {
                openHurtigSnackTab = !openHurtigSnackTab;
            }
            if (openLunchBoxTab)
            {
                openLunchBoxTab = !openLunchBoxTab;
            }
            if (openSportDrinkTab)
            {
                openSportDrinkTab = !openSportDrinkTab;
            }
            if (openUncleanWaterTab)
            {
                openUncleanWaterTab = !openUncleanWaterTab;
            }
        }
    }
    public void UseWaterBottle()
    {
        if (hasWaterBottle >= 1 && myPlayer.Thirst < 100.0f)
        {
            myPlayer.Thirst += 100.0f;

            hasWaterBottle -= 1;
            matBottle += 1;


        }

    }
    public void DroptWaterBottle()
    {
        if (hasWaterBottle >= 1)
        {
            hasWaterBottle -= 1;

        }
    }
    public void DescriptionWaterBottle()
    {
        OpenWaterBottleDescription = !OpenWaterBottleDescription;
    }
    public void PickUpWaterBottle(int numberOfWaterBottle)
    {
        hasWaterBottle += numberOfWaterBottle;
    }

    //Bandages Functions.
    public void OpenBandages()
    {
        openBandagesTab = !openBandagesTab;

        if (openAdrenalineTab || openAntibioticsTab || openBlueBerryTab || openBlueOxTab || openFirstAidKitTab || openFishtab || openHurtigSnackTab || openLunchBoxTab || openSportDrinkTab || openUncleanWaterTab || openWaterBottleTab)
        {
            if (openAdrenalineTab)
            {
                openAdrenalineTab = !openAdrenalineTab;
            }
            if (openAntibioticsTab)
            {
                openAntibioticsTab = !openAntibioticsTab;
            }
            if (openBlueBerryTab)
            {
                openBlueBerryTab = !openBlueBerryTab;
            }
            if (openWaterBottleTab)
            {
                openWaterBottleTab = !openWaterBottleTab;
            }
            if (openBlueOxTab)
            {
                openBlueOxTab = !openBlueOxTab;
            }
            if (openFirstAidKitTab)
            {
                openFirstAidKitTab = !openFirstAidKitTab;
            }
            if (openFishtab)
            {
                openFishtab = !openFishtab;
            }
            if (openHurtigSnackTab)
            {
                openHurtigSnackTab = !openHurtigSnackTab;
            }
            if (openLunchBoxTab)
            {
                openLunchBoxTab = !openLunchBoxTab;
            }
            if (openSportDrinkTab)
            {
                openSportDrinkTab = !openSportDrinkTab;
            }
            if (openUncleanWaterTab)
            {
                openUncleanWaterTab = !openUncleanWaterTab;
            }
        }
    }
    public void UseBandages()
    {
        if (hasBandages >= 1 && myPlayer.currentHealth < myPlayer.maxHealth)
        {
            myPlayer.currentHealth += 3;

            hasBandages -= 1;


        }

    }
    public void DropBandages()
    {
        if (hasBandages >= 1)
        {
            hasBandages -= 1;

        }
    }
    public void DescriptionBandages()
    {
        openBandagesDescription = !openBandagesDescription;
    }
    public void PickUpBandages(int numberOfBandages)
    {
        hasBandages += numberOfBandages;
    }

    //Unclean Water Functions.
    public void OpenUncleanWater()
    {
        openUncleanWaterTab = !openUncleanWaterTab;

        if (openAdrenalineTab || openAntibioticsTab || openBandagesTab || openBlueBerryTab || openBlueOxTab || openFirstAidKitTab || openFishtab || openHurtigSnackTab || openLunchBoxTab || openSportDrinkTab || openWaterBottleTab)
        {
            if (openAdrenalineTab)
            {
                openAdrenalineTab = !openAdrenalineTab;
            }
            if (openAntibioticsTab)
            {
                openAntibioticsTab = !openAntibioticsTab;
            }
            if (openBandagesTab)
            {
                openBandagesTab = !openBandagesTab;
            }
            if (openBlueBerryTab)
            {
                openBlueBerryTab = !openBlueBerryTab;
            }
            if (openWaterBottleTab)
            {
                openWaterBottleTab = !openWaterBottleTab;
            }
            if (openBlueOxTab)
            {
                openBlueOxTab = !openBlueOxTab;
            }
            if (openFirstAidKitTab)
            {
                openFirstAidKitTab = !openFirstAidKitTab;
            }
            if (openFishtab)
            {
                openFishtab = !openFishtab;
            }
            if (openHurtigSnackTab)
            {
                openHurtigSnackTab = !openHurtigSnackTab;
            }
            if (openLunchBoxTab)
            {
                openLunchBoxTab = !openLunchBoxTab;
            }
            if (openSportDrinkTab)
            {
                openSportDrinkTab = !openSportDrinkTab;
            }
        }
    }
    public void UseUncleanWater()
    {
        if (hasuncleanWater >= 1 && myPlayer.Thirst < 100.0f)
        {
            myPlayer.Thirst += 25.0f;

            hasuncleanWater -= 1;
            matBottle += 1;

            int randomNumber = Random.Range(0, 2);
            GameController.gameControllerInstance.UncleanWaterRNG(randomNumber);
        }

    }
    public void DropUncleanWater()
    {
        if (hasuncleanWater >= 1)
        {
            hasuncleanWater -= 1;

        }
    }
    public void DescriptionUncleanWater()
    {
        openUncleanWaterDescription = !openUncleanWaterDescription;
    }
    public void PickUpUncleanWater(int numberofUncleanWater)
    {
        hasuncleanWater += numberofUncleanWater;
    }
    private void UncleanWaterRNG(int RNG)
    {
        if (!UCW_DBU)
        {
            if (RNG == 0)
            {
                Debug.Log("You managed to chug it down without dying in the process, good job!");
            }
            if (RNG == 1)
            {
                Debug.Log("Ouch, the water was nasty and got you all poisoned up and shit...");

                myPlayer.sprintRegenMultiplier += 0.5f;

                Invoke("UncleanWaterOff", 180.0f);

                UCW_DBU = true;

                //HUD icon pop up whenever I am free to do so.
            }
            if (RNG == 2)
            {
                Debug.Log("You managed to chug it down without dying in the process, good job!");
            }
        }
    }
    private void UnCleanWaterOff()
    {
        myPlayer.sprintRegenMultiplier -= 0.5f;

        UCW_DBU = false;
    }

    //Fish Functions.
    public void OpenFish()
    {
        openFishtab = !openFishtab;

        if (openAdrenalineTab || openAntibioticsTab || openBandagesTab || openBlueBerryTab || openBlueOxTab || openFirstAidKitTab || openHurtigSnackTab || openLunchBoxTab || openSportDrinkTab || openUncleanWaterTab || openWaterBottleTab)
        {
            if (openAdrenalineTab)
            {
                openAdrenalineTab = !openAdrenalineTab;
            }
            if (openAntibioticsTab)
            {
                openAntibioticsTab = !openAntibioticsTab;
            }
            if (openBandagesTab)
            {
                openBandagesTab = !openBandagesTab;
            }
            if (openBlueBerryTab)
            {
                openBlueBerryTab = !openBlueBerryTab;
            }
            if (openWaterBottleTab)
            {
                openWaterBottleTab = !openWaterBottleTab;
            }
            if (openBlueOxTab)
            {
                openBlueOxTab = !openBlueOxTab;
            }
            if (openFirstAidKitTab)
            {
                openFirstAidKitTab = !openFirstAidKitTab;
            }
            if (openHurtigSnackTab)
            {
                openHurtigSnackTab = !openHurtigSnackTab;
            }
            if (openLunchBoxTab)
            {
                openLunchBoxTab = !openLunchBoxTab;
            }
            if (openSportDrinkTab)
            {
                openSportDrinkTab = !openSportDrinkTab;
            }
            if (openUncleanWaterTab)
            {
                openUncleanWaterTab = !openUncleanWaterTab;
            }
        }
    }
    public void UseFish()
    {
        if (hasFish >= 1 && myPlayer.Hunger < 100.0f)
        {
            myPlayer.Hunger += 50.0f;

            hasFish -= 1;

        }

    }
    public void DropFish()
    {
        if (hasFish >= 1)
        {
            hasFish -= 1;

        }
    }
    public void DescriptionFish()
    {
        openFishDescription = !openFishDescription;
    }
    public void PickUpFish(int numberOfFish)
    {
        hasFish += numberOfFish;
    }

    //Blueberry Functions.
    public void OpenBlueberry()
    {
        openBlueBerryTab = !openBlueBerryTab;

        if (openAdrenalineTab || openAntibioticsTab || openBandagesTab || openBlueOxTab || openFirstAidKitTab || openFishtab || openHurtigSnackTab || openLunchBoxTab || openSportDrinkTab || openUncleanWaterTab || openWaterBottleTab)
        {
            if (openAdrenalineTab)
            {
                openAdrenalineTab = !openAdrenalineTab;
            }
            if (openAntibioticsTab)
            {
                openAntibioticsTab = !openAntibioticsTab;
            }
            if (openBandagesTab)
            {
                openBandagesTab = !openBandagesTab;
            }
            if (openWaterBottleTab)
            {
                openWaterBottleTab = !openWaterBottleTab;
            }
            if (openBlueOxTab)
            {
                openBlueOxTab = !openBlueOxTab;
            }
            if (openFirstAidKitTab)
            {
                openFirstAidKitTab = !openFirstAidKitTab;
            }
            if (openFishtab)
            {
                openFishtab = !openFishtab;
            }
            if (openHurtigSnackTab)
            {
                openHurtigSnackTab = !openHurtigSnackTab;
            }
            if (openLunchBoxTab)
            {
                openLunchBoxTab = !openLunchBoxTab;
            }
            if (openSportDrinkTab)
            {
                openSportDrinkTab = !openSportDrinkTab;
            }
            if (openUncleanWaterTab)
            {
                openUncleanWaterTab = !openUncleanWaterTab;
            }
        }
    }
    public void UseBlueberry()
    {
        if (hasBlueberry >= 1 && myPlayer.Hunger < 100.0f)
        {
            myPlayer.Hunger += 5.0f;

            hasBlueberry -= 1;

        }

    }
    public void DropBlueberry()
    {
        if (hasBlueberry >= 1)
        {
            hasBlueberry -= 1;

        }
    }
    public void DescriptionBlueberry()
    {
        openBlueberryDescription = !openBlueberryDescription;
    }
    public void PickupBlueberry(int numberOfBlueberry)
    {
        hasBlueberry += numberOfBlueberry;
    }

    //HurtigSnack Functions.
    public void OpenHurtigSnack()
    {
        openHurtigSnackTab = !openHurtigSnackTab;

        if (openAdrenalineTab || openAntibioticsTab || openBandagesTab || openBlueBerryTab || openBlueOxTab || openFirstAidKitTab || openFishtab || openLunchBoxTab || openSportDrinkTab || openUncleanWaterTab || openWaterBottleTab)
        {
            if (openAdrenalineTab)
            {
                openAdrenalineTab = !openAdrenalineTab;
            }
            if (openAntibioticsTab)
            {
                openAntibioticsTab = !openAntibioticsTab;
            }
            if (openBandagesTab)
            {
                openBandagesTab = !openBandagesTab;
            }
            if (openBlueBerryTab)
            {
                openBlueBerryTab = !openBlueBerryTab;
            }
            if (openWaterBottleTab)
            {
                openWaterBottleTab = !openWaterBottleTab;
            }
            if (openBlueOxTab)
            {
                openBlueOxTab = !openBlueOxTab;
            }
            if (openFirstAidKitTab)
            {
                openFirstAidKitTab = !openFirstAidKitTab;
            }
            if (openFishtab)
            {
                openFishtab = !openFishtab;
            }
            if (openLunchBoxTab)
            {
                openLunchBoxTab = !openLunchBoxTab;
            }
            if (openSportDrinkTab)
            {
                openSportDrinkTab = !openSportDrinkTab;
            }
            if (openUncleanWaterTab)
            {
                openUncleanWaterTab = !openUncleanWaterTab;
            }
        }
    }
    public void UseHurtigSnack()
    {
        if (hasHurtigSnack >= 1 && myPlayer.Hunger < 100.0f)
        {
            myPlayer.Hunger += 25.0f;
            myPlayer.SendMessage("HurtigSnackBuff");

            hasHurtigSnack -= 1;
        }

    }
    public void DropHurtigSnack()
    {
        if (hasHurtigSnack >= 1)
        {
            hasHurtigSnack -= 1;

        }
    }
    public void DescriptionHurtigSnack()
    {
        openHurtigSnackDescription = !openHurtigSnackDescription;
    }
    public void PickUpHurtigSnack(int numberOfHS)
    {
        hasHurtigSnack += numberOfHS;
    }

    //BlueOx Functions.
    public void OpenBlueOx()
    {
        openBlueOxTab = !openBlueOxTab;

        if (openAdrenalineTab || openAntibioticsTab || openBandagesTab || openBlueBerryTab || openFirstAidKitTab || openFishtab || openHurtigSnackTab || openLunchBoxTab || openSportDrinkTab || openUncleanWaterTab || openWaterBottleTab)
        {
            if (openAdrenalineTab)
            {
                openAdrenalineTab = !openAdrenalineTab;
            }
            if (openAntibioticsTab)
            {
                openAntibioticsTab = !openAntibioticsTab;
            }
            if (openBandagesTab)
            {
                openBandagesTab = !openBandagesTab;
            }
            if (openBlueBerryTab)
            {
                openBlueBerryTab = !openBlueBerryTab;
            }
            if (openWaterBottleTab)
            {
                openWaterBottleTab = !openWaterBottleTab;
            }
            if (openFirstAidKitTab)
            {
                openFirstAidKitTab = !openFirstAidKitTab;
            }
            if (openFishtab)
            {
                openFishtab = !openFishtab;
            }
            if (openHurtigSnackTab)
            {
                openHurtigSnackTab = !openHurtigSnackTab;
            }
            if (openLunchBoxTab)
            {
                openLunchBoxTab = !openLunchBoxTab;
            }
            if (openSportDrinkTab)
            {
                openSportDrinkTab = !openSportDrinkTab;
            }
            if (openUncleanWaterTab)
            {
                openUncleanWaterTab = !openUncleanWaterTab;
            }
        }
    }
    public void UseBlueOx()
    {
        if (hasBlueOx >= 1)
        {
            myPlayer.Thirst += 10.0f;
            myPlayer.SendMessage("BlueOxBuff");

            hasBlueOx -= 1;
        }

    }
    public void DropBlueOx()
    {
        if (hasBlueOx >= 1)
        {
            hasBlueOx -= 1;

        }
    }
    public void DescriptionBlueOx()
    {
        openBlueOxDescription = !openBlueOxDescription;
    }
    public void PickUpBlueOx(int numberOfBlueOx)
    {
        hasBlueOx += numberOfBlueOx;
    }

    //Adrenaline Functions.
    public void OpenAdrenaline()
    {
        openAdrenalineTab = !openAdrenalineTab;

        if (openAntibioticsTab || openBandagesTab || openBlueBerryTab || openBlueOxTab || openFirstAidKitTab || openFishtab || openHurtigSnackTab || openLunchBoxTab || openSportDrinkTab || openUncleanWaterTab || openWaterBottleTab)
        {
            if (openAntibioticsTab)
            {
                openAntibioticsTab = !openAntibioticsTab;
            }
            if (openBandagesTab)
            {
                openBandagesTab = !openBandagesTab;
            }
            if (openBlueBerryTab)
            {
                openBlueBerryTab = !openBlueBerryTab;
            }
            if (openWaterBottleTab)
            {
                openWaterBottleTab = !openWaterBottleTab;
            }
            if (openBlueOxTab)
            {
                openBlueOxTab = !openBlueOxTab;
            }
            if (openFirstAidKitTab)
            {
                openFirstAidKitTab = !openFirstAidKitTab;
            }
            if (openFishtab)
            {
                openFishtab = !openFishtab;
            }
            if (openHurtigSnackTab)
            {
                openHurtigSnackTab = !openHurtigSnackTab;
            }
            if (openLunchBoxTab)
            {
                openLunchBoxTab = !openLunchBoxTab;
            }
            if (openSportDrinkTab)
            {
                openSportDrinkTab = !openSportDrinkTab;
            }
            if (openUncleanWaterTab)
            {
                openUncleanWaterTab = !openUncleanWaterTab;
            }
        }
    }
    public void UseAdrenaline()
    {
        if (hasAdrenaline >= 1)
        {
            myPlayer.Thirst -= 25.0f;
            myPlayer.SendMessage("AdrenalineBuff");

            hasAdrenaline -= 1;
        }

    }
    public void DropAdrenaline()
    {
        if (hasAdrenaline >= 1)
        {
            hasAdrenaline -= 1;

        }
    }
    public void DescriptionAdrenaline()
    {
        openAdrenalineDescription = !openAdrenalineDescription;
    }
    public void PickUpAdrenaline(int numberOfAdrenaline)
    {
        hasAdrenaline += numberOfAdrenaline;
    }

    //Antibiotics Functions.
    public void OpenAntibiotics()
    {
        openAntibioticsTab = !openAntibioticsTab;

        if (openAdrenalineTab || openBandagesTab || openBlueBerryTab || openBlueOxTab || openFirstAidKitTab || openFishtab || openHurtigSnackTab || openLunchBoxTab || openSportDrinkTab || openUncleanWaterTab || openWaterBottleTab)
        {
            if (openAdrenalineTab)
            {
                openAdrenalineTab = !openAdrenalineTab;
            }
            if (openBandagesTab)
            {
                openBandagesTab = !openBandagesTab;
            }
            if (openBlueBerryTab)
            {
                openBlueBerryTab = !openBlueBerryTab;
            }
            if (openWaterBottleTab)
            {
                openWaterBottleTab = !openWaterBottleTab;
            }
            if (openBlueOxTab)
            {
                openBlueOxTab = !openBlueOxTab;
            }
            if (openFirstAidKitTab)
            {
                openFirstAidKitTab = !openFirstAidKitTab;
            }
            if (openFishtab)
            {
                openFishtab = !openFishtab;
            }
            if (openHurtigSnackTab)
            {
                openHurtigSnackTab = !openHurtigSnackTab;
            }
            if (openLunchBoxTab)
            {
                openLunchBoxTab = !openLunchBoxTab;
            }
            if (openSportDrinkTab)
            {
                openSportDrinkTab = !openSportDrinkTab;
            }
            if (openUncleanWaterTab)
            {
                openUncleanWaterTab = !openUncleanWaterTab;
            }
        }
    }
    public void UseAntibiotics()
    {
        if (hasAntibiotics >= 1)
        {
            myPlayer.Thirst -= 10.0f;
            myPlayer.SendMessage("Antibiotics");

            hasAntibiotics -= 1;
        }

    }
    public void DropAntibiotics()
    {
        if (hasAntibiotics >= 1)
        {
            hasAntibiotics -= 1;

        }
    }
    public void DescriptionAntibiotics()
    {
        openAntibioticsDescription = !openAntibioticsDescription;
    }
    public void PickUpAntibiotics(int numberOfAntibiotics)
    {
        hasAntibiotics += numberOfAntibiotics;
    }

    //Sports Drink Functions.
    public void OpenSportsDrink()
    {
        openSportDrinkTab = !openSportDrinkTab;

        if (openAntibioticsTab || openAntibioticsTab || openBandagesTab || openBlueBerryTab || openBlueOxTab || openFirstAidKitTab || openFishtab || openHurtigSnackTab || openLunchBoxTab || openUncleanWaterTab || openWaterBottleTab)
        {
            if (openAdrenalineTab)
            {
                openAdrenalineTab = !openAdrenalineTab;
            }
            if (openAntibioticsTab)
            {
                openAntibioticsTab = !openAntibioticsTab;
            }
            if (openBandagesTab)
            {
                openBandagesTab = !openBandagesTab;
            }
            if (openBlueBerryTab)
            {
                openBlueBerryTab = !openBlueBerryTab;
            }
            if (openWaterBottleTab)
            {
                openWaterBottleTab = !openWaterBottleTab;
            }
            if (openBlueOxTab)
            {
                openBlueOxTab = !openBlueOxTab;
            }
            if (openFirstAidKitTab)
            {
                openFirstAidKitTab = !openFirstAidKitTab;
            }
            if (openFishtab)
            {
                openFishtab = !openFishtab;
            }
            if (openHurtigSnackTab)
            {
                openHurtigSnackTab = !openHurtigSnackTab;
            }
            if (openLunchBoxTab)
            {
                openLunchBoxTab = !openLunchBoxTab;
            }
            if (openUncleanWaterTab)
            {
                openUncleanWaterTab = !openUncleanWaterTab;
            }
        }
    }
    public void UseSportsDrink()
    {
        if (hasSportDrink >= 1)
        {
            myPlayer.Thirst += 50.0f;
            myPlayer.sprintAvail = myPlayer.maxSprint;
            myPlayer.SendMessage("SportsDrinkBuff");

            hasSportDrink -= 1;
        }

    }
    public void DropSportDrink()
    {
        if (hasSportDrink >= 1)
        {
            hasSportDrink -= 1;

        }
    }
    public void DescriptionSportsDrink()
    {
        openSportDrinkDescription = !openSportDrinkDescription;
    }
    public void PickUpSportsDrink(int numberOfSportsdrink)
    {
        hasSportDrink += numberOfSportsdrink;
    }

}

