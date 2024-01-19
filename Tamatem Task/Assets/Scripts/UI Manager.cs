using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject RollButton;

    void Update()
    {
        if (DieManager.allowedToRoll == false&&  RollButton.activeInHierarchy==true)
        {
            RollButton.SetActive(false);                                                                        //we can cahnge the emlents color and scale based on the game states here ..
        }
        if (DieManager.allowedToRoll == true && RollButton.activeInHierarchy==false) 
        {
            RollButton.SetActive(true);
        }

    }
}
