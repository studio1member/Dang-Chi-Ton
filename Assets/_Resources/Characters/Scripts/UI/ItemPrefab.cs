using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        this.player.icon.sprite = sprite;
        this.player.sellingPrice_Text.text = item.GetComponent<SwordItem>().sellingPrice.ToString() + ".TCĐ";
    }
}
