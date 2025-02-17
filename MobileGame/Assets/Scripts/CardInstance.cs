using TMPro;
using UnityEngine;

public class CardInstance : MonoBehaviour
{
    //this will be on every instance card and it will have their rank and suit.
    //its talking with inputmanager script

    //be EGO

    //will be able to see the rank and suit in the inspector
    public Card.RankEnum _Rank;
    public Card.SuitEnum _Suit;

    public Card Card;


    //took these from cardvisual this should handle the things
    public Vector3 _orgPos;

    public void Init(Card card)
    {
        Card = card;
        _Suit = card._suit;
        _Rank = card._rank;

        TextMeshPro[] textComponents = GetComponentsInChildren<TextMeshPro>();

        foreach (var textMeshPro in textComponents)
        {
            textMeshPro.text = ((int)_Rank).ToString();
        }


    }
    void Start()
    {
        _orgPos = transform.position;
        //Debug.Log($"suit {_Suit} with rank {_Rank} in the CARDINSTANCE CLASS");
    }

    void Update()
    {
        //BE AWARE THIS CHANGE EVERY FREAKING CARD 

        //if (InputManager.Instance._followMouse == true)
        //{
        //    Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    transform.position = mousepos;
        //}

        ////when holding down left mouse button/touch
        //if (Input.GetMouseButton(0)) 
        //{
        //    Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //    RaycastHit2D hit = Physics2D.Raycast(mousepos, Vector2.zero);

        //    if (hit.collider != null && hit.collider.CompareTag("Card") && InputManager.Instance._currentCardHeld == null)
        //    {
        //        Debug.Log("I hit card");
        //        InputManager.Instance._followMouse = true;
        //        InputManager.Instance._currentCardHeld = hit.collider.gameObject;
        //    }
        //    else
        //    {
        //        Debug.Log("no card here");
        //    }

        //    //when releasing the mouse
        //    if (Input.GetMouseButtonUp(0)) 
        //    {
        //        InputManager.Instance._followMouse = false;
        //        GoBackOrgPos();

        //       // Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //        RaycastHit2D CheckIfDropZoneCollider = Physics2D.Raycast(mousepos, Vector2.zero, 100f, LayerMask.GetMask("dropZoneLayer"));

        //        if (CheckIfDropZoneCollider != false)
        //        {
        //            //will check now if the card can be played
        //            Dropzone.Instance.CanIGoInDropZone(Card); //get the card gameobject
        //        }
        //        else
        //        {
        //            Debug.Log("no dropzone here");
        //        }

        //       //bla bla stop followmouse
        //    }

        //}



    }

    public void GoBackOrgPos()
    {
        transform.position = _orgPos;
       // Debug.Log("going back orgpos");
    }

    public void GoToDropZonePosition()
    {
        transform.position = SpawnLocations.instance.dropzoneLocationForCards.transform.position;
        Debug.Log("Card should now be in dropzone");
    }

    public void GoToDiscardLocation()
    {
        transform.position = SpawnLocations.instance.discardLocation.transform.position;
    }

    public Card GetCardData()
    {
        return Card;
    }
}
