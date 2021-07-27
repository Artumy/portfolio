using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
    public InputField Input;
    public Text TextBlock;

    private PlayerHelper _currentPlayer;

    public PlayerHelper CurrentPlayer
    {
        get { return _currentPlayer; }
        set { _currentPlayer = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Send()
    {
        CurrentPlayer.Send(Input.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
