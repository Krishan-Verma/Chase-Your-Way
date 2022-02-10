 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Mover : MonoBehaviour
{
    [SerializeField] float rotate=200f;

    public Rigidbody rb;
    public Swipe swipeControls;
    public AudioSource audiosrc;
    public AudioClip coin;
    public AudioClip gameOver;
    public ParticleSystem gameOverParticle;
    public TMP_Text cheatMsg;
  
    public Transform frontwheel1;
    public Transform frontwheel2;
    public Transform rarewheel1;
    public Transform rarewheel2;



    public float vspeed=2000;
    public float hspeed=1500;
    public float force=0;
    public bool cheat=false;
    private float initialy;

    void Start()
    {
        //initialy=transform.position.y;
        rb=GetComponent<Rigidbody>();
        audiosrc=GetComponent<AudioSource>();
        vspeed=PlayerPrefs.GetFloat("vspeed");
        hspeed=PlayerPrefs.GetFloat("hspeed");
        force=PlayerPrefs.GetFloat("force");
    }
    
    void FixedUpdate()
    {
        Move();
       // Jump();
        Rotate();
        Cheat();
       
    }

    public void Move()
    {
    
        float x,z;
       
        x=Input.GetAxis("Horizontal");
        z=1*Time.deltaTime*vspeed;
    
        if(swipeControls.SwipeLeft)
        x=-1;

        if(swipeControls.SwipeRight)
        x=1;   
    

        rb.velocity=new Vector3(x*Time.deltaTime*hspeed,0,z);

        RotateWheel();
       

    }


    public void RotateWheel()
    {    

        UpdateWheelPos( frontwheel1);
        UpdateWheelPos( frontwheel2);
        UpdateWheelPos( rarewheel1);
        UpdateWheelPos( rarewheel2);

    }


    public void UpdateWheelPos(Transform wtransform)
    {
        wtransform.Rotate(Vector3.right * Time.deltaTime * rotate);
       
       
    }

    public void Jump()
    {
        Vector3 impulse= new Vector3(0,force*Time.deltaTime,0);
        if(transform.position.y<initialy+2)
        {
            if(Input.GetKey(KeyCode.Space))
            {
             rb.AddForce(impulse,ForceMode.Impulse);
            }

            if(swipeControls.SwipeUp)
            {
             rb.AddForce(impulse,ForceMode.Impulse);
            }

        }

        if (transform.position.y > initialy)
        {
            transform.Translate(new Vector3(0, -0.05f, 0));
        }
    }

    public void Rotate()
    {
        rb.freezeRotation = true;
        if (Input.GetKey(KeyCode.F))
            transform.Rotate(Vector3.left * Time.deltaTime * rotate);

        else if (Input.GetKey(KeyCode.H))
            transform.Rotate(Vector3.right * Time.deltaTime * rotate);

        rb.freezeRotation = false;
    }


    private void OnCollisionEnter(Collision other)
    {
        
       if(other.gameObject.tag=="Coin")
       {
            audiosrc.Pause();
            audiosrc.PlayOneShot(coin);
       
       }

        float delay=3f;
        if(other.gameObject.tag=="Obstical")
        {   
            if(!cheat)
            {   other.gameObject.GetComponent<MeshRenderer>().material.color=Color.red;
                GetComponent<Mover>().enabled=false;
                audiosrc.Stop();
                audiosrc.PlayOneShot(gameOver);
                gameOverParticle.Play();
                Invoke("GameOver",delay);
                other.gameObject.GetComponent<Rigidbody>().useGravity=false;
            }
            else
            {
             other.gameObject.GetComponent<Rigidbody>().useGravity=true;
             other.gameObject.GetComponent<Rigidbody>().AddForce( new Vector3(0,15f,30f));
             
            }
        }

    }

    
    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void Cheat()
    {
        if(Input.GetKey(KeyCode.C))
        {
            cheat=true;
            cheatMsg.text="Cheat Enable";

        }

        if(Input.GetKey(KeyCode.N))
        {
            cheat=false;
           cheatMsg.text="Cheat Disable";
        }

        if(swipeControls.DoubleTap)
        {
            cheat=!cheat;

            if(cheat)
            {
              cheatMsg.text="Cheat Enable";
            }
            else
            {
              cheatMsg.text="Cheat Disable";
            }
        }
    }

}
