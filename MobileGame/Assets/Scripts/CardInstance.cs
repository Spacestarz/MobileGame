using System;
using TMPro;
using UnityEngine;
using static Card;
using DG.Tweening;

public class CardInstance : MonoBehaviour
{
    //this will be on every instance card and it will have their rank and suit.
    //its talking with inputmanager script

    //be EGO

    //will be able to see the rank and suit in the inspector
    public Card.RankEnum _Rank;
    public Card.SuitEnum _Suit;

    public Card Card;

    public Vector3 _orgPos;

    private Action<bool> _OnTextVisibilityChanged;

    private bool isTextEnabled = true;

    public void Init(Card card)
    {
       var cardscript = GetComponent<Card>();

         Card = card;
        _Suit = card._suit;
        _Rank = card._rank;

        TextMeshPro[] textComponents = GetComponentsInChildren<TextMeshPro>(true); //checking inactivated things

        foreach (var textMeshPro in textComponents)
        {
            textMeshPro.text = ((int)_Rank).ToString();
        }

        card.IsUp();
    }

    void Start()
    {
        _orgPos = transform.position;

        _OnTextVisibilityChanged -= OntextVisibilityChanges;
        _OnTextVisibilityChanged += OntextVisibilityChanges;
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

    public void SetTextVisability (bool enable)
    {
        if (isTextEnabled != enable)
        {
            Debug.Log("textenable is not the same as i want it...changing");

            isTextEnabled = enable;
            _OnTextVisibilityChanged?.Invoke(isTextEnabled);
        }
    }


    public void OntextVisibilityChanges(bool enable)
    {
        var textMesh = GetComponentsInChildren<TextMeshPro>(true);
        foreach (var textmeshpro in textMesh)
        {
            textmeshpro.enabled = enable;
        }
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

    
    public void Shake()
    {
        //Creates a sequence
        Sequence mySequence = DOTween.Sequence();

        //add this to sequence and then it starts the sequence
        mySequence.Append(Card.transform.DOShakePosition(0.3f, new Vector3(0.3f, 0, 0), 50, 0, false, true));  
        //this joins so they are doing their thing at the same time.
        mySequence.Join(Card.transform.DOShakeRotation(0.3f, new Vector3(0, 0, 1f), 10, 0, true)); 
       
    }
}
