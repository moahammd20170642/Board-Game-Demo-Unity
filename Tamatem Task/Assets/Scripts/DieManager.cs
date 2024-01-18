using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;
public class DieManager : MonoBehaviour
{
    public SpriteRenderer AnimatedDie;
    public  PlayerController PlayerController;
    public RandomApiManager randomApiManager;
    public List <Sprite> DieImages;              //It will be filled from the Addressable Manager  
    private SpriteRenderer Die;
    public Animator DiceAnimator;
  
    public static int  randomDiceSide;
    // Use this for initialization
    private void Start()
    {
        AnimatedDie.enabled=false;
        Die = GetComponent<SpriteRenderer>();
        Die.enabled = false;
     
    }

    public void Roll()
    {
      
            StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
           Die.enabled = false;
           randomDiceSide = randomApiManager.GetCurrentRandomNumber();

      if (randomDiceSide != -1)                // if the Api request succeed 
        {
            AnimatedDie.enabled = true; //// Eanble  animated die when roll button is pressed 
            DiceAnimator.SetTrigger("Roll");
            yield return new WaitForSeconds(0.5f);
            AnimatedDie.enabled = false;

            Die.enabled = true;                                // enable the actual die with the randomied image 
            Die.sprite = DieImages[randomDiceSide - 1];           // the images list first index is 0 ;
            PlayerController.waypointIndex += randomDiceSide;   //updating the waypoint index for the player (chip)   



        }
    }
}
