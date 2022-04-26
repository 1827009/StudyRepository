from cgitb import text
from os import access
import time
import tkinter as tk

class ATM():
    def __init__(self, passbook, cord) -> None:
        self.account=Account()
        self.passbook=passbook
        self.cord=cord
        self.inputValue=0
        self.current_number=0

    def createGUI(self, flame):
        drawerButton=tk.Button(flame,text="引出",command=self.drawer,font=(",14"))
        drawerButton.grid(row=2,column=5)
        depositButton=tk.Button(flame,text="預入",command=self.deposit,font=(",14"))
        depositButton.grid(row=3,column=5)
        depositButton=tk.Button(flame,text="記帳",command=self.printing,font=(",14"))
        depositButton.grid(row=4,column=5)

        btList=[]
        for i in range(10):
            btList.append(tk.Button(flame,text=i,command=lambda x=i:self.key(x),font=('Helvetica',14),width=2,bg='#ffffc0'))
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
        depositButton=tk.Button(flame,text="C",command=self.clear,font=('Helvetica',14),width=2,bg='#ffffc0')
        depositButton.grid(row=5,column=4)

        self.e=tk.Entry(f)
        self.e.grid(row=1,column=2,columnspan=5)

        self.account.draw(flame)
        self.passbook.draw(flame)
        
    def key(self, value):
        self.current_number=self.current_number*10+value
        self.show_number(self.current_number)
    def clear(self):
        self.current_number=0
        self.show_number(self.current_number)
    def show_number(self,num):
        self.e.delete(0,tk.END)
        self.e.insert(0,str(num))


    def drawer(self):
        self.account.drawer(self.current_number)
    def deposit(self):
        self.account.deposit(self.current_number)
    def printing(self):
        self.passbook.printin(self.account.history.printing())

class User():
    def __init__(self):
        self.name="佐藤 太郎"
        self.card=Cord()
    
    def draw(self, flame):
        text = tk.Label(flame,text="名前："+self.name)
        text.grid(row=1,column=1)

class Passbook():
    def __init__(self):
        self.intext=""
    def update(self):
        self.text.destroy()
        self.draw(self.g)
    def draw(self, flame):
        self.g=tk.Frame(flame)
        self.g.grid(row=6,column=1)
        self.text = tk.Label(self.g,text="通帳："+str(self.intext))
        self.text.grid(row=1,column=1)

    def printin(self, s):
        self.intext=s
        self.update()

class Cord():
    def __init__(self):
        self.number=0
    def draw(self, flame):
        g=tk.Frame(flame)
        g.grid(row=3,column=1)
        text = tk.Label(g,text="カード番号：未実装"+ str(self.number))
        text.grid(row=1,column=1)

class Account():
    def __init__(self):
        self.number=0
        self.money=10000

        self.history=History()
    def update(self):
        self.text.destroy()
        self.draw(self.g)
    def draw(self, flame):        
        self.g=tk.Frame(flame)
        self.g.grid(row=2,column=1)
        self.text = tk.Label(self.g,text="残高："+str(self.money))
        self.text.grid(row=1,column=1)

    def drawer(self, value):
        if self.money<value:
            print("Errer:お金が足りません")
            return
            
        self.history.addHistory(str(value)+"引出")
        self.money-=value

        self.update()

    def deposit(self, value):
        self.history.addHistory(str(value)+"預入")
        self.money+=value
        
        self.update()

class History():
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

class Calendar():
    def __init__(self) -> None:
        self.year=time.localtime().tm_year
        self.mon=time.localtime().tm_mon
        self.dey=time.localtime().tm_mday
        self.hour=time.localtime().tm_hour
        self.min=time.localtime().tm_min
        self.sec=time.localtime().tm_sec

    def getDateAndTime(self):
        return str(self.year)+"/"+str(self.mon)+"/"+str(self.dey)+"/"+str(self.hour)+"/"+str(self.min)+"/"+str(self.sec)+":"

root=tk.Tk()
f=tk.Frame(root)
f.grid()

user=User()
user.draw(f)

atm=ATM(Passbook(), user.card)
atm.createGUI(f)


cord=Cord()
cord.draw(f)

root.mainloop()