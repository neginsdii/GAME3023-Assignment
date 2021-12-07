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


    private void Start()
    {
       
        anim = GetComponent<Animator>();
    }
    public override void TakeTurn(EncounterInstance ei)
    {
        encounter = ei;
        player = ei.Player;
        EnemySelf = ei.Enemy;
        StartCoroutine(DelayDecision(ei));

    }


    // Update is called once per frame
    void Update()
    {

    }
    public void UseAbility()
    {

       
    }
    IEnumerator DelayDecision(EncounterInstance ei)
    {
       
        yield return new WaitForSeconds(5.0f);

        ei.AdvanceTurn();
    }
    IEnumerator DelayToPlayAnimation(EncounterInstance ei)
    {

        yield return new WaitForSeconds(1.5f);
      

    }
}
