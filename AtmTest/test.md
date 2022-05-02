#ドキュメント
各クラスの機能をビジネスクラスし集約させ、ビジネスクラスをATMUIクラスから呼び出すことで操作できるようにしています。
イメージ的にはATMの機械がATMUI、ビジネスがATMの内部の処理機能です。
ATMUIからは引出、預入、記帳、両替ができるようになっており、ATM内の現金が足りないか、残高を越して引き出そうとするとMoneyOfOutのエラーを吐きます。

```puml

@startuml

title ATMサンプル

class ATMUI{
    表示()
    操作()
}

class ビジネス{
    現金
}
ビジネス "1" -o ATMUI

class 取引 {
出金()
入金()
}
取引 "1" o-o ビジネス

class 口座 {
残高
}
口座 "1..." -o ビジネス

class 取引履歴 {
記録
記録する(string)
}
取引履歴 "1" -o 口座

class カレンダー{
    日数計算()
}
カレンダー "1" -o 取引履歴

class 通帳{
    印字
}
ビジネス "1" o- 通帳

class 現金{
    価値
    枚数
    static 数値現金変換(int)
    static 現金数値変換(現金)
}
ビジネス "1" o- 現金

@enduml

```

#コードレビュー
現金を価値・個数の構造体配列にしていたが、価値はコード内で不変であるため分離してleadonlyにした
Cashs.cs
```
struct Cashs
{
    public int[] quantity={0,0,0,0,0,0,0,0,0};
    public static readonly int[] Worth={10000,5000,1000,500,100,50,10,5,1};
```

指定の価値を持つ貨幣のindexを取得するための検索効率が悪かったため、forでの総当たり(O(N))からIndexOf(O(NLogN))にした
Transaction.cs
```
        result.quantity[Array.IndexOf(Cashs.Worth, after)] = amount / after;
```

各所にコメントを追加

初期所持金を調整しやすいようにコンストラクタに引数をとって設定できるようにした
Account.cs
```
    public Account(){}
    public Account(int money)
    {
        this.money=money;
    }
```