# zundoko-dotnet

勉強として、ズンドコ節アプリを実装しました。

## 元ネタ

<blockquote class="twitter-tweet"><p lang="ja" dir="ltr">Javaの講義、試験が「自作関数を作り記述しなさい」って問題だったから<br>「ズン」「ドコ」のいずれかをランダムで出力し続けて「ズン」「ズン」「ズン」「ズン」「ドコ」の配列が出たら「キ・ヨ・シ！」って出力した後終了って関数作ったら満点で単位貰ってた</p>&mdash; てくも (@kumiromilk) <a href="https://twitter.com/kumiromilk/status/707437861881180160?ref_src=twsrc%5Etfw">March 9, 2016</a></blockquote>

## 成果物まとめ

- 基本的な内容は 2016 年当時に作成済みだったが、2020 年にフレームワークの最新化やリファクタリングを行った。

### Web 版

[https://zundoko-dotnet.ushibutatory.net](https://zundoko-dotnet.ushibutatory.net)

- BackEnd
  - C#
  - AWS Lambda + API Gateway
- FrontEnd
  - Next.js
  - Vercel
  - Route53

### コンソールアプリケーション版

#### 工夫・勉強したこと

- 歌を増やしやすくする（拡張性を考える）。
  - インタフェースとクラスの分離。
  - 複数の歌を格納するアルバムクラスを作った。
  - 今回の要件であれば、歌データを静的ファイルなどの外部リソースで管理するように作ったほうがより拡張しやすい作りになったかもしれない。
- DI を使う。
  - あまり効果的に動いていないが、DI の練習として。
- CUI アプリケーションらしくする（ヘルプオプションなど）。
  - .NET の `CommandLineApplication` を使って実装する。

#### 遊んでみたこと

- 「キ・ヨ・シ！」は観客側のセリフにしたい。
  - 歌手クラスと観客クラスを定義し、それぞれ歌クラスから担当フレーズを取得するようにしてみた。
- 歌手や観客は、会場に集まっていることにしたい。
  - 会場クラスを定義し、歌手と観客を入れるようにした。

#### 課題

- ランダムな挙動のロジックに対して、どんなテストコードを書くとよいか？

#### 動作イメージ

##### list: 一覧

実装済みの歌を出力します。

```bash
$ dotnet Zundoko.App.dll list
Arashi
Kinchan
LoveSomebody
NetsujoRhythm
Progress
SoranBushi
Thrill
Ultrasoul
ZundokoBushi
```

##### play: 実行

回数を指定して実行します。
未指定の場合は 100 回試行します。

```bash
$ dotnet Zundoko.App.dll play z
ズンドコズンズンズンズンドコ＼キ・ヨ・シ！／
7回で完成しました。

$ dotnet Zundoko.App.dll play s 100
ソーランソーランソーランソーランヤーレンヤーレンソーランソーランソーランソーランソーランヤーレ
ンヤーレンヤーレンソーランヤーレンソーランソーランソーランソーランヤーレンヤーレンヤーレンヤー
レンソーランヤーレンヤーレンヤーレンソーランヤーレンソーランソーランソーランソーランヤーレンヤ
ーレンソーランソーランソーランソーランヤーレンヤーレンソーランヤーレンヤーレンソーランソーラン
ヤーレンヤーレンソーランヤーレンヤーレンヤーレンヤーレンソーランソーランヤーレンソーランソーラ
ン（ハイ！　ハイ！）
59回で完成しました。
```

##### cheat: チートモード

絶対成功します。

```bash
$ dotnet Zundoko.App.dll cheat z
ズンズンズンズンドコ
＼キ・ヨ・シ！／
チートモードで完成しました。

$ $ dotnet Zundoko.App.dll cheat s
ヤーレンソーランソーランヤーレンソーランソーラン
（ハイ！　ハイ！）
チートモードで完成しました。
```
