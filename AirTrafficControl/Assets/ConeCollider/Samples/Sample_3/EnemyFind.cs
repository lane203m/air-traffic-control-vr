using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyFind : MonoBehaviour {
    
    private Text exclamation;
    public GameObject[] objects;
    public GameObject[] colliders;
    public AudioSource scoreSound;
    private int iterator;

    void Awake()
    {
        exclamation = this.transform.Find("ExCanvas/ExclamationText").GetComponent<Text>();
        //this.objects = GameObject.FindGameObjectsWithTag("ScoreUI");
        iterator = 0;
    }

    // Use this for initialization
    void Start () {
	for(int i = 0; i<this.objects.Length; i++){
            this.objects[i].GetComponent<Text>().text = this.iterator.ToString();
            this.objects[i].GetComponent<Text>().enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        iterator = int.Parse(this.objects[0].GetComponent<Text>().text);
        if(other.GetComponent<Collider>().tag == "plane" && other.GetComponent<landingStatus>().passed3 == true){
            iterator++;
            iterator++;
            exclamation.enabled = true;
            scoreSound.Play();
            for(int i = 0; i< this.objects.Length; i++){
                this.objects[i].GetComponent<Text>().text = this.iterator.ToString();
                
                
            }
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        exclamation.enabled = false;
        //for(int i = 0; i<4; i++){
        //    this.objects[i].GetComponent<Text>().enabled = true;
        //}
    }
}
