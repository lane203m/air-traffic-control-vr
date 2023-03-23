using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AirCollision : MonoBehaviour
{
    public GameObject[] objects;
    public AudioSource crashNoise;
    public AudioSource leaveNoise;
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
        if(other.GetComponent<Collider>().tag == "plane"){
            other.gameObject.GetComponent<destroyHandler>().destroyState = 1;
            other.gameObject.GetComponent<destroyHandler>().canBeDestroyed = 1;
            other.gameObject.GetComponent<destroyHandler>().isACrash = 1;
            other.gameObject.GetComponent<MeshRenderer>().material = brokenPlane;
            //other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            foreach(BoxCollider c in other.gameObject.GetComponents<BoxCollider>()) {
                c.enabled = false;
            }
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            other.gameObject.GetComponent<ParticleSystem>().Play();
            crashNoise.Play();
            gameObject.GetComponent<destroyHandler>().destroyState = 1;
            gameObject.GetComponent<destroyHandler>().canBeDestroyed = 1;
            gameObject.GetComponent<destroyHandler>().isACrash = 1;
            gameObject.GetComponent<MeshRenderer>().material = brokenPlane;
            //gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            foreach(BoxCollider c in gameObject.GetComponents<BoxCollider>()) {
                c.enabled = false;
            }
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<ParticleSystem>().Play();
            //Destroy(gameObject);

        }
    }

}
