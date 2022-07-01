using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// モデルを管理するクラス
/// </summary>
public class Model : MonoBehaviour
{
    /// <summary>
    /// ユーザー
    /// </summary>    
    [System.Serializable]
    public class User
    {
        [SerializeField] public uint id = 0;
        [SerializeField] public string name = "username";
        [SerializeField] public string password = "";

        //Userクラスのコンストラクタ: User user = new User(); とした時に実行されるもの。
        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
        }
        public User(uint id, string name, string password)
        {
            this.id = id;
            this.name = name;
            this.password = password;
        }
    }


    /// <summary>
    /// 成功したかどうかを示す最も基本となるレスポンス
    /// </summary>
    [System.Serializable]
    public class Response
    {
        [SerializeField] public bool success = false;
        [SerializeField] public string error = "";
    }


    /// <summary>
    /// Signupの結果を返すレスポンス
    /// Responseを継承している = successフィールドやerrorフィールドをもつ。
    /// それに比べて自分のユーザIDも取得する。
    /// </summary>
    [System.Serializable]
    public class SignupResponse: Response
    {
        [SerializeField] public int id = 0;
    }
}
