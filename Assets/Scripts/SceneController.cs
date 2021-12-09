using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    private AudioSource clickSound;
   
    public GameObject player;
    public GameDataManager gameData;
    private void Start()
    {
        clickSound = GetComponent<AudioSource>();
    }
    public void OnStartButton()
    {
        SceneManager.LoadScene("Main");
        clickSound.Play();
 
    }

    public void OnSaveButton()
    {
       
        PlayerPrefs.SetFloat("PlayerPositionX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPositionY", player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerPositionZ", player.transform.position.z);
        PlayerPrefs.SetFloat("PlayerHealth", gameData.playerHealth);
        PlayerPrefs.SetInt("AbilityCount", GameDataManager.Instance.PlayerAbilities.Count);

        for (int i = 0;  i < GameDataManager.Instance.PlayerAbilities.Count; i++)
        {
            PlayerPrefs.SetString("Ability"+i, GameDataManager.Instance.PlayerAbilities[i].name);
        }
        PlayerPrefs.Save();

        clickSound.Play();
    }
    public void OnExitButton()
    {
        clickSound.Play();
        Application.Quit();
    }

  
}
