using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diceroll
{

    public static int[] Roll(int max, int n)
    {
            System.Random r = new System.Random();
        int[] resultarray = new int[10000];
        for (int i = 0; i < n; i++)
            {
                resultarray[i] = r.Next(max);
            }
            return resultarray;


    }
}
