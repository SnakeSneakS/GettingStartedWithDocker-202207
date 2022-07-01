package db

import (
	"fmt"
	"log"
	"os"

	"time"

	"github.com/SnakeSneakS/GettingStartedWithDocker-202207/unity-account-registration/backend/db/model"

	"gorm.io/driver/mysql"
	"gorm.io/gorm"
)

// using gorm: https://gorm.io/ja_JP/docs/connecting_to_the_database.html

var DB *gorm.DB

func Start() {
	DB = connect()
	autoMigrate()
}

func autoMigrate() {
	DB.AutoMigrate(&model.User{})
}

func connect() *gorm.DB {
	user := os.Getenv("MYSQL_USER")
	pass := os.Getenv("MYSQL_PASSWORD")
	host := os.Getenv("MYSQL_HOST")
	database := os.Getenv("MYSQL_DATABASE")
	port := os.Getenv("MYSQL_PORT")
	dsn := fmt.Sprintf("%s:%s@tcp(%s:%s)/%s?charset=utf8mb4&parseTime=True&loc=Local", user, pass, host, port, database)

	count := 0

	var db *gorm.DB
	var err error
	log.Println("connecting to DB...")
	for count < 100 {
		db, err = gorm.Open(mysql.Open(dsn), &gorm.Config{})
		if err != nil {
			log.Println("connecting to DB...")
			time.Sleep(time.Second)
		} else {
			log.Println("DB connected!")
			return db
		}
		count++
	}

	log.Fatalln("DB connection error")
	panic(err)
}
