using NaughtyAttributes;
using NUnit.Framework.Constraints;
using System;
using TMPro;
using UnityEngine;

public class TrackingTurns : MonoBehaviour
{
    public static TrackingTurns Instance;

    public Action _OnCardDropZone;

    public Action _OnDrawnCard;

    [SerializeField] private TextMeshProUGUI _WhichTurnText;

    [SerializeField] private TextMeshProUGUI _textOnDrawButton;

    private string _DefaultTextDrawButton = "Draw";
    private float _DefaultFontSizeDrawButton = 24;


    //bools
    public bool DisableInput = false; 

    public bool HasDrawnCard = false;

    public bool GuessCard = false;



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
        _DefaultTextDrawButton = _textOnDrawButton.text;
        _DefaultFontSizeDrawButton = _textOnDrawButton.fontSize;


        _OnCardDropZone -= OnAddedToDropZone;
        _OnCardDropZone += OnAddedToDropZone;

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

    public void OnAddedToDropZone()
    {
        Debug.Log("a card was added to the dropzone... making so that input will be disabled");
        Debug.Log("Highlight on end turn (not implemented yet");
        DisableInput = true;
    }

    public void OnHighlightEndTurn()
    {
        //will want to highlight end turn
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
    public void CheckCardsVSDropZone()
    {
        Debug.Log("CheckCardsVSdropzone method");

        if (Dropzone.Instance.cards.Count > 0)
       {
            var latestCard = Dropzone.Instance.cards[Dropzone.Instance.cards.Count - 1];

            if (_CurrentTurn == TurnState.Playerturn) 
            {
                foreach (var card in PlayerHand.instance.cards) //this is for playerhand
                {
                    if (card._rank >= latestCard._rank)
                    {
                         Debug.Log($"{card._suit} with rank {card._rank} can be put in cardzone");
                    }
                    else
                    {
                         Debug.LogWarning("player cant put any card in dropzone");

                        _textOnDrawButton.text = "Take a chance"; //take a leap
                        _textOnDrawButton.fontSize = 19;

                        // Debug.LogWarning("sending an observer to change draw card text");
                        //player can now end turn (and pick up the whole cardpile or do a guess draw)
                        DisableInput = true;
                    }
                }
            }
            else if (_CurrentTurn == TurnState.OpponentTurn) 
            {
                Debug.Log("checkthing opponenthand");

                Card lowestValidCard = null;


                foreach (var card in OpponentHand.instance.cards) //this is for opponent hand
                {
                    if (card._rank >= latestCard._rank)
                    {
                        Debug.Log($"{card._suit} with rank {card._rank} can be put in cardzone");

                        if (lowestValidCard == null || card._rank < lowestValidCard._rank)
                        {
                            lowestValidCard = card;

                            Debug.Log($"the lowest valid card in the opponenthand is {card._suit} with rank {card._rank}");
                        } 

                    }
                    else
                    {
                        Debug.LogWarning("opponent cant put any card in dropzone");

                        // Debug.LogWarning("sending an observer to change draw card text");

                        Debug.Log("opponent cant play any cards");

                    }
                }

                if (lowestValidCard != null)
                {
                    Debug.Log($"Opponent plays the lowest valid card: {lowestValidCard._suit} with rank {lowestValidCard._rank}");
                    Dropzone.Instance.PutCardInDropzone(lowestValidCard);
                }

            }
        }
    }


    public void OpponentCheck()
    {
        //same as above but with opponent
    }

    public void EndTurn()
    {
        //end logic here 

        if (_CurrentTurn == TurnState.Playerturn)
        {
            Debug.LogWarning("Player turn ended...Switching to opponent");
            _CurrentTurn = TurnState.OpponentTurn;
            _WhichTurnText.text = ("Opponent Turn");

            if (_textOnDrawButton.text != _DefaultTextDrawButton || _textOnDrawButton.fontSize != _DefaultFontSizeDrawButton)
            {
                _textOnDrawButton.text   = _DefaultTextDrawButton;
                _textOnDrawButton.fontSize = _DefaultFontSizeDrawButton;
            }

            _WhichTurnText.color = Color.red;

            OpponentAi.instance.OpponentTurn();
        }
        else
        {
            Debug.LogWarning("Opponent turn ended....switching to player turn");
            _CurrentTurn = TurnState.Playerturn;
            _WhichTurnText.text = ("Your Turn");

            _WhichTurnText.color = Color.green;
            DisableInput = false;
        }
    }
}
