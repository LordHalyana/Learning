import pyautogui as pag
import random
import time

class RsPy:
    def __init__(self):
        print('Say Cheeeeze. taking photo')
        self.screen_shot = pag.screenshot()
        self.prepwork()


    def prepwork(self):
        willow_log = pag.locateOnScreen('Resources/willow_log.png', confidence=0.9)
        if willow_log == None:
            print('Could not find willow log')
            self.checkBank()

        willow_logPoint = pag.center(willow_log)
        willow_logX, willow_logY = willow_logPoint
        

        knife = pag.locateOnScreen('Resources/knife.png', confidence=0.9)
        if knife == None:
            print('could not find Knife')
            exit()
        knifePoint = pag.center(knife)
        knifeX, knifeY = knifePoint

        print('Prep Done')
        print('#########')
        print('Moving to Willow log')
        pag.moveTo(willow_logX, willow_logY, 0.5)
        print('Clicking Willow log')
        pag.click(willow_logX, willow_logY)
        print('Moving to knife ')
        pag.moveTo(knifeX, knifeY, 0.2)
        print('Clicking knife')
        pag.click(knifeX, knifeY)
        time.sleep(1)
        print('Sending keypress Space')
        pag.press('space')
        time.sleep(10)

        self.moveMouseStupid()
    
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
        time.sleep(1)
        if bank == None:
            print('trying Bank2')
            bank = pag.locateOnScreen('Resources/bank_test2.png', confidence=0.8)
            time.sleep(1)
            if bank == None:
                print('trying Bank3')
                bank = pag.locateOnScreen('Resources/bank_test3.png', confidence=0.8)
                time.sleep(1)
                if bank == None:
                    print('trying bank4')
                    bank = pag.locateOnScreen('Resources/bank_test4.png', confidence=0.8)
                    time.sleep(1)
                    if bank == None:
                        print('trying bank5')
                        bank = pag.locateOnScreen('Resources/bank_test5.png', confidence=0.8)
                        time.sleep(1)
                        if bank == None:
                            print('trying bank6')
                            bank = pag.locateOnScreen('Resources/bank_test6.png', confidence=0.8)
                            time.sleep(1)
                            if bank == None:
                                print('trying bank7')
                                bank = pag.locateOnScreen('Resources/bank_test7.png', confidence=0.8)
                                time.sleep(1)
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

        willow_log = pag.locateOnScreen('Resources/willow_log.png', confidence=0.9)
        if willow_log == None:
            print('Could not find willow log')
            exit()
        willow_logPoint = pag.center(willow_log)
        willow_logX, willow_logY = willow_logPoint

        pag.moveTo(willow_logX, willow_logY, 0.5)
        pag.click(willow_logX, willow_logY)
        time.sleep(1)

        self.closebank()

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

    def moveMouseStupid(self):
        ##random mouse movement
        randomX = random.randint(0, 600)
        randomY = random.randint(0,600)
        pag.moveTo(randomX, randomY, 0.9)
        #should rly randomise sleep timer
        time.sleep(10)
        randomX = random.randint(0, 600)
        randomY = random.randint(0,600)
        pag.moveTo(randomX, randomY, 0.9)
        #should rly randomise sleep timer
        time.sleep(40)
        self.prepwork()

        



RsPy()
