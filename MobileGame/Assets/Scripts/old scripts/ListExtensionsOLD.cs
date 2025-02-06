//using System.Collections.Generic;
//using UnityEngine;

//namespace ListsExtensionsOLDSCRIPT
//{
//    public static class ListExtensions
//    {
//        //this works yay
//        public static void ShuffleCards<T>(this IList<T> list)
//        {
//            System.Random rng = new System.Random();

//            //this is the fisher yates shuffle from stackoverflow
//            int n = list.Count;
//            while (n > 1)
//            {
//                n--;
//                int k = rng.Next(n + 1);
//                T card = list[k];
//                list[k] = list[n];
//                list[n] = card;
//            }
//            Debug.Log("done shuffling");
//        }
//    }
//}
