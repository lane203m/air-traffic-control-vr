using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlaneCrash : MonoBehaviour
{
    public GameObject[] objects;
    public bool isGround = false;
    public Material brokenPlane; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "plane" && other.GetComponent<destroyHandler>().canBeDestroyed == 1){
            other.gameObject.GetComponent<destroyHandler>().destroyState = 1;
            other.gameObject.GetComponent<destroyHandler>().isACrash = 1;
            
            other.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            foreach(BoxCollider c in other.gameObject.GetComponents<BoxCollider>()) {
                c.enabled = false;
            }

            foreach( Transform child in other.gameObject.transform )
            {
                child.gameObject.SetActive(false);
            }
            if(isGround){
                other.gameObject.GetComponent<MeshRenderer>().material = brokenPlane;
                other.gameObject.GetComponent<ParticleSystem>().Play();
                other.gameObject.GetComponent<AirCollision>().crashNoise.Play();
                other.gameObject.GetComponent<Rigidbody>().useGravity = true;

            }
            else{
                other.gameObject.GetComponent<AirCollision>().leaveNoise.Play();
                other.gameObject.GetComponent<MeshRenderer>().enabled = false;
                for(int i = 0; i< this.objects.Length; i++){
                    int value = int.Parse(this.objects[i].GetComponent<Text>().text);
                    this.objects[i].GetComponent<Text>().text = (value-1).ToString();
                
                }
            }
        }else if(other.gameObject.tag == "planeTip"){
            GameObject parentObj = other.GetComponent<Transform>().parent.gameObject;

            other.gameObject.GetComponent<SphereCollider>().enabled = false;
            parentObj.GetComponent<destroyHandler>().destroyState = 1;
            parentObj.GetComponent<destroyHandler>().destroyState = 1;
            parentObj.GetComponent<destroyHandler>().isACrash = 1;
            parentObj.GetComponent<destroyHandler>().destroyOverride = 1;
            parentObj.GetComponent<CapsuleCollider>().enabled = false;
            foreach(BoxCollider c in parentObj.GetComponents<BoxCollider>()) {
                c.enabled = false;
            }
            if(isGround){
                
                parentObj.GetComponent<MeshRenderer>().material = brokenPlane;
                parentObj.GetComponent<AirCollision>().crashNoise.Play();
                parentObj.GetComponent<ParticleSystem>().Play();
                parentObj.GetComponent<Rigidbody>().useGravity = true;
            }
            else{
                parentObj.GetComponent<AirCollision>().leaveNoise.Play();
                parentObj.GetComponent<MeshRenderer>().enabled = false;
                for(int i = 0; i< this.objects.Length; i++){
                    int value = int.Parse(this.objects[i].GetComponent<Text>().text);
                    this.objects[i].GetComponent<Text>().text = (value-1).ToString();
                
                }
            }
        }
    }
}
