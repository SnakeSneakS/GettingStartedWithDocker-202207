using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// UnityでHttp通信をするクライアント
/// UnityWebRequestの参考: https://docs.unity3d.com/ja/2021.3/Manual/UnityWebRequest.html など。
/// ドキュメントコメント推奨: https://docs.microsoft.com/ja-jp/dotnet/csharp/language-reference/xmldoc/recommended-tags 
/// </summary>
public class HttpClient : MonoBehaviour
{
    // プロトコル: コンピュータ間で通信をやり取りするための共通規格みたいなやつ 
    // Webページの場合、基本的にHTTPプロトコル: https://developer.mozilla.org/ja/docs/Web/HTTP/Overview 
    [System.Serializable]
    public enum Protocol
    {
        http,   //暗号化なし
        https   //暗号化あり
    }

    // httpリクエストメソッド: https://developer.mozilla.org/ja/docs/Web/HTTP/Methods 
    [System.Serializable]
    public enum Method
    {
        GET,
        POST
    }

    [Tooltip("これは通信プロトコルです。httpやhttpsなどがあります。")]
    [SerializeField] private Protocol protocol = Protocol.http;

    [Tooltip("通信先のホスト名です。idアドレスも可能です。")]
    [SerializeField] private string host = "localhost";

    [Tooltip("通信先のポートです。")]
    [SerializeField] private string port = "8888";

    // protocol, host, port, pathからurlを作る 
    private string url (string path) => $"{protocol}://{host}:{port}{path}"; //getter



    /// <summary>
    /// リクエストを送信する。
    /// </summary>
    /// <param name="handleResponse">レスポンスデータを扱う関数</param>
    /// <param name="method">httpリクエストメソッド。GetやPostなど。</param>
    /// <param name="path">パス</param>
    /// <param name="requestData">リクエストとして送信するデータ</param>
    public void Request(System.Action<string> handleResponse, Method method = Method.GET, string path = "/", string requestData = null)
    {
        StartCoroutine(RequestCoroutine(handleResponse, method, path, requestData)); 
    }


    /// <summary>
    /// リクエストを送信する。
    /// IEnumeratorを使う(コルーチンを使う)ことで、非同期を実現している．
    ///     スレッド: 一つのスレッド内では同期処理。スレッドを切り替えることで非同期を実現。
    ///     コルーチン: (多分)一つのフレームで実行する処理を区切る。フレームは高頻度で変わるため非同期を実現。メインスレッドで動いているためUI変更などもできて嬉しい。  
    /// </summary>
    /// <param name="handleResponse">レスポンスデータを扱う関数</param>
    /// <param name="method">httpリクエストメソッド。GetやPostなど。</param>
    /// <param name="path">パス</param>
    /// <param name="requestData">リクエストとして送信するデータ</param>
    /// <returns></returns>
    protected IEnumerator RequestCoroutine(System.Action<string> handleResponse, Method method=Method.GET, string path="/", string requestData=null)
    {
        UnityWebRequest www = new UnityWebRequest( url(path), method.ToString() );

        //送信するデータを設定する 
        if (requestData != null)
        {
            byte[] data_bytes = System.Text.Encoding.UTF8.GetBytes(requestData); 
            www.uploadHandler = new UploadHandlerRaw(data_bytes);
        }

        //受信用のバッファを生成する
        www.downloadHandler = new DownloadHandlerBuffer();

        //リクエストを送信する。
        //コルーチンの中で実行終了(=サーバから返答が返ってくるまで)を待つ
        yield return www.SendWebRequest();  


        //通信データをログに出力
        Debug.Log($"Request data: {requestData }\n To: {www.url}, Method: {www.method}");
        Debug.Log($"Response code: {www.responseCode}");
        Debug.Log($"Response data: {www.downloadHandler.text}");


        try
        {
            handleResponse(www.downloadHandler.text);
        }
        catch(System.Exception e)
        {
            Debug.LogError(e);
        }

        //httpレスポンスコードが成功を示していなかった場合にはエラーログを表示する
        if(www.result!= UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Error: {www.error}");
        }

        //使い終わったので廃棄 
        www.Dispose();
    }
    
}
