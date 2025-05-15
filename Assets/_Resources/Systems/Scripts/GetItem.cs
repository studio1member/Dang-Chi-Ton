using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    [SerializeField] private Transform item;
    public void _Get_Item()
    {
        GameObject playerGet = PhotonView.Find(PhotonNetwork.LocalPlayer.ActorNumber).gameObject;
        playerGet.GetComponent<Player>()._Add_Item(item);
    }
}
