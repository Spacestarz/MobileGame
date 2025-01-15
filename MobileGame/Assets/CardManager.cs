using UnityEngine;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;

public class CardManager : MonoBehaviour
{
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
