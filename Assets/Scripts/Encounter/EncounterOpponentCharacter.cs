using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncounterOpponentCharacter : Icharacter
{ // Start is called before the first frame update
    [SerializeField]
    private EncounterPlayerCharacter player;
    [SerializeField]
    private EncounterOpponentCharacter EnemySelf;
    [SerializeField]
    private EncounterInstance encounter;
    private Animator anim;
    [SerializeField]
    private EncounterUI encounterUI;
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private Text HealthText;
    private void Start()
    {
        health = 100;
        anim = GetComponent<Animator>();
        
    }
    //Calling use ability function
    public override void TakeTurn(EncounterInstance ei)
    {
        encounter = ei;
        player = ei.Player;
        EnemySelf = ei.Enemy;
        UseAbility();
    }

   
    // Update is called once per frame
    void Update()
    {
        HealthText.text = "Health: " + health;
        if (health >= 100)
            health = 100;
    }
    //Choosing a ability with a delay
    public void UseAbility()
    {
        StartCoroutine(DelayDecision());
    }
    //Finding an ability based on player's health
    //deactivating that ability for one turn
    IEnumerator DelayDecision()
    {
       
        yield return new WaitForSeconds(3.5f);
        int i = 0;
        if (health >= 35)
        {
           // if((i=FindAnAbilityWithHealingEffect())<=-1)
            i = findRandomActiveAbility();
            abilities[i].cast(this, player);
        }
        else if (health < 35)
		{
            i = FindAbilityWithHighestDamage();
            abilities[i].cast(this, player);

        }
        abilities[LastTurnAbilityIndex].isActive = true;
        LastTurnAbilityIndex = i;
        abilities[LastTurnAbilityIndex].isActive = false;

        encounter.AdvanceTurn();
    }


    //Check to see if the ability is active
    bool IsAbilityActive(int indx)
	{
        return abilities[indx].isActive;
	}
    //Find a random active ability
    int findRandomActiveAbility()
	{

        int ind =0;
        	for (int i = 0; i < abilities.Count; i++)
			{
                if (IsAbilityActive(i))
			    {
                    ind = i;
                    break;
			    }


			}
       
        return ind;
	}
    //finding an active ability with highest damage 
    int FindAbilityWithHighestDamage()
	{
        int maxDamage = -1;
        int indx = 0;
		for (int i = 0; i < abilities.Count; i++)
		{
            if (IsAbilityActive(i))
            {
                foreach (var effect in abilities[i].effects)
                {
                    if (effect.damage>maxDamage)
					{
                        maxDamage = effect.damage;
                        indx = i;
					}

            }
            }
		}
        return indx;
	}

    int FindAnAbilityWithHealingEffect()
	{
        int maxHeal = 0;
        int indx = -1;
        for (int i = 0; i < abilities.Count; i++)
        {
            if (IsAbilityActive(i))
            {
                foreach (var effect in abilities[i].effects)
                {
                    if (effect.heal > maxHeal)
                    {
                        maxHeal = effect.heal;
                        indx = i;
                    }

                }
            }
        }
        return indx;
    }
}
