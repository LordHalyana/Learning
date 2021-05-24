import pyautogui as pag
import random
import time
import rspylib as rslib
import rspydeposit as rsdeposit

def find_feather():
    feathers = pag.locateOnScreen('Resources/feather.png', confidence=0.9)
    if feathers == None:
        print('Could not find feathers')
        exit()
    feathersPoint = pag.center(feathers)
    featherX, featherY = feathersPoint
    pag.moveTo(featherX, featherY, 0.5)
    pag.click(featherX, featherY)

def find_sticks():
    sticks = pag.locateOnScreen('Resources/sticks.png', confidence=0.9)
    if sticks == None:
        print('Could not find Sticks')
        exit()
        
    sticksPoint = pag.center(sticks)
    sticksX, sticksY = sticksPoint
    pag.moveTo(sticksX, sticksY, 0.2)
    pag.click(sticksX, sticksY)

def find_knife():
    knife = pag.locateOnScreen('Resources/knife.png', confidence=0.9)
    if knife == None:
        print('could not find Knife')
        exit()
    knifePoint = pag.center(knife)
    knifeX, knifeY = knifePoint
    pag.moveTo(knifeX, knifeY, 0.2)
    pag.click(knifeX, knifeY)

def find_yew_log():
    yew_log = pag.locateOnScreen('Resources/yew_log.png', confidence=0.9)
    if yew_log == None:
        print('Could not find yew log')
        rslib.checkBank()

    yew_logPoint = pag.center(yew_log)
    yew_logX, yew_logY = yew_logPoint
    pag.moveTo(yew_logX, yew_logY, 0.5)
    pag.click(yew_logX, yew_logY)

def find_inventory():
    inventory = pag.locateOnScreen('Resources/inventory.png', confidence=0.9)
    if inventory == None:
        print('Should be in right screen')
    inventoryPoint = pag.center(inventory)
    inventoryX, inventoryY = inventoryPoint
    pag.moveTo(inventoryX, inventoryY, 0.9)
    pag.click(inventoryX, inventoryY)

def find_bankbanker():
    bankbanker = pag.locateOnScreen('Resources/bank_banker2.png', confidence=0.9)
    if bankbanker == None:
        print('Could not find bank Banker')
        exit()
        
    bankbankerPoint = pag.center(bankbanker)
    bankbankerX, bankbankerY = bankbankerPoint

    pag.moveTo(bankbankerX,bankbankerY)
    time.sleep(0.1)
    pag.click(button='left', clicks=1)
    time.sleep(1)

def find_feather():
    feathers = pag.locateOnScreen('Resources/feather.png', confidence=0.9)
    if feathers == None:
        print('Could not find feathers')
        exit()
    feathersPoint = pag.center(feathers)
    featherX, featherY = feathersPoint
    pag.moveTo(featherX, featherY, 0.5)
    pag.click(featherX, featherY)

def find_sticks():
    sticks = pag.locateOnScreen('Resources/sticks.png', confidence=0.9)
    if sticks == None:
        print('Could not find Sticks')
        exit()
        
    sticksPoint = pag.center(sticks)
    sticksX, sticksY = sticksPoint
    pag.moveTo(sticksX, sticksY, 0.2)
    pag.click(sticksX, sticksY)

def find_yew_longbow_u_i():
    yew_longbow_u = pag.locateOnScreen('Resources/yew_longbow_u_i.png', confidence=0.9)
    if yew_longbow_u == None:
        print('Could not find yew Longbow U')
        exit()

    yew_longbow_uPoint = pag.center(yew_longbow_u)
    yew_longbow_uX, yew_longbow_uY = yew_longbow_uPoint
    pag.moveTo(yew_longbow_uX, yew_longbow_uY, 0.5)
    pag.click(yew_longbow_uX, yew_longbow_uY)
    
def find_yew_longbow_u():
    yew_longbow_u = pag.locateOnScreen('Resources/yew_longbow_u.png', confidence=0.9)
    if yew_longbow_u == None:
        time.sleep(0.3)
        yew_longbow_u = pag.locateOnScreen('Resources/yew_longbow_u2.png', confidence=0.9)
        if yew_longbow_u == None:
            print('Could not find yew Longbow U')
            rslib.checkBank()

    yew_longbow_uPoint = pag.center(yew_longbow_u)
    yew_longbow_uX, yew_longbow_uY = yew_longbow_uPoint
    pag.moveTo(yew_longbow_uX, yew_longbow_uY, 0.5)
    pag.click(yew_longbow_uX, yew_longbow_uY)

def find_yew_longbow():
    yew_longbow = pag.locateOnScreen('Resources/yew_longbow.png', confidence=0.9)
    if yew_longbow == None:
        print('Could not find yew_longbow')
        rslib.checkBank()
            

    yew_longbowPoint = pag.center(yew_longbow)
    yew_longbowX, yew_longbowY = yew_longbowPoint
    pag.moveTo(yew_longbowX, yew_longbowY, 0.5)
    pag.click(yew_longbowX, yew_longbowY)

def find_noted_longbow():
    noted_yew_longbow = pag.locateOnScreen('Resources/noted_yew_longbow.png')
    if noted_yew_longbow == None:
        time.sleep(0.3)
        noted_yew_longbow = pag.locateOnScreen('Resources/noted_yew_longbow2.png')
        if noted_yew_longbow == None:
            time.sleep(0.3)
            noted_yew_longbow = pag.locateOnScreen('Resources/noted_yew_longbow3.png')
            if noted_yew_longbow == None:
                noted_yew_longbow = pag.locateOnScreen('Resources/noted_yew_longbow4.png')
                if noted_yew_longbow == None:
                    print('Out of Noted Yew longbow')
                    exit()

    noted_yew_longbowpoint = pag.center(noted_yew_longbow)
    noted_yew_longbowX, noted_yew_longbowY = noted_yew_longbowpoint
    pag.moveTo(noted_yew_longbowX, noted_yew_longbowY, 0.2)
    pag.click(noted_yew_longbowX, noted_yew_longbowY)
    
def find_bowstring():
    bowstring = pag.locateOnScreen('Resources/bowstring.png', confidence=0.9)
    if bowstring == None:
        print('could not find bowstring')
        rslib.checkBank()
    bowstringPoint = pag.center(bowstring)
    bowstringX, bowstringY = bowstringPoint
    pag.moveTo(bowstringX, bowstringY, 0.5)
    pag.click(bowstringX, bowstringY)

def find_seersbank():
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
                                        bank = pag.locateOnScreen('Resources/bank_test10.png', confidence=0.8)
                                        if bank == None:
                                            bank = pag.locateOnScreen('Resources/bank_test11.png', confidence=0.8)
                                            if bank == None:
                                                print('#error 5107 Lazy developer.! Need fix for bank issue !.')
                                                exit()

    bankPoint = pag.center(bank)
    bankX, bankY = bankPoint
    time.sleep(1.5)
    pag.moveTo(bankX, bankY, 0.5)
    print('Clicking Bank')
    pag.click(button='right', clicks=1)
    time.sleep(1)