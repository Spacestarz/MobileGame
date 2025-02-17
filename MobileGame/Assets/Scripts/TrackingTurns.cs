using NUnit.Framework.Constraints;
using System;
using UnityEngine;

public class TrackingTurns : MonoBehaviour
{
    public static TrackingTurns Instance;


    public bool DisableInput = false;

    //this class will track what player/opponent can do.
    //and it will check if you have done it and you cant do it again etc. 

    //probarly best to just have an observer? like if player has drawn 1 card it cant do it again etc

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
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
