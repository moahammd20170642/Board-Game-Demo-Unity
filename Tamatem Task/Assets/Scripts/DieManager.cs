using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieManager : MonoBehaviour
{
   public  PlayerController PlayerController;

    public RandomApiManager randomApiManager;
    public List <Sprite> DieImages;      //It will be filled from the Addressable Manager  
    private SpriteRenderer rend;
    public Animator DiceAnimator;
   
    public static int  randomDiceSide;
    // Use this for initialization
    private void Start()
    {
        
        rend = GetComponent<SpriteRenderer>();
        rend.enabled = false;
        //rend.sprite = DieImages[0];
    }

    public void Roll()
    {
      
            StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        rend.enabled = false;
         randomDiceSide = 0;
        randomDiceSide = randomApiManager.GetCurrentRandomNumber();
        DiceAnimator.SetTrigger("Roll");
        yield return new WaitForSeconds(0.5f);
        rend.enabled=true;
        rend.sprite = DieImages[randomDiceSide-1];
        PlayerController.waypointIndex += randomDiceSide;
       
  


    }
}
