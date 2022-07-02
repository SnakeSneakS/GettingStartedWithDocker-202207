package main

import (
	"fmt"
	"os"

	"github.com/gin-gonic/gin"
	"gopkg.in/olahol/melody.v1"
)

func main() {
	//http router
	r := gin.Default()

	//websocket
	m := melody.New()

	r.GET("/", func(c *gin.Context) {
		c.Writer.Write([]byte("websocket server"))
	})

	r.GET("/ws", func(c *gin.Context) {
		m.HandleRequest(c.Writer, c.Request)
	})

	//broadcast message
	m.HandleMessage(func(s *melody.Session, msg []byte) {
		m.Broadcast(msg)
	})

	port := os.Getenv("PORT")
	if port == "" {
		port = "80"
	}
	r.Run(fmt.Sprintf(":%s", port))
}
