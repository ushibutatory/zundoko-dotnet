# zundoko-dotnet

.NETの勉強として、ズンドコ節アプリを実装しました。

## 元ネタ

<blockquote class="twitter-tweet"><p lang="ja" dir="ltr">Javaの講義、試験が「自作関数を作り記述しなさい」って問題だったから<br>「ズン」「ドコ」のいずれかをランダムで出力し続けて「ズン」「ズン」「ズン」「ズン」「ドコ」の配列が出たら「キ・ヨ・シ！」って出力した後終了って関数作ったら満点で単位貰ってた</p>&mdash; てくも (@kumiromilk) <a href="https://twitter.com/kumiromilk/status/707437861881180160?ref_src=twsrc%5Etfw">March 9, 2016</a></blockquote>

## 成果物まとめ

### コンソールアプリケーション版

（基本的な内容は2016年当時に作成済みだったが、2020年にフレームワークの最新化やリファクタリングを行った。）

#### 勉強したこと

- 歌を増やしやすくする（拡張性を考える）。
    - インタフェースとクラスの分離。
    - 複数の歌を格納するアルバムクラスを作った。
    - 今回の要件であれば、歌データを静的ファイルなどの外部リソースで管理するように作ったほうがより拡張しやすい作りになったかもしれない。
- DIを使う。
    - あまり効果的に動いていないが、DIの練習として。
- CUIアプリケーションらしくする（ヘルプオプションなど）。
    - .NETの `CommandLineApplication` を使って実装する。

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
未指定の場合は100回試行します。

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

### Web版

![Publish Web](https://github.com/ushibutatory/zundoko-dotnet/workflows/Publish%20Web/badge.svg)

[https://zundoko-dotnet.herokuapp.com/](https://zundoko-dotnet.herokuapp.com/)

（※Heroku Free Plan）

#### 勉強したこと

- CI/CDの活用
    - GitHubActionsでHerokuにデプロイするようにしました。
