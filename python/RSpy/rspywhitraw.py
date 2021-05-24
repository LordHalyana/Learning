import pyautogui as pag
import random
import time
import rspylib as rslib
import rspydeposit as rsdeposit
import rspyfind as rsfind


def whitraw_yew_logs():
    rsfind.find_yew_log()

    rslib.closebank()

def whitraw_bowstring_yew_longbow_u():
    rsfind.find_yew_longbow_u()
    time.sleep(0.3)
    rsfind.find_bowstring()

    rslib.closebank()