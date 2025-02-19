using UnityEngine;
using UnityEngine.Serialization;
using System.Collections.Generic;
using static CardPile;
using TMPro;

public class Card : MonoBehaviour 
{
    public SuitEnum _suit { get; private set; }
    public RankEnum _rank { get; private set; }

    public GameObject _visualsUp;
    public GameObject _visualsDown;

    private SpriteRenderer _renderUp;
    private SpriteRenderer _renderDown;


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


    private void Awake()
    {
        _visualsUp = transform.Find("Visual Up").gameObject;
        _visualsDown = transform.Find("Visual Down").gameObject;

       _renderUp = _visualsUp.GetComponent<SpriteRenderer>();
       _renderDown = _visualsDown.GetComponent<SpriteRenderer>();

       _renderDown.sprite = MakeCards.Instance._backSprite;

        if (_visualsUp == null || _visualsDown == null)
        {
            Debug.Log("cant find visuals gameobject");
        }

        if (_renderUp == null || _renderDown == null)
        {
            Debug.Log("cant find sprite renderer");
        }

        _visualsUp.SetActive(false);
        _visualsDown.SetActive(true);
    }

    public void FlipCard() 
    {
       if(_visualsUp != null && _visualsDown != null)
       {
            bool isFaceup = _visualsUp.activeSelf;

            _visualsUp.SetActive(!isFaceup);
            _visualsDown.SetActive(isFaceup);

            TextMeshPro[] textComponents = GetComponentsInChildren<TextMeshPro>();

            foreach (var textMeshPro in textComponents)
            {
                textMeshPro.gameObject.SetActive(!isFaceup); //shows when face is up 
            }
          
        }
    }

    public void Initialize(SuitEnum suit, RankEnum rank)
    {
        this._suit = suit;
        this._rank = rank;

        _renderUp.sprite = GetSprite(this);

        GetComponent<CardInstance>().Init(this);
    }


    public Sprite GetSprite(Card card)
    {
        //Debug.Log("getting sprites");

        switch (card._suit)
        {
            case SuitEnum.Hearts:
                return MakeCards.Instance._HeartSprite;

            case SuitEnum.Diamonds:
                return MakeCards.Instance._DiamondSprite;

            case SuitEnum.Spades:
                return MakeCards.Instance._SpadeSprite;

            case SuitEnum.Clubs:
                return MakeCards.Instance._CloverSprite;


            default:
                {

                    return null;
                }
        }
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



