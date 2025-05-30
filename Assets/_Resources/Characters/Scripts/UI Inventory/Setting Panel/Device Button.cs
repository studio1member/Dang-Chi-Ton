using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceButton : MonoBehaviour
{
    private SettingPanel settingPanel;
    private void Start()
    {
        if (this.settingPanel == null) this.settingPanel = GetComponentInParent<SettingPanel>();
    }
}
