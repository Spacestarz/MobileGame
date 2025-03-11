using UnityEngine;
using UnityEngine.Serialization;
using System.Collections.Generic;
using static CardPile;
using TMPro;

public class Card : MonoBehaviour
{
    public SuitEnum _suit { get; private set; }
    public RankEnum _rank { get; private set; }

    [SerializeField] private GameObject _visualsUp;
    [SerializeField] private GameObject _visualsDown;

    private SpriteRenderer _renderUp;
    private SpriteRenderer _renderDown;


    private bool _isUp = false;

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

        TextMeshPro[] textComponents = GetComponentsInChildren<TextMeshPro>();

        foreach (var textMeshPro in textComponents)
        {
           textMeshPro.gameObject.SetActive(false); //no textmesh
        }

    }

    public void FlipCard() 
    {
        if (_visualsUp != null && _visualsDown != null)
        {
            _isUp = !_isUp;

            bool seIfActive = !_visualsUp.activeSelf;

            _visualsUp.SetActive(seIfActive);
            _visualsDown.SetActive(!seIfActive);

            _isUp = seIfActive;


            if (_isUp)
            {
                _visualsDown.SetActive(false);
                _visualsUp.SetActive(true);
            }

            if (!_isUp)
            {
                _visualsUp.SetActive(false) ;
                _visualsDown.SetActive(true);
            }

            TextMeshPro[] textComponents = GetComponentsInChildren<TextMeshPro>(true); //when having true it checks inactive object too

            //Debug.Log("textcomponent lenghts is " + " " + textComponents.Length); 

            foreach (var textMeshPro in textComponents)
            {
                textMeshPro.gameObject.SetActive(_isUp);
                textMeshPro.sortingOrder = 2;
            }

            ChangeSortingOrder();
        }
    }

    public bool IsUp()
    {
        _isUp = _visualsUp.activeSelf;
       // Debug.Log("is up bool is " + " " + _isUp);
        return _isUp;
       
    }

    public void Initialize(SuitEnum suit, RankEnum rank)
    {
        this._suit = suit;
        this._rank = rank;

        _renderUp.sprite = GetSprite(this);

        GetComponent<CardInstance>().Init(this);
    }

    public void ChangeSortingOrder()
    {
        //make so faceup is above the renderdown the sorting order. 

        if (_isUp == true)
        {
            _renderUp.sortingOrder = 1;
            Debug.Log("sortingorder of this card is now 1");
        }
        else
        {
            _renderDown.sortingOrder = 0;
            Debug.Log("sortingorder of this card is now 0");
        }
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



