using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModelList : MonoBehaviour
{
    public GameObject[] ModelsToScroll;

    [Header(" !! UYARI !! ")]
    [Header(" Array Buyuklugu (toplam model sayisi - 1) olmak zorunda yoksa fazla ileriye gider")]
    [Tooltip(" Eger sag gitsin istiyorsaniz - ile eger sola gitsin istiyorsaniz + ile baslamali sayilar")]
    public int[] differentScrollDistanceForEachModel;

    public float movementAmount = 0;

    private void Start()
    {
        print(Scroll.count);
    }
}

public static class Scroll
{
    public static int count = 1;
}