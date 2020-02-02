using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureController : MonoBehaviour {

    //player info UI (until moved to stat panel or something)
    public Text txtHealth;
    public Text txtName;
    public Image healthBar;

    //enemy info UI
    public Text txtHealthE;
    public Text txtNameE;
    public Image healthBarE;

    //to be moved to character eventually
    private double health;
    private double maxHealth;
    private double healthRegen;

    Enemy currentEnemy;
    bool currentEnemyDead = true;
    bool dead;

    public Dungeon[] Dungeons;
    private Dungeon currentDungeon;

    [SerializeField] private Inventory inventory;
    [SerializeField] private Character character;
    [SerializeField] private StatPanel enemyStatPanel;

    bool isAttacking = true;
    float timer = 0.0f;

    void Start () {

        health = 500;
        maxHealth = 500;
        healthRegen = 20;

        currentDungeon = Dungeons[0];
        spawnEnemy ();
        InvokeRepeating ("UpdateEverySecond", 0, 1.0f);
    }

    // Update is called once per frame
    void Update () {
        updateHealthBar ();
        regen ();
    }

    // Update is called once per second
    void UpdateEverySecond () {
        if (isAttacking) {
            combat ();
        }
    }

    void combat () {

        //deal damage
        currentEnemy.loseHealthCalc (character.PhysicalAttack, character.MagicalAttack);
        // Debug.Log ("Enemy health: " + currentEnemy.Health);

        if (currentEnemy.Health > 0) {
            //take damage
            loseHealthCalc ();

            // Debug.Log ("player health: " + health);
            if (health <= 0) {
                death ();
            }

        } else {
            defeatEnemy ();
        }

    }

    void updateHealthBar () {
        if (health > 0) {
            healthBar.fillAmount = (float) (health / maxHealth);
            txtHealth.text = health.ToString ("F1") + "hp";
        } else {
            txtHealth.text = "dead";
        }

        if (!currentEnemyDead) {
            healthBarE.fillAmount = (float) (currentEnemy.Health / currentEnemy.MaxHealth);
            txtHealthE.text = currentEnemy.Health.ToString ("F1") + "hp";
        } else {
            txtHealthE.text = "dead";
        }
    }

    void dropItem () {
        Item itemCopy = currentEnemy.ItemDrop.GetCopy ();
        Debug.Log("Adding a " + itemCopy.ToString());
        inventory.AddItem (itemCopy);
    }

    void spawnEnemy () {
        currentEnemy = currentDungeon.ReturnRandomEnemy ();
        currentEnemy.Health = currentEnemy.MaxHealth;
        currentEnemyDead = false;

        //UI stuff
        enemyStatPanel.SetStats (currentEnemy.PhysicalAttack, currentEnemy.PhysicalDefense, currentEnemy.MagicalAttack, currentEnemy.MagicalDefense);
        enemyStatPanel.UpdateStatValues ();
        txtNameE.text = currentEnemy.Name;
    }

    void defeatEnemy () {
        currentEnemyDead = true;
        dropItem ();
        spawnEnemy ();
        Debug.Log ("new enemy spawned is " + currentEnemy.Name);
    }

    public void loseHealthCalc () {
        double ptotal = currentEnemy.PhysicalAttack.Value - character.PhysicalDefense.Value;
        double mtotal = currentEnemy.MagicalAttack.Value - character.MagicalDefense.Value;
        if (ptotal > 0) {
            health -= ptotal;
            // Debug.Log ("Player took " + ptotal + " p dmg");
        }
        if (mtotal > 0) {
            health -= mtotal;
            // Debug.Log ("Player took " + mtotal + " m dmg");
        }
    }

    void death () {
        isAttacking = false;
        Debug.Log ("Player has died");
    }

    public void regen () {
        if (health < maxHealth) { health += (healthRegen * Time.deltaTime); }
        if (!currentEnemyDead && currentEnemy.Health < currentEnemy.MaxHealth) { currentEnemy.gainHealth (currentEnemy.HealthRegen * Time.deltaTime); }
    }
}