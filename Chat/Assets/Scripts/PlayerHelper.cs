using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Obsolete]
public class PlayerHelper : NetworkBehaviour
{
    GameHelper _gameHelper;

    // Start is called before the first frame update
    void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();

        if (isLocalPlayer)
            _gameHelper.CurrentPlayer = this;
    }

    
    public void Send(string message)
    {
        CmdSend(netId, message);
    }

    [Command]

    public void CmdSend(NetworkInstanceId id, string message)
    {
        int rand = Random.Range(0, 100);

        Debug.Log("Send = " + message + "/" + id);
        RpcSend(id, message, rand);
    }

    [ClientRpc]

    public void RpcSend(NetworkInstanceId id, string message, int rand)
    {
        _gameHelper.TextBlock.text += System.Environment.NewLine + id + " : " + message + "/ random : " + rand;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
