using System;
using DG.Tweening;
using UnityEngine;

public class HoverOverCard : MonoBehaviour
{
    private float MovehowMuch = 0.20f;
    private float newpos;
    private Vector3 help;
    private Vector3 _orgposCard;
    private bool _CardhasbeenMoved = false;
    private GameObject CardClicked;
    private GameObject _lasthovocard;
    
    //on mouse press, if cardFound, heldCardRef = cardFound
    // update, cardFound . position = mousePointer
    // on mouse press, if heldCardRef != null, drop card (or return card to somewhere)
    
    // on mouse pressed, cardPickedUp = true
    // if cPU == true, position = mousePointer //cPU = card pick up
    // if pressed while CPU true, cpu false
    // ScreenToWorldPosition
    
    private void OnMouseOver() //have this script on cards and this event will trigger when hover over with mouse/held down touch
    {
        
        Debug.Log(gameObject.name);
        if (_CardhasbeenMoved && _lasthovocard == gameObject)
        {
            return;
        }
        
        _lasthovocard = gameObject;
      
         _orgposCard = gameObject.transform.position;
    
        newpos = _orgposCard.y + MovehowMuch;
    
        help = new Vector3(_orgposCard.x,newpos,_orgposCard.z);
        
        gameObject.transform.DOMove(help, 0.1f);
        DOTween.Kill(gameObject);
        _CardhasbeenMoved = true;
    
     }

    private void OnMouseExit()
    {
        if (_CardhasbeenMoved && _lasthovocard == gameObject)
        {
            //make a tween here too
            _lasthovocard.transform.DOMove(_orgposCard, 0.1f);
            DOTween.Kill(gameObject);
            _CardhasbeenMoved = false;
        }
    }
}
