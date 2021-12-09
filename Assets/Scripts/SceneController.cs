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
        for (int i = 0;  i < gameData.PlayerAbilities.Count; i++)
        {
            PlayerPrefs.SetString("Ability"+i, gameData.PlayerAbilities[i].name);
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
