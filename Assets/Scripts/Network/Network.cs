//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using ExitGames.Client.Photon;
//using Photon.Pun;
//using Photon.Realtime;
//using UnityEngine.UI;


//public class Network : MonoBehaviourPunCallbacks
//{
//    public Text status;
//    public CameraFollow playerCamera;

//    // Start is called before the first frame update
//    void Start()
//    {
//        status.text = "Connecting...";
//        PhotonNetwork.NickName = "Player" + Random.Range(0, 5000);
//        PhotonNetwork.ConnectUsingSettings();

//    }

//    public override void OnConnectedToMaster()
//    {
//        status.text = "Connected to Server... Joining Room";
//        PhotonNetwork.JoinOrCreateRoom("Room1", new RoomOptions() { MaxPlayers = 4 }, null);
//    }

//    public override void OnJoinedRoom()
//    {
//        status.text = "Connected";
//        playerCamera.target = PhotonNetwork.Instantiate("Player",
//            new Vector3(
//                Random.Range(-8, 8),
//                Random.Range(-8, 8),
//                -1
//            ), Quaternion.identity).transform;
//    }


//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


public class Network : MonoBehaviourPunCallbacks
{
    public Text status;
    public CameraFollow playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera.target = PhotonNetwork.Instantiate("Player",
           new Vector3(
               Random.Range(-8, 8),
               Random.Range(-8, 8),
               -1
           ), Quaternion.identity).transform;
        status.text = "Connected to: " + PhotonNetwork.CurrentRoom.Name;

    }


    public override void OnJoinedRoom()
    {


    }


    // Update is called once per frame
    void Update()
    {

    }
}
