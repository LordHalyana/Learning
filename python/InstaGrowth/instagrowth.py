from selenium import webdriver
from time import sleep


whitelist = ['illegalblueberry','ofuckingla','deadlyslob.ig', 'elgatogaming', 'twitch', 'fridakarlsson', 'emmmaaa95']

class InstaGrowth:
    def __init__(self, username, pw):
        self.driver = webdriver.Chrome()
        self.username = username
        #goes to instagram
        self.driver.get("http://www.instagram.com")
        sleep(2)
        #goes to login page
        self.driver.find_element_by_xpath("//a[contains(text(), 'Log in')]").click()
        sleep(2)
        #sends login info
        self.driver.find_element_by_xpath("//input[@name= \"username\"]").send_keys(username)
        self.driver.find_element_by_xpath("//input[@name= \"password\"]").send_keys(pw)
        #clicks login button
        self.driver.find_element_by_xpath("/html/body/div[1]/section/main/div/article/div/div[1]/div/form/div[4]/button/div").click()
        sleep(2)
        #clicks away notification pop-up
        self.driver.find_element_by_xpath("/html/body/div[4]/div/div/div[3]/button[2]").click()
        sleep(2)

    def get_unfollowers(self):
        self.go_to_profile()
        sleep(2)
        #goes to following tab
        self.driver.find_element_by_xpath("//a[contains(@href,'/following')]").click()
        following = self._get_names()
        sleep(2)
        #goes to the followers tab
        self.driver.find_element_by_xpath("//a[contains(@href,'/followers')]").click()
        followers = self._get_names()
        sleep(2)
        not_following_back = [user for user in following if user not in followers]
        not_following_back_wlist = [user for user in not_following_back if user not in whitelist]
        print(not_following_back_wlist)
        self.go_home()
       

    def go_home(self):
        #goes to home screen
        self.driver.find_element_by_xpath("/html/body/div[1]/section/nav/div[2]/div/div/div[1]").click()
        sleep(2)
        self.driver.find_element_by_xpath("/html/body/div[1]/section/main/section/div[2]/div[1]/div/article[1]/div[2]/section[1]/span[1]/button").click()
        sleep(2)
        self.driver.find_element_by_xpath("/html/body/div[1]/section/main/section/div[2]/div[1]/div/article[2]/div[2]/section[1]/span[1]/button").click()
        sleep(200)
        
    def _get_names(self):
        sleep(2)
        sugs = self.driver.find_element_by_xpath('//a[contains(text(), Suggestions)]')
        self.driver.execute_script('arguments[0].scrollIntoView()', sugs)
        sleep(2)
        #targets scrollbox in following tab
        scroll_box = self.driver.find_element_by_xpath("/html/body/div[4]/div/div[2]")
        last_ht, ht = 0, 1
        while last_ht != ht:
            last_ht = ht
            sleep(2)
            ht = self.driver.execute_script("""arguments[0].scrollTo(0, arguments[0].scrollHeight);
            return arguments[0].scrollHeight;
            """, scroll_box)
        links = scroll_box.find_elements_by_tag_name('a')
        names = [name.text for name in links if name.text != '']
        sleep(2)
        self.driver.find_element_by_xpath("/html/body/div[4]/div/div[1]/div/div[2]/button").click()
        return names

    def _scroll_down(self):
        last_ht, ht = 0, 1
        scroll_box = self.driver.find_element_by_xpath("/html")
        while last_ht != ht:
            last_ht = ht
            sleep(2)
            ht = self.driver.execute_script("""arguments[0].scrollTo(0, arguments[0].scrollHeight);
            return arguments[0].scrollHeight;
            """, scroll_box)

    def go_to_profile(self):
        #goes to profile
        self.driver.find_element_by_xpath("/html/body/div[1]/section/nav/div[2]/div/div/div[3]/div/div[3]/a").click()

    #def like_latest_post(self):
    #    self.go_to_profile()
    #    sleep(2)
    #
    #    self.driver.find_element_by_xpath("//a[contains(@href,'/p/')]").click
    #    sleep(2)
    #    self.driver.find_element_by_xpath("/html/body/div[4]/div[2]/div/article/div[2]/section[1]/span[1]/button").click()
    #    sleep(2)
    #    self.driver.find_element_by_xpath("/html/body/div[4]").click()
    #    like = chrome.find_element_by_xpath('/html/body/div[3]/div[2]/div/article/div[2]/section[1]/span[1]/button/span') 
    #    sleep(2)

my_bot = InstaGrowth('Username', 'Password')
my_bot.get_unfollowers()