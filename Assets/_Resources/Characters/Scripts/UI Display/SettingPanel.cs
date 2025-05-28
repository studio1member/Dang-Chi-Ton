using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [Header("Device")]
    [SerializeField] Button Device_Button;
    [SerializeField] Sprite Mobile_Sprite;
    [SerializeField] Sprite PC_Sprite;
    public void _Device()
    {
        this.Device_Button.image.sprite = PC_Sprite;
    }
}
