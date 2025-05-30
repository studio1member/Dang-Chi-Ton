using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Transform playerParent;
    public Rigidbody rb;
    public Animator anim;
    public LayerMask Enemy;

    [Header("Scripts")]
    public PlayerStatus playerStatus;
    public PlayfabManager playfabManager;
    public PlayerPhoton playerPhoton;
    public PlayerEvasionSkill playerEvasionSkill;

    public GameObject playerScripts;
    public PlayerCtrl playerCtrl;
    public PlayerCamera playerCamera;
    public AttackSystem attacksSystem;

    [Header("UI")]
    public UiInventory uiInventory;
    public UiShop uiShop;

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
    public float sensitivity = 50f;

    [Header("Move")]
    public bool isGet = false;
    public bool checkGround;
    public bool checkWall;
    public float air = 0.3f;
    public float drag = 5f;

    [Header("Jump")]
    public LayerMask layerGround;

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

    private void Awake()
    {
        if (playerStatus == null) playerStatus = transform.root.GetComponent<PlayerStatus>();
        if (playerEvasionSkill == null) playerEvasionSkill = transform.GetComponent<PlayerEvasionSkill>();
    }
}
