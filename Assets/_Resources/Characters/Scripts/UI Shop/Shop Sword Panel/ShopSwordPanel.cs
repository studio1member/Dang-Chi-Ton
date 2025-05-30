using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSwordPanel : MonoBehaviour
{
    public Transform ShopItem_Panel;
    public Button Item_Prefab;

    [Space]
    public Text NameItem_Text;
    public Image Item_Image;
    public Text Selling_Price_Text;
    public Text InfoItem_Text;
    public void _Display(Sprite Item_Image, string Selling_Price_Text)
    {
        this.NameItem_Text = null;
        this.Item_Image.sprite = Item_Image;
        this.Selling_Price_Text.text = Selling_Price_Text;
        this.InfoItem_Text = null;
    }

    public void _Buyding_Button()
    {

    }
}
