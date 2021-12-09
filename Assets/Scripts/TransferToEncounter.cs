using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransferToEncounter : MonoBehaviour
{
    //Index of encounter scene
    public int index;
    public RawImage img;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checking if the player has already battled in this scene

        if (!GameDataManager.Instance.Encounters.Contains(index))
        {
            GameDataManager.Instance.ActiveEncouterIndex = index;
            StartCoroutine(DelayInTransition(index));
            img.GetComponent<Animator>().SetBool("FadeIn",true);
           

        }
    }
    private IEnumerator DelayInTransition(int index)
    {
        yield return new WaitForSeconds(1f);
        img.GetComponent<Animator>().SetBool("FadeIn",false);
        //Add the encounter scene to the list of scenes that player entered them
        SceneManager.LoadScene("Encounter"+index);

    }
}
