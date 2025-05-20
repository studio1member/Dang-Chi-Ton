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
            item.transform.SetParent(player.inventory_Button.shopItem_Panel);

            Sprite sprite = Resources.Load<Sprite>("Icons/" + idItem[i].ToString());
            item.image.sprite = sprite;

            Buy buy = item.GetComponent<Buy>();
            buy.itemSell = Resources.Load<GameObject>("Prefabs/Items/" + idItem[i].ToString());
            buy.icon = sprite;
        }
    }
}
