public class ListVisitor :Visitor
{
    private string currentdir="";

    public override void visit(File file)
    {
        Console.WriteLine(currentdir+"/"+file);
    }

    public override void visit(Directory directory)
    {
        Console.WriteLine(currentdir+"/"+directory);
        string savedir=currentdir;
        currentdir=currentdir+"/"+directory.getName();
        IEnumerator<Entry> it=directory.enumerable();
        while (it.MoveNext())
        {
            Entry entry=(Entry)it.Current;
            entry.accept(this);
        }
        currentdir=savedir;
    }
}