using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{

    [System.Serializable]
    public class SocketModel
    {
        [SerializeField] public System.Guid user_id;
        [SerializeField] public string name;
        [SerializeField] public Vector3 move;

        public SocketModel(System.Guid user_id, string name, Vector3 move)
        {
            this.user_id = user_id;
            this.name = name;
            this.move = move;
        }
    }
}
