using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SignupSceneController : MonoBehaviour
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
        //ボタンがクリックイベントを受け取った時に、httpリクエスト(Postメソッド)を飛ばし、返ってきた文字を表示する。 
        button.onClick.AddListener(() =>
        {
            SignupRequest(usernameInputField.text, passwordInputField.text); 
        });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    void SignupRequest(string username, string password)
    {
        // 送信するデータ
        // json = オブジェクトを文字列で表す。httpリクエストによるやり取りでは文字列(やバイト)で送受信する必要があるため、オブジェクトを文字列で表して通信するということをやりがち。 
        Model.User user = new Model.User(username, password);
        string requestData = JsonUtility.ToJson(user);

        httpClient.Request(DisplayResult, HttpClient.Method.POST, "/user/signup", requestData);
    }

    /// <summary>
    /// 返ってきた結果を表示する
    /// </summary>
    /// <param name="responseData"></param>
    void DisplayResult(string responseData)
    {
        // 文字列をSignupResponse型のオブジェクトに変換してC♯で扱い易いようにする。
        Model.SignupResponse signupResponse = JsonUtility.FromJson<Model.SignupResponse>(responseData);
        if (signupResponse.success)
        {
            textMeshPro.text = $"signup success! user_id: {signupResponse.id}\n";
        }
        else
        {
            textMeshPro.text = $"signup failed. error: {signupResponse.error}\n";
            Canvas.ForceUpdateCanvases();
        }
    }
}
