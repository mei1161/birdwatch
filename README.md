# birdwatch
友達関係、恋人関係などの人間関係をより分かりやすく、目に見えるようにできるCLIツール
フォローバック比率などが、わかりやすい！

## 前提条件
* .NET Core 3.0
* Graphviz
* TwitterApiの登録を済ませていること。

## インストール方法
TBD 

## 使い方
アクセスするには、TwitterAPIの```ConsumerKey``` ```ConsumerSercret``` ```AccsessToken``` ```AccsessSercret```が必要です。
birdwatchフォルダの直下に```conf```フォルダを作り、フォルダ内に```birdwatch.json```を作り、以下のように記述して下さい。
※ダブルクォーテーション内に自身のキーを記述してください。
```json
{
  "ConsumerKey" : "",
  "ConsumerSercret": "",
  "AccsessToken": "",
  "AccsessSercret": ""
}
```

下記のコマンドで、情報の取得ができます。
### 指定したアカウントのフォロワー一覧を表示する

```sh
$ birdwatch followers @account
```

