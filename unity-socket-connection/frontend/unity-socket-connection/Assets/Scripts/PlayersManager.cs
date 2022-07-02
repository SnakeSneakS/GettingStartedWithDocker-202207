using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour
{
    [SerializeField] PlayerController basePlayerController;
    Dictionary<System.Guid, PlayerController> players;

    public void handleData(Model.SocketModel data)
    {
        //既に存在 = 動かす
        if (players.ContainsKey(data.user_id))
        {
            players[data.user_id].MoveToward(data.move);
        }
        //存在しない = 新しく作る
        else
        {
            PlayerController playerCon = GameObject.Instantiate(basePlayerController.gameObject).GetComponent<PlayerController>();
            playerCon.UserID = data.user_id;
            playerCon.Username = data.name;
            players.Add(data.user_id, playerCon);
        }
    }
}
