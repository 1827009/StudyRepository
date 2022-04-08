using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;

class ArreyTest {
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

        arrey=CreateRamdonList(1000000);

        DrawingList(arrey,5);
    }

    public void Search(string word){
        stopwatch.Start();

        for (int i = 0; i < word.Length; i++)
        {
            bool match=false;
            int matchHed=0;
            int matchBottom=arrey.Count;
            for (int j = matchHed; j < matchBottom; j++)
            {
                if(!match && word[i] == arrey[j][i]){
                    match=true;
                    matchHed=j;
                }
                else if(match && word[i] != arrey[j][i]){
                    match=false;
                    matchBottom=j;
                }                    
            }
        }
        

        stopwatch.Stop();
        Console.WriteLine("処理時間："+stopwatch.Elapsed.Milliseconds);
        stopwatch.Reset();
    }
    private void DrawingList(List<String> list, int drawCount=-1){
        stopwatch.Start();
        drawCount=drawCount < 0 ? list.Count : drawCount;
        for (int i = 0; i < drawCount; i++)        
        {
            Console.WriteLine(list[i]);
            
            if(stopwatch.Elapsed.Seconds>=2){
                Console.WriteLine("量が多すぎます。表示を中断しました。");
                break;
            }
        }
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