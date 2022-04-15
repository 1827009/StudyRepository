public class File :Entry
{
    private string name;

    public File(string name){
        this.name=name;
    }

    public override string getName()
    {
        return name;
    }

    public override void accept(Visitor v)
    {
        v.visit(this);
    }
}
