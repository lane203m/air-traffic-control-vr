using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class changeColour : MonoBehaviour
{
    private bool contact;
    List<GameObject> collision;
    GameObject gameObject;
    //Material m = Resources.Load<Material>("oMaterial") as Material;
    //Material airportM = Resources.Load<Material>("SimpleAirport/_Materials/SimpleAirport.mat") as Material;
    public Material defaultMaterial;
    public Material highlightMaterial;
    //public bool select = false;
     
    



    void Start()
    {
        contact = false;
        collision = new List<GameObject>();
        defaultMaterial = gameObject.GetComponent<Renderer>().material;
        highlightMaterial = gameObject.GetComponent<Renderer>().material;


    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void OnTriggerEnter(Collider col) //touching object
    {
        contact = true;
        collision.Add(col.gameObject);
        if (col.gameObject.tag == "plane" && col.gameObject.GetComponent<destroyHandler>().destroyState == 0)
            col.gameObject.GetComponent<Renderer>().material = highlightMaterial;
        
    }

    
    void OnTriggerExit(Collider col) //no longer touching object
    {
        contact = false;
        collision.Remove(col.gameObject);
        if (col.gameObject.tag == "plane" && col.gameObject.GetComponent<destroyHandler>().destroyState == 0)
             col.gameObject.GetComponent<Renderer>().material = defaultMaterial;
        
        
       
    }
   

}
