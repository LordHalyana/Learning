import pyautogui as pag
import random
import time
import rspylib as rslib
import rspydeposit as rsdeposit
import rspyfind as rsfind
import rspywhitraw as rswhitraw

class RsPy:
    def __init__(self):
        rslib.magicmenu()
        self.prepwork()


    def prepwork(self):
        time.sleep(0.3)
        rslib.highalch()
        rsfind.find_noted_longbow()
        time.sleep(1.1)


        self.prepwork()



RsPy()