using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public new GameObject []gameObject;
    public Transform Ipos;    
    static GameObject instance;
    static GameObject previous;
    static GameObject current;
    private void OnTriggerExit(Collider other)
    {
        float x,y,z;   
                

        if(other.gameObject.tag=="Player")
        {   
          
            x=Ipos.position.x;
            y=Ipos.position.y;
            z=Ipos.position.z;
            Vector3 respawnpos= new Vector3(x,y,z+900);
            if(instance!=null)
            {
                //Debug.Log("Destroyed");
                previous=current;
                current=instance;
                Destroy(previous);  
            }

            instance = Instantiate(gameObject[Random.Range(0, 1)], respawnpos, Quaternion.identity); //,GameObject.Find("Canvas").transform);
         
        }


        
        
    }
}
