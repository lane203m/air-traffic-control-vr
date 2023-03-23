using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int radius;
    public float spawnTime;
    public GameObject plane;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPlane", 2.0f, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlane()
    {
        var random = Random.Range(1,255);
        var radians = 2 * Mathf.PI / random * Random.Range(1,random);
         
         /* Get the vector direction */ 
        var vertical = Mathf.Sin(radians);
        var horizontal = Mathf.Cos(radians); 
        var randomHeight = Random.Range(50,255);
        var spawnDir = gameObject.GetComponent<Transform>().position + radius * new Vector3 (horizontal, 0, vertical);
        spawnDir = spawnDir + new Vector3(0,randomHeight,0);
        var endDir = gameObject.GetComponent<Transform>().position + radius * new Vector3 (-horizontal, 0, -vertical);
        endDir = endDir + new Vector3(0, randomHeight, 0);
        GameObject instance = Instantiate(plane);
        instance.GetComponent<Transform>().position = spawnDir;
        //instance.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Transform>().position * 20;
        instance.GetComponent<LineRenderer>().SetPosition(0, instance.GetComponent<Transform>().position);
        instance.GetComponent<LineRenderer>().SetPosition(1, endDir);
        instance.GetComponent<LineFollower2>().speed = 25;
        //instance.GetComponent<LineRenderer>().SetPosition(2, -instance.GetComponent<Transform>().position);
        audio.Play();
    }
}
