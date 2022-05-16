// 参考サイト
// https://qiita.com/i-tanaka730/items/a0f53d70b0830cfd150b

abstract class Display
{
    // 横の文字数
    public abstract int getColums();
    // 縦の文字列
    public abstract int getRows();
    // 指定した行の文字列
    public abstract string getRowsText(int row);

    public void show()
    {
        for (int i = 0; i < getRows(); i++)
        {
            Console.WriteLine(getRowsText(i));
        }
    }
}

// １行のみのテキストクラス
class StringDisplay : Display
{
    private string text;

    public StringDisplay(string text)
    {
        this.text = text;
    }

    public override int getColums()
    {
        return text.Length;
    }

    public override int getRows()
    {
        return 1;
    }

    public override string getRowsText(int row)
    {
        return row == 0 ? text : null;
    }
}

// 飾り枠を表すクラス
abstract class Border : Display
{
    protected Display display;
    protected Border(Display display)
    {
        this.display = display;
    }
}
class SideBorder : Border
{
    public SideBorder(Display display) : base(display) { }

    // 両脇に飾り分の文字
    public override int getColums()
    {
        return 1 + display.getColums() + 1;
    }
    public override int getRows()
    {
        return display.getRows();
    }
    public override string getRowsText(int row)
    {
        return "*" + display.getRowsText(row) + "*";
    }
}

class FullBorder : Border
{
    public FullBorder(Display display) : base(display) { }

    // 両端に装飾分の文字数
    public override int getColums()
    {
        return 1 + display.getColums()+1;
    }
    public override int getRows()
    {
        return 1+display.getRows()+1;
    }

    public override string getRowsText(int row)
    {
        string outout="";
        if(row==0){
            outout="+";
            for (int i = 0; i < getColums(); i++)
            {
                outout+="-";
            }
            outout+="+";
        }
        else if(row==display.getRows()+1){
            outout="+";
            for (int i = 0; i < getColums(); i++)
            {
                outout+="-";
            }
            outout+="+";
        }
        else{
            outout= "|"+display.getRowsText(row-1)+"|";
        }
        return outout;
    }
}