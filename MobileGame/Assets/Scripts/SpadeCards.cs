using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpadeCards : MonoBehaviour
{
    public int _SpadeCount = 13;
    [SerializeField] private int _MaxCount = 13;
    public bool noMoreSpade = false;

    public List spadeList = new List();

    //make so each spade, heart etc is in a list

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(spadeList + "spadelist");
    }
}
