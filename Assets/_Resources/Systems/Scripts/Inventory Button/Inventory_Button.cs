using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Button : MonoBehaviour
{
    public Transform list_Inventory_Panel, profile_Panel, inventory_Panel, setting_Panel, shop_Panel, buyding_Panel, typesOfMoney_Panel;
    [SerializeField] private Player player;
    public void _List_Inventory_Button()
    {
        _Turn_Off_Panel();
        if (list_Inventory_Panel.gameObject.activeSelf) list_Inventory_Panel.gameObject.SetActive(false);
        else list_Inventory_Panel.gameObject.SetActive(true);
        _On_Update_Coin();
    }
    public void _Profile_Button()
    {
        _Turn_Off_Panel();
        if (profile_Panel.gameObject.activeSelf) profile_Panel.gameObject.SetActive(false);
        else profile_Panel.gameObject.SetActive(true);
        _On_Update_Coin();
    }
    public void _Inventory_Button()
    {
        _Turn_Off_Panel();
        if (inventory_Panel.gameObject.activeSelf) inventory_Panel.gameObject.SetActive(false);
        else inventory_Panel.gameObject.SetActive(true);
        _On_Update_Coin();
    }
    public void _Setting_Button()
    {
        _Turn_Off_Panel();
        if (setting_Panel.gameObject.activeSelf) setting_Panel.gameObject.SetActive(false);
        else setting_Panel.gameObject.SetActive(true);
        _On_Update_Coin();
    }
    private void _Turn_Off_Panel()
    {
        player.playfabManager._Update_Coin();
        if (profile_Panel.gameObject.activeSelf) profile_Panel.gameObject.SetActive(false);
        if (inventory_Panel.gameObject.activeSelf) inventory_Panel.gameObject.SetActive(false);
        if (setting_Panel.gameObject.activeSelf) setting_Panel.gameObject.SetActive(false);
    }
    private void _On_Update_Coin()
    {
        if (list_Inventory_Panel.gameObject.activeSelf) typesOfMoney_Panel.gameObject.SetActive(true);
        else typesOfMoney_Panel.gameObject.SetActive(false);
    }
}
