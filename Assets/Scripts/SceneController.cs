using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{

    public GameObject player;
  public void OnStartButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnSaveButton()
    {
        PlayerPrefs.SetFloat("PlayerPositionX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPositionY", player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerPositionZ", player.transform.position.z);
        PlayerPrefs.Save();
    }
    public void OnExitButton()
    {
        Application.Quit();
    }
}
