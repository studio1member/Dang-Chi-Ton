using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlSettingPanel : MonoBehaviour
{
    [SerializeField] SettingPanel settingPanel;
    public void _Press_Device()
    {
        settingPanel._Device();
    }
}
