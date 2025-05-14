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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Get"))
        {
            car = other.gameObject;
            getButton.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Get"))
        {
            car = null;
            getButton.SetActive(false);
        }
    }
}
