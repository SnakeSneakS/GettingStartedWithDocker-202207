# nextcloudを動かす 

# 準備
- [.env.templateファイル](./.env.template)を書き換えて新たに.envファイルを作る
- 例1: 
    ```.env
    SQLITE_DATABASE=nextcloud_db
    NEXTCLOUD_ADMIN_USER=admin
    NEXTCLOUD_ADMIN_PASSWORD=admin
    ```
- 例2: 
    - 書き換えるのめんどくせ〜〜っていう人は次のコマンドでおk 
        ```cp.sh
        cp ./.env.template ./.env
        ``` 


# nextcloudを動かす 
- カレンとディレクトリ下にdocker-compose.yamlが来るようにする

- 実行: ```docker compose up```
    - ```Ctrl+C```で実行停止する

- バックグラウンドで実行: ```docker compose up -d```
    - ```docker compose stop```で実行停止 
    - ```docker compose exec app /bin/bash```でコンテナに入る 
    - ```docker compose logs -f --tail 100```で最新100件のログを見る

- アクセス
    - http://localhost:8888 または　http://127.0.0.1:8888
        - localhost(または127.0.0.1)は自分自身のPCを表す 
        - :8888は接続先のポート(動かしているポート)を表す 

- その他
    - docker-composeファイルを書き換えてビルドし直す場合は```---build```オプションをつけて```docker compose up --build```などをする  
    - 全削除: ```docker compose down --rmi all --volumes --remove-orphans```
        - ローカルフォルダにbindしている場合はそのディレクトリを削除する必要あり。```rm -rf nextcloud```など。
    - ヘルプ: ```docker compose --help```でヘルプを確認できます 

# 上級者向け
## カスタマイズ
- [nextcloudのdockerイメージ](https://hub.docker.com/_/nextcloud)の「Auto configuration via environment variables」という項目に色々カスタマイズできる要素があるので、それでカスタマイズして試してみよう！
    - 例えば...
        - PHP_MEMORY_LIMITに値を設定する
        - PHP_UPLOAD_LIMITに値を設定する
        - データベースをSQLite以外のものに変える(これはdocker-compose.yamlファイルを書き換える必要あり) 
- environment variablesは```.env```ファイルに書いたものになります。[.env.template](./.env/template)ファイルが参考になるかも。 

## 公開する
- ファイアーウォール設定、ポート解放、証明書(https通信に必要)、（DNS登録） など色々手間がかかるためここではやりません。意欲ある方は頑張ってください。  

# 参考
- [docker compose](https://docs.docker.jp/engine/reference/commandline/compose_toc.html) 
- [nextcloudのdockerイメージ](https://hub.docker.com/_/nextcloud)