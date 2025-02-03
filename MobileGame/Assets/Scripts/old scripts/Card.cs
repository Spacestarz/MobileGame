using UnityEngine;

public class Card 
{
    public enum SuitEnum
    {
        Hearts = 1,
        Clubs = 2,
        Diamonds = 3,
        Spades = 4,
    }
    
    public SuitEnum _suit; //suit of card
    public int _rank; //rank of card
   // private GameObject _Card; //the card itself, get how it will look depending on the rank and suit


    public Card (SuitEnum suit , int rank) //a constructor
    {
        _suit = suit;
        _rank = rank;
    }
}
