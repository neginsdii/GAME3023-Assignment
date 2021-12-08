using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Damage", menuName = "AbilitySystem/Effect")]

public class DamageEffect : IEffect
{
    [SerializeField]
    private int damage;
	public override void applyEffect(Icharacter self, Icharacter other)
	{
			other.health -= damage;

	}
}
