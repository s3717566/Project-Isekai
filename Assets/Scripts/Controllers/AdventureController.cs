using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureController : MonoBehaviour {
    // public Text txtPhyAttack;
    // public Text txtPhyDefence;
    // public Text txtMagAttack;
    // public Text txtMagDefence;
    public Text txtHealth;
    public Text txtName;

    public Image healthBar;

    //enemy statistics
    // public Text txtPhyAttackE;
    // public Text txtPhyDefenceE;
    // public Text txtMagAttackE;
    // public Text txtMagDefenceE;
    public Text txtHealthE;
    public Text txtNameE;

    public Image healthBarE;

    double phyAttack;
    double phyDefence;
    double magAttack;
    double magDefence;
    double health;
    double maxHealth;
    double healthRegen;

    Enemy currentEnemy;
    bool currentEnemyDead = true;
    bool dead;
    // private Inventory inventory;
    private HaremStorage haremStorage;

    public Dungeon[] Dungeons;
    private Dungeon currentDungeon;

    [SerializeField] private Inventory inventory;
    [SerializeField] private Character character;
    [SerializeField] private StatPanel enemyStatPanel;

    bool isAttacking = true;
    float timer = 0.0f;

    List<Enemy> enemyList = new List<Enemy> ();
    List<Dungeon> dungeonList = new List<Dungeon> ();

    void Awake () {
        // haremStorage = new HaremStorage();
        // uiHarem.setHaremStorage (haremStorage);
    }

    void Start () {

        phyAttack = 100;
        phyDefence = 100;
        magAttack = 3;
        magDefence = 1;
        health = 100;
        maxHealth = 1000;
        healthRegen = 100;

        // populateItems ();
        // populateDungeons ();
        // populateEnemies ();

        currentDungeon = Dungeons[0];
        // Debug.Log ("dungeon name: " + dungeonList[0].getName () + dungeonList[0].getId ());
        spawnEnemy ();
        // updateEnemySummary ();
        InvokeRepeating ("UpdateEverySecond", 0, 1.0f);
    }

    // Update is called once per frame
    void Update () {
        updateHealthBar ();
        // updateSummary ();
        // regen ();
    }

    // Update is called once per second
    void UpdateEverySecond () {
        if (isAttacking) {
            combat ();
        }
    }

    void combat () {
        //deal damage
        // currentEnemy.loseHealthCalc (phyAttack, "physical");
        // currentEnemy.loseHealthCalc (magAttack, "magical");

        // currentEnemy.loseHealthCalc (phyAttack, magAttack);

        // if (currentEnemy.getHealth () > 0) {
        //     //take damage
        //     loseHealthCalc ();

        //     if (health <= 0) {
        //         death ();
        //     }

        // } else {
        //     defeatEnemy();
        // }

    }

    // void updateEnemySummary () {
    //     txtPhyAttackE.text = "p.Attack: " + currentEnemy.PhysicalAttack ();
    //     txtPhyDefenceE.text = "p.Defence: " + currentEnemy.PhysicalDefense ();
    //     txtMagAttackE.text = "m.Attack: " + currentEnemy.getMagAttack ();
    //     txtMagDefenceE.text = "m.Defence: " + currentEnemy.getMagDefence ();
    //     txtNameE.text = currentEnemy.getName ();
    //     //add image too
    // }

    // void updateSummary () {
    //     txtPhyAttack.text = "p.Attack: " + phyAttack;
    //     txtPhyDefence.text = "p.Defence: " + phyDefence;
    //     txtMagAttack.text = "m.Attack: " + magAttack;
    //     txtMagDefence.text = "m.Defence: " + magDefence;
    //     txtName.text = "Player";
    //     //add image too
    // }

    void updateHealthBar () {
        if (health > 0) {
            healthBar.fillAmount = (float) (health / maxHealth);
            txtHealth.text = health.ToString ("F1") + "hp";
        } else {
            txtHealth.text = "dead";
        }

        if (!currentEnemyDead) {
            // healthBarE.fillAmount = (float) (currentEnemy.getHealth () / currentEnemy.getMaxHealth ());
            // txtHealthE.text = currentEnemy.getHealth ().ToString ("F1") + "hp";
        } else {
            txtHealthE.text = "dead";
        }
    }

    void dropItem () {
        inventory.AddItem(currentEnemy.ItemDrop);

    }

    // void populateEnemies () {
    // //     //todo: add enemy spawn rate to list
    //     int i = 0;
    //     enemyList.Add (new Enemy (i++, 0, "Thomas", "His friends call him tom.", 2, 2, 2, 2, 100, 1, items.getRandomItem() ));
    //     enemyList.Add (new Enemy (i++, 0, "Bartholomew", "His enemies call him tom.", 2, 2, 3, 2, 100, 1.5,items.getRandomItem()));
    //     enemyList.Add (new Enemy (i++, 0, "bradley", "His friends call him brodey.", 2, 2, 3, 2, 100, 1.5,items.getRandomItem()));
    //     enemyList.Add (new Enemy (i++, 0, "rain", "Not the weather.", 2, 2, 3, 2, 100, 1.5,items.getRandomItem()));
    //     enemyList.Add (new Enemy (i++, 0, "God", "Not much you can do about that buddy.", 40, 40, 40, 40, 200, 10,items.getRandomItem()));
    //     // enemyList.Add (new Enemy (i++, 0, "rain", "Not the weather.", 2, 2, 3, 2, 100, 1.5));
    //     // enemyList.Add (new Enemy (i++, 0, "rain", "Not the weather.", 2, 2, 3, 2, 100, 1.5));
    //     // enemyList.Add (new Enemy (i++, 0, "rain", "Not the weather.", 2, 2, 3, 2, 100, 1.5));
    //     // enemyList.Add (new Enemy (i++, 0, "rain", "Not the weather.", 2, 2, 3, 2, 100, 1.5));
    //     // enemyList.Add (new Enemy (i++, 0, "rain", "Not the weather.", 2, 2, 3, 2, 100, 1.5));

    // }

    // void populateDungeons () {
    //     //todo: store enemies in hashmap where dungeonid is the key
    //     int i = 0;
    //     dungeonList.Add (new Dungeon (i++, "the spooky forest", "like really spooky"));
    // }

    void spawnEnemy () {
        // currentEnemy = pickEnemy (currentDungeon.getId ());
    //     currentEnemy.setHealth (currentEnemy.getMaxHealth ());
            currentEnemy = currentDungeon.ReturnRandomEnemy();
            enemyStatPanel.SetStats(currentEnemy.PhysicalAttack, currentEnemy.PhysicalDefense, currentEnemy.MagicalAttack, currentEnemy.MagicalDefense);
            enemyStatPanel.UpdateStatValues ();
            txtNameE.text = currentEnemy.Name;

    //     updateEnemySummary ();
    //     currentEnemyDead = false;
    }

    // void defeatEnemy() {
    //         currentEnemyDead = true;
    //         dropItem ();
    //         // Debug.Log (currentEnemy.getName() + " has been slain");
    //         spawnEnemy ();
    //         Debug.Log ("new enemy spawned is " + currentEnemy.getName ());
    // }

    // Enemy pickEnemy (int dungeonId) {
    //     //todo: store templist until player changes dungeon
    //     List<Enemy> tempList = new List<Enemy> ();
    //     foreach (Enemy e in enemyList) {
    //         if (e.getDungeonId () == dungeonId) {
    //             tempList.Add (e);
    //         }
    //     }

    //     System.Random random = new System.Random ();
    //     int index = random.Next (tempList.Count);
    //     return tempList[index];

    //     //dumb solution
    //     //make a new list
    //     //populate that new list from the old list where the variables match
    //     //hold that list until the dungeon is changed
    //     //return random enemy from that list
    // }

    public void loseHealthCalc () {
        // double ptotal = currentEnemy.getPhyAttack () - phyDefence;
        // double mtotal = currentEnemy.getMagAttack () - magDefence;
        // if (ptotal > 0) {
        //     health -= ptotal;
        //     // Debug.Log ("Player took " + ptotal + " p dmg");
        // }
        // if (mtotal > 0) {
        //     health -= mtotal;
            // Debug.Log ("Player took " + mtotal + " m dmg");
        // }
    }

    void death () {
        isAttacking = false;
        Debug.Log ("Player has died");
    }

    // public void regen () {
    //     if (health < maxHealth) { health += (healthRegen * Time.deltaTime); }
    //     if (!currentEnemyDead && currentEnemy.getHealth () < currentEnemy.getMaxHealth ()) { currentEnemy.gainHealth (currentEnemy.getHealthRegen () * Time.deltaTime); }
    // }
}