using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [Header("Chế độ chơi")]
    [SerializeField] private Sprite DeviceSprite;
    public void _Device()
    {
        if(DeviceSprite.name == "Mobile Mod")
        {
            Button clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
            DeviceSprite = Resources.Load<Sprite>("Setting/Icon/Mobile or PC/PC Mod");
            clickedButton.GetComponent<Image>().sprite = DeviceSprite;
            Debug.Log("Mobile Mod");
        }
        else
        {
            Button clickedButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
            DeviceSprite = Resources.Load<Sprite>("Setting/Icon/Mobile or PC/Mobile Mod");
            clickedButton.GetComponent<Image>().sprite = DeviceSprite;
            Debug.Log("PC Mod");
        }
    }
}
