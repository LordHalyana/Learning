import pyautogui as pag
import time
import rspyfind as rsfind

class RsPy:
    def __init__(self):
       # print('Say Cheeeeze. taking photo')
       # self.screen_shot = pag.screenshot()
        self.prepwork()


    def prepwork(self):

        rsfind.find_feather()
        rsfind.find_sticks()
        print('Prep Done')
        time.sleep(1)
        print('Sending keypress Space')
        pag.press('space')
        time.sleep(11)

        self.prepwork()



RsPy()
