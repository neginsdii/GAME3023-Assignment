using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    IEnumerator AdvanceTurnDelay()
	{
        yield return new WaitForSeconds(3.5f);

    }
    public void AdvanceTurn()
    {
        StartCoroutine(AdvanceTurnDelay());

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
        if (enemy.health <= 0)
        {
            GameDataManager.Instance.playerHealth = player.health;
            StartCoroutine( GetAbilityFromEnemy());
            SceneManager.LoadScene("Main");
        }
        if(player.health<=0)
		{
            SceneManager.LoadScene("EndScene");

        }
    }
    IEnumerator GetAbilityFromEnemy()
	{

        for (int i = 0; i < enemy.Abilities.Count; i++)
		{
            if (!player.Abilities.Contains(enemy.Abilities[i]))
            {
                player.Abilities.Add(enemy.Abilities[i]);
                break;
            }
		}
        yield return new WaitForSeconds(3.5f);

    }
}
