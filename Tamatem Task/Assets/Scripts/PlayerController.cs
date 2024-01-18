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
    public int nextwaypoint = 0;
    public bool moveAllowed = false;
    public bool playertapped = false;
    // Use this for initialization
    private void Start()
    {
        ResetPlayerPosition();            
    }

    public void ResetPlayerPosition()  ///Asigned On Reset Button 
    {

        waypointIndex = 0;
        nextwaypoint = 1;
        transform.position = waypoints[waypointIndex].transform.position;   /////Start position 
        target = waypoints[nextwaypoint].transform.position;

    }
    public void TapPlayer()
    {
        playertapped = true;
        Debug.Log("playerTapped");
    }
    private void Update()
    {
        Move();
        checkIfPlayerTapped();

    }


    public void checkIfPlayerTapped()
    {
        // Check for touch or mouse input
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector3 touchPosition;

            // Check if it's a touch or mouse click
            if (Input.touchCount > 0)
            {
                // Use touch position for mobile
                touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            }
            else
            {
                // Use mouse position for other platforms
                touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            // Check if the touch/click is on the player
            if (GetComponent<Collider2D>().OverlapPoint(touchPosition))
            {

                TapPlayer();


            }
        }


    }

    public void Move()
    {
        if (nextwaypoint <= waypointIndex && playertapped)
        {
            target = waypoints[nextwaypoint].transform.position;
            transform.position = Vector2.MoveTowards(transform.position,
             target,

            moveSpeed * Time.deltaTime);                                        // why coded this way ?.. the player must move on the board by all waypoint on the way without crossing  
            if (transform.position == target)                                                       
            {
                nextwaypoint++;

            }

        }
        else
        {
            playertapped = false;
        }

    }

}
