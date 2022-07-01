# 本番環境で使うような場合には、以下のようにしてビルド済みのものを使う。 
# 環境開発では、ソースコードの変更を反映する必要があるため、ビルド済みのものは使わない。 
# 以下ではビルド環境と実行環境を分けることで、実行環境のdockerイメージの容量削減をしている。（go言語はシングルバイナリでビルドされるため、実行環境ではシングルバイナリさえあれば良い）

# STAGE1: build stage
FROM golang:latest AS builder   

# (ビルドに使う)手元のファイルを全てコピー 
COPY . /work 
WORKDIR /work  

# ビルド 
# ビルドしたら、/work/serverにシングルバイナリが生成される。 
RUN go mod download 
RUN CGO_ENABLED=0 GOOS=linux GOARCH=amd64 go build -o /work/server ./main.go 



# STAGE2: release stage 
FROM busybox:latest AS release 
WORKDIR /bin 

# build stageでビルドして生成されたシングルバイナリのみをコピーして実行 = dockerイメージの容量が小さくなる 
COPY --from=builder /work/server /bin/server  
CMD ["/bin/server"]
