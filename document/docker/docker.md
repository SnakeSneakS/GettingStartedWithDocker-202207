---
marp: true
paginate: true

//class: lead
//header: header
//footer: footter
---

# Dockerを始めよう
- 55代 ヘビ

--- 

# 突然ですが...環境構築って辛い！！ 

--- 

# 環境構築の辛さ
1. 依存モジュール多すぎ...
   1. あれインストールしてこれインストールして...うゎぁぁあああああ

2. バージョンが違う
   1. バージョンが違うから動かない...

3. 色々な環境が混じる
   1. 1つのデータベースにプロジェクトAのやつとプロジェクトBのやつと...色々混じっててややこしいいいい
   
4. そもそもどんな環境を構築したか忘れた
5. 共同開発者同士で環境が異なる 

---

# 環境構築にDockerを使えばとても便利

---

# Docker 
- Dockerはコンテナを動かす
    - コンテナとは: 仮想マシンと比べて軽量な仮想環境  
    - 仮想環境なので、手元PCの環境を汚さない。
    - コンテナにパッケージングされてる
        - 移行・運用が容易
        - コンテナ・オーケストレーション（Kubernetes） 

- Dockerイメージ: コンテナが動作するためのテンプレート 
    - 環境設定などがDockerイメージに書かれている  
        - 自分で環境構築する必要がない（嬉しい）
        - 複数人間で実行環境に差異がない

--- 

# docker実行環境の用意 
- 従来: [Docker Desktop](https://www.docker.com/products/docker-desktop/) 

- 今回使いたいもの: [Rancher Desktop](https://rancherdesktop.io/) 
    - k3s(軽量なk8s)を動かせるもの
    - k8s: 複数のコンテナを運用する基盤。コンテナ・オーケストレーションをできる。(今回はそこまで出来ないけど、いずれ出来たらいいね...)

--- 

# Dockerイメージについて
- [Docker Hub](https://hub.docker.com/)など、Dockerイメージを公開している
- Dockerfileを作り自作することもできる。[参考](https://docs.docker.jp/engine/reference/builder.html) 

---

# Docker実践

---

# dockerを利用したアプリを動かす 
- [dockerでホームページを動かす](https://github.com/SnakeSneakS/GettingStartedWithDocker-202207/tree/wip/docker-misw-hp) 
- [nextcloudを動かす](https://github.com/SnakeSneakS/GettingStartedWithDocker-202207/tree/wip/docker-nextcloud)
- [unityとgo-serverでアカウント登録やログイン](https://github.com/SnakeSneakS/GettingStartedWithDocker-202207/tree/wip/unity-account-registration/) 
- [unityとgo-serverでsocker通信を実装(WIP)](https://github.com/SnakeSneakS/GettingStartedWithDocker-202207/tree/wip/unity-socket-connection)

--- 

# 〜END〜