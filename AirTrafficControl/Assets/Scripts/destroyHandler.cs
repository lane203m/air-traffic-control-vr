using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class destroyHandler : MonoBehaviour
{

    public int destroyState;
    public AudioSource player;
    public AudioSource leavePlayer;
    public GameObject[] objects;
    public int canBeDestroyed = 1;
    public int isACrash = 0; 
    public int destroyOverride = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isPlaying){
            gameObject.GetComponent<LineRenderer>().enabled = false;
        }
        if(!leavePlayer.isPlaying && !player.isPlaying && destroyState == 1 && canBeDestroyed == 1){
            if(isACrash == 1){
                for(int i = 0; i< this.objects.Length; i++){
                    int value = int.Parse(this.objects[i].GetComponent<Text>().text);
                    this.objects[i].GetComponent<Text>().text = (value-3).ToString();
                }  
            }
            Destroy(gameObject);
        }
        else if(!leavePlayer.isPlaying && !player.isPlaying && destroyOverride == 1){

            if(isACrash == 1){
                for(int i = 0; i< this.objects.Length; i++){
                    int value = int.Parse(this.objects[i].GetComponent<Text>().text);
                    this.objects[i].GetComponent<Text>().text = (value-3).ToString();
                }                  
            }
            Destroy(gameObject);
        }
    }
}
