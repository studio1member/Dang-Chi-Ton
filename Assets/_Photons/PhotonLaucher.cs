using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonLaucher : MonoBehaviourPunCallbacks
{
    [SerializeField] private Vector3 spawnPoint = new Vector3(0, 2, 0);
    [SerializeField] private GameObject player;
    private void Awake()
    {
        Debug.Log("Đang kết nối...");
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Đã kết nối");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Vào Lobby");
        PhotonNetwork.JoinOrCreateRoom("Game", null, null);
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Vào game");
        GameObject player = PhotonNetwork.Instantiate("Prefabs/Player/Player", spawnPoint, Quaternion.identity);
        player.GetComponent<Status>().enabled = true;
        player.GetComponent<PlayerStatus>().playerScript.SetActive(true);
        player.GetComponent<Status>().enabled = true;
    }
}
