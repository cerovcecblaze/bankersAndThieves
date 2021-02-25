using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItem : MonoBehaviour
{
    public LobbyManager lobbyManager;
    [SerializeField] private Text playerName;

    public void SetName(string ln)
    {
        playerName.text = ln;
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
