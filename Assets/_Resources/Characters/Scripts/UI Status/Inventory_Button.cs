using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Button : MonoBehaviour
{
    [SerializeField] private GameObject ListInventory_Panel;
    public void _Inventory_Button()
    {
        if (this.ListInventory_Panel.activeSelf) _TurnOff();
        else _TurnOn();
    }
    private void _TurnOn()
    {
        this.ListInventory_Panel.SetActive(true);
    }
    private void _TurnOff()
    {
        this.ListInventory_Panel.SetActive(false);
    }
}
