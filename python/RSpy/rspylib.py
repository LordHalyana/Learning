import pyautogui as pag
import random
import time
import rspyfind as rsfind
import rspydeposit as rsdeposit
#from PIL import Image
    
def _inventory():
    rsfind.find_inventory()

def magicmenu():
    magic_menu = pag.locateOnScreen('Resources/menu_magic.png', confidence=0.9)
    if magic_menu == None:
        print('could not find magic_menu, should be in right screen')
    magic_menuPoint = pag.center(magic_menu)
    magic_menuX, magic_menuY = magic_menuPoint
    pag.moveTo(magic_menuX, magic_menuY)
    pag.click(magic_menuX, magic_menuY)
    time.sleep(0.3)

def checkBank():
    time.sleep(0.3)
    rsfind.find_seersbank()
    time.sleep(0.3)
    rsfind.find_bankbanker()
    time.sleep(0.3)

def _takefrombank_bowstring_yew_longbow_u():
    time.sleep(1)
    rsfind.find_yew_longbow_u()        
    rsfind.find_bowstring()
    closebank()


def closebank():
    time.sleep(1)
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

def highalch():
    time.sleep(0.8)
    high_alch = pag.locateOnScreen('Resources/magic_ha.png')
    if high_alch == None:
        time.sleep(0.3)
        high_alch = pag.locateOnScreen('Resources/magic_ha2.png')
        if high_alch == None:
            high_alch = pag.locateOnScreen('Resources/magic_ha3.png')
            if high_alch == None:
                print('Out of runes')
                exit()
        
    high_aclhPoint = pag.center(high_alch)
    high_alchX, high_alchY = high_aclhPoint
    pag.moveTo(high_alchX, high_alchY, 0.3)
    pag.click(high_alchX, high_alchY)
    time.sleep(0.3)



    
def moveMouseStupid():
    randomX = random.randint(0, 600)
    randomY = random.randint(0, 600)
    randomT = random.randint(9, 13)
    pag.moveTo(randomX, randomY, 0.9)
    time.sleep(randomT)

        



