using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewEffect", menuName = "AbilitySystem/Effect")]
public abstract class IEffect : ScriptableObject
{
	public abstract void applyEffect(Icharacter self, Icharacter other);

}
