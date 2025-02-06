using System.Collections.Generic;
using UnityEngine;

public class PlayerTableCards : CardPile 
{
    public List<Card> CardPlayerTable;

    public override void AddCard(Card cardToAdd)
    {
        CardPlayerTable.Add(cardToAdd);
    }

    public override void RemoveCard(Card cardToRemove)
    {
        CardPlayerTable.Remove(cardToRemove);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
