using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordShop : MonoBehaviour
{
    [SerializeField] private List<int> idItem;
    public void _Item_Sell(Player player)
    {
        foreach (Transform i in player.inventory_Button.shopItem_Panel) Destroy(i.gameObject);
        for (int i = 0; i < idItem.Count; i++)
        {
            Button item = Instantiate(player.inventory_Button.item_Prefab);
            item.gameObject.SetActive(true);
            item.transform.SetParent(player.inventory_Button.shopItem_Panel);
            item.GetComponent<ItemPrefab>()._Getcomponent_Item(Resources.Load<GameObject>("Prefabs/Items/" + idItem[i].ToString()), player, Resources.Load<Sprite>("Prefabs/Items/" + idItem[i].ToString()));
        }
    }
}
