using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    
    int points;
    TMP_Text pointaroonis;

    void Start()
    {
        pointaroonis = GetComponent<TMP_Text>();
        pointaroonis.text = "Pointaroonis: ";
    }

    public void IncreasePoints(int amountToIncrease)
    {
        points += amountToIncrease;
        pointaroonis.text = "Pointaroonis: " + points.ToString();
    }
}
