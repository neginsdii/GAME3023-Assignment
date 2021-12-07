using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Icharacter : MonoBehaviour
{
    [SerializeField]
    protected Ability[] abilities;

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
