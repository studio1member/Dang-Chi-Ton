using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class ItemPrefab : MonoBehaviour
{
    public GameObject item;
    public Player player;
    public Sprite sprite;
    public void _Getcomponent_Item(GameObject item, Player player, Sprite sprite)
    {
        this.item = item;
        this.player = player;
        this.sprite = sprite;
    }
    public void _Click_Buy_Item()
    {
        if (this.player == null) return;
        this.player.uiShop.shopSwordPanel._Display(this.sprite, this.item.GetComponent<SwordItem>().ToString() + ".TCĐ");
    }
}
