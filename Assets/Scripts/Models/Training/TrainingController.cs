using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingController : MonoBehaviour
{
    [SerializeField] Character character;
    private int maxClones;

    private int physicalAttackClones;
    private int physicalDefenceClones;
    private int magicalAttackClones;
    private int magicalDefenceClones;

    private int physicalAttackLevel;
    private int physicalDefenceLevel;
    private int magicalAttackLevel;
    private int magicalDefenceLevel;

    private int incrementAmount;
    void Start()
    {
        incrementAmount = 1;
        InvokeRepeating("UpdateEverySecond", 0, 1.0f);

    }

    void UpdateEverySecond()
    {
        physicalAttackLevel += (physicalAttackClones * incrementAmount);
        physicalDefenceLevel += (physicalDefenceClones * incrementAmount);
        magicalAttackLevel += (magicalAttackClones * incrementAmount);
        magicalDefenceLevel += (magicalDefenceClones * incrementAmount);
    }

    void incrementPhysicalAttack()
    {
        if (areClonesFree())
        {
            physicalAttackClones++;
        }
    }  
    
    void incrementPhysicalDefence()
    {
        if (areClonesFree())
        {
            physicalAttackClones++;
        }
    }  
    
    void incrementMagicalAttack()
    {
        if (areClonesFree())
        {
            physicalAttackClones++;
        }
    }  
    
    void incrementMagicalDefence()
    {
        if (areClonesFree())
        {
            physicalAttackClones++;
        }
    }

    public bool areClonesFree()
    {
        return (maxClones > (physicalAttackClones + physicalDefenceClones + magicalAttackClones + magicalDefenceClones));
    }


}
