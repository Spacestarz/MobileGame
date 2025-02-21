using NUnit.Framework.Constraints;
using System;
using UnityEngine;

public class TrackingTurns : MonoBehaviour
{
    public static TrackingTurns Instance;

    public Action _OnCardDropZone;

    public bool DisableInput = false; 

    public bool HasDrawnCard = false;

    public bool GuessCard = false;

    //this class will track what player/opponent can do.
    //and it will check if you have done it and you cant do it again etc. 

    //probarly best to just have an observer? like if player has drawn 1 card it cant do it again etc

    private void Awake()
    {
        _OnCardDropZone -= OnAddedToDropZone;
        _OnCardDropZone += OnAddedToDropZone;

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
        DisableInput = true;
    }

    public void OnHighlightEndTurn()
    {
        //will want to highlight end turn
    }


    public void PlayerCheck()
    {
        //if player has successfully put a card in dropzone 

        //if player has drawn  a "guess" card and fails

        //here i will check if player has done all they can do
        //so the only option left will be to click the end turn button
    }

    public void CheckCardsVSDropZone()
    {
        Debug.Log("CheckCardsVSdropzone method");

        if (Dropzone.Instance.cards.Count > 0)
       {

            var latestCard = Dropzone.Instance.cards[Dropzone.Instance.cards.Count - 1];

            foreach (var card in PlayerHand.instance.cards) //this is for playerhand
            {
                if (card._rank >= latestCard._rank)
                {
                    Debug.Log($"{card._suit} with rank {card._rank} can be put in cardzone");
                }
                else
                {
                    Debug.LogWarning("player cant put any card in dropzone");
                    //player can now end turn (and pick up the whole cardpile or do a guess draw)
                    DisableInput = true;
                }
            }
        }
    }

    public void OpponentCheck()
    {
        //same as above but with opponent
    }
}
