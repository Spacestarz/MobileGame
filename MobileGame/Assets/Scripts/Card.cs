using UnityEngine;
using UnityEngine.Serialization;
using System.Collections.Generic;
using static CardPile;

public class Card : MonoBehaviour 
{
    //just a thing
    //have singleton instead of a bunch of findobjectoftype

    public SuitEnum _suit { get; private set; }
    public RankEnum _rank { get; private set; }

    public GameObject _InstanceCard;

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

    
    public void Initialize(SuitEnum suit, RankEnum rank)
    {
        _suit = suit;
        _rank = rank;
    }


    #region laterVisuals
    //not needed right now work in behind the scenes
    //make so behind the scenes work then add visuals!


    //public GameObject CreateCardObject(SuitEnum _Suit, RankEnum _Rank)
    //{
    //    UnityEngine.Debug.Log("Make a card thing");

    //    switch (_Suit)
    //    {
    //        case SuitEnum.Hearts:
    //            return Instantiate(HeartsPreFab);
    //            break;

    //        case SuitEnum.Diamonds:
    //            return Instantiate(DiamondPrefab);
    //            break;

    //        case SuitEnum.Spades:
    //            return Instantiate(SpadePreFab);
    //            break;

    //        case SuitEnum.Clubs:
    //            return Instantiate(CloverPreFab);
    //            break;


    //        default:
    //            {

    //                return null;
    //            }
    //    }

    //}
    #endregion
}



