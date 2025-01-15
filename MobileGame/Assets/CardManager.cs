using UnityEngine;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;
using JetBrains.Annotations;
using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

public class CardManager : MonoBehaviour //addid static becayse i cant shuffle if its not static
{
    private System.Random rng = new System.Random();
    [SerializeField]  int _howManyCards = 52;
    [SerializeField]  int _maxAmountCards = 52;

    public TextMeshProUGUI _cardCountText;

     private List<Card> allCardsList;

    //make an object pool with the cards? yes i think so i can just reuse cards  and have them in a discard pile maybe?

    void Start()
    {
        
        allCardsList = new List<Card>();

        //makes one card
        var card = new Card((Card.SuitEnum)1, 5);

        //time to make the whole deck thing. 
        //1-4 for the suit and then the rank 1-13 for each of the suits 

        //first for suit
        for (int s = 0; s <4; s++)
        {
            
            //second for ranks
            for (global::System.Int32 r = 0; r < 13; r++)
            {
                var wholedeck = new Card((Card.SuitEnum)s, r);

                allCardsList.Add(wholedeck);
                //made the whole "deck" now
            }
            
        }

        ShuffleCards(allCardsList);      
        
    }

    private void ShuffleCards<T>(this IList<T> list)
    {
        //this is the fisher yates shuffle from overstackflow
       int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T card = list[k];
            list[k] = list[n];
            list[n] = card;
        }
        Debug.Log("done shuffling");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            GoThroughDeck();
        }
        
    }

    private void GoThroughDeck()
    {
        foreach (var card in allCardsList)
        {
            Debug.Log($"Card: {card}, Suit: {card._suit}, Rank: {card._rank}");
        }
    }
}
