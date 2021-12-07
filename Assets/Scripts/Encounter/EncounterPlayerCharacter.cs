using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EncounterPlayerCharacter : Icharacter
{
    [SerializeField]
    private EncounterOpponentCharacter opponent;
    [SerializeField]
    private EncounterInstance encounter;
    [SerializeField]
    private EncounterPlayerCharacter player;

    private Animator anim;

    private void Start()
    {
        
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
        encounter.AdvanceTurn();

    }
    IEnumerator DelayToPlayAnimation(EncounterInstance ei)
    {

        yield return new WaitForSeconds(1.5f);
     

    }

}
