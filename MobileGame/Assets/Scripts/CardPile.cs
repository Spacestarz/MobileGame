using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class CardPile: MonoBehaviour
{
    public List<Card> cards;

    public virtual void AddCard(Card cardToAdd)
    {
        cards.Add(cardToAdd);//Here you will add cards 
    }

    public virtual void RemoveCard(Card cardToRemove)
    {
       // cards.Remove(cardToRemove); //Here you will remove cards
        bool removed = cards.Remove(cardToRemove); // Try to remove the card

        if (removed)
        {
           // Debug.Log($"Card {cardToRemove._suit} with rank {cardToRemove._rank} successfully removed.");
        }
        else
        {
            Debug.LogWarning($"couldent find the card you want to remove.");
        }
    } 
}


