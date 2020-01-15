using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrptIsekai : MonoBehaviour
{

    public Text txtGold;
    public Text txtGoldPerSec;
    public Text btnUpgrClk1;
    public Text btnUpgr1;

    public double amtGold;
    public double amtGoldClick;
    public double goldPerSec;

    public double clickUpgradeCost1;
    public int clickUpgradeLevel1;

    public double clickProductionCost1;
    public int clickProductionLevel1;

    
    // Start is called before the first frame update
    void Start()
    {
        amtGoldClick = 1;
        clickUpgradeCost1 = 10;
        clickProductionCost1 = 25;
    }

    // Update is called once per frame
    void Update()
    {
        goldPerSec = clickProductionLevel1;
        txtGold.text = "Coins: " + amtGold.ToString("F0");
        txtGoldPerSec.text = goldPerSec.ToString("F1") + " Gold/s";
        btnUpgrClk1.text = "upgr 1 C\ncost: " + clickUpgradeCost1 + " coins\nIncrease: " + clickUpgradeLevel1;
        btnUpgr1.text = "upgr 1\ncost: " + clickProductionCost1 + " coins\nIncrease: " + clickProductionLevel1;

        amtGold += goldPerSec * Time.deltaTime;
    }

    public void IncrementGold() 
    {
        amtGold+= amtGoldClick;
    }

    public void UpgradeClicker() 
    {
        amtGold+= 1;
    }

    public void BuyClicker1()
    {
        if (amtGold >= clickUpgradeCost1) 
        {
            amtGold -= clickUpgradeCost1;
            clickUpgradeLevel1++;
            clickUpgradeCost1 *= 1.07;
            amtGoldClick++;
        }
    }

    public void BuyFactory1() 
    {
        if (amtGold >= clickProductionCost1) 
        {
            amtGold -= clickProductionCost1;
            clickProductionLevel1++;
            clickProductionCost1 *= 1.07;
        }

    }
}
