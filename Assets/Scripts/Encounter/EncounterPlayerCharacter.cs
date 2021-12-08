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
    private Text  HealthText;
    [SerializeField]
    private EncounterUI encounterUI;
    private Animator anim;
    public UnityEvent<Ability> onCharacterUsedAbility;

    private void Start()
    {
        abilities = GameDataManager.Instance.PlayerAbilities;
        health = GameDataManager.Instance.playerHealth;
        anim = GetComponent<Animator>();
    }
    public override void TakeTurn(EncounterInstance ei)
    {
        encounter = ei;
        player = ei.Player;
        opponent = ei.Enemy;
    }
    public void UseAbility(int slot)
    {
       
        abilities[slot].cast(this, opponent);
        encounterUI.AnnounceCharacterChoosenAbility(this,abilities[slot]);

    }
    IEnumerator DelayToPlayAnimation(EncounterInstance ei)
    {

        yield return new WaitForSeconds(1.5f);
     

    }
	private void Update()
	{
        HealthText.text = "Health: " + health;
	}

}
