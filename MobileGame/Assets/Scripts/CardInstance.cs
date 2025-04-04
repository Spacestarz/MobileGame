using System;
using TMPro;
using UnityEngine;
using static Card;
using DG.Tweening;
using Unity.VisualScripting;

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

    private void Awake()
    {
        _OnTextVisibilityChanged -= OntextVisibilityChanges;
        _OnTextVisibilityChanged += OntextVisibilityChanges;
    }


    void Start()
    {
        _orgPos = transform.position;
        //Debug.Log($"suit {_Suit} with rank {_Rank} in the CARDINSTANCE CLASS");
    }
  
    public void SetTextVisability (bool IsVisible)
    {
        //Debug.Log($"settextvisability enable is {IsVisible}");

        TextMeshPro[] textComponents = GetComponentsInChildren<TextMeshPro>(true); //checking inactivated things

        foreach (var textMeshPro in textComponents)
        {
            textMeshPro.enabled = IsVisible;
            //Debug.Log($"textmesho shall be {IsVisible} this should show 2 times for 2 textmesh up and down.");
            textMeshPro.sortingOrder = 2;
        }
    }


    public void OntextVisibilityChanges(bool IsVisible)
    {
        Debug.Log("HJNAEHGOL");

        var textMesh = GetComponentsInChildren<TextMeshPro>(true);
        Debug.LogWarning($"have {textMesh.Length} Texts");

        foreach (var textmeshpro in textMesh)
        {
            textmeshpro.enabled = IsVisible;
            textmeshpro.sortingOrder = 2;
        }
    }

    public void GoBackOrgPos()
    {
        transform.position = _orgPos;
       // Debug.Log("going back orgpos");
    }

    public void UpdateOrgPos(Vector3 newOrgPos)
    {
        _orgPos = newOrgPos;
    }

    public void GoToDropZonePosition()
    {
        transform.position = SpawnLocations.instance.dropzoneLocationForCards.transform.position;
        Debug.Log("Card should now be in dropzonePOS");
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
        DG.Tweening.Sequence mySequence = DOTween.Sequence();

        //add this to sequence and then it starts the sequence
        mySequence.Append(Card.transform.DOShakePosition(0.3f, new Vector3(0.3f, 0, 0), 50, 0, false, true));  
        //this joins so they are doing their thing at the same time.
        mySequence.Join(Card.transform.DOShakeRotation(0.3f, new Vector3(0, 0, 1f), 10, 0, true)); 
       
    }
}
