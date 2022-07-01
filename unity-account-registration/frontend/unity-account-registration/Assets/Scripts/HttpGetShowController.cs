using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 入力したパスに対してGetリクエストを送り、返ってきたレスポンスの中身を表示する（=ブラウザと似た機能）クラス 
/// </summary>
public class HttpGetShowController : MonoBehaviour
{
    [SerializeField] HttpClient httpClient;
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] Button button;

    [SerializeField] TMP_InputField pathInputField;

    // Start is called before the first frame update
    void Start()
    {
        //ボタンがクリックイベントを受け取った時に、httpリクエスト(Getメソッド)を飛ばし、返ってきた文字を表示する。 
        button.onClick.AddListener(() =>
        {
            httpClient.Request(GetHelloWorld, HttpClient.Method.GET, pathInputField.text, null);
        });
    }

    void GetHelloWorld(string responseData)
    {
        textMeshPro.text = responseData;
        Canvas.ForceUpdateCanvases(); //強制的に描画し直ししないと、scroll viewの高さが変わらない
    }
}

