using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CollisionEnter : MonoBehaviour
{
    GameObject Movement;
    [SerializeField] int crachdelay = 1;
    [SerializeField] int nextleveldelay = 2;
    [SerializeField] AudioClip dead;
    [SerializeField] AudioClip successs;
    AudioSource audd;
    [SerializeField] ParticleSystem successeffect;
    [SerializeField] ParticleSystem faileffect;
    bool isloading;
    bool collisiondisabled=false;
    void Start()
    {
        audd= GetComponent<AudioSource>();
        isloading= false;
    }
    void Update()
    {
        RespondToDebugKeys();
    }
    void RespondToDebugKeys() 
    { 
        if (Input.GetKeyDown(KeyCode.L)) 
        {
        NextLevel();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            collisiondisabled = !collisiondisabled;
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (isloading ) {
            return;
        }
        switch (collision.gameObject.tag)
        {
              case "Finish":
                Debug.Log("Finish");
                success();
                return;
                break;

            case "obstacle":
                Debug.Log("obstacle");
                if (collisiondisabled)
                {


                }
                else
                {
                crash();
                }
               
               
                break;
           
            case "Respawn":
                Debug.Log("Respawn");
                break;
        }
    }
    void success()
    { 
        successeffect.Play();
        audd.Stop();
        GetComponent<Movement>().enabled = false;
        if (isloading == false)
        {
             audd.PlayOneShot(successs);
        }
        isloading = true;
        Invoke("NextLevel", nextleveldelay);
    }
    void crash()
    {
        faileffect.Play();
        audd.Stop();
        GetComponent<Movement>().enabled=false;
        if (isloading == false)
        { 
        audd.PlayOneShot(dead);
        }
        isloading= true; 
        
        Invoke("ReloadLevel", crachdelay);
    }
   public void ReloadLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextlevel = currentSceneIndex + 1;
        if (nextlevel ==SceneManager.sceneCountInBuildSettings)
        {
            nextlevel = 0;
        }
        SceneManager.LoadScene(nextlevel);
    }
}
