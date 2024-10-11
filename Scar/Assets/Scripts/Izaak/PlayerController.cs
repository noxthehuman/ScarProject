using System;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     private string chemin, jsonString;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private  float playerSpeed;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GunController theGun;
    [SerializeField] private WeaponController theWeapon;
    [SerializeField] private Rigidbody playerRigidbody;
    
    //Statistiques
    public static int numberBullets = 0;
    public static float numberDamagesReceived = 0;
    public static float numberDamagesDealt = 0;
    public static int score = 0;
    
    //Movement and Dash variables
    public static Vector3 lastDirectionIntent;
    private float dashCounter;
    private float dashDistance = 200000;
    public static bool isDashing;

    public static int BossRushroomCounter;

    public static int cpt;

    private void Awake()
    {
        BossRushroomCounter = 0;
        numberBullets = 0;
        numberDamagesReceived = 0;
        numberDamagesDealt = 0;
        score = 0;
        SpawnEnemy.nbMonster = 0;
        BossBehaviour.isAlive = 1;
        cpt = 0;
        chemin = Application.streamingAssetsPath + "/ActifPassif.json";
        jsonString = File.ReadAllText(chemin);
        JSONActifPassif choosePower = JsonUtility.FromJson<JSONActifPassif>(jsonString);
        GameInfo.passiveSkill = choosePower.passif;
        GameInfo.activeSkill = choosePower.actif;
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void FixedUpdate()
    {
        playerTransform.localPosition += lastDirectionIntent * (Time.deltaTime * playerSpeed);
    }
    
    void Update()
    {
        if (!CutScenesEnter.isCutscene)
        {
            Movement();
            View();
            Dashing();
            Firing();

            lastDirectionIntent = lastDirectionIntent.normalized;   
        }
    }

    private void Dashing()
    {
        dashCounter -= Time.deltaTime;
        if (dashCounter <= 0 && Input.GetMouseButtonDown(1))
        {
            dashCounter = 2;
            if (Input.GetKey(KeyCode.D))
            {
                playerRigidbody.AddForce(Vector3.right * dashDistance);
                isDashing = true;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                playerRigidbody.AddForce(Vector3.left * dashDistance);
                isDashing = true;
            }
            if (Input.GetKey(KeyCode.Z))
            {
                playerRigidbody.AddForce(Vector3.forward * dashDistance);
                isDashing = true;
            }
            if (Input.GetKey(KeyCode.S))
            {
                playerRigidbody.AddForce(Vector3.back * dashDistance);
                isDashing = true;
            }
        }
        else if (dashCounter <= 1)
        {
            isDashing = false;
        }
    }

    private void Firing()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f)
            theGun.isFiring = true;

        if (Input.GetMouseButtonUp(0))
            theGun.isFiring = false;
    }

    private void Hitting()
    {
        if (Input.GetMouseButtonDown(0))
            theWeapon.isFighting = true;

        if (Input.GetMouseButtonUp(0))
            theWeapon.isFighting = false;
    }

    private void View()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            
            playerTransform.LookAt(new Vector3(pointToLook.x, playerTransform.position.y, pointToLook.z));
        }
    }

    private void Movement()
    {
        // Get key down (Z,Q,S,D) 
        if (Input.GetKey(KeyCode.D))
        {
            lastDirectionIntent += Vector3.right;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            lastDirectionIntent +=  Vector3.left;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            lastDirectionIntent +=  Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            lastDirectionIntent +=  Vector3.back;
        }
        if (!Input.GetKey(KeyCode.Z) && !Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            // Si on lâche la touche on s'arrête
            lastDirectionIntent = Vector3.zero;
        }
    }
}
