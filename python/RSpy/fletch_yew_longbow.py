import pyautogui as pag
import random
import time
import rspylib as rslib
import rspydeposit as rsdeposit
import rspyfind as rsfind
#from PIL import Image

class RsPy:
    def __init__(self):
       #im2 = pag.screenshot(region=(1200, 0, 500, 1200))
       self.prepwork()


    def prepwork(self):
        rsdeposit.deposit_yew_longbow_u_take_yew_logs()
        time.sleep(0.5)
        rsfind.find_yew_log()
        rsfind.find_knife()
        time.sleep(1)
        print('Prep Done - Fletching')
        time.sleep(1)
        print('Sending keypress 3')
        pag.press('3')
        time.sleep(43)

        self.prepwork()
        



RsPy()
