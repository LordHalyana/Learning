import pyautogui as pag
import random
import time
import rspylib as rslib
import rspyfind as rsfind
import rspywhitraw as rswhitraw

#region=(1200, 0, 500, 1200)

def deposit_yew_longbow_u_take_yew_logs():
    rslib.checkBank()
    yew_longbow_u = pag.locateOnScreen('Resources/yew_longbow_u_i.png', confidence=0.9, region=(1200, 0, 500, 1200))
    time.sleep(0.3)
    if yew_longbow_u == None:
        print('Depositing yew longbow u - taking Yew Logs')
        rswhitraw.whitraw_yew_logs()

    yew_longbow_uPoint = pag.center(yew_longbow_u)
    yew_longbow_uX, yew_longbow_uY = yew_longbow_uPoint
    pag.moveTo(yew_longbow_uX, yew_longbow_uY, 0.5)
    pag.click(yew_longbow_uX, yew_longbow_uY)

    rswhitraw.whitraw_yew_logs()

def deposit_yew_longbow_u():
    rslib.checkBank()
    yew_longbow_u = pag.locateOnScreen('Resources/yew_longbow_u.png', confidence=0.9, region=(1200, 0, 500, 1200))
    time.sleep(0.3)
    if yew_longbow_u == None:
        print('Depositing yew longbow u')

    yew_longbow_uPoint = pag.center(yew_longbow_u)
    yew_longbow_uX, yew_longbow_uY = yew_longbow_uPoint
    pag.moveTo(yew_longbow_uX, yew_longbow_uY, 0.5)
    pag.click(yew_longbow_uX, yew_longbow_uY)

def deposit_yew_longbow():
    rslib.checkBank()
    yew_longbow = pag.locateOnScreen('Resources/yew_longbow.png', confidence=0.9, region=(1200, 0, 500, 1200))
    time.sleep(0.3)
    if yew_longbow == None:
        print('Depositing yew longbow')

    yew_longbowPoint = pag.center(yew_longbow)
    yew_longbowX, yew_longbowY = yew_longbowPoint
    pag.moveTo(yew_longbowX, yew_longbowY, 0.5)
    pag.click(yew_longbowX, yew_longbowY)

