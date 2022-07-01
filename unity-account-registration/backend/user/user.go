package user

import (
	"errors"

	"github.com/SnakeSneakS/GettingStartedWithDocker-202207/unity-account-registration/backend/core"
	"github.com/SnakeSneakS/GettingStartedWithDocker-202207/unity-account-registration/backend/db"
	"github.com/SnakeSneakS/GettingStartedWithDocker-202207/unity-account-registration/backend/db/model"
)

func Signup(name, password string) (uint32, error) {
	//パスワードは暗号化して保存しよう
	hashed, err := core.BcryptHash(password)
	if err != nil {
		return 0, err
	}

	u := &model.User{
		Name:     name,
		Password: hashed,
	}

	r := db.DB.Create(&u)
	if r.Error != nil {
		return 0, r.Error
	}
	if r.RowsAffected == 0 {
		return 0, errors.New("no row affected")
	}

	return u.ID, nil
}

func Login(name, password string) error {
	var u model.User
	r := db.DB.Where("name = ?", name).First(&u)
	if r.Error != nil {
		return r.Error
	}
	if r.RowsAffected != 1 {
		return errors.New("rowsAffected is not one")
	}

	return core.BcryptCompare(u.Password, password)
}

func List() []model.User {
	var users []model.User
	db.DB.Select("id", "name").Find(&users)
	return users
}
