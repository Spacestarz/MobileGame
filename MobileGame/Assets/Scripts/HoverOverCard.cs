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
         //todo make card go up a bit
        gameObject.transform.DOMove(help, 0.1f);
        _CardhasbeenMoved = true;
    
     }

    private void OnMouseExit()
    {
        if (_CardhasbeenMoved && _lasthovocard == gameObject)
        {
            _lasthovocard.transform.localPosition = _orgposCard;
            _CardhasbeenMoved = false;
        }
    }
}
