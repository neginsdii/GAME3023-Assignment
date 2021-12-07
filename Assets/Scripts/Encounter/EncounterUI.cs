using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void AnnounceCharacterTurnBegin(Icharacter characterTurn)
    {
        if (animateTextCoroutineRef != null)
            StopCoroutine(animateTextCoroutineRef);
        animateTextCoroutineRef = AnimateTextCoroutine(" It is " + characterTurn.name + " 's turn", timeBetweenCharacter);
        StartCoroutine(animateTextCoroutineRef);



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


}
