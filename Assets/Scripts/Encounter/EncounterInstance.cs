using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EncounterInstance : MonoBehaviour
{
    public bool AbilityAdded = false;
    int numOfAbilities =0;
    [SerializeField]
    private EncounterPlayerCharacter player;
    [SerializeField]
    private EncounterOpponentCharacter enemy;

    private int turnNumber = 0;
    public GameObject encounterUI;
    private Icharacter currentCharacterTurn;
    public GameObject ResultPanel;
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
;
       
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
        if (enemy.health <= 0 || player.health <= 0)
        {
           
            if (enemy.health <= 0)
			{
                GameObject resultPanel = Instantiate(ResultPanel,encounterUI.transform);
                resultPanel.GetComponentInChildren<Text>().text = "Player won the battle!";
                numOfAbilities = player.Abilities.Count;
                GameDataManager.Instance.Encounters.Add(GameDataManager.Instance.ActiveEncouterIndex);

            }
            else if (player.health <= 0)
			{
            GameObject resultPanel = Instantiate(ResultPanel, encounterUI.transform);
            resultPanel.GetComponentInChildren<Text>().text = "Player lost the battle!";
            }

            
            StartCoroutine( GetAbilityFromEnemy());
            GameDataManager.Instance.ActiveEncouterIndex = 0;

        }
      
    }
    IEnumerator GetAbilityFromEnemy()
	{
        int found = -1;
        if (enemy.health <= 0 )
        {
            for (int i = 0; i < enemy.Abilities.Count; i++)
            {
                if (!player.Abilities.Contains(enemy.Abilities[i]))
                {
                    found = i;
                    numOfAbilities++;
                    break;
                }
            }
        }
        if(found!=-1)
		{
            if (!AbilityAdded && GameDataManager.Instance.PlayerAbilities.Count<6)
            {
                AbilityAdded = true;
                GameDataManager.Instance.PlayerAbilities.Add(enemy.Abilities[found]);

            }
		}
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene("Main");

    }

    public void onClickBackButton()
	{
        int i = Random.Range(0, 2);
		if (i == 1)
			player.health = 0;
		else
			enemy.health = 0;
	}
}
