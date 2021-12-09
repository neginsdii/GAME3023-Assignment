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
            img.GetComponent<Animator>().SetBool("FadeIn",true);
            StartCoroutine(DelayInTransition(index));
           

        }
    }
    private IEnumerator DelayInTransition(int index)
    {
        yield return new WaitForSeconds(1f);
        img.GetComponent<Animator>().SetBool("FadeIn",false);
        SceneManager.LoadScene("Encounter");
        //Add the encounter scene to the list of scenes that player entered them
        GameDataManager.Instance.Encounters.Add(index);
    }
}
