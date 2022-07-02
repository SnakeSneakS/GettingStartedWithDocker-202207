using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//(web)socketを取り扱う
using NativeWebSocket;

public class GameController : MonoBehaviour
{
    [SerializeField] WebSocketController wsController;
    [SerializeField] PlayersManager PlayersManager;

    private System.Guid user_id = 0;
    private string username = "player";

    private void Start()
    {
        user_id = System.Guid.NewGuid();

        wsController.websocket.OnMessage += ((bytes) =>
        {
            string message = System.Text.Encoding.UTF8.GetString(bytes);
            Model.SocketModel data = JsonUtility.FromJson<Model.SocketModel>(message);
            PlayersManager.handleData(data);
        });
    }

    int i = 0;
    private void Update()
    {
        if (i < 30)
        {
            i += 1;
            return;
        }
        i = 0;

        if (wsController.websocket.State == NativeWebSocket.WebSocketState.Open)
        {
            string message = JsonUtility.ToJson(
                new Model.SocketModel(user_id, name, new Vector3(1,0,0))
            );
            wsController.websocket.Send(System.Text.Encoding.UTF8.GetBytes(message));
        }
    }
}
