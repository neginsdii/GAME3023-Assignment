using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewAbility", menuName = "AbilitySystem/Ability")]
public class Ability : ScriptableObject
{
    public new string name;
    public string description;
    public IEffect[] effects;
    public bool isActive = true;

    public void cast(Icharacter self, Icharacter other)
    {
        foreach (var effect in effects)
        {
            effect.applyEffect(self, other);
        }
        Debug.Log("Used: " + name);
    }
}
