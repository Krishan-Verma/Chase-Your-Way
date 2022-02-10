using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class finalScore : MonoBehaviour
{ 
    public TMP_Text final;
       
       private void Start() {

       final=GameObject.Find("finalScore").GetComponent<TMP_Text>();
       final.text=PlayerPrefs.GetString("score","0");
       }

  
}
