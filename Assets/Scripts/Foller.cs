using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foller : MonoBehaviour
{
    Rigidbody rb;
    MeshRenderer mr;
    Vector3 position;
    GameObject player = null;

    // Start is called before the first frame update
    private void Awake()
    {
        position = GetComponentInParent<Transform>().localPosition;
        rb = GetComponentInParent<Rigidbody>();
        mr = GetComponentInParent<MeshRenderer>();

        rb.useGravity = false;
        mr.enabled = false;
    }

    void Start()
    {
        if (player == null)
            player = GameObject.Find("Player");
    }

   private void OnTriggerEnter(Collider other)
   {
      
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Detected");
            rb.useGravity = true;
            mr.enabled = true;
        }
    }



}

    //void Update()
    //{
    //   Fall();
             
    //}


    //public void Fall()
    //{
    //        float pz=Mathf.Abs(player.transform.position.z);
    //        float oz=Mathf.Abs(gameObject.transform.position.z);
    //        if(Mathf.Abs(oz-pz)<fallDiff)
    //        {     
    //         
             
    //        // transform.Translate(0,-0.1f,0);
            
    //        }
    //}

