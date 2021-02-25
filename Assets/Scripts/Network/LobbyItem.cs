using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyItem : MonoBehaviour
{
    public LobbyManager lobbyManager;
    [SerializeField] private Text lobbyName;

    public void SetName(string ln)
    {
        lobbyName.text = ln;
    }

    public void OnJoinPressed()
    {
        lobbyManager.JoinRoom(lobbyName.text);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
