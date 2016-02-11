# -*- coding: utf-8 -*-
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.common.keys import Keys
from selenium.webdriver.support.ui import Select
from selenium.common.exceptions import NoSuchElementException
from selenium.common.exceptions import NoAlertPresentException
import unittest, time, re,sys
from bs4 import BeautifulSoup
import datetime, time
import io
import os
def WriteTxt(writeTxtInput):
	f = io.open('D:\unity\Unity_5.1_Project\ChineseRecognize_5.3-2\Speech recognition5.3\Assets\A.txt', 'w',encoding = 'UTF-8')
	f.write(writeTxtInput)
def tryOpenfile():
	try:
		for i in io.open('D:\unity\Unity_5.1_Project\ChineseRecognize_5.3-2\Speech recognition5.3\Assets\A.txt', 'r',encoding = 'UTF-8'):
			print u"辨識結果為:"+i
			
	except:
		pass
cwd="C:\Python27\Scripts\ChromeWebDrive\chromedriver.exe"
browser=webdriver.Chrome(cwd)
browser.get('https://www.google.com/intl/en/chrome/demos/speech.html')
Select(browser.find_element_by_id("select_language")).select_by_value("36")
Select(browser.find_element_by_id("select_dialect")).select_by_value("cmn-Hant-TW")
browser.find_element_by_id("start_button").click()
time.sleep(10)

browser.find_element_by_id("start_button").click()
soup = BeautifulSoup(browser.page_source,"html.parser")
for ele in soup.select('.interim'):
	writeTxtInput=ele.text
	writeTxtInputcut=writeTxtInput[0:5]
	WriteTxt(writeTxtInputcut)
tryOpenfile()
for loop in range(10, 0, -1):
	os.system("pause")
	browser.find_element_by_id("start_button").click()
	time.sleep(5)
	browser.find_element_by_id("start_button").click()
	soup = BeautifulSoup(browser.page_source,"html.parser")
	for ele in soup.select('.interim'):
		writeTxtInput=ele.text
		writeTxtInputcut=writeTxtInput[0:5]
		WriteTxt(writeTxtInputcut)
	tryOpenfile()
browser.close()
