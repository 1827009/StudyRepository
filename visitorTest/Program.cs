// 参考サイト:https://qiita.com/i-tanaka730/items/2e2d4fac2075b3e45ef7
static class Program
{
    static void Main(string[] args)
    {
        Directory workspaceDir=new Directory("workspace");
        Directory compositeDir=new Directory("composite");
        Directory testDir1=new Directory("test1");
        Directory testDir2=new Directory("test2");
        workspaceDir.add(compositeDir);
        workspaceDir.add(testDir1);
        workspaceDir.add(testDir2);

        File element=new File("Element.cs");
        File entry=new File("Entry.cs");
        File file=new File("File.cs");
        File directory=new File("Directory.cs");
        File visitor=new File("Visitor.cs");
        File listVisitor=new File("ListVisitor.cs");
        File main=new File("Program.cs");
        compositeDir.add(element);
        compositeDir.add(entry);
        compositeDir.add(file);
        compositeDir.add(directory);
        compositeDir.add(visitor);
        compositeDir.add(listVisitor);
        compositeDir.add(main);

        workspaceDir.accept(new ListVisitor());
    }
}
