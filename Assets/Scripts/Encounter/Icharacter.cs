using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Icharacter : MonoBehaviour
{
    [SerializeField]
    protected Ability[] abilities;
    public Ability[] Abilities
    {
        get { return abilities; }
        
    }
    public int health;
    public abstract void TakeTurn(EncounterInstance EI);
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

    }
}
