class AtmUi{
    Business business=new Business();

    public void Draw(){
        Console.WriteLine("残高: "+business.account.money);
        Console.Write("ATM内: ");
        for(int i=0;i<business.cashs.cashs.Length;i++)
            Console.Write(business.cashs.cashs[i].Worth+"円: "+business.cashs.cashs[i].quantity+"枚 | ");
        Console.WriteLine();
    }
    public void Control(string order, int value){
        try{
        if(order=="drawer"){
            business.Drawer(value);
            Console.WriteLine(value+"円　引出");
        }
        else if(order=="deposit"){
            business.Deposit(value);
            Console.WriteLine(value+"円　預入");
        }
        else if(order=="print"){
            business.PrintPassbook();
            Console.WriteLine("通帳");
            Console.WriteLine(business.passbook.text);            
        }
        }
        catch(MoneyOfOut){
            Console.WriteLine("error：残高・ATM内の現金が足りない");
        }        
    }
}