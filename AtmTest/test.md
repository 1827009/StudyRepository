```puml

@startuml

title ATMサンプル

class 口座 {
現金
出金()
入金()
}

class 顧客 {
氏名
}

class 取引履歴 {
日時
内容
金額
記録()
}

class カード {
番号
暗証番号
}

class カレンダー{
    日数計算()
}

class 通帳{
    印字()
}

顧客 "1" -* 口座
顧客 "1" *- "0..1" カード

口座 "1" o- 通帳
口座 "1" o- 取引履歴

@enduml

```

```puml
@startuml
title アクティビティサンプル

start 
if(カードを挿入)
    if(暗証番号を入力) then (成功)
        if(入金) then (はい)
        elseif(出金) then (はい)
        endif
    else
        :エラーメッセージ;
    endif
elseif(通帳を挿入)
    :印字;
endif

:記録;
stop

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

指定の価値を持つ貨幣のindexを取得するための検索効率が悪かったため
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