// 参考サイト:https://zenn.dev/nekoniki/articles/2fe4dfe3d2f29fead797

// 素材
abstract class MaterialImple{
    public abstract string getMaterialString();
}
class Metal :MaterialImple
{
    public override string getMaterialString()
    {
        return "Metal";
    }
}
class Wood : MaterialImple{
    public override string getMaterialString()
    {
        return "Wood";
    }
}

// 食器の
class Dishware
{
    private MaterialImple materialImple;
    public MaterialImple getMaterialImple{get{return materialImple;}}
}

// 物体
class Chopsticks:Dishware{

}
class Spoon:Dishware{

}