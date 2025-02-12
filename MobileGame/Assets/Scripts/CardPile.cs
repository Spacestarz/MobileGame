using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class CardPile: MonoBehaviour
{
    public List<Card> cards;

    private void Start()
    {

    }

    public virtual void AddCard(Card cardToAdd)
    {
        cards.Add(cardToAdd);//Here you will add cards 
    }
    

    public virtual void RemoveCard(Card cardToRemove)
    {
        cards.Remove(cardToRemove); //Here you will remove cards
        if (!cards.Contains (cardToRemove))
        {
            Debug.Log("couldent find card you want to remove");
        }
    } 

}


