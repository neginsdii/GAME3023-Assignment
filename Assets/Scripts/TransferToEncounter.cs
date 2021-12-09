using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferToEncounter : MonoBehaviour
{
    //Index of encounter scene
    public int index;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checking if the player has already battled in this scene

        if (!GameDataManager.Instance.Encounters.Contains(index))
        {
            
            SceneManager.LoadScene("Encounter");
            //Add the encounter scene to the list of scenes that player entered them
            GameDataManager.Instance.Encounters.Add(index);

        }
    }
}
