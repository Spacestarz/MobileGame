using System.Collections.Generic;
using System;
using UnityEngine;

namespace Listsextensions
{
    public static class listextensions
    {
        public static void shufflecards<t>(this IList<t> list)
        {
            System.Random rng = new System.Random();

            //this is the fisher yates shuffle from stackoverflow
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                t card = list[k];
                list[k] = list[n];
                list[n] = card;
            }
            //Debug.Log("done shuffling");
        }
    }
}