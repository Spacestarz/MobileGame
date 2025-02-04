using UnityEngine;

public class Card : MonoBehaviour
{
    private int _Rank;
    private int _Suit;
    
    public enum SuitEnum //Here is the suits
    {
        Hearts = 1,
        Clubs = 2,
        Diamonds = 3,
        Spades = 4,
    }

    public enum RankEnum
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
    }
    
    void Start()
    {
        //makes the card
        //time to make the whole deck thing. 
        
        //1-4 for the suit and then the rank 1-13 for each of the suits 

        //first for suit
        for (int s = 1; s <=4; s++)
        {
            //second for ranks
            for (global::System.Int32 r = 1; r <= 13; r++)
            {
               // Card newCard = ((SuitEnum)s, (RankEnum)r);

                //made the whole "deck" now
            }
        }
    }

    void Update()
    {
        
    }
    
    
}
