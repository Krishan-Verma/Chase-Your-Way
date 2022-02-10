using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    
       int score=0;
       public TMP_Text count;
       
       private void Start() {

       count=GameObject.Find("count").GetComponent<TMP_Text>();
         
       }
       private void OnCollisionEnter(Collision other) 
       {
         if(other.gameObject.tag=="Coin")
         {
            score+=10;
            //Debug.Log("Your Score : "+score);
            PlayerPrefs.SetString("score",score.ToString());
            count.text=PlayerPrefs.GetString("score");
            Destroy(other.gameObject);
           
         } 
        
       }
}
