using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class landingStatus : MonoBehaviour
{
    public bool passed1;
    public bool passed2;
    public bool passed3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        gameObject.GetComponent<destroyHandler>().canBeDestroyed = 0;
        if(other.tag == "landingCheckpoint"){
          passed1 = true;  
        }
        else if(other.tag == "landingCheckpoint2" && passed1 == true){
          passed2 = true;
        }
        else if(other.tag == "landingCheckpoint3" && passed2 == true){
          passed3 = true;
        }else if(passed1 == false && passed2 == false && passed3 == false){
          gameObject.GetComponent<destroyHandler>().canBeDestroyed = 1;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "landingCheckpoint"){
          passed1 = false;  
        }
        else if(other.tag == "landingCheckpoint2"){
          passed2 = false;
        }
        else if(other.tag == "landingCheckpoint3"){
          passed3 = false;
        }
        if(passed1 == false && passed2 == false && passed3 == false){
            gameObject.GetComponent<destroyHandler>().canBeDestroyed = 1; 
        }
    }
}
