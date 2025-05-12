using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonLaucher : MonoBehaviourPunCallbacks
{
    [SerializeField] private Vector3 spawnPoint = new Vector3(0, 2, 0);
    [SerializeField] private GameObject player;
    private GameObject playerScripts;
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
        GameObject player = PhotonNetwork.Instantiate(this.player.name, spawnPoint, Quaternion.identity);
        foreach (Transform i in player.transform) if (i.name == "Player Scripts") playerScripts = i.gameObject;
        playerScripts.SetActive(true);
        player.GetComponent<Status>().enabled = true;
    }
}
