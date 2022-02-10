using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool swipeLeft,tap,swipeRight,swipeUp,swipeDown,doubleTap;
    private Vector2 startTouch,swipeDelta;
    private bool isDragging =false;
   
    private float firstClickTime;
    private int clickCount;
    private bool corutineAllowed;

    private void Start() {
        firstClickTime=0f;
        clickCount=0;
        corutineAllowed=true;
    }

    private void Update()
    {
        swipeLeft=tap=swipeRight=swipeUp=swipeDown=doubleTap=false;

     #region  standalone Input
        if(Input.GetMouseButtonDown(0))
        {

            tap=true;
            isDragging=true;
            startTouch=Input.mousePosition;
            clickCount+=1;
           
        }
        
         if(Input.GetMouseButtonUp(0))
        {
             
           
            isDragging=false;
            Reset();
        }
     #endregion   
        
     #region Mobile Input  
        if(Input.touchCount>0)
        {
            
            if(Input.touchCount==2)
            {
                doubleTap=true;
            }
            if(Input.touches[0].phase==TouchPhase.Began)
            {   
                tap=true;
                isDragging=true;
                startTouch=Input.touches[0].position;
               // clickCount+=1;  
                                
            }
            if(Input.touches[0].phase==TouchPhase.Ended||Input.touches[0].phase==TouchPhase.Canceled)
            {   
                       
                isDragging=false;
                Reset();
            }
        }
      #endregion  

        if(clickCount==1 && corutineAllowed)
        {
            firstClickTime=Time.time;
            StartCoroutine(DoubleTaps());
        }
    
        swipeDelta=Vector2.zero;
        if(isDragging)
        {
            if(Input.touches.Length>0)
            {
                swipeDelta=Input.touches[0].position-startTouch;
                
            }
            else if(Input.GetMouseButton(0))
            {
                swipeDelta=(Vector2)Input.mousePosition-startTouch;
            }

        }

        if(swipeDelta.magnitude>125)
        {
            float x=swipeDelta.x;
            float y=swipeDelta.y;

            if(Mathf.Abs(x)>Mathf.Abs(y))
            {
                if(x<0)
                    swipeLeft=true;
                else
                    swipeRight=true;
            }
            else
            {
                if(y<0)
                    swipeDown=true;
                else
                    swipeUp=true;
            }
        }
    }

    private IEnumerator DoubleTaps()
    {

        corutineAllowed=false;
        while (Time.time<firstClickTime+0.5f)
        {
            if(clickCount==2)
            {
                doubleTap=true;
                break;
            }
            yield return new WaitForEndOfFrame();
        }

        clickCount=0;
        firstClickTime=0f;
        corutineAllowed=true;

    }
    
     private void Reset()
    {
        startTouch=swipeDelta=Vector2.zero;
        isDragging=false;
                
    }


    public Vector2 SwipeDelta{get{return swipeDelta;}}
    public bool SwipeLeft {get{return swipeLeft;}}
    public bool SwipeRight {get{return swipeRight;}}
    public bool SwipeUp {get{return swipeUp;}}
    public bool SwipeDown {get{return swipeDown;}}
    public bool Tap {get{return tap;}}
    public bool DoubleTap {get{return doubleTap;}}
}
