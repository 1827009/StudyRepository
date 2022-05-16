#クラス図
```puml

class プレイヤー{
    座標
    移動レスポンス
    取得レスポンス
    機数
}

class 敵{
    行動ループ頻度
}
class 触手{
    行動ループ[]
}
敵 "1..." *- 触手

class マップ{
    max座標制限
    min座標制限
}

class 操作{
    入力取得()
}

```