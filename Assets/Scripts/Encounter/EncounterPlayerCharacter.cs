using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class EncounterPlayerCharacter : Icharacter
{
    [SerializeField]
    private EncounterOpponentCharacter opponent;
    [SerializeField]
    private EncounterInstance encounter;
    [SerializeField]
    private EncounterPlayerCharacter player;
    [SerializeField]
    private Text HealthText;
    [SerializeField]
    private EncounterUI encounterUI;
    private Animator anim;
    public UnityEvent<Ability> onCharacterUsedAbility;

    private void Start()
    {
        abilities = GameDataManager.Instance.PlayerAbilities;
        //Loading player's health
        health = GameDataManager.Instance.playerHealth;
        anim = GetComponent<Animator>();
    }
    public override void TakeTurn(EncounterInstance ei)
    {
        encounter = ei;
        player = ei.Player;
        opponent = ei.Enemy;
    }
    //Use ability based on selceted ability button.
    //make that button disable to one turn
    public void UseAbility(int slot)
    {

        abilities[slot].cast(this, opponent);
        abilities[LastTurnAbilityIndex].isActive = true;
        //Updating ability buttons in ability panel based corresponding ability being active or not

        encounterUI.abilityButtons[LastTurnAbilityIndex].GetComponent<Button>().interactable = true;

        LastTurnAbilityIndex = slot;
        encounterUI.abilityButtons[LastTurnAbilityIndex].GetComponent<Button>().interactable = false;

        abilities[LastTurnAbilityIndex].isActive = false;
        
        encounterUI.AnnounceCharacterChoosenAbility(this, abilities[slot]);
        encounter.AdvanceTurn();

    }
    //Updating player's health
    private void Update()
    {
        HealthText.text = "Health: " + health;
        if (health >= 100)
            health = 100;
    }
    
}