using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{

    [SerializeField] private InputField lobbyName;

    [SerializeField] private LobbyItem lobbyItem;
    [SerializeField] private PlayerItem playerItem;
    [SerializeField] private GameObject lobbyListParent;
    [SerializeField] private GameObject createRoom;
    [SerializeField] private GameObject room;
    [SerializeField] private Button LeaveButton;
    [SerializeField] private Button StartButton;

    private List<LobbyItem> roomListUI = new List<LobbyItem>();
    private List<PlayerItem> playerListUI = new List<PlayerItem>();

    // Start is called before the first frame update
    void Start()
    {
        Connect();
        room.SetActive(false);
        StartButton.interactable = false;
        LeaveButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Connect() {
        PhotonNetwork.NickName = "Player" + Random.Range(0, 5000);
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);
        createRoom.SetActive(false);
        lobbyListParent.SetActive(false);
        room.SetActive(true);
        UpdatePlayerList();
        LeaveButton.interactable = true;

        if (PhotonNetwork.IsMasterClient) {
            StartButton.interactable = true;
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdatePlayerList();
    }

    public override void OnLeftRoom()
    {
        createRoom.SetActive(true);
        lobbyListParent.SetActive(true);
        room.SetActive(false);
        Debug.Log("Left Room");
        StartButton.interactable = false;
        LeaveButton.interactable = false;

    }

    public void CreateRoom() {
        if(string.IsNullOrEmpty(lobbyName.text) == false)
        {
            PhotonNetwork.CreateRoom(lobbyName.text, new RoomOptions() { MaxPlayers = 4 }, null);
        }
        
    }

    public void JoinRoom(string n) {
        PhotonNetwork.JoinRoom(n);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
    }

    public void UpdateRoomList(List<RoomInfo> roomList)
    {
       
        
        for(int i = 0; i < roomListUI.Count; i++)
        {
            Destroy(roomListUI[i].gameObject);
        }
        roomListUI.Clear();

        

        for (int i = 0; i < roomList.Count; i++)
        {
            
            if (roomList[i].PlayerCount == 0) { continue; }
            LobbyItem newLobby = Instantiate(lobbyItem);
            newLobby.lobbyManager = this;
            newLobby.SetName(roomList[i].Name);
            newLobby.transform.SetParent(lobbyListParent.transform);
            newLobby.transform.localScale = new Vector3(1, 1, 1);

            roomListUI.Add(newLobby);
        }

    }

    public void UpdatePlayerList()
    {
        for (int i = 0; i < playerListUI.Count; i++)
        {
            Destroy(playerListUI[i].gameObject);
        }
        playerListUI.Clear();
        if (PhotonNetwork.CurrentRoom == null) { return; }
        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            PlayerItem newPLayer = Instantiate(playerItem);
            newPLayer.lobbyManager = this;
            newPLayer.SetName(player.Value.NickName);
            newPLayer.transform.SetParent(room.transform);
            newPLayer.transform.localScale = new Vector3(1, 1, 1);

            playerListUI.Add(newPLayer);
        }
    }

    public void LeaveRoom() {
        PhotonNetwork.LeaveRoom();
        
    }

    public void StartGame() {
        PhotonNetwork.LoadLevel("Main");
    }
}
