using UnityEngine;

public class InputManager : MonoBehaviour
{


    void Start()
    {
        
    }

    // private bool TryDrop(out gameObject)
    // returnerar true om den lyckas droppa den på grejen
    // gameObject.trygetcomponent<cardPile>().AddCard(heldCard.Card) eller något
    // if false, return to pickedUp location / hand


    void Update()
    {
        if (Input.GetMouseButton(0)) //when holding down left mouse button/touch
        {
            // tryClick

            try
            {

            }
            catch
            {
                Debug.Log("dident click antthing");
            }
            
        }

        if (Input.GetMouseButtonUp(0)) //when releasing the mouse
        {
            // trydrop
        }
    }
}
