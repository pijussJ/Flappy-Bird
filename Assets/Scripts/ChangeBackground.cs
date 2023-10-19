using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{

    public GameObject DayBackground;
    public GameObject NightBackground;
    private void Start()
    {
        RandomizeBackground();
    }
    void RandomizeBackground()
    {
        int randomIndex = Random.Range(1, 3);
        switch (randomIndex)
        {
            case 1:
               DayBackground.SetActive(true);
               break;
            case 2:
               NightBackground.SetActive(true);
               break;
        }

    }
}
