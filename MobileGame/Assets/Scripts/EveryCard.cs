using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static Card;
using Listsextensions;

public class EveryCard : CardPile
{
    public Card card;
    [SerializeField] CardInstance _cardDataScript;

    public override void AddCard(Card cardToAdd)
    {
        cards.Add(cardToAdd);
        //Debug.Log($"adding {cardToAdd._suit} and rank {cardToAdd._rank}");
    }

    public override void RemoveCard(Card cardToRemove)
    {
        cards.Remove(cardToRemove);
      //  Debug.Log($"Removing {cardToRemove._suit} with rank {cardToRemove._rank}");
    }

    private void Awake()
    {
        cards = new List<Card>();
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
       GetStarterCards();
    }

    public void ShuffleCards() //shuffle the cards with fisher yates shuffle.
    {
        listextensions.shufflecards(cards);
    }


    public void GetStarterCards()
    {
        //TODO
        //3 cards upside down to player
        //3 cards above those
        //3 cards to player hand

        //same to the opponent

        //players first 3 card 
        for (int i = 0; i < 3; i++)// (upside down)
        {
            card = cards[0];//first card in list.
            RemoveCard(card); //removing from allcardslist
            PlayerTableCards.instance.AddCard(card); //Adding 3 cards tO TABLECARD
        }

        for (int i = 0; i < 3; i++) //not upside down
        {
            card = cards[0];//first card in list.
            RemoveCard(card); //removing from allcardslist
            PlayerTableCards.instance.AddCard(card); //Adding 3 cards TO TABLECARD
            
        }

        for (int i = 0; i < 3; i++) //adding to playerhand
        {
            card = cards[0];//first card in list.
            RemoveCard(card); //removing from allcardslist
            PlayerHand.instance.AddCard(card);
        }

        //adding to OPPONENT NEED TO FIX PLACEMENT OF OPPONENT LATER
        for (int i = 0; i < 3; i++) //upside down first
        {
            card = cards[0];//first card in list.
            RemoveCard(card); //removing from allcardslist
            OpponentTableCard.Instance.AddCard(card);
        }

        for (int i = 0; i < 3; i++) //not upside down
        {
            card = cards[0];//first card in list.
            RemoveCard(card); //removing from allcardslist
            OpponentTableCard.Instance.AddCard(card);
        }

        //adding to opponent HAND
        for (int i = 0; i < 3; i++) //not upside down
        {
            card = cards[0];//first card in list.
            RemoveCard(card); //removing from allcardslist
            OpponentHand.Instance.AddCard(card);
        }
    }

    public void GetCard() //get card from the draw button
    {
        Debug.Log("getcard from button");
        card = cards[0];
        RemoveCard(card); //remove card from allcardslist
        PlayerHand.instance.AddCard(card);
        Debug.Log($"PlayerHand got {card._suit} with rank {card._rank}");
    }
}
