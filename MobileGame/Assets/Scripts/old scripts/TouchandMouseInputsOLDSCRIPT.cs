//using UnityEngine;
//using DG.Tweening;
//using System;
//using Unity.VisualScripting;
//using NUnit.Framework.Internal;

//public class TouchandMouseInputsOLDSCRIPT : MonoBehaviour
//{
//    //will test mouseinput and touch here
//    // watched a yt thing https://www.youtube.com/watch?v=aTtheFyh7Ac


//    //TODO
//    //make so player can drag the card to drop zone


//    private Vector2 _orgScaleCard;
//    private Vector2 _zoomScaleCard;

//    private GameObject _currentZoomInCard;

//    [SerializeField] private float _zoomScale = 0.5f;
//    [SerializeField] private float _zoomDuration = 2f;

//    public bool zoomedInCard;

//    public bool FollowMouse;

//    public GameObject _clickedCard;
//    private Vector3 _clickedCardPosition;
//   // public Vector2 _orgCardPosition;

//    private HoverOverCardOLDSCRIPT _HoverOverCardScript;

//    public DropZoneOLDSCRIPT _dropzoneScript;
//    public Collider2D _dropzoneCollider;

//    public HoverOverCardOLDSCRIPT _hoverOverCard; //test
//    public Vector3 _OrgPosFromHoverScript; //test location
   


//    void Start()
//    {
        
//    }

//    void Update()
//    {

//        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
//        {
//            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[0].position);

//            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero);

//            if (hit.collider != null)
//            {
//                //Debug.Log($"touched object {hit.collider.name}");
//            }
//        }


////#if UNITY_EDITOR //if you are in the unity editor. Cool thing i am learning yay
//        if (Input.GetMouseButtonUp(0)) //changing so it will check when releasing 
//        {
//            //TODO
//            //do a raycast and check on just the layer for an example dropzone layer
//            //if there jiho go to droplist list.

//            if (_clickedCard != null)
//            {
//                //checking here if player click while over the dropzone locations
//                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//                RaycastHit2D CheckIfDropZoneCollider = Physics2D.Raycast(mousePos, Vector2.zero, 100f, LayerMask.GetMask("dropZoneLayer"));

//                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

//                if (CheckIfDropZoneCollider.collider != null)
//                {
//                   // Debug.Log($"you hit {hit.collider.name}");
//                    var CardData = _clickedCard.GetComponent<CardScriptOLDSCRIPT>();

//                    CardOldScript cardInfo = CardData.GetCardData();

//                    if (cardInfo._rank == 10)
//                    {
//                        Debug.Log("returning you are a 10 byee");
//                        _clickedCard.transform.position = _OrgPosFromHoverScript;
//                        return;
//                    }
//                    else
//                    {
//                        Debug.Log("not a 10 continue");
//                        //Debug.Log("this should be something" + CardData.GetCardData());
//                        _dropzoneScript.PutCardInDropZone(CardData.GetCardData(), _clickedCard.gameObject);
//                    }

//                }

//                if (CheckIfDropZoneCollider.collider == null)
//                {
//                    _clickedCard.transform.position = _OrgPosFromHoverScript;
//                    FollowMouse = false;
//                    _clickedCard = null;
//                    Debug.Log("RETURNING");

//                }
//                else
//                {
//                    //Debug.Log("nothing where you clicked with collides thing");
//                }

//            }

//                #region badzoom

//                // //make clickedcard another color
//                // HighlightCard(clickedCard);
//                //
//                // if (_currentZoomInCard == clickedCard)
//                // {
//                //     var sprite = clickedCard.GetComponent<SpriteRenderer>();
//                //     sprite.color = Color.white;
//                //     zoomBack(currentCardTransform);
//                // }
//                // else
//                // {
//                //     if (_currentZoomInCard != null)
//                //     {
//                //         var sprite = _currentZoomInCard.GetComponent<SpriteRenderer>();
//                //         sprite.color= Color.white;
//                //         zoomBack(_currentZoomInCard.transform);
//                //     }
//                //
//                //     Debug.Log($"zooming in on {clickedCard}");
//                //     ZoomIn(clickedCard);
//                // }

//                #endregion

//                #region comments
//                // 1. Spara isZOomedIn p� kortet i sig, n�r du klickar, if(iZoomedin) zoomOut()

//                // 2. Spara h�r(?) currentlyZoomedInCard n�r man zoomar in p� ett kort
//                // sedan n�r man klickar p� ett nytt kort, if (cardClicked == currentlyZooemdinCard) zoomOut, else
//                // current.. Zoom out, then  zoomInNewCard & currentlyZoomedInCard = newCard

//                // 3. OnMouseEnter // OnMouseExit/Leave

//                //start nerifran and up 

//                //EVENT?/observer if you click on collider do this?
//                //HAVE TO MAKE A LIMIt also
//                //make so the card dont go out of bound of the screen so it adapts to screen!(do math)

//                //also make so that card that zooms gets put above the other cards
//                #endregion

//        }


//        if (Input.GetMouseButton(0) && FollowMouse == false) //if holding down left click button. //need to make so its only checking if clickedcard is null and follows mouse.
//        {
//            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//            RaycastHit2D checkIfdropzone = Physics2D.Raycast(mousePos, Vector2.zero, 100f, LayerMask.GetMask("dropZoneLayer"));

//            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

//            if (hit.collider != null && checkIfdropzone.collider == null)
//            {
//                Debug.Log($"you touch/click {hit.collider.name}");
                
//                //get the Card thing TODO need to make script on cards with their data for suit and rank so i can get it. //this is done

//                _clickedCard = hit.collider.gameObject;
//                _hoverOverCard = _clickedCard.GetComponent<HoverOverCardOLDSCRIPT>();
//                _OrgPosFromHoverScript = _hoverOverCard._orgposCard; //gets the cards original position
//            }
//            else
//            {
//                Debug.Log("you hit nothing");
//            }

//            if (_clickedCard != null)
//            {
//                Debug.Log("following mouse");
//                _clickedCard.transform.position = mousePos;
//                FollowMouse = true;
//            }
//        }

//        if (FollowMouse)
//        {
//            //Debug.Log("please follow please");
//            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//            _clickedCard.transform.position = mousePos;
//        }
      
//    }
//}
////#endif
    



//    #region badzoom
//    // private void HighlightCard(GameObject CurrentCard)
//    // {
//    //   var sprite =  CurrentCard.GetComponent<SpriteRenderer>();
//    //
//    //     sprite.color = Color.blue;
//    //     //Debug.Log($"changed color on sprite to {sprite.color}");
//    // }
//    //
//    // private void ZoomIn(GameObject card)
//    // {
//    //     _orgScaleCard = card.transform.localScale;
//    //     card.transform.DOScale(_orgScaleCard * _zoomScale, _zoomDuration);
//    //     _currentZoomInCard = card;
//    //
//    //     zoomedInCard = true;
//    // }
//    //
//    // private void zoomBack(Transform card)
//    // {
//    //     card.localScale = _orgScaleCard;
//    //     zoomedInCard = false;
//    //     _currentZoomInCard = null;
//    // }
//    #endregion
    

