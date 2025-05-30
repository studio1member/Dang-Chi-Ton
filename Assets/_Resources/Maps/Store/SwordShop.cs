using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordShop : MonoBehaviour
{
    [SerializeField] private List<int> idItem;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) _In_Shop(other.GetComponent<PlayerStatus>().playerScript.GetComponent<Player>()); ;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) { _Out_Shop(other.GetComponent<PlayerStatus>().playerScript.GetComponent<Player>()); }
    }
    private void _In_Shop(Player player)
    {
        player.uiShop.gameObject.SetActive(true);
        player.uiShop.shopSwordPanel.gameObject.SetActive(true);
        foreach (Transform i in player.uiShop.shopSwordPanel.ShopItem_Panel) Destroy(i.gameObject);
        for (int i = 0; i < idItem.Count; i++)
        {
            Button item = Instantiate(player.uiShop.shopSwordPanel.Item_Prefab);
            item.gameObject.SetActive(true);
            item.transform.SetParent(player.uiShop.shopSwordPanel.ShopItem_Panel);
            item.GetComponent<ItemPrefab>()._Getcomponent_Item(Resources.Load<GameObject>("Prefabs/Items/" + idItem[i].ToString()), player, Resources.Load<Sprite>("Icons/" + idItem[i].ToString()));
        }
    }
    private void _Out_Shop(Player player)
    {
        player.uiShop.gameObject.SetActive(false);
        player.uiShop.shopSwordPanel.gameObject.SetActive(false);
    }
}
