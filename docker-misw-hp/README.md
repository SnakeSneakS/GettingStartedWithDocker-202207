# dockerでmiswの公式ホームページを動かす
1. dockerイメージをpullして手元に持ってくる
  - ```docker pull ghcr.io/misw/misw-jp:latest```

2. 手元のイメージにmisw-jpがあることを確認する 
    - ```docker image ls```
    - ```ghcr.io/misw/misw-jp```があるはずです。 

3. dockerイメージを動かす: 
    - ```docker run -p 8888:8080 ghcr.io/misw/misw-jp``` 
        - 違うポートで動かす場合は、```-p ${動かしたいポート番号}:8080```に変更する。

4. アクセスして動いていることを確認する: http://localhost:8888/
    - ```localhost```: 自分自身のPCを示すホスト名。ipアドレス「127.0.0.1」と紐づいている
    - ```:8080```: port番号。違うポートを使った場合はそのポート番号を指定する必要がある。

**Dockerイメージに「環境構築から実行までの全ての情報」が入っているため、とても簡単に実行できます。嬉しい！！**


