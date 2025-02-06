using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class CardPile: MonoBehaviour
{
    public List<Card> cards;

    private void Start()
    {
    }

    public abstract void AddCard(Card cardToAdd); //Here you will add cards 
    

    public abstract void RemoveCard(Card cardToRemove); //Here you will remove cards

}


