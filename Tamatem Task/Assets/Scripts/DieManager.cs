using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieManager : MonoBehaviour
{
    public RandomApiManager randomApiManager;
    private Sprite[] diceSides;
    private SpriteRenderer rend;
  
   

    // Use this for initialization
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
    }

    private void OnMouseDown()
    {
      
            StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
       
             int randomDiceSide = 0;
       
            randomDiceSide = randomApiManager.GetCurrentRandomNumber();
            rend.sprite = diceSides[randomDiceSide-1];
            yield return new WaitForSeconds(0.05f);
        

     
    }
}
