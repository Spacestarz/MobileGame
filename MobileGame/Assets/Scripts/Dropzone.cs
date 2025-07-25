using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using NaughtyAttributes;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using System;


public enum CardResults
{
    Illegal,
    Ten,
    FourInARow,
    NormalHigher
}

public class Dropzone : CardPile
{
    [SerializeField] private AudioClip _failSound;
    [SerializeField] private AudioClip _successSound;
    [SerializeField] private AudioClip _FlipOneCardSound;
    [SerializeField] private AudioClip _FlippingManyCardsSound;
    [SerializeField] private AudioClip _NumberTenSound;



    public static Dropzone Instance;

    private Card _FirstInStackCard;

    private Card _card;

    public bool _IsTakingAChance = false; //got a method here with changing draw text

    [SerializeField] private TextMeshProUGUI _textOnDrawButton;

    public bool _ChangedDefaultText = false;
    [SerializeField] private ButtonInteractable _drawbuttonScript;
    private string _DefaultTextDrawButton = "Draw";

    private float _DefaultFontSizeDrawButton = 24;

    public Button _DrawButton;

    public Action _OnChangedChanceBool;

    public override void AddCard(Card cardToAdd)
    {
        base.AddCard(cardToAdd);
        var cardInstanceScript = cardToAdd.GetComponent<CardInstance>();
        cardToAdd._CardOrigin = Card.CardOriginEnum.Dropzone;

        Debug.Log("addcard for dropzone");

        if ( _FirstInStackCard != null ) 
        {
            Debug.LogWarning($"{_FirstInStackCard._suit} and rank {_FirstInStackCard._rank} is _firstinstackcard will DISABLE textmesh (dropzone row 46)");

            var UnderMe = _FirstInStackCard.GetComponent<CardInstance>();

            if ( UnderMe == null )
            {
                Debug.Log("i dont have cardinstance from _firststackincard");
            }

            UnderMe.SetTextVisability(false); //disables the textmesh

            //changing the sorting order directly here for this special case
            Debug.Log("sorting order for firstcardinstack is 0 it will be in back.");
            _FirstInStackCard._renderUp.sortingOrder = 0;
            _FirstInStackCard._renderDown.sortingOrder = 0;
        }

       if ( TrackingTurns.Instance._CurrentTurn == TrackingTurns.TurnState.OpponentTurn)
       {
            Debug.Log($"flippin {cardToAdd._suit} with rank {cardToAdd._rank} for opponent");
            cardToAdd.SetCardFaceUp(true);
            cardToAdd.ChangeSortingOrder();
            //Debug.Log("changing sorrting please be above");
       }
        
        TrackingTurns.Instance._OnCardDropZone?.Invoke();

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

        //if the bool off _ istakingachance is changing this gets invoked
        _OnChangedChanceBool -= OnBoolChange;
        _OnChangedChanceBool += OnBoolChange;

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

    public void LastPhaseButtonTextChangeDefault()
    {
        _DefaultTextDrawButton = "Get card pile"; //take a leap
        _DefaultFontSizeDrawButton = 19;
        Debug.Log("make button text to get pile");
        _ChangedDefaultText = true;

        if (_DrawButton != null)
        {
            _drawbuttonScript = _DrawButton.GetComponent<ButtonInteractable>();
            if (_drawbuttonScript != null)
            {
                _drawbuttonScript.ChangeClickActionToGetDropzonePile();
            }
            else
            {
                Debug.LogWarning("drawbutton script is null!");
            }
        }
        else
        {
            Debug.LogWarning("drawbutton is null!");
        }
    }


    public CardResults CanIGoInDropzone(Card Newcard)
    {


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

        if (Newcard._rank == Card.RankEnum.Ten)
        {
            if (cards.Count <= 0)
            {
                return CardResults.Ten;
            }
            _FirstInStackCard = cards[cards.Count - 1];
            return CardResults.Ten;
        }


        if (cards.Count > 0)
        {
            Debug.Log("dropzone list is above 0. Checking if card is above dropzone rank");
            _FirstInStackCard = cards[cards.Count - 1];
            Debug.Log("getting new firstinstackcard");
            Debug.Log($"firstCardInsStack is {_FirstInStackCard._suit} with rank {_FirstInStackCard._rank}");

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

    private void OnBoolChange()
    {
        if (_IsTakingAChance == true)
        {
            //insert to change draw card text and be able to guess a card
            ChangeDrawCardText();

            if (TrackingTurns.Instance._CurrentTurn == TrackingTurns.TurnState.OpponentTurn)
            {
                OpponentAi.Instance.GuessCard();
                Debug.LogWarning("This should only show when current turn is opponent");
            }
        }
        else
        {

        }
    }


    public void PutCardInDropzone(Card Newcard) 
    {

        _FirstInStackCard = null;
        var result = CanIGoInDropzone(Newcard);

        var cardInstanceScript = Newcard.GetComponent<CardInstance>();

        var CardOrigin = WhereIsCardFrom(Newcard);


        if (!_IsTakingAChance)
        {
            switch (result)
            {
                case CardResults.Ten:

                    Debug.Log("ten card");
                    Debug.Log("Player put down a 10 card. Taking the dropzone to discard pile");
                    OpponentDialog.Instance.ActivateDialog("No more cards! Here is my magic 10 card!");
                    AddCard(Newcard);
                    RemoveCardFromOriginList(CardOrigin, Newcard);
                    DropzoneToDiscardPile();

                    if (TrackingTurns.Instance._CurrentTurn == TrackingTurns.TurnState.Playerturn)
                    {
                        SavePlayerPrefs.instance.IncreaseTenCardUsedPlayer();
                    }

                    break;


                case CardResults.FourInARow:
                    Debug.Log("4 in a row");
                    AddCard(Newcard);
                   RemoveCardFromOriginList(CardOrigin, Newcard);

                    DropzoneToDiscardPile();
                    break;

                case CardResults.NormalHigher:
                    Debug.Log("normal higher");
                    AddCard(Newcard);

                  RemoveCardFromOriginList(CardOrigin, Newcard);
                    
                    break;


                case CardResults.Illegal:
                    Debug.Log("illegal card");
                    SoundFXManager.instance.PlaySoundEffectClip(_failSound, transform, 20);
                    cardInstanceScript.Shake();
                    Debug.Log("shaking and playing fail sound");
                    //_IsTakingAChance = true;
                    cardInstanceScript.GoBackOrgPos();
                    break;

                default:
                    Debug.Log("default in switch case wtf");

                    break;
            }
        }

         
        if (_IsTakingAChance) 
        {
            StartCoroutine(animateToDropZone( Newcard, result));
            if (result != CardResults.Illegal)
            {
                //removing card here to make it eassier because i have cardorigin and newcard here. 
                RemoveCardFromOriginList(CardOrigin, Newcard);
                Debug.Log("removing card from ORIGIN the result is not illegal");
            }
            Debug.LogWarning("takinga chance method moving with dotween");
        }

       
    }

    public void RemoveCardFromOriginList(Card.CardOriginEnum origin , Card card)
    {
        switch (origin)
        {
            case Card.CardOriginEnum.PlayerHand:
                Debug.LogWarning(" Calling to Remove Card from PlayerHand");
                PlayerHand.instance.RemoveCard(card);
                break;

            case Card.CardOriginEnum.PlayerTable:
                Debug.LogWarning(" Calling to Remove Card from Playertable");
                PlayerTableCards.instance.RemoveCard(card);
                break ;

            case Card.CardOriginEnum.OpponentHand:
                Debug.LogWarning("Calling to Remove Card from Opponenthand");
                OpponentHand.instance.RemoveCard(card);
                break;

            case Card.CardOriginEnum.OpponentTable:
                Debug.LogWarning("Calling to Remove Card from OpponentTable");
                OpponentTableCard.Instance.RemoveCard(card);
                break;

            default:
                Debug.LogWarning("unknown origin");
                break;
        }
    }

    public Card.CardOriginEnum WhereIsCardFrom(Card card)
    {
        Card.CardOriginEnum Origin = card._CardOrigin;

        switch (Origin)
        {
            case Card.CardOriginEnum.PlayerHand:
                Debug.LogWarning("Card from PlayerHand");
                return Card.CardOriginEnum.PlayerHand;

            case Card.CardOriginEnum.PlayerTable:
                Debug.LogWarning("Card from Playertable");
                return Card.CardOriginEnum.PlayerTable;

            case Card.CardOriginEnum.OpponentHand:
                Debug.LogWarning("Card from Opponenthand");
                return Card.CardOriginEnum.OpponentHand;

            case Card.CardOriginEnum.OpponentTable:
                Debug.LogWarning("Card from OpponentTable");
                return Card.CardOriginEnum.OpponentTable;

            default:
                Debug.LogWarning("unknown origin");
                return Card.CardOriginEnum.unknown;
        }
    }

    public void ChangeDrawCardText()
    {
        _IsTakingAChance = true;
        _textOnDrawButton.text = "Take a chance"; //take a leap
        _textOnDrawButton.fontSize = 19;
        Debug.Log($"taking a chance bool is {_IsTakingAChance} ");

    }

    private IEnumerator animateToDropZone(Card NewCard, CardResults cardresult) 
    {
        Debug.LogWarning("animate to dropzone method");

        NewCard.ChangeSortingOrder();
        Vector3 targetPosition = SpawnLocations.instance.dropzoneLocationForCards.transform.position;
        float moveDuration = 0.3f;
        float hideThreshold = 0.05f;

        yield return NewCard.transform.DOMove(targetPosition, moveDuration).WaitForCompletion();

        if (cards.Count > 0)
        {
            _FirstInStackCard = cards[cards.Count - 1];
            Debug.Log("changing sorrting order of _firstcardinstack");
            _FirstInStackCard.ChangeSortingOrder();

            if (Vector3.Distance(NewCard.transform.position, _FirstInStackCard.transform.position) <= hideThreshold)
            {
                var cardInstance = _FirstInStackCard.GetComponent<CardInstance>();
                if (cardInstance != null)
                {
                    cardInstance.SetTextVisability(false);
                }
            }
        }

        yield return new WaitForSeconds(3); // Delay for effects //maybe add a cam zoom?
        //playing flip card sound
        SoundFXManager.instance.PlaySoundEffectClip(_FlipOneCardSound, transform, 20);

        //getting orgpos
        var originalPositionY = NewCard.transform.position.y;

        //moving the card up a bit for a fake effect of "flipping" the card
        NewCard.transform.DOLocalMoveY(originalPositionY + 0.5f, 0.3f)
          .OnComplete(() => NewCard.transform.DOLocalMoveY(originalPositionY, 0.2f));

        NewCard.SetCardFaceUp(true);
        //After when the card flips we wait a bit. 
        yield return new WaitForSeconds(3); 

        var cardInstanceScript = NewCard.GetComponent<CardInstance>();

        if (cardresult == CardResults.Illegal)
        {
            Debug.Log("Play sound: Illegal move");

            SoundFXManager.instance.PlaySoundEffectClip(_failSound, transform, 20);

            if (TrackingTurns.Instance._CurrentTurn == TrackingTurns.TurnState.Playerturn)
            {
                PlayerHand.instance.AddCard(NewCard);
                GetDropZonePile(); //make player get the dropzone cards
            }
            else
            {
                
                OpponentHand.instance.AddCard(NewCard);
                GetDropZonePile();
                //if this happens make sure the opponent turn ends!
            }
        }
        else if (cardresult != CardResults.Illegal)  
        {
            Debug.Log("Play sound: Success");
            SoundFXManager.instance.PlaySoundEffectClip(_successSound, transform, 20);
            AddCard(NewCard); //removing card from origin in before method (putcardindropzone)
            if (cardresult == CardResults.Ten)
            {
                DropzoneToDiscardPile();
                Debug.Log("cardresult is ten moving cards to discardpile");
            }
            TrackingTurns.Instance.DisableInput = true;
            TrackingTurns.Instance._OnCanInteractWithButton?.Invoke();
            Debug.Log("disables input");

            //waiting a bit so ai wont end turn to early
            yield return new WaitForSeconds(3f);

            if (TrackingTurns.Instance._CurrentTurn == TrackingTurns.TurnState.Playerturn)
            {
                if (LastPhase.Instance.LastPhaseActive == true)
                {
                    PlayerHand.instance.WinCheckPlayer();
                    Debug.Log("done a wincheck for player");
                }
            }

            if (TrackingTurns.Instance._CurrentTurn == TrackingTurns.TurnState.OpponentTurn)
            {
                OpponentAi.Instance.EndAITurnDelay();
                Debug.Log("ending turn for opponent");
            }
        
        }
    }

    public void DropzoneToDiscardPile()
    {
        //removing all dropzone cards to discardpile
        for (global::System.Int32 i = 0; i < cards.Count; i++)
        {
            List<Card> tempcard =  new List<Card> (cards); //copy of cards list

            foreach (var card in tempcard)
            {
                RemoveCard (card);
                DiscardCards.Instance.AddCard(card);
            }
        }
        Debug.Log("adding all cards from dropzonepile to DiscardPILE. (dropzone row 341, method dropzonetodiscardpile)");
        Debug.Log($"Cards left in dropzone: {cards.Count}");
    }

    [Button]
    public void GetDropZonePile() 
    {
        Debug.Log("getdropzonepile method");

        //removing all dropzone cards to player/opponent hand.

        List<Card> tempcard = new List<Card>(cards); //copy of cards list

        var currentTurn = TrackingTurns.Instance._CurrentTurn;

        foreach (var card in tempcard)
        {
            Debug.Log($"Attempting to remove card: {card} from dropzone (cards count: {cards.Count})");

            if (cards.Contains(card))
            {
                RemoveCard(card);
            }
            else
            {
                Debug.LogWarning($"Card {card} not found in dropzone before removal");
            }
            //RemoveCard(card);

            if (currentTurn == TrackingTurns.TurnState.Playerturn)
            {
                PlayerHand.instance.AddCard(card);
                Debug.Log("adding all cards from dropzonepile to PlayerHand");
            }
            else
            {
                OpponentDialog.Instance.ActivateDialog(" Great more cards for me.... Of course i diden't have a higher card");

                OpponentHand.instance.AddCard(card);
                Debug.Log("adding all cards from dropzonepile to opponenthand");
            }

        }

        Debug.Log($"Cards left in dropzone: {cards.Count}");
        Debug.Log($" disable input is: {TrackingTurns.Instance.DisableInput}");
        Debug.LogWarning("Opponent ending turn after he got all dropzone cards is updating");
        OpponentAi.Instance.EndAITurnDelay();
    }
}
    

