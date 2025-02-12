using UnityEngine;

public class SpawnLocations : MonoBehaviour
{
    public GameObject discardLocation;
    public GameObject dropzoneLocationForCards;
    public Vector3 startAPlayer;
    public Vector3 StartBPlayer;

    private CardInstance cardInstance;

    //got this in the playerhand script instead
    public void CardLocationPlayerHand()
    {
        if (PlayerHand.instance.cards.Count >0)
        {
            for (int i = 0; i < PlayerHand.instance.cards.Count; i++)
            {
               // cardInstance = PlayerHand.instance._PlayerHandcards[i].GetComponent<CardInstance>();
            }
        }

        var objectcount = PlayerHand.instance.cards.Count;

        var A = startAPlayer;
        var B = StartBPlayer;

        Vector3 direction = (B - A).normalized;
        float totalDistance = Vector3.Distance(A, B);
        float step = totalDistance / (PlayerHand.instance.cards.Count + 1);

        for (int i = 1; i <= PlayerHand.instance.cards.Count; i++)
        {
            Vector3 position = A + direction * step * i;

           // PlayerHand.instance._PlayerHandcards[i].transform.position = position;


        //from github from gamedev math:

            //void PlaceObjects(Vector3 A, Vector3 B, int objectCount, GameObject prefab)
            //{
            //    Vector3 direction = (B - A).normalized;
            //    float totalDistance = Vector3.Distance(A, B);
            //    float step = totalDistance / (objectCount + 1);

            //    for (int i = 1; i <= objectCount; i++)
            //    {
            //        Vector3 position = A + direction * step * i;
            //        Instantiate(prefab, position, Quaternion.identity);
            //    }
            //}

        }
    }
}
