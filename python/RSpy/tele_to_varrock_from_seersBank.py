import pyautogui as pag
import random
import time

class RsPy:
    def __init__(self):
        print('Say Cheeeeze. taking photo')
        self.screen_shot = pag.screenshot()
        self.prepwork()


    def prepwork(self):
        magic_menu = pag.locateOnScreen('Resources/menu_magic.png', confidence=0.9)
        if magic_menu == None:
            print('Could not find Magic Menu')
            self.checkBank()

        magic_menuPoint = pag.center(magic_menu)
        magic_menuX, magic_menuY = magic_menuPoint
        pag.moveTo(magic_menuX, magic_menuY)
        pag.click(magic_menuX, magic_menuY)
        

        varrok_av = pag.locateOnScreen('Resources/varrok_yes_runes.png', confidence=0.9)
        if varrok_av == None:
            print('.! Need runes !.')
            varrok_not = pag.locateOnScreen('Resources/varrok_no_runes.png', confidence=0.9)
            self.checkBank()
            if varrok_not == None:
                print('.! bugs !.')
        varrok_avPoint = pag.center(varrok_av)
        varrok_avX, varrok_avY = varrok_avPoint
        pag.moveTo(varrok_avX, varrok_avY)
        pag.click(varrok_avX, varrok_avY)
        print('We have arrived in Varrok')
        exit()

        
    
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
                                        print('#error 5107 Lazy developer.! Need fix for bank issue !.')
                                        exit()

            

        bankPoint = pag.center(bank)
        bankX, bankY = bankPoint

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


        bank_quant5 = pag.locateOnScreen('Resources/bankQuant5.png', confidence=0.5)
        if bank_quant5 == None:
            print('could not find quantety for bank')

        bank_quant5Point = pag.center(bank_quant5)
        bank_q5X, bank_q5Y = bank_quant5Point
        pag.moveTo(bank_q5X, bank_q5Y, 0.2)
        pag.click(bank_q5X, bank_q5Y)

        rune_air = pag.locateOnScreen('Resources/rune_air.png', confidence=0.9)
        if rune_air == None:
            rune_air = pag.locateOnScreen('Resources/rune_air2.png', confidence=0.9)
            if rune_air == None:
                print('Could not find air runes in bank !. Exiting .!')
                exit()
        rune_airPoint = pag.center(rune_air)
        rune_airX, rune_airY = rune_airPoint

        pag.moveTo(rune_airX, rune_airY, 0.5)
        pag.click(rune_airX, rune_airY)
        time.sleep(1)

        rune_fire = pag.locateOnScreen('Resources/rune_fire.png', confidence=0.9)
        if rune_fire == None:
            rune_fire = pag.locateOnScreen('Resources/rune_fire2.png', confidence=0.9)
            if rune_fire == None:
                print('Could not find fire runes in bank !. Exiting .!')
                exit()
        rune_firePoint = pag.center(rune_fire)
        rune_fireX, rune_fireY = rune_firePoint

        pag.moveTo(rune_fireX, rune_fireY, 0.5)
        pag.click(rune_fireX, rune_fireY)
        time.sleep(1)

        rune_law = pag.locateOnScreen('Resources/rune_law.png', confidence=0.9)
        if rune_law == None:
            rune_law = pag.locateOnScreen('Resources/rune_law2.png', confidence=0.9)
            if rune_law == None:
                print('Could not find law runes in bank !. Exiting .!')
                exit()
        rune_lawPoint = pag.center(rune_law)
        rune_lawX, rune_lawY = rune_lawPoint

        pag.moveTo(rune_lawX, rune_lawY, 0.5)
        pag.click(rune_lawX, rune_lawY)
        time.sleep(1)


        bank_quantAll = pag.locateOnScreen('Resources/bankQuantAll.png', confidence=0.5)
        if bank_quantAll == None:
            print('could not find quantety for bank')
            self.closebank()

        bank_quantAllPoint = pag.center(bank_quantAll)
        bank_qAllX, bank_qAllY = bank_quantAllPoint
        pag.moveTo(bank_qAllX, bank_qAllY, 0.2)
        pag.click(bank_qAllX, bank_qAllY)

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
