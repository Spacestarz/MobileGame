using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using static Card;
using Listsextensions;

public class EveryCard : CardPile
{
    private Card card;
    public GameObject allLocation;

    public static EveryCard instance;

    public override void AddCard(Card cardToAdd)
    {
        base.AddCard(cardToAdd);
        MoveToallCardsLocation();
        //Debug.Log($"adding {cardToAdd._suit} and rank {cardToAdd._rank}");
    }

    public override void RemoveCard(Card cardToRemove)
    {
        base.RemoveCard(cardToRemove);
      //  Debug.Log($"Removing {cardToRemove._suit} with rank {cardToRemove._rank}");
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
                //here i am making ALLLLL the cards
                SuitEnum suit = (SuitEnum)s; 
                RankEnum rank = (RankEnum)r;

                //making the cards but upside down
                Card card = MakeCards.Instance.MakeCard(suit, rank); //now i am making all the cards upside down

                //now add card to allcardsLIST
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
            OpponentHand.instance.AddCard(card);
        }
    }

    public void GetCard() //get card from the draw button
    {
        Debug.Log("getcard from button");

        card = cards[0];
        RemoveCard(card); //remove card from allcardslist
        //insert if its playerturn or opponentturn

        if (TrackingTurns.Instance._CurrentTurn == TrackingTurns.TurnState.Playerturn)
        {
            PlayerHand.instance.AddCard(card);
            Debug.Log($"PlayerHand got {card._suit} with rank {card._rank}");

        }
        else
        {
            OpponentHand.instance.AddCard(card);
            Debug.Log($"OpponentHand got {card._suit} with rank {card._rank}");
        }
    }

    private void MoveToallCardsLocation()
    {
        foreach (var item in cards)
        {
            item.gameObject.transform.position = allLocation.transform.position;
        }
    }

    public void GuessCard()
    {
        //when player/opponent cant play any cards in their hand they can guess a card
        Debug.Log("guessing card method");
        card = cards[0];
        RemoveCard(card);

        if ((TrackingTurns.Instance._CurrentTurn == TrackingTurns.TurnState.Playerturn))
        {
            //check if card can go in dropzone
            //when it comes to the visual make the card look like it goes to dropzone and
            //have a sound cue if it can go or not
        }
        else
        {

        }

    }
}
