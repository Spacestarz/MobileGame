using UnityEngine;
using UnityEngine.Serialization;
using System.Collections.Generic;
using static CardPile;
using TMPro;
using Unity.VisualScripting;

public class Card : MonoBehaviour
{
    public SuitEnum _suit { get; private set; }
    public RankEnum _rank { get; private set; }

    [SerializeField] private GameObject _visualsUp;
    [SerializeField] private GameObject _visualsDown;

    public SpriteRenderer _renderUp;
    public SpriteRenderer _renderDown;

    [SerializeField] private GameObject _number;
    [SerializeField] private GameObject _numberDown;

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

    }

    private void Start()
    {
        //makes those that have textmeshgameobject active
        if (!_number.activeSelf)
        {
            _number.SetActive(true);
            _numberDown.SetActive(true);
        }
     
    }

    public void SetCardFaceUp(bool faceup) 
    {
        TextMeshPro[] textComponents = GetComponentsInChildren<TextMeshPro>(true);
        var instanceRef = this.GetComponent<CardInstance>();
        Debug.Log("flipcard method card row 84");
        //Debug.Log("textcomponent lenghts is " + " " + textComponents.Length);

        _isUp = faceup;


        if (_visualsUp != null && _visualsDown != null )
        {
            _visualsUp.SetActive(faceup);
            _visualsDown.SetActive(!faceup);
        }

        instanceRef.SetTextVisability(faceup);

        ChangeSortingOrder();
        
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

        if (Dropzone.Instance._IsTakingAChance == true)
        {

            // Check which sprite is active using your _isUp flag.
            if (_isUp)
            {
                // The up sprite is active. Toggle its sorting order.
                if (_renderUp.sortingOrder == 1)
                {
                    _renderUp.sortingOrder = 0;
                }
                else
                {
                    _renderUp.sortingOrder = 1;
                }
                Debug.Log("Toggled sorting order for _renderUp to " + _renderUp.sortingOrder);
            }
            else
            {
                // The down sprite is active. Toggle its sorting order.
                if (_renderDown.sortingOrder == 0)
                {
                    _renderDown.sortingOrder = 1;
                }
                else
                {
                    _renderDown.sortingOrder = 0;
                }
                Debug.Log("Toggled sorting order for _renderDown to " + _renderDown.sortingOrder);
            }
            return;
        }

        //if takingachance is not true do the normal thing

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
}



