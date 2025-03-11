using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using NaughtyAttributes;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;


public enum CardResults
{
    Illegal,
    Ten,
    FourInARow,
    NormalHigher
}

public class Dropzone : CardPile
{
    public static Dropzone Instance;

    private Card _FirstInStackCard;

    private Card _card;

    public bool _IsTakingAChance; //got a method here with changing draw text

    [SerializeField] private TextMeshProUGUI _textOnDrawButton;

    private string _DefaultTextDrawButton = "Draw";

    private float _DefaultFontSizeDrawButton = 24;

    public Button DrawButton;

    public override void AddCard(Card cardToAdd)
    {
        base.AddCard(cardToAdd);
        var cardInstanceScript = cardToAdd.GetComponent<CardInstance>();

        Debug.Log("addcard for dropzone");

        if ( _FirstInStackCard != null ) 
        {
            Debug.Log("firstinstackcard is not nuul");
           var UnderMe = _FirstInStackCard.GetComponent<CardInstance>();
            if ( UnderMe == null )
            {
                Debug.Log("i dont have cardinstance from _firststackincard");
            }

            UnderMe.SetTextVisability(false); //disables the textmesh
        }

        if (TrackingTurns.Instance._CurrentTurn == TrackingTurns.TurnState.Playerturn)
        {
            TrackingTurns.Instance._OnCardDropZone?.Invoke();
            Debug.Log("i should show only when in playerturn");
        }
        else
        {
            cardToAdd.FlipCard();
        }

        Debug.Log($"Adding {cardToAdd._suit} with rank {cardToAdd._rank} to Dropzone");
        cardInstanceScript.GoToDropZonePosition();
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

        DefaultValueDrawButton();// getting default value on drawbutton
    }

    public void DefaultValueDrawButton()
    {
        _DefaultTextDrawButton = _textOnDrawButton.text;
        _DefaultFontSizeDrawButton = _textOnDrawButton.fontSize;
    }

    public void CheckIfNeedChangeDrawText()
    {
        if (_textOnDrawButton.text != _DefaultTextDrawButton || _textOnDrawButton.fontSize != _DefaultFontSizeDrawButton)
        {
            _textOnDrawButton.text = _DefaultTextDrawButton;
            _textOnDrawButton.fontSize = _DefaultFontSizeDrawButton;
        }
        _IsTakingAChance = false;
        Debug.Log("taking a chance bool is now false");

    }


    public CardResults CanIGoInDropzone(Card Newcard)
    {

        //if (newcard._rank == card.rankenum.ten)
        //{
        //    debug.log("player put down a 10 card. taking the dropzone to discard pile");
        //    return cardresults.ten;
        //}

        if (cards.Count >= 4) //here i will check if the all have the same rank so 4 in a row
        {
            Card SecondInStackCard;
            Card ThirdCard;
            Card FourthCard;

            //  getting the cards top 4 including the players last added card
            _FirstInStackCard = cards[cards.Count - 1];
            SecondInStackCard = cards[cards.Count - 2];
            ThirdCard = cards[cards.Count - 3];
            FourthCard = cards[cards.Count - 4];

            if (_FirstInStackCard._rank == SecondInStackCard._rank && SecondInStackCard._rank == ThirdCard._rank &&
               ThirdCard._rank == FourthCard._rank)
            {
                return CardResults.FourInARow;
            }
        }


        if (cards.Count > 0)
        {
            Debug.Log("dropzone list is above 0. Checking if card is above dropzone rank");
            _FirstInStackCard = cards[cards.Count - 1];

            if (Newcard._rank > _FirstInStackCard._rank || Newcard._rank == _FirstInStackCard._rank)
            {
                return CardResults.NormalHigher;
            }
            else
            {
                 return CardResults.Illegal;
            }
        }
        else
        {
            return CardResults.NormalHigher;
        }


        return CardResults.Illegal; //default
    }


    public void PutCardInDropzone(Card Newcard) 
    {
        var result = CanIGoInDropzone(Newcard);

        var cardInstanceScript = Newcard.GetComponent<CardInstance>();

        switch (CanIGoInDropzone(Newcard))
        {
             case CardResults.Ten:
                
                Debug.Log("ten card");
                Debug.Log("Player put down a 10 card. Taking the dropzone to discard pile");
                AddCard(Newcard);
                DropzoneToDiscardPile();
                break;


            case CardResults.FourInARow:
                 Debug.Log("4 in a row");
                AddCard(Newcard);
                DropzoneToDiscardPile();
                break;

                case CardResults.NormalHigher:
                Debug.Log("normal higher");
                AddCard(Newcard);
                    break;


               case CardResults.Illegal:
                Debug.Log("illegal card");
                _IsTakingAChance = true;
                cardInstanceScript.GoBackOrgPos();
                break;

            default:
                Debug.Log("default in switch case wtf");

                break;
        }


        if (result != CardResults.Illegal && _IsTakingAChance) 
        {
            StartCoroutine("animateToDropZone", Newcard);
            Debug.Log("takinga chance method moving with dotween");
            // start coroutine animation
            //wait coroutine stuff
        }

        if (_IsTakingAChance)
        {
            Debug.Log("taking a chance bool is on");


            return;
        }
        #region shit
        //if (Newcard._rank == Card.RankEnum.Ten)
        //{
        //    Debug.Log("Player put down a 10 card. Taking the dropzone to discard pile");
        //    AddCard(Newcard);
        //    DropzoneToDiscardPile();
        //    return;
        //}

        //if (cards.Count > 0)
        //{
        //    Debug.Log("dropzone list is above 0. Checking if card is above dropzone rank");
        //    _FirstInStackCard = cards[cards.Count - 1];

        //    if (Newcard._rank > _FirstInStackCard._rank || Newcard._rank == _FirstInStackCard._rank)
        //    {
        //        Debug.Log("adding card to dropzone. Rank is higher than the one in dropzone");

        //        if (TrackingTurns.Instance._CurrentTurn == TrackingTurns.TurnState.Playerturn)
        //        {
        //            PlayerHand.instance.RemoveCard(Newcard);
        //            Debug.Log("playerhand card adding");
        //        }
        //        else
        //        {
        //            OpponentHand.instance.RemoveCard(Newcard);
        //            Debug.Log("opponent hand card adding");
        //        }

        //        AddCard(Newcard);
        //        InputManager.Instance._CardHeld = null;
        //        cardInstanceScript.GoToDropZonePosition();
        //    }
        //    else
        //    {
        //        Debug.Log("You cant add this card");
        //        cardInstanceScript.GoBackOrgPos();
        //        return;
        //    }
        //}
        //else
        //{
        //    AddCard(Newcard);

        //    if (TrackingTurns.Instance._CurrentTurn == TrackingTurns.TurnState.Playerturn)
        //    {
        //        PlayerHand.instance.RemoveCard(Newcard); //removing card from playerhand

        //    }
        //    else
        //    {
        //        OpponentHand.instance.RemoveCard(Newcard);
        //        Debug.Log("removing card from opponenthand");
        //    }

        //    //insert card go to dropzone
        //    cardInstanceScript.GoToDropZonePosition();
        //    Debug.Log($"adding a new card to dropzone (dropzone script here... {Newcard._suit} with rank {Newcard._rank})");
        //}

        //    if (cards.Count >= 4) //here i will check if the all have the same rank so 4 in a row
        //    {
        //        Card SecondInStackCard;
        //        Card ThirdCard;
        //        Card FourthCard;

        //       // getting the cards top 4 including the players last added card
        //        _FirstInStackCard = cards[cards.Count - 1];
        //        SecondInStackCard = cards[cards.Count - 2];
        //        ThirdCard = cards[cards.Count - 3];
        //        FourthCard = cards[cards.Count - 4];

        //        if (_FirstInStackCard._rank == SecondInStackCard._rank && SecondInStackCard._rank == ThirdCard._rank &&
        //           ThirdCard._rank == FourthCard._rank)
        //        {
        //            Debug.Log("This is four in a row. Pile will go to discard");
        //            DropzoneToDiscardPile();
        //        }
        //    }
        #endregion
    }

    public void ChangeDrawCardText()
    {
        _IsTakingAChance = true;
        _textOnDrawButton.text = "Take a chance"; //take a leap
        _textOnDrawButton.fontSize = 19;

    }

    private IEnumerator animateToDropZone(Card NewCard) //working to make this wurk
    {
        Debug.Log("ienumator to dropzone will use dotween");
        //this will happened when you "guess" a card

        yield return NewCard.transform.DOMove(SpawnLocations.instance.dropzoneLocationForCards.transform.position, 2f)
            .WaitForCompletion();
    }

    public void DropzoneToDiscardPile()
    {
        Debug.Log("dropzonetodiscardpile method here");
    }

    public void GetDropZonePile() //this only works for player rn. //add observer to see if player cant make any more actions? same with opponent.
    {
        //removing all dropzone cards to discardpile
        for (global::System.Int32 i = 0; i < cards.Count; i++)
        {
            _card = cards[i];
            RemoveCard(_card);
            if (TrackingTurns.Instance._CurrentTurn == TrackingTurns.TurnState.Playerturn)
            {
                PlayerHand.instance.AddCard(_card);
                Debug.Log("adding all cards from dropzonepile to PlayerHand");
            }
            else
            {
                OpponentHand.instance.AddCard(_card);
                Debug.Log("adding all cards from dropzonepile to opponenthand");
            }
        }
    }
}
    

