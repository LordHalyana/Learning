import pyautogui as pag
import random
import time
import rspylib as rslib
import rspydeposit as rsdeposit
import rspyfind as rsfind
import rspywhitraw as rswhitraw
#from PIL import Image

class RsPy:
    def __init__(self):
       # print('Say Cheeeeze. taking photo')
       # im2 = pag.screenshot(region=(1200, 0, 500, 1200))
       # im2.save(r'screenshot/regionSS.png')
        self.prepwork()


    def prepwork(self):
        time.sleep(0.3)
        rsdeposit.deposit_yew_longbow()
        time.sleep(0.3)
        rswhitraw.whitraw_bowstring_yew_longbow_u()
        time.sleep(0.3)
        rsfind.find_yew_longbow_u_i()
        time.sleep(0.3)
        rsfind.find_bowstring()
        time.sleep(1.5)
        print('Prep Done - Fletching')
        pag.press('space')
        time.sleep(19)


        self.prepwork()  



RsPy()

