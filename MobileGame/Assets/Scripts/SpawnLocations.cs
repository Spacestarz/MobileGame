using UnityEngine;

public class SpawnLocations : MonoBehaviour
{
    public GameObject discardLocation;
    public GameObject dropzoneLocationForCards;
    public Vector3 startAPlayer;
    public Vector3 StartBPlayer;

    private CardInstance cardInstance;

    public void CardLocationPlayerHand()
    {
        if (PlayerHand.instance._PlayerHandcards.Count >0)
        {
            for (int i = 0; i < PlayerHand.instance._PlayerHandcards.Count; i++)
            {
               // cardInstance = PlayerHand.instance._PlayerHandcards[i].GetComponent<CardInstance>();
            }
        }

        var objectcount = PlayerHand.instance._PlayerHandcards.Count;

        var A = startAPlayer;
        var B = StartBPlayer;

        Vector3 direction = (B - A).normalized;
        float totalDistance = Vector3.Distance(A, B);
        float step = totalDistance / (PlayerHand.instance._PlayerHandcards.Count + 1);

        for (int i = 1; i <= PlayerHand.instance._PlayerHandcards.Count; i++)
        {
            Vector3 position = A + direction * step * i;

            //PlayerHand.instance._PlayerHandcards[i].transform.position = position;


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
