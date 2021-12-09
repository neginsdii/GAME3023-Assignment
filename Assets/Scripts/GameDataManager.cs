using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
	public List<Ability> PlayerAbilities;
	public List<int> Encounters;
	public List<Ability> AllAbilities;
	public int ActiveEncouterIndex;
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
		LoadPlayerAbilities();
	}

	public void LoadPlayerAbilities()
	{
		int count=0;
		if (PlayerPrefs.HasKey("AbilityCount"))
			count = PlayerPrefs.GetInt("AbilityCount");
		if (count > 0)
		{
			for (int i = 0; i < count; i++)
			{
				if (PlayerPrefs.HasKey("Ability" + i))
					findAbility(PlayerPrefs.GetString("Ability" + i));

			}
		}
		else
		{
			PlayerAbilities.Add(AllAbilities[0]);
			PlayerAbilities.Add(AllAbilities[1]);
		}
	}

	public void findAbility(string name)
	{
		for (int i = 0; i < AllAbilities.Count; i++)
		{
			if (AllAbilities[i].name == name)
			{
				PlayerAbilities.Add(AllAbilities[i]);
				break;
			}
		}
	}
}
