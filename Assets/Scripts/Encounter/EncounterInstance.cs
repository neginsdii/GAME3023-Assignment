using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EncounterInstance : MonoBehaviour
{
   

    [SerializeField]
    private EncounterPlayerCharacter player;
    [SerializeField]
    private EncounterOpponentCharacter enemy;

    private int turnNumber = 0;

    private Icharacter currentCharacterTurn;

    public EncounterOpponentCharacter Enemy
    {
        get { return enemy; }
        private set { enemy = value; }
    }
    public EncounterPlayerCharacter Player
    {
        get { return player; }
        private set { player = value; }
    }
    public UnityEvent<Icharacter> onCharacterTurnBegin;
    public UnityEvent<Icharacter> onCharacterTurnEnd;

    public UnityEvent<EncounterPlayerCharacter> onPlayerTurnBegin;
    public UnityEvent<EncounterPlayerCharacter> onPlayerTurnEnd;


    // Start is called before the first frame update
    void Start()
    {
       
        currentCharacterTurn = player;

    }
    public void AdvanceTurn()
    {

        Debug.Log(currentCharacterTurn.name);
        onCharacterTurnEnd.Invoke(currentCharacterTurn);
        if (currentCharacterTurn == player)
        {
          

          

            onPlayerTurnEnd.Invoke(player);
            currentCharacterTurn = enemy;



        }
        else
        {
           
          


            currentCharacterTurn = player;
            onPlayerTurnBegin.Invoke(player);
        }

        turnNumber++;

        onCharacterTurnBegin.Invoke(currentCharacterTurn);
        currentCharacterTurn.TakeTurn(this);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
