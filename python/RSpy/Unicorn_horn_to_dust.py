import pyautogui as pag
import random
import time
#from PIL import Image

class RsPy:
    def __init__(self):
       # print('Say Cheeeeze. taking photo')
        #im2 = pag.screenshot(region=(1525, 950, 50, 55))
        #im2.save(r'screenshot/regionSS.png')
        self.prepwork()


    def prepwork(self):
        unicorn_horn = pag.locateOnScreen('Resources/unicorn_horn.png', confidence=0.9, region=(1525, 950, 50, 55))
        if unicorn_horn == None:
            print('Could not find unicorn_horn')
            self.checkBank()

        unicorn_hornPoint = pag.center(unicorn_horn)
        unicorn_hornX, unicorn_hornY = unicorn_hornPoint
        
        pestle_and_mortar = pag.locateOnScreen('Resources/pestle_and_mortar.png', confidence=0.9)
        if pestle_and_mortar == None:
            print('could not find pestle_and_mortar.png')
            exit()
        pestle_and_mortarPoint = pag.center(pestle_and_mortar)
        pestle_and_mortarX, pestle_and_mortarY = pestle_and_mortarPoint

        i = [1,2,3,4,5]
        l = 0
        for x in i:
            pag.moveTo(pestle_and_mortarX, pestle_and_mortarY)
            pag.click(pestle_and_mortarX, pestle_and_mortarY)
            pag.moveTo(unicorn_hornX, unicorn_hornY)
            pag.click(unicorn_hornX, unicorn_hornY)
            time.sleep(0.1)
            l += 1
            if l == 5:
                break
        
        self.prepwork()
    
    def _inventory(self):
        inventory = pag.locateOnScreen('Resources/inventory.png', confidence=0.9)
        if inventory == None:
            print('Should be in right screen')
            self.prepwork()

        inventoryPoint = pag.center(inventory)
        inventoryX, inventoryY = inventoryPoint
        pag.moveTo(inventoryX, inventoryY, 0.9)
        pag.click(inventoryX, inventoryY)
        self.prepwork()



    def checkBank(self):
        bank = pag.locateOnScreen('Resources/bank_test.png', confidence=0.8)
        if bank == None:
            bank = pag.locateOnScreen('Resources/bank_test2.png', confidence=0.8)
            if bank == None:
                bank = pag.locateOnScreen('Resources/bank_test3.png', confidence=0.8)
                if bank == None:
                    bank = pag.locateOnScreen('Resources/bank_test4.png', confidence=0.8)
                    if bank == None:
                        bank = pag.locateOnScreen('Resources/bank_test5.png', confidence=0.8)
                        if bank == None:
                            bank = pag.locateOnScreen('Resources/bank_test6.png', confidence=0.8)
                            if bank == None:
                                bank = pag.locateOnScreen('Resources/bank_test7.png', confidence=0.8)
                                if bank == None:
                                    bank = pag.locateOnScreen('Resources/bank_test8.png', confidence=0.8)
                                    if bank == None:
                                        bank = pag.locateOnScreen('Resources/bank_test9.png', confidence=0.8)
                                        if bank == None:
                                            print('#error 5107 Lazy developer.! Need fix for bank issue !.')
                                            exit()

            

        bankPoint = pag.center(bank)
        bankX, bankY = bankPoint

        print('Moving to Bank')
        pag.moveTo(bankX, bankY, 0.5)
        print('Clicking Bank')
        pag.click(button='right', clicks=1)
        time.sleep(2)

        bankbanker = pag.locateOnScreen('Resources/bank_banker2.png', confidence=0.9)
        if bankbanker == None:
            print('Could not find bank Banker')
            exit()
        
        bankbankerPoint = pag.center(bankbanker)
        bankbankerX, bankbankerY = bankbankerPoint

        pag.moveTo(bankbankerX,bankbankerY)
        time.sleep(0.1)
        pag.click(button='left', clicks=1)
        time.sleep(2)

        self.deposit_unicorn_dust()


    def closebank(self):
        close_bank = pag.locateOnScreen('Resources/close_bank.png', confidence=0.9)
        if close_bank == None:
            print('#404! !Error with close bank image! exiting')
            exit()
        closebankPoint = pag.center(close_bank)
        closebankX, closebankY = closebankPoint
        pag.moveTo(closebankX, closebankY, 0.5)
        print('!.Exiting Bank.!')
        pag.click(closebankX, closebankY)
        time.sleep(1)
        self._inventory()

    def deposit_unicorn_dust(self):
        unicorn_dust = pag.locateOnScreen('Resources/unicorn_dust.png',region=(1200, 0, 500, 1200), confidence=0.9)
        if unicorn_dust == None:
            print('Could not find unicorn dust')
            self.whitraw_unicorn_horn()

        unicorn_dustPoint = pag.center(unicorn_dust)
        unicorn_dustX, unicorn_dustY = unicorn_dustPoint
        pag.moveTo(unicorn_dustX, unicorn_dustY, 0.5)
        pag.click(unicorn_dustX, unicorn_dustY)

        self.whitraw_unicorn_horn()

    def whitraw_unicorn_horn(self):
        unicorn_horn = pag.locateOnScreen('Resources/unicorn_horn.png', confidence=0.9)
        if unicorn_horn == None:
            print('Could not find unicorn_horn')
            exit()

        unicorn_hornPoint = pag.center(unicorn_horn)
        unicorn_hornX, unicorn_hornY = unicorn_hornPoint

        unicorn_hornPoint = pag.center(unicorn_horn)
        unicorn_hornX, unicorn_hornY = unicorn_hornPoint
        pag.moveTo(unicorn_hornX, unicorn_hornY, 0.5)
        pag.click(unicorn_hornX, unicorn_hornY)

        self.closebank()

    def moveMouseStupid(self):
        ##random mouse movement
        randomX = random.randint(0, 600)
        randomY = random.randint(0, 600)
        randomT = random.randint(9, 13)
        pag.moveTo(randomX, randomY, 0.9)
        #should rly randomise sleep timer
        time.sleep(randomT)
        randomX = random.randint(0, 600)
        randomY = random.randint(0,600)
        randomT = random.randint(39, 44)
        pag.moveTo(randomX, randomY, 0.9)
        #should rly randomise sleep timer
        time.sleep(randomT)
        self.prepwork()

        



RsPy()
