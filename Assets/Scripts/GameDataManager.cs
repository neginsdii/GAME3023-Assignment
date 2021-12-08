using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
	public Ability[] PlayerAbilities;
	public int playerHealth;
	private static GameDataManager instance = null;
	public static GameDataManager Instance { get { return instance; }	}

	private void Awake()
	{
		if(instance==null)
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
	}
	private void Start()
	{
		playerHealth = 100;
	}
	
}
