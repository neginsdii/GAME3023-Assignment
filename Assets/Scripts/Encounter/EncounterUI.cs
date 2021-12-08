using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class EncounterUI : MonoBehaviour
{
    [SerializeField]
    private EncounterInstance encounter;

    [SerializeField]
    private TMPro.TextMeshProUGUI EncounterText;

    [SerializeField]
    private GameObject abilityPanel;

    [SerializeField]
    private float timeBetweenCharacter = 0.1f;

    public GameObject AbilityPrefab;
    private IEnumerator animateTextCoroutineRef = null;
    // Start is called before the first frame update
    void Start()
    {

        animateTextCoroutineRef = (AnimateTextCoroutine("You have encountered an opponent!", timeBetweenCharacter));
        StartCoroutine(animateTextCoroutineRef);
        encounter.onCharacterTurnBegin.AddListener(AnnounceCharacterTurnBegin);
        encounter.onPlayerTurnBegin.AddListener(EnablePlayerUI);
        encounter.onPlayerTurnEnd.AddListener(DisablePLayerUI);

    }

	private void Update()
	{
		if(abilityPanel.transform.childCount<encounter.Player.Abilities.Length)
		{
            GenerateAbilityPanel();

        }
	}
	void AnnounceCharacterTurnBegin(Icharacter characterTurn)
    {
        if (animateTextCoroutineRef != null)
          StopCoroutine(animateTextCoroutineRef);
        animateTextCoroutineRef = AnimateTextCoroutine(" It is " + characterTurn.name + " 's turn", timeBetweenCharacter);
        StartCoroutine(animateTextCoroutineRef);



    }
  public void AnnounceCharacterChoosenAbility(Icharacter characterTurn, Ability ability)
    {
        if (animateTextCoroutineRef != null)
            StopCoroutine(animateTextCoroutineRef);
        animateTextCoroutineRef = AnimateTextCoroutine( characterTurn.name + " chose " + ability.name+". It "+ ability.description);
       
        StartCoroutine(animateTextCoroutineRef);
        encounter.AdvanceTurn();
    }
    void EnablePlayerUI(Icharacter characterTurn)
    {

        abilityPanel.SetActive(true);


    }
    void DisablePLayerUI(Icharacter characterTurn)
    {

        abilityPanel.SetActive(false);

    }
    IEnumerator AnimateTextCoroutine(string message, float secondsPerCharacter = 0.1f)
    {

        EncounterText.text = "";
        for (int currentCharacter = 0; currentCharacter < message.Length; currentCharacter++)
        {
            EncounterText.text += message[currentCharacter];
            yield return new WaitForSeconds(secondsPerCharacter);
        }


        animateTextCoroutineRef = null;
    }
    

    public void GenerateAbilityPanel()
	{
		for (int i = 0; i < encounter.Player.Abilities.Length; i++)
		{
           GameObject newAbility = Instantiate(AbilityPrefab, abilityPanel.transform);
            newAbility.GetComponent<AbilityUI>().index = i;
            newAbility.GetComponentInChildren<Text>().text = encounter.Player.Abilities[i].name;
   
            newAbility.GetComponent<Button>().onClick.AddListener(() => UsePlayerAbility(newAbility.GetComponent<AbilityUI>()));

        } 
	}
    public void UsePlayerAbility(AbilityUI ability)
	{
        encounter.Player.UseAbility(ability.index);

    }

}
