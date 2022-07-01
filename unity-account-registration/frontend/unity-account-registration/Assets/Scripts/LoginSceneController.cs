using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoginSceneController : MonoBehaviour
{
    [SerializeField] HttpClient httpClient;
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] Button button;
    [SerializeField] TMP_InputField usernameInputField;
    [SerializeField] TMP_InputField passwordInputField;



    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        //ボタンがクリックイベントを受け取った時に、httpリクエスト(Postメソッド)を飛ばし、ログインする。 
        button.onClick.AddListener(() =>
        {
            LoginRequest(usernameInputField.text, passwordInputField.text);
        });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    void LoginRequest(string username, string password)
    {
        // 送信するデータ
        // json = オブジェクトを文字列で表す。httpリクエストによるやり取りでは文字列(やバイト)で送受信する必要があるため、オブジェクトを文字列で表して通信するということをやりがち。 
        Model.User user = new Model.User(username, password);
        string requestData = JsonUtility.ToJson(user);

        httpClient.Request(DisplayResult, HttpClient.Method.POST, "/user/login", requestData);
    }

    /// <summary>
    /// 返ってきた結果を表示する
    /// </summary>
    /// <param name="responseData"></param>
    void DisplayResult(string responseData)
    {
        // 文字列をSignupResponse型のオブジェクトに変換してC♯で扱い易いようにする。
        Model.Response response = JsonUtility.FromJson<Model.Response>(responseData);
        if (response.success)
        {
            textMeshPro.text = $"login success! \n";
        }
        else
        {
            textMeshPro.text = $"login failed. error: {response.error}\n";
            Canvas.ForceUpdateCanvases();
        }
    }
}
