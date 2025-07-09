using NaughtyAttributes;
using NUnit.Framework.Constraints;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static TrackingTurns;

public class TrackingTurns : MonoBehaviour
{
    public static TrackingTurns Instance;

    public Action _OnCardDropZone;

    public Action _OnDrawnCard;

    public Action _OnHighlightEndTurn;

    public Action _OnDisableHighLight;

    public Action _OnCanInteractWithButton;


    [SerializeField] private ButtonInteractable takeAChanceButton;

    [SerializeField] private TextMeshProUGUI _WhichTurnText;

    [SerializeField] private ButtonInteractable _DrawButtonInteractScript;

    [SerializeField] private ButtonInteractable _EndButtonInteractScript;



    //[SerializeField] private TextMeshProUGUI _textOnDrawButton;

    //private string _DefaultTextDrawButton = "Draw";
    //private float _DefaultFontSizeDrawButton = 24;

    //public Button _EndButton;
    //public Button _DrawButton;

    private bool _InteractableButton = false;


    //bools
    public bool DisableInput = false; 

    public bool HasDrawnCard = false;

    public enum TurnState
    {
        Playerturn,
        OpponentTurn
    }

    public TurnState _CurrentTurn = TurnState.Playerturn;


    //this class will track what player/opponent can do.
    //and it will check if you have done it and you cant do it again etc. 

    //probarly best to just have an observer? like if player has drawn 1 card it cant do it again etc

    private void Awake()
    {
        //_DefaultTextDrawButton = _textOnDrawButton.text;
        //_DefaultFontSizeDrawButton = _textOnDrawButton.fontSize;


        _OnCardDropZone -= OnAddedToDropZone;
        _OnCardDropZone += OnAddedToDropZone;

        _OnHighlightEndTurn -= OnHighlightEndTurn;
        _OnHighlightEndTurn += OnHighlightEndTurn;

        _OnDisableHighLight -= OnDisableHighLight;
        _OnDisableHighLight += OnDisableHighLight;


        _WhichTurnText.text = ("Your Turn");
        _WhichTurnText.color = Color.green;

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //if i want to highlight..
    //just make a square with eh color underneath..
    //what i want to highlight and activate/disable it

    private void Start()
    {
        if (StartSwappingBeforeStart.instance._SwappingPhase == true)
        {
            _WhichTurnText.text = ("Swapping Phase");
            _EndButtonInteractScript.SetInteractable(false);
        }
    }

    public void SwappPhaseOver()
    {
        _WhichTurnText.text = ("Your Turn");
        _EndButtonInteractScript.SetInteractable(true);
    }
        

    public void OnAddedToDropZone()
    {
        Debug.Log("added on dropzone method in trackingturn row 97");
        //Debug.Log("a card was added to the dropzone... making so that input will be disabled");
        //DisableInput = true;

        if (_CurrentTurn == TurnState.OpponentTurn && Dropzone.Instance._IsTakingAChance == false )
        {
            Debug.Log("its ai turn and taking a chance is FALSE");
           // OpponentAi.instance.EndAiTurn();
        }
        else
        {
            OnHighlightEndTurn();
        }
    }

    public void OnHighlightEndTurn()
    {
        //will want to highlight end turn
        HighLight.Instance.HighLightMe();
        Debug.Log("highlighting end turn button");
    }

    public void OnDisableHighLight()
    {
        HighLight.Instance.DisableHighLight();
       // Debug.Log("diables highlight end tunr");
    }

    public void PlayerCheck()
    {
        if (DisableInput) ;
        //if player has successfully put a card in dropzone 

        //if player has drawn  a "guess" card and fails

        //here i will check if player has done all they can do
        //so the only option left will be to click the end turn button
    }


    [Button]
    public void CheckCardsVSDropZone() //
    {
        Debug.Log("CheckCardsVSdropzone method");

        if (Dropzone.Instance.cards.Count > 0)
        {
            Debug.Log("dropzone cards is above 0");
            var latestCard = Dropzone.Instance.cards[Dropzone.Instance.cards.Count - 1];
            bool canPLaceCard = false;

            if (_CurrentTurn == TurnState.Playerturn)
            {
                if (PlayerHand.instance.cards.Count == 0 )
                {
                    Debug.Log("comparing dropzonevscard with player tablecards with tag Card");
                    foreach (var card in PlayerTableCards.instance.cards)
                    {
                        //comparing the cards with only the tag Card so it dont compare those that are not interactable
                        if (card.CompareTag("Card"))
                        {
                            if (card._rank >= latestCard._rank || card._rank == Card.RankEnum.Ten)
                            {
                                Debug.Log($"{card._suit} with rank {card._rank} can be put in cardzone PLAYER");
                                canPLaceCard = true;
                            }
                        }
                        
                    }
                }
                else
                {
                    foreach (var card in PlayerHand.instance.cards) //this is for playerhand
                    {
                        if (card._rank >= latestCard._rank || card._rank == Card.RankEnum.Ten)
                        {
                            Debug.Log($"{card._suit} with rank {card._rank} can be put in cardzone PLAYER");
                            canPLaceCard = true;
                        }
                    }
                }

                   

                if (!canPLaceCard)
                {
                    Debug.LogWarning("player cant put any card in dropzone");
                    Dropzone.Instance._IsTakingAChance = true;
                    Dropzone.Instance._OnChangedChanceBool?.Invoke();
                    takeAChanceButton.SetInteractable(true);
                    // Debug.LogWarning("sending an observer to change draw card text");
                    //player can now end turn (and pick up the whole cardpile or do a guess draw)

                    //DisableInput = true;
                }
            }
            else if (_CurrentTurn == TurnState.OpponentTurn)
            {
                Debug.Log("checkcardVSdropzone  opponenthand");

                Card lowestValidCard = null;

                //if opponent have no cards left in hand or the lastphaseai is active
                if (OpponentHand.instance.cards.Count == 0 || LastPhase.Instance.LastPhaseAIActive)
                {
                    OpponentAi.Instance.AItablecardsVsDropzone();
                    return;
                }

                OpponentAi.Instance.AiHandCardsVsDropzone();

            }
        }
        else
        {
            NOCardsInDropZone();
            Debug.Log("nocards in dropzone");
        }

    }


    //this  should be in opponentAI script only works for AI anyway
    public void NOCardsInDropZone() 
    {
            if (_CurrentTurn == TurnState.OpponentTurn)
            {
                Card lowestValidCard = null;

                foreach (var card in OpponentHand.instance.cards) //this is for opponent hand
                {

                    Debug.Log($"- {card._suit} rank: {card._rank}");

                    if (lowestValidCard == null || card._rank < lowestValidCard._rank)
                    {
                        lowestValidCard = card;
                        Debug.Log($"the lowest valid card in the opponenthand is {card._suit} with rank {card._rank}");
                    }
                }

                if (lowestValidCard != null)
                {
                    Debug.Log($"Opponent plays the lowest valid card: {lowestValidCard._suit} with rank {lowestValidCard._rank}");
                    Dropzone.Instance.PutCardInDropzone(lowestValidCard);

                }
                else
                {
                    Debug.Log("opponent has no cards?");
                }

            }
    }

    public void EndTurn()
    {
        takeAChanceButton.SetInteractable(false);

        if (EveryCard.instance.cards.Count == 0 )
        {
            if (Dropzone.Instance._ChangedDefaultText == false)
            {
                Dropzone.Instance.LastPhaseButtonTextChangeDefault();
            }
        }

        if (_CurrentTurn == TurnState.Playerturn)
        {
            Debug.LogWarning("Player turn ended...Switching to opponent");
            _CurrentTurn = TurnState.OpponentTurn;
            _WhichTurnText.text = ("Opponent Turn");

           // Debug.Log($"OpponentHAAAND cards count is: {OpponentHand.instance.cards.Count});");

            if (Dropzone.Instance._IsTakingAChance)
            {
                Dropzone.Instance.CheckIfNeedChangeDrawText();               
            }

            _WhichTurnText.color = Color.red;

            OnDisableHighLight(); 

            OpponentAi.Instance.OpponentTurn();
        }
        else
        {
            Debug.LogWarning("Opponent turn ended....switching to player turn");
            Dropzone.Instance.CheckIfNeedChangeDrawText();

            OnDisableHighLight();

            _CurrentTurn = TurnState.Playerturn;
            _WhichTurnText.text = ("Your Turn");

            Debug.Log($"playerHAND cards count is: {PlayerHand.instance.cards.Count}");

            if (LastPhase.Instance.LastPhaseActive)
            {
                LastPhase.Instance.CheckIfLastPhaseStillNeededForPlayer();
                Debug.Log("checkingiflastphase is still needed for player. trackingturn script row 347");
            }

            PlayerHand.instance.CheckIfLastPhase();

            while (PlayerHand.instance.cards.Count < 3)
            {
                if (EveryCard.instance.cards.Count == 0)
                {
                    break;
                }
                EveryCard.instance.GetCard();
            }

           if (PlayerHand.instance.cards.Count >= 3)
            {
                PlayerHand.instance.UpdateHand();
            }
           else
            {
                CheckCardsVSDropZone();
                Debug.Log("playerhand cards less than 3 trackingturn script row 314. Moving on to checkcardvsdropzone");
            }

           _WhichTurnText.color = Color.green;
           DisableInput = false;

        }
    }
}
