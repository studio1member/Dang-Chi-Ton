using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Component")]
    public Transform playerParent;
    public Rigidbody rb;
    public Animator anim;
    public LayerMask Enemy;
    public Status status;
    public PlayfabManager playfabManager;

    public GameObject playerScripts;
    public PlayerCtrl playerCtrl;
    public PlayerCamera playerCamera;
    public PlayerStatus playerStatus;
    public AttackSystem attacksSystem;

    [Header("Camera")]
    public bool zoom;
    public Transform cameraMain;
    public Transform look;
    public Transform camera01;
    public Transform camera02;
    public Transform camera03;
    public Transform mainCamera;
    public Transform lookSword;

    [Header("Sensitivity")]
    public float sensitivity;

    [Header("Move")]
    public bool isGet = false;
    public bool checkGround;
    public bool checkWall;
    public float moveSpeedBasic = 5f;
    public float moveSpeeMax = 10;
    public float moveSpeed;
    public float air = 0.3f;
    public float drag = 5f;

    [Header("Jump")]
    public LayerMask layerGround;
    public int jumpContinuously = 10;
    public float jumpForce = 6f;

    [Header("Animation")]
    public string moveAnim = "Move";
    public string jumpAnim = "Jump";
    public string attackAnim = "Attack01";

    [Header("Body Part")]
    public Transform rightHand;
    public Transform leftHand;

    [Header("Inventory")]
    public Inventory_Button inventory_Button;
    public Transform listInventory_Panel;
    public Transform itemsInInventory_Panel;

    [Header("Shop")]
    public Transform shop_Panel;
    public Transform shopItem_Panel;

    [Header("Buyding Panel")]
    public Text sellingPrice_Text;
    public Image icon;
}
