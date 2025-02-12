using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTableCards : CardPile 
{
    public static PlayerTableCards instance;

    public Dictionary<Card, CardInstance> _CardDictoTable = new Dictionary<Card, CardInstance>();

    public override void AddCard(Card cardToAdd)
    {
        cards.Add(cardToAdd);
        Debug.Log($"Adding {cardToAdd._suit} with rank {cardToAdd._rank} to CardPlayerCards");
    }

    public override void RemoveCard(Card cardToRemove)
    {
        cards.Remove(cardToRemove);
        Debug.Log($"Removing {cardToRemove._suit}  with rank  {cardToRemove._rank}  from dropzone");
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        cards = new List<Card>();
    }

    //trying to make it like playerhand kinda
    public void GetCardInstance(Card card)
    {
        var CardInstanceThing = MakeCards.Instance.CreateCardObject(card);
        _CardDictoTable.Add(card, CardInstanceThing);
        UpdateTable();
    }

    private void UpdateTable()
    {

    }

    public void GetCardInstanceUpsideDown()
   {

   }
   
}
