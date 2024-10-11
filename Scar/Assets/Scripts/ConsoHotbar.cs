using System.Collections;
using UnityEngine;


public class ConsoHotbar : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject inventory1;
    [SerializeField] private GameObject hotbar;
    private SlotsInventaire hotbarPart;
    private SlotsInventaire inventoryPart1;
    private GameObject amountBoard;
    private AmountBoard amounts;
    private float counter;
    private float damageCooldown = 10f;
    private float defenseCooldown = 15f;
    private GameObject[] enemyBullets;

    private void Awake() {
        //player = GameObject.FindGameObjectWithTag("Player");
        amountBoard = GameObject.FindWithTag("AmountBoard");
        amounts = amountBoard.GetComponent<AmountBoard>();
        hotbarPart = hotbar.GetComponent<SlotsInventaire>();
        inventoryPart1 = inventory1.GetComponent<SlotsInventaire>();
    }

    private void Start()
    {
        counter = damageCooldown;
    }

    IEnumerator DamagePotionCoroutine()
    {
        counter -= Time.deltaTime;
        if(counter <= 0)
        {
            GameInfo.rangedDamage /= 2;
            counter = damageCooldown;
        }
        yield return new WaitForSeconds(0);
    }
    
    private void DamagePotionCooldown()
    {
        GameInfo.rangedDamage /= 2;
    }
    
    private void DefensePotionCooldown()
    {
        EnemyDamages.damageMultiplication = 1f;
    }

    private void Potions(int potionType) {
        switch (potionType)
        {
            case 0:
                GameInfo.rangedDamage *= 2;
                Debug.Log("Damage On");
                Invoke("DamagePotionCooldown", 10);
                break;
            case 1:
                EnemyDamages.damageMultiplication = 0.5f;
                Invoke("DefensePotionCooldown", 15);
                break;
        }
    }

    public void Update() {
        CheckTypeHotBar();
        CheckTypeSlot1();
        CheckTypeSlot2();
        CheckTypeSlot3();
        if(Input.GetKeyDown(KeyCode.F) && hotbarPart.isFull[0]) { // Si on appuie sur F et que la hotbar est pleine, on utilise la potion
            switch(hotbarPart.slots[0].transform.GetChild(0).gameObject.tag) {
                case "DamagePotionHotbar":
                    CheckAmountHotBar();
                    Potions(0);
                    break;
                case "DestructPotionHotbar":
                    CheckAmountHotBar();
                    enemyBullets = GameObject.FindGameObjectsWithTag("bulEnemy");
                    foreach (var bullet in enemyBullets)
                    {
                        float dist = Vector3.Distance(player.transform.position, bullet.transform.position);
                        if (dist <= 20)
                        {
                            Destroy(bullet);   
                        }
                    }
                    break;
                case "ShieldPotionHotbar":
                    CheckAmountHotBar();
                    Potions(1);
                    break;
                case "ManaPotionHotbar":
                    CheckAmountHotBar();
                    if (Mana.currentMana < Mana.maxMana)
                    {
                        Mana.currentMana += Mana.maxMana * 0.3f;
                        if (Mana.currentMana > Mana.maxMana)
                        {
                            Mana.currentMana = Mana.maxMana;
                        }
                    }
                    break;
                case "HealthPotionHotbar":
                    CheckAmountHotBar();
                    if (HealthPlayer.currentHealth < HealthPlayer.maxHealth)
                    {
                        HealthPlayer.currentHealth += HealthPlayer.maxHealth * 0.4f;
                        if (HealthPlayer.currentHealth > HealthPlayer.maxHealth)
                        {
                            HealthPlayer.currentHealth = HealthPlayer.maxHealth;
                        }
                    }
                    
                    break;
                default:
                    break;
            }
        }
    }

    //*** Permet de supprimer par utilisation une potion de la hotbar ***//
    private void CheckAmountHotBar() {
        if(amounts.GetAmountHotBar() == 1) {
            amounts.SetHotBarMany(-1);
            Destroy(hotbarPart.slots[0].transform.GetChild(0).gameObject);
            hotbarPart.isFull[0] = false;
        } else if(amounts.GetAmountHotBar() > 1) {
            amounts.SetHotBarMany(-1);
        }
    }


    //*** Permet de set le type de potion présent dans la hotbar ***//
    private void CheckTypeHotBar() {
        switch(hotbarPart.slots[0].transform.GetChild(0).gameObject.tag) {
            case "DestructPotionHotbar":
                amounts.SetHotbarType("destruct_potion");
                break;
            case "DamagePotionHotbar":
                amounts.SetHotbarType("damage_potion");
                break;
            case "HealthPotionHotbar":
                amounts.SetHotbarType("heal_potion");
                break;
            case "ManaPotionHotbar":
                amounts.SetHotbarType("mana_potion");
                break;
            case "ShieldPotionHotbar":
                amounts.SetHotbarType("shield_potion");
                break;
            default:
                amounts.SetHotbarType("null");
                break;
        }
    }

    //*** Permet de set le type de potion présent dans le slot 3 ***//
    private void CheckTypeSlot3() {
        switch(inventoryPart1.slots[2].transform.GetChild(0).gameObject.tag) {
            case "DestructPotionInventory":
                amounts.SetSlot3Type("destruct_potion");
                break;
            case "DamagePotionInventory":
                amounts.SetSlot3Type("damage_potion");
                break;
            case "ShieldPotionInventory":
                amounts.SetSlot3Type("shield_potion");
                break;
            default:
                amounts.SetSlot3Type("null");
                break;
        }
    }

    //*** Permet de set le type de potion présent dans le slot 2 ***//
    private void CheckTypeSlot2() {
        switch(inventoryPart1.slots[1].transform.GetChild(0).gameObject.tag) {
            case "ManaPotionInventory":
                amounts.SetSlot2Type("mana_potion");
                break;
            default:
                amounts.SetSlot2Type("null");
                break;
        }
    }

    //*** Permet de set le type de potion présent dans le slot 1 ***//
    private void CheckTypeSlot1() {
        switch(inventoryPart1.slots[0].transform.GetChild(0).gameObject.tag) {
            case "HealthPotionInventory":
                amounts.SetSlot1Type("heal_potion");
                break;
            default:
                amounts.SetSlot1Type("null");
                break;
        }
    }
}
