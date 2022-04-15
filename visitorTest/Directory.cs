public class Directory :Entry{
    private string name;
    private List<Entry> dir=new List<Entry>();

    public Directory(string name){
        this.name=name;
    }

    public override string getName()
    {
        return name;
    }

    public Entry add(Entry entry){
        dir.Add(entry);
        return this;
    }

    public IEnumerator<Entry> enumerable(){
        return dir.GetEnumerator();
    }

    public override void accept(Visitor v)
    {
        v.visit(this);
    }
}