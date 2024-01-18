using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieManager : MonoBehaviour
{
   public  PlayerController PlayerController;

    public RandomApiManager randomApiManager;
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    public Animator DiceAnimator;
   
    public static int  randomDiceSide;
    // Use this for initialization
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.enabled = false;
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
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
        rend.sprite = diceSides[randomDiceSide-1];
         Debug.Log(""+ randomDiceSide);
        PlayerController.waypointIndex += randomDiceSide;
        Debug.Log("" + PlayerController.waypointIndex);
        //yield return new WaitForSeconds(0.05f);
        //PlayerController.allow();


    }
}
