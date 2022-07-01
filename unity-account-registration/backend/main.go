package main

import (
	"fmt"
	"log"
	"net/http"
	"os"

	"github.com/SnakeSneakS/GettingStartedWithDocker-202207/unity-account-registration/backend/db"
	"github.com/SnakeSneakS/GettingStartedWithDocker-202207/unity-account-registration/backend/db/model"
	"github.com/SnakeSneakS/GettingStartedWithDocker-202207/unity-account-registration/backend/user"
	"github.com/gin-gonic/gin"
)

//main.goファイルのmain関数の中が実行される
func main() {
	//データベースと接続する
	db.Start()

	//ginのエンジンを作る
	engine := gin.Default()

	// どのパスで何を実行するか(ルーティング)を記述する
	engine.GET("/", helloWorld)
	engine.POST("/user/signup", userSignup)
	engine.POST("/user/login", userLogin)
	engine.GET("/users", userList)

	//port
	port := os.Getenv("SERVER_PORT")
	if port == "" {
		port = "80"
	}

	//start server
	log.Printf("Server run on port %s", port)
	engine.Run(fmt.Sprintf(":%s", port))
}

// helloWorld just write hello World
func helloWorld(c *gin.Context) {
	c.JSON(http.StatusOK, gin.H{
		"message": "Hello World!!",
	})
}

// userSignup handle user signup data
func userSignup(c *gin.Context) {
	var err error

	//リクエストのBodyからユーザの情報を取り出す
	var u model.User
	err = c.ShouldBindJSON(&u)
	log.Print(u)

	//ユーザの情報がリクエスト中に正しくなかった場合、エラーを返す
	if err != nil {
		c.JSON(http.StatusBadRequest, gin.H{
			"success": false,
			"id":      0,
			"error":   err.Error(),
		})
		return
	}
	//名前かパスワードが空だった場合、エラーを返す
	if u.Name == "" || u.Password == "" {
		c.JSON(http.StatusBadRequest, gin.H{
			"success": false,
			"id":      0,
			"error":   "empty name or password",
		})
		return
	}

	//ログ出力
	log.Printf("Signup User: %s", u.Name)

	//サインアップ（アカウント作成）処理
	var id uint32
	id, err = user.Signup(u.Name, u.Password)
	if err != nil {
		c.JSON(http.StatusBadRequest, gin.H{
			"success": false,
			"id":      id,
			"error":   err.Error(),
		})
		return
	}

	u.ID = id

	c.JSON(http.StatusOK, gin.H{
		"success": true,
		"id":      id,
		"error":   "",
	})
}

//user login
func userLogin(c *gin.Context) {
	var u model.User
	var err error
	err = c.ShouldBindJSON(&u)
	if err != nil {
		c.JSON(http.StatusBadRequest, gin.H{
			"success": false,
			"error":   err.Error(),
		})
		return
	}

	err = user.Login(u.Name, u.Password)
	if err != nil {
		c.JSON(http.StatusUnauthorized, gin.H{
			"success": false,
			"error":   err.Error(),
		})
		return
	}

	c.JSON(http.StatusOK, gin.H{
		"success": true,
		"error":   "",
	})
}

//list users
func userList(c *gin.Context) {
	users := user.List()
	c.JSON(http.StatusOK, gin.H{
		"users": users,
	})
}
