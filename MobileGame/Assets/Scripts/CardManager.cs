using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System;
using ListsExtensions;
using System.Linq;
using UnityEngine.Events;

public class CardManager : MonoBehaviour
{
    [SerializeField]  int _howManyCards = 52;
    [SerializeField]  int _maxAmountCards = 52;
    private distributeCards _distributeCards;

    public TextMeshProUGUI _cardCountText;
    public TextMeshProUGUI _DiscardPileCountText;

    public List<Card> allCardsList;

    public List <Card> DiscardList;

    //make an object pool with the cards? yes i think so i can just reuse cards and have them in a discard pile maybe?

    void Start()
    {
        _distributeCards = GetComponent<distributeCards>();
        allCardsList = new List<Card>();
        DiscardList = new List<Card>();

        //makes one card
        var card = new Card((Card.SuitEnum)1, 5);

        //time to make the whole deck thing. 
        //1-4 for the suit and then the rank 1-13 for each of the suits 

        //first for suit
        for (int s = 1; s <=4; s++)
        {
            //second for ranks
            for (global::System.Int32 r = 1; r <= 13; r++)
            {
                var wholedeck = new Card((Card.SuitEnum)s, r);

                allCardsList.Add(wholedeck);
                //made the whole "deck" now
            }
        }
        Spin();
        _distributeCards.GetStartCards();
        #region debug code
        /*
        int heartCount = allCardsList.Count(card => card._suit == Card.SuitEnum.Hearts); //check how many heart cards in the cardpile
        Debug.Log($"the cardpile have {heartCount}" + " " + "heart" + " " + "cards");

        int diamondCount = allCardsList.Count(card => card._suit == Card.SuitEnum.Diamonds); //check how many diamond cards in the cardpile
        Debug.Log($"the cardpile have {diamondCount}" + " " + "diamond" + " " + "cards");

        int spadeCount = allCardsList.Count(card => card._suit == Card.SuitEnum.Spades); //check how many spade cards in the cardpile
        Debug.Log($"the cardpile have {spadeCount}" + " " + "spade" + " " + "cards");

        int cloverCount = allCardsList.Count(card => card._suit == Card.SuitEnum.Clubs); //check how many clubs cards in the cardpile
        Debug.Log($"the cardpile have {cloverCount}" + " " + "clover" + " " + "cards");

        */
        #endregion
    }

    void Update()
    {
        _cardCountText.text = allCardsList.Count.ToString() + "  " + "cards left"; //want an observer instead of being in update!!

        _DiscardPileCountText.text = DiscardList.Count.ToString() + "  " + " cards  " + "in discard pile";
        /*
        if (Input.GetKeyDown(KeyCode.F))
        {
            GoThroughDeck();
        }
        */


        if (Input.GetKeyDown(KeyCode.W))
        {
            checkDiscardList();
        }
    }

    private void checkDiscardList()
    {
        foreach (var card in DiscardList)
        {
            Debug.Log($" Suit: {card._suit}, Rank: {card._rank}");
        }
    }

    private void GoThroughDeck()
    {
        foreach (var card in allCardsList)
        {
            Debug.Log($" Suit: {card._suit}, Rank: {card._rank}");
        }
    }

    private void Spin()
    {
        allCardsList.ShuffleCards();
    }
}
