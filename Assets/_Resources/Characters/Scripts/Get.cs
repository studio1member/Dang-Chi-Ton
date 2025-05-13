using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject car, getButton, playerGet;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && car != null && !player.isGet)
        {
            player.isGet = true;
            playerGet.transform.SetParent(car.transform);
            playerGet.transform.position = new Vector3(0, 1, 0);
        }else if (Input.GetKeyDown(KeyCode.F) && player.isGet)
        {
            player.isGet = false;
            playerGet.transform.SetParent(null);
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
