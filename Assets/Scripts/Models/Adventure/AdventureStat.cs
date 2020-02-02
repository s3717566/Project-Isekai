using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

[Serializable]
public class AdventureStat {

    //adventure stats is where the stats are stored. Modifiers are stat bonuses such as things from equipping weapons.

    public float BaseValue;

    public virtual float Value {
        get {
            if (isDirty || BaseValue != lastBaseValue) {
                lastBaseValue = BaseValue;
                _value = CalculateFinalValue ();
                isDirty = false;
            }
            return _value;
        }
    }

    protected bool isDirty = true;
    protected float _value;
    protected float lastBaseValue = float.MinValue;

    protected readonly List<StatModifier> statModifiers;
    public readonly ReadOnlyCollection<StatModifier> StatModifiers;

    public AdventureStat () {
        statModifiers = new List<StatModifier> ();
        StatModifiers = statModifiers.AsReadOnly ();
    }

    public AdventureStat (float baseValue) : this () {
        BaseValue = baseValue;
    }

    public virtual void AddModifier (StatModifier mod) {
        isDirty = true;
        statModifiers.Add (mod);
        statModifiers.Sort (CompareModifierOrder);
    }

    protected virtual int CompareModifierOrder (StatModifier a, StatModifier b) {
        if (a.Order < b.Order)
            return -1;
        else if (a.Order > b.Order)
            return 1;
        return 0; //if a==b
    }

    public virtual bool RemoveModifier (StatModifier mod) {

        if (statModifiers.Remove (mod)) {
            isDirty = true;
            return true;
        }
        return false;
    }
    
    public virtual bool RemoveAllModifiersFromSource (object source) {
        bool didRemove = false;
        for (int i = statModifiers.Count - 1; i >= 0; i--) {
            if (statModifiers[i].Source == source) {
                isDirty = true;
                statModifiers.RemoveAt (i);
                didRemove = true;
            }

        }
        return didRemove;
    }

    protected virtual float CalculateFinalValue () {
        float finalValue = BaseValue;
        float sumPercentAdd = 0;

        for (int i = 0; i < statModifiers.Count; i++) {
            StatModifier mod = statModifiers[i];

            if (mod.Type == StatModType.Flat) {
                finalValue += statModifiers[i].Value;
            } else if (mod.Type == StatModType.PercentMult) {
                sumPercentAdd += mod.Value;
                if (i + 1 >= statModifiers.Count || statModifiers[i + 1].Type != StatModType.PercentAdd) {
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
                }
            } else if (mod.Type == StatModType.PercentMult) {
                finalValue *= 1 + mod.Value;
            }
        }

        return (float) Math.Round (finalValue, 4);
    }

}