using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using NaughtyAttributes;

public class Dropzone : CardPile
{
    public static Dropzone Instance;

    private Card _FirstInStackCard;

    public Dictionary<Card, CardInstance> _CardDictoDropZone = new Dictionary<Card, CardInstance>();

    private Card _card;
    private CardInstance _cardInstance;

    public override void AddCard(Card cardToAdd)
    {
        base.AddCard(cardToAdd);
        //also adding to the dictonary
        _CardDictoDropZone.Add(cardToAdd,_cardInstance);
        Debug.Log("adding card to dropzone dictonary");
        Debug.Log($"Adding {cardToAdd._suit} with rank {cardToAdd._rank} to Dropzone");
    }

    public override void RemoveCard(Card cardToRemove)
    {
       base.RemoveCard(cardToRemove);

        if(_CardDictoDropZone.TryGetValue(cardToRemove, out _cardInstance))
        {
            _CardDictoDropZone.Remove(cardToRemove);
            Debug.Log("removed card from the dropzone dictonary also");
        }

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

    public void WantbothInThisScript(Card Card, CardInstance instanceCard)
    {
        _card = Card;
        _cardInstance = instanceCard;

        Debug.Log($"this is card thing from wantboth {_card._suit} and rank {Card._rank}");

        //will see now if this card can go in dropzone
        CanIGoInDropZone(_card);

    }

    //need to change a bit in code so this works with opponent also (maybe a bool which turn it is on player or opponent?)
    public void CanIGoInDropZone(Card Newcard) 
    {

        if (Newcard._rank == Card.RankEnum.Ten)
        {
            Debug.Log("Player put down a 10 card. Taking the dropzone to discard pile");
            AddCard(Newcard);
            DropzoneToDiscardPile();
            return;
        }


        if (cards.Count > 0)
        {
            Debug.Log("dropzone list is above 0. Checking if playerhand card is above dropzone rank");
            _FirstInStackCard = cards[cards.Count - 1];

            if (Newcard._rank > _FirstInStackCard._rank || Newcard._rank == _FirstInStackCard._rank)
            {
                Debug.Log("adding card to dropzone. Rank is higher than the one in dropzone");
                PlayerHand.instance.RemoveCard(Newcard);
                AddCard(Newcard);
                InputManager.Instance._CardHeld = null;
                _cardInstance.GoToDropZonePosition();
            }
            else
            {
                Debug.Log("You cant add this card");
                _cardInstance.GoBackOrgPos();
                return;
            }
        }
        else
        {
            AddCard(Newcard);
            PlayerHand.instance.RemoveCard(Newcard); //removing card from playerhand
            _cardInstance.GoToDropZonePosition();
            Debug.Log($"adding a new card to dropzone (dropzone script here... {Newcard._suit} with rank {Newcard._rank})");
        }


        if (cards.Count >= 4) //here i will check if the all have the same rank so 4 in a row
        {
            Card SecondInStackCard;
            Card ThirdCard;
            Card FourthCard;

            //  getting the cards top 4 including the players last added card
            _FirstInStackCard = cards[cards.Count - 1];
            SecondInStackCard = cards[cards.Count - 2];
            ThirdCard = cards[cards.Count - 3];
            FourthCard = cards [cards.Count - 4];


            if(_FirstInStackCard._rank == SecondInStackCard._rank && SecondInStackCard._rank == ThirdCard._rank &&
               ThirdCard._rank == FourthCard._rank )
            {
                Debug.Log("This is four in a row. Pile will go to discard");
                DropzoneToDiscardPile();
            }
        }

    }

    public void DropzoneToDiscardPile()
    {
        foreach (var entry in _CardDictoDropZone)
        {
            DiscardCards.Instance.addToDictonary(entry.Key, entry.Value);
            RemoveCard(entry.Key);
        }
    }

    public void GetDropZonePile() //this only works for player rn. //add observer to see if player cant make any more actions? same with opponent.
    {
        //removing all dropzone cards to discardpile
        for (global::System.Int32 i = 0; i < cards.Count; i++)
        {
            _card = cards[i];
            RemoveCard(_card);
            PlayerHand.instance.AddCard(_card);
           
        }
    }
}
    

