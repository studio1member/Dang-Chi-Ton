using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy : MonoBehaviour
{
    [SerializeField] private GameObject itemSell;
    [SerializeField] private Player player;
    [SerializeField] private Buyding buyding;
    public void _On_Buy()
    {
        this.buyding.item = this.itemSell;
        this.player.inventory_Button.buyding_Panel.gameObject.SetActive(true);
    }
}
