using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    public GameObject item;
    [SerializeField] private Player player;
    public void _Click_Buyding_Item()
    {
        GameObject item = Instantiate(this.item);
        item.transform.SetParent(player.itemsInInventory_Panel);
    }
}
