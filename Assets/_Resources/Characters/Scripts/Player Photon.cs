using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhoton : MonoBehaviour
{
    [SerializeField] private Player player;
    public GameObject InventoryDisplay;
    private void Awake()
    {
        _Inventory_Display();
    }
    public void _Jump_Effects()
    {
        GameObject EffectJump = PhotonNetwork.Instantiate("Prefabs/Effects/Jump Effect", transform.position, Quaternion.identity);
        Destroy(EffectJump, 0.5f);
    }
    public void _Inventory_Display()
    {
        this.InventoryDisplay.transform.localScale = Vector3.zero;
        if (this.player.playerStatus.GetComponent<PhotonView>().IsMine) this.InventoryDisplay.SetActive(false);
        else this.InventoryDisplay.SetActive(true);
    }
}
