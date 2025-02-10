using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;
using NaughtyAttributes;

public class Dropzone : CardPile
{
    public static Dropzone Instance;

    private Card FirstInStackCard;

    private Card card;

    public override void AddCard(Card cardToAdd)
    {
        base.AddCard(cardToAdd);

        Debug.Log($"Adding {cardToAdd._suit} with rank {cardToAdd._rank} to Dropzone");
    }

    public override void RemoveCard(Card cardToRemove)
    {
       base.RemoveCard(cardToRemove);
       Debug.Log($"Removing {cardToRemove._suit} with rank {cardToRemove._rank} from dropzone");
    }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        cards = new List<Card>();
    }

    [Button]
    public void CanIGoInDropZone(Card Newcard) //in here should be Card NewCard later
    {
      // Card Newcard = PlayerHand.instance._PlayerHandcards[0];//testing

        if (Newcard._rank == Card.RankEnum.Ten)
        {
            Debug.Log("Player put down a 10 card. Taking the dropzone to discard pile");
            DropzoneToDiscardPile();
            return;
        }


        if (cards.Count > 0)
        {
            Debug.Log("dropzone list is above 0. Checking if playerhand card is above dropzone rank");

            cards[0] = FirstInStackCard;

            if (Newcard._rank > FirstInStackCard._rank || Newcard._rank == FirstInStackCard._rank)
            {
                Debug.Log("adding card to dropzone. Rank is higher than the one in dropzone");
                PlayerHand.instance.RemoveCard(Newcard);
                AddCard(Newcard);
            }
            else
            {
                Debug.Log("You cant add this card");
                return;
            }
        }
        else
        {
            AddCard(Newcard);
            PlayerHand.instance.RemoveCard(Newcard);
            Debug.Log($"adding a new card to dropzone (dropzone script here... {Newcard._suit} with rank {Newcard._rank})");
        }


        if (cards.Count >= 3) //here i will check if the all have the same rank so 4 in a row
        {
            Card SecondInStackCard;
            Card ThirdCard;
            Card FourthCard;

            //  getting the cards top 4 including the players last added card
            FirstInStackCard = cards[cards.Count - 1];
            SecondInStackCard = cards[cards.Count - 2];
            ThirdCard = cards[cards.Count - 3];
            FourthCard = cards [cards.Count - 4];


            if(FirstInStackCard._rank == SecondInStackCard._rank && SecondInStackCard._rank == ThirdCard._rank &&
               ThirdCard._rank == FourthCard._rank )
            {
                Debug.Log("This is four in a row. Pile will go to discard");
                DropzoneToDiscardPile();
            }
        }

    }

    public void DropzoneToDiscardPile()
    {
        //removing all dropzone cards to discardpile
        for (global::System.Int32 i = 0; i < cards.Count; i++)
        {
            card = cards[i];
            RemoveCard(card);
            DiscardCards.Instance.AddCard(card);
        }
    }

    public void GetDropZonePile() //this only works for player rn. //add observer to see if player cant make any more actions? same with opponent.
    {
        //removing all dropzone cards to discardpile
        for (global::System.Int32 i = 0; i < cards.Count; i++)
        {
            card = cards[i];
            RemoveCard(card);
            PlayerHand.instance.AddCard(card);
           
        }
    }
}
    

