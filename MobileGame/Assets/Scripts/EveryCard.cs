using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static Card;
using Listsextensions;

public class EveryCard : CardPile
{
    public List<Card> AllcardsList;

    public Card card;

    public override void AddCard(Card cardToAdd)
    {
        AllcardsList.Add(cardToAdd);
        //Debug.Log($"adding {cardToAdd._suit} and rank {cardToAdd._rank}");
    }

    public override void RemoveCard(Card cardToRemove)
    {
        AllcardsList.Remove(cardToRemove);
    }

    private void Awake()
    {
        AllcardsList = new List<Card>();
    }

    void Start()
    {
        
        //makes the card
        //1-4 for the suit and then the rank 1-13 for each of the suits 

        //first for suit
        for (int s = 1; s <= 4; s++)
        {
            //second for ranks
            for (int r = 1; r <= 13; r++)
            {
                SuitEnum suit = (SuitEnum)s; 
                RankEnum rank = (RankEnum)r;
                // Debug.Log($"Creating card with Suit: {suit}, Rank: {rank}");
                //now add card to allcardsLIST
                card = new Card(suit, rank);
                
                AddCard(card);
            }
        }

        ShuffleCards();
    }

    public void ShuffleCards() //shuffle the cards with fisher yates shuffle.
    {
        listextensions.shufflecards(AllcardsList);
    }

    public void GetStarterCards()
    {
        //3 cards upside down to player
        //3 cards above those
        //3 cards to player hand

        //same to the opponent
        for (int i = 0; i < 3; i++)
        {
            card = AllcardsList[0];//first card in list.
            RemoveCard(card); 
            
        }
      
    }
}
