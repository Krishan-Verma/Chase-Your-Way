using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ChangeScene : MonoBehaviour
{
    public Slider vspeed;
    public Slider hspeed;
    public Slider force;



    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }
    private void Start() {

        vspeed.value=PlayerPrefs.GetFloat("vspeed");
        hspeed.value=PlayerPrefs.GetFloat("hspeed");
        force.value=PlayerPrefs.GetFloat("force");
    }
    public void ChangeScenes(int sceneNo)
    {
        SceneManager.LoadScene(sceneNo);
    }
 
    public void AdjustVSpeed(float speed)
    {
       PlayerPrefs.SetFloat("vspeed",speed);
    }
    
    public void AdjustHSpeed(float speed)
    {
        PlayerPrefs.SetFloat("hspeed",speed);
    }

    public void AdjustJSpeed(float speed)
    {
       PlayerPrefs.SetFloat("force",speed);
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
