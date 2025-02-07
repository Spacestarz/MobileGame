using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public CardVisuals currentCardVisualScript;

    void Start()
    {
        
    }
    // tryClick
    // trydrop
    // private bool TryDrop(out gameObject)
    // returnerar true om den lyckas droppa den på grejen
    // gameObject.trygetcomponent<cardPile>().AddCard(heldCard.Card) eller något
    // if false, return to pickedUp location / hand


    void Update()
    {
        if (Input.GetMouseButton(0)) //when holding down left mouse button/touch
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousepos, Vector2.zero);

           if (hit.collider!= null && hit.collider.CompareTag("Card"))
           {
                if (currentCardVisualScript == null)
                {
                    Debug.Log("hit a card");
                    currentCardVisualScript = hit.collider.gameObject.GetComponentInChildren<CardVisuals>();
                }
                

                if (hit.collider.gameObject.GetComponentInChildren<CardVisuals>() == null)
                {
                    Debug.Log("cant find the cardvisual script");
                }

                currentCardVisualScript._followMouse = true; 
           }
           else
            {
                Debug.Log("no card here or currenviscript is not null");
            }

            
        }

        if (Input.GetMouseButtonUp(0)) //when releasing the mouse
        {
            if (currentCardVisualScript)
            {
                currentCardVisualScript._followMouse = false; //stop follow mouse
                currentCardVisualScript = null;
            }
            
        }
    }
}
