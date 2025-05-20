using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Get : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject car, getButton;

    private void Update()
    {
        _Get_Car();
    }
    private void _Get_Car()
    {
        if (Input.GetKeyDown(KeyCode.F) && car != null && !player.isGet)
        {
            player.isGet = true;
            player.rb.isKinematic = true;
            SwordMovement swordMovement = null;
            if (swordMovement == null) swordMovement = car.GetComponent<SwordMovement>();
            swordMovement.player = player;
            swordMovement.rb.useGravity = false;
            swordMovement.rb.drag = 5;
            car.transform.rotation = Quaternion.identity;
            player.playerParent.rotation = Quaternion.identity;
            player.playerParent.SetParent(car.transform);
            player.playerParent.position = new Vector3(car.transform.position.x, car.transform.position.y + 1, car.transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.F) && player.isGet)
        {
            player.isGet = false;
            player.rb.isKinematic = false;
            SwordMovement swordMovement = null;
            if (swordMovement == null) swordMovement = car.GetComponent<SwordMovement>();
            swordMovement.player = null;
            swordMovement.rb.useGravity = true;
            swordMovement.rb.drag = 1;
            player.playerParent.transform.SetParent(null);
        }
    }
    private void _Get_Item_Shop()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Get"))
        {
            car = other.gameObject;
            getButton.SetActive(true);
        }
        if (other.gameObject.CompareTag("Shop"))
        {
            other.GetComponent<SwordShop>()._Item_Sell(player);
            this.player.inventory_Button._Turn_Off_Panel();
            this.player.inventory_Button.shop_Panel.gameObject.SetActive(true);
            this.player.inventory_Button.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Get"))
        {
            car = null;
            getButton.SetActive(false);
        }
        if (other.gameObject.CompareTag("Shop"))
        {
            this.player.inventory_Button.shop_Panel.gameObject.SetActive(false);
            this.player.inventory_Button.gameObject.SetActive(true);
        }
    }
}
