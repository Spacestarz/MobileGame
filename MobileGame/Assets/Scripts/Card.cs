using UnityEngine;
using UnityEngine.Serialization;
using System.Collections.Generic;
using static CardPile;

public class Card : MonoBehaviour
{
    public int _Rank;
    public int _Suit;

    public GameObject _InstanceCard;

    //The Prefabs gameobjects
    public GameObject HeartsPreFab;
    public GameObject DiamondPrefab;
    public GameObject CloverPreFab;
    public GameObject SpadePreFab;

    private AllCardList _allCards;

    public enum SuitEnum //Here is the suits
    {
        Hearts = 1,
        Clubs = 2,
        Diamonds = 3,
        Spades = 4,
    }

    public enum RankEnum //here is the ranks
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

    // Constructor
    public Card(SuitEnum suit, RankEnum rank)
    {
        _Suit = (int)suit;  
        _Rank = (int)rank;  
    }

    void Start()
    {
        //makes the card
        //1-4 for the suit and then the rank 1-13 for each of the suits 

        //first for suit
        for (int s = 1; s <= 4; s++)
        {
            //second for ranks
            for (global::System.Int32 r = 1; r <= 13; r++)
            {
                SuitEnum _Suit = (SuitEnum)s;
                RankEnum _Rank = (RankEnum)r;
                //have done the whole deck now ggw

                //need to add these to the whole card deck now
                // Debug.Log($"this card with suit {_Suit} and rank {_Rank}");

                Card card = new Card(_Suit,_Rank);
                


                //CreateCardObject(_Suit, _Rank);
            }

            //TODO
            //now send the rank and suit to the cardpile and add it to the list!!!!

        }
    }

    void Update()
    {

    }


    //not needed right now work in behind the scenes
    //make so behind the scenes work then add visuals!
    public GameObject CreateCardObject(SuitEnum _Suit, RankEnum _Rank)
    {
        UnityEngine.Debug.Log("Make a card thing");

        switch (_Suit)
        {
            case SuitEnum.Hearts:
                return Instantiate(HeartsPreFab);
                break;

            case SuitEnum.Diamonds:
                return Instantiate(DiamondPrefab);
                break;

            case SuitEnum.Spades:
                return Instantiate(SpadePreFab);
                break;

            case SuitEnum.Clubs:
                return Instantiate(CloverPreFab);
                break;


            default:
                {

                    return null;
                }
        }

    }
}



