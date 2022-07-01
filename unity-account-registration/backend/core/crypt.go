package core

import "golang.org/x/crypto/bcrypt"

const (
	cost = 10
)

//BcryptHash returns bcrypt hash string
func BcryptHash(s string) (string, error) {
	b := []byte(s)
	hashed, err := bcrypt.GenerateFromPassword(b, cost)
	if err != nil {
		return "", err
	}
	return string(hashed), err
}

//BcryptCompare compares bcrypt hash string and plane string
func BcryptCompare(hashed, plane string) error {
	err := bcrypt.CompareHashAndPassword([]byte(hashed), []byte(plane))
	return err
}
