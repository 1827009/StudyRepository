from cgitb import reset, text
from os import access
import time
import tkinter as tk
from unittest import result

from sqlalchemy import false

class OutOfMoney(Exception):
    pass

class AtmUi:
    def __init__(self,frame):
        self.frame=frame

        self.business=Business(self)
        self.current_number=0

    def createGUI(self):
        drawerButton=tk.Button(self.frame,text="引出",command=self.drawer,font=(",14"))
        drawerButton.grid(row=2,column=5)
        depositButton=tk.Button(self.frame,text="預入",command=self.deposit,font=(",14"))
        depositButton.grid(row=3,column=5)
        depositButton=tk.Button(self.frame,text="記帳",command=self.printing,font=(",14"))
        depositButton.grid(row=4,column=5)

        btList=[]
        for i in range(10):
            btList.append(tk.Button(self.frame,text=i,command=lambda x=i:self.key(x),font=('Helvetica',14),width=2,bg='#ffffc0'))
        btList[0].grid(row=5,column=3)
        btList[1].grid(row=2,column=2)
        btList[2].grid(row=2,column=3)
        btList[3].grid(row=2,column=4)
        btList[4].grid(row=3,column=2)
        btList[5].grid(row=3,column=3)
        btList[6].grid(row=3,column=4)
        btList[7].grid(row=4,column=2)
        btList[8].grid(row=4,column=3)
        btList[9].grid(row=4,column=4)
        depositButton=tk.Button(self.frame,text="C",command=self.clear,font=('Helvetica',14),width=2,bg='#ffffc0')
        depositButton.grid(row=5,column=4)

        self.moneyDraw()
        self.numberDraw()
        self.cashsDraw() 
        
        self.passbookDraw()
        
    def passbookDraw(self):
        self.passbookUi = tk.Label(self.frame,text="通帳："+str(self.business.passbook.text))
        self.passbookUi.grid(row=6,column=1)
    def passbookUpdate(self):
        self.passbookUi.destroy()
        self.passbookDraw()

    def moneyDraw(self):
        self.moneytext = tk.Label(self.frame,text="残高："+str(self.business.account.money))
        self.moneytext.grid(row=2,column=1)
    def moneyUpdate(self):
        self.moneytext.destroy()
        self.moneyDraw()

    def numberDraw(self):
        self.e=tk.Entry(self.frame)
        self.e.grid(row=1,column=2,columnspan=5)
    def numberUpdate(self):
        self.e.delete(0,tk.END)
        self.e.insert(0,str(self.current_number))

    def cashsDraw(self):
        casshtext=""
        for i in range(len(self.business.cashs.moneys)):
            casshtext+=str(self.business.cashs.moneys[i].worth)+"円: "+str(self.business.cashs.moneys[i].quantity)+"枚\n"
        self.cashsText=tk.Label(self.frame,text=casshtext)
        self.cashsText.grid(row=1,column=1)
    def cashsUpdate(self):
        self.cashsText.destroy()
        self.cashsDraw()
        
    def key(self, value):
        self.current_number=self.current_number*10+value
        self.numberUpdate()
    def clear(self):
        self.current_number=0
        self.numberUpdate()

    def drawer(self):
        self.business.drawer(self.current_number)
        self.moneyUpdate()
        self.cashsUpdate()
    def deposit(self):
        self.business.deposit(self.current_number)
        self.moneyUpdate()
        self.cashsUpdate()
    def printing(self):
        self.business.printin()
        self.passbookUpdate()

    def ErrerDisplay(self):
        errerWin=tk.Toplevel()
        errerText=tk.Label(errerWin,text="エラーが発生しました\n残高、または紙幣・硬貨の不足")
        errerText.pack()


class Business:
    def __init__(self, ui):
        self.ui=ui

        self.userData=UserData()
        self.passbook=Passbook()
        self.cord=Cord()
        self.account=Account()
        self.calender=Calendar()

        self.cashs=Cashs(1)
    
    def drawer(self, value):
        try:
            if self.account.money<value:
                raise OutOfMoney("残高が足りない")
            
            self.cashs.subPossession(value)
            self.account.history.addHistory(str(value)+"引出")
            self.account.money-=value
            print(self.cashs)
        except OutOfMoney as e:
            self.ui.ErrerDisplay()
            print("エラー画面")

    def deposit(self, value):
        self.account.history.addHistory(str(value)+"預入")
        self.account.money+=value
        self.cashs.addPossession(self.cashs.valueToCashs(value))

    def printin(self):
        self.passbook.printin(self.account.history.printing())

class UserData:
    def __init__(self):
        self.name="佐藤 太郎"
        self.card=Cord()
    
    def draw(self, flame):
        text = tk.Label(flame,text="名前："+self.name)
        text.grid(row=1,column=1)

class Passbook:
    def __init__(self):
        self.text=""

    def printin(self, s):
        self.text=s

class Cord:
    def __init__(self):
        self.number=0
    def draw(self, flame):
        g=tk.Frame(flame)
        g.grid(row=3,column=1)
        text = tk.Label(g,text="カード番号：未実装"+ str(self.number))
        text.grid(row=1,column=1)

class Account:
    def __init__(self):
        self.number=0
        self.money=10000

        self.history=History()

class History:
    def __init__(self):
        self.logList=[""]
        self.calender=Calendar()

    def addHistory(self, message):
        log=self.calender.getDateAndTime()+str(message)
        self.logList.append(log)
        print(log)

    def printing(self):        
        result=""
        for i in range(len(self.logList)):
            result+=str(self.logList[i])+"\n"
        return result

class Calendar:
    def __init__(self) -> None:
        self.year=time.localtime().tm_year
        self.mon=time.localtime().tm_mon
        self.dey=time.localtime().tm_mday
        self.hour=time.localtime().tm_hour
        self.min=time.localtime().tm_min
        self.sec=time.localtime().tm_sec

    def getDateAndTime(self):
        return str(self.year)+"/"+str(self.mon)+"/"+str(self.dey)+"/"+str(self.hour)+"/"+str(self.min)+"/"+str(self.sec)+":"
class Cashs:
    def __init__(self, possession=0) -> None:
        self.moneys=[Cash(10000, possession),Cash(5000, possession),Cash(1000, possession),
        Cash(500, possession),Cash(100, possession),Cash(50, possession),Cash(10, possession),Cash(5, possession),Cash(1, possession)]
        
    def addPossession(self, cashs):
        for i in range(len(self.moneys)):
            self.moneys[i].quantity+=cashs.moneys[i].quantity

    def subPossession(self, valus):
        result=Cashs()
        temp=Cashs()
        for i in range(len(self.moneys)):
            temp.moneys[i].quantity=self.moneys[i].quantity

        for i in range(len(temp.moneys)):
            result.moneys[i].quantity=valus//temp.moneys[i].worth
            temp.moneys[i].quantity-=result.moneys[i].quantity
            valus%=temp.moneys[i].worth
            
            if temp.moneys[i].quantity<0:
                valus+=abs(temp.moneys[i].quantity)*temp.moneys[i].worth
                result.moneys[i].quantity-=abs(temp.moneys[i].quantity)
                temp.moneys[i].quantity=0
        if valus>0:
            raise OutOfMoney("紙幣・硬貨が足りない")
        self.moneys=temp.moneys
        return result

    def valueToCashs(self, value):
        result=Cashs()
        for i in result.moneys:
            i.quantity=value//i.worth
            value%=i.worth
        return result
    def cashsToValue(self, cashs):
        result=0
        for i in range(len(cashs.moneys)):
            result+=cashs.moneys[i].quantity*cashs.moneys[i].worth
        return result
class Cash:
    def __init__(self, worth, quantity) -> None:
        self.worth=worth
        self.quantity=quantity


root=tk.Tk()
f=tk.Frame(root)
f.grid()

ui=AtmUi(f)
ui.createGUI()

root.mainloop()