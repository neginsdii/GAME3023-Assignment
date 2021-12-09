using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Damage", menuName = "AbilitySystem/Effect")]

public class DamageEffect : IEffect
{
	//Applying damage to characters.
	//showing propper animation based on the amount of damage
	public override void applyEffect(Icharacter self, Icharacter other)
	{
		other.health -= damage;
		self.health += heal;
		switch (damage)
		{
			case  30:
				other.GetComponent<Animator>().SetTrigger("Hurt");

				break;
			case 20:
				other.GetComponent<Animator>().SetTrigger("Hit");

				break;
			case 15:
				other.GetComponent<Animator>().SetTrigger("Fire");

				break;
			case 10:
				other.GetComponent<Animator>().SetTrigger("Shock");
				break;
			default:
				other.GetComponent<Animator>().SetTrigger("Water");
				break;
		}
	}
}
