public abstract class Entry :Element{
    public abstract String getName();

    public abstract void accept(Visitor v);

    public override string ToString()
    {
        return getName();
    }
}