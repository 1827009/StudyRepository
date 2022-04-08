using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;

class ArreyTest {
    public static string SEARCH_WORD="GOAL";
    public static ArreyTest arreyTest = new ArreyTest();
    
    private Stopwatch stopwatch=new Stopwatch();
    private List<String> arrey=new List<string>();

    public static void Main(){
        arreyTest.Run();
        // 入力あるまで停止
        //Console.ReadKey();
    }

    public void Run(){        
        Random random=new Random();

        for (int i = 0; i < 1; i++)
        {
            arrey=CreateRamdonList(100000);
            // 検索対象の追加
            arrey[0]=ArreyTest.SEARCH_WORD;
            arrey[4]=ArreyTest.SEARCH_WORD;
            arrey[5]=ArreyTest.SEARCH_WORD+"TEST";

            Search(ArreyTest.SEARCH_WORD);   
            //DrawingList(arrey);   
        }      
        
        stopwatch.Start();
        int index = arrey.IndexOf(ArreyTest.SEARCH_WORD);
        stopwatch.Stop();
        Console.WriteLine("ちなみにList検索インデックス番号："+index);
        Console.WriteLine("処理時間："+stopwatch.Elapsed.Milliseconds);
        stopwatch.Reset();
    }

    public void Search(string word){
        arrey.Sort();  
        stopwatch.Start();
      
        int index = SearchIndex(word, arrey);

        stopwatch.Stop();

        if(index!=-1)
            Console.WriteLine("インデックス番号："+index+"で"+arrey[index]+"を発見しました");
        else
            Console.WriteLine(ArreyTest.SEARCH_WORD+"を発見できませんでした");
        Console.WriteLine("処理時間："+stopwatch.Elapsed.Milliseconds);

        stopwatch.Reset();
    }
    private int SearchIndex(string word, List<string> dictionary, int top=0, int number=0){
        bool match=false;
        //Console.WriteLine("word:"+word+" top:"+top+" number:"+number);
                
        // １文字の一致～不一致までの範囲を調べ、再帰呼び出しで繰り替えして絞り込む
        for (int j = top; j < dictionary.Count; j++)
        {
            if(!match && number < dictionary[j].Length && word[number] == dictionary[j][number]){
                match=true;
                top=j;
            }
            else if(match && (number >= dictionary[j].Length || word[number] != dictionary[j][number])){
                if(number+1 == word.Length) {return j-1;}
                return SearchIndex(word, dictionary, top, number+1); 
            }
            if (match && (j+1 == dictionary.Count || number+1 == word.Length)){
                return j;
            }

        }
        return -1;
    }

    private void DrawingList(List<String> list, int drawCount=-1){
        stopwatch.Start();
        
        // 引数入力がなければ二秒経過時点でストップ
        drawCount=(drawCount > -1 && drawCount <= list.Count) ? drawCount : list.Count;

        for (int i = 0; i < drawCount; i++)        
        {
            Console.WriteLine(list[i]);
            
            if(stopwatch.Elapsed.Seconds>=2){
                Console.WriteLine("量が多すぎます。表示を中断しました。");
                break;
            }
        }
        stopwatch.Stop();
        stopwatch.Reset();
    }
    private List<String> CreateRamdonList(int count){
        List<String> output=new List<string>(count);
        for (int i = 0; i < count; i++)
        {
            output.Add(CreateRamdomString());
        }

        // とりあえずデフォ機能利用
        output.Sort();

        return output;
    }
    private string CreateRamdomString(){
        Random random=new Random();

        int wordCount=random.Next(2, 10);
        string output = "";
        for (int i = 0; i < wordCount; i++)
        {
            output+=(char)random.Next(65, 91);
        }

        return output;
    }
}