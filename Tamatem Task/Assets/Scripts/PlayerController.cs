using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1f;

    public Vector3 target;
   
    public static int waypointIndex = 0;
   public  int nextwaypoint = 0;
    public bool moveAllowed = false;
    public bool playertapped=false ;
    // Use this for initialization
    private void Start()
    {
        nextwaypoint = 1;
        target = waypoints[nextwaypoint].transform.position;
        transform.position = waypoints[waypointIndex].transform.position;
    }


    private void Update()
    {
        if (nextwaypoint <= waypointIndex&&playertapped)
        {
            target = waypoints[nextwaypoint].transform.position;


            transform.position = Vector2.MoveTowards(transform.position,
             target,

            moveSpeed * Time.deltaTime);
            if(transform.position==target)
            {
                nextwaypoint++;
            }
        }
        }


        public  void   Move( )
    {
        int numOfsteps = DieManager.randomDiceSide;
         waypointIndex += numOfsteps;
      
       
            if (waypointIndex <= waypoints.Length - 1)
            {

               


            }
        }
        
    }


