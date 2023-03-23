using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class VRPen : MonoBehaviour
{
     

    public LineRenderer currentLineRender;
    private Vector3 prevPointDistance;
    private int positionCount = 1; // 2 by default
    public int lineState = 0;
    public int start = 0;
    private GameObject selectedPlane;
    public Material lineMat;  
    void Awake(){
        //newLineRenderer();
        //lineState = 0;
    } 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(start == 1){
            OVRInput.Update();
            if(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5){
                if(lineState == 0){
                    newLineRenderer();
                    lineState = 1;
                    selectedPlane.GetComponent<LineFollower2>().completed = false;
                    selectedPlane.GetComponent<LineFollower2>().isOriginal = false;
                    selectedPlane.GetComponent<Rigidbody>().useGravity = false;
                    selectedPlane.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    selectedPlane.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; 
                    Debug.Log("test");
                }
                else if(lineState == 1){
                    updateLine();
                    //lineState = 2;
                }
                
            }else if(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) <= 0.5f){
                start = 0;
                if(lineState == 0){

                }
                else{
                    lineState = 0;
                    
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="plane"){
            //OVRInput.Update();
            //if(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5){
            start = 1;
            selectedPlane = other.gameObject;
                
            //}else if(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) <= 0.5f){
            //    start = 0;
            //}
        }
    }
    private void OnTriggerStay(Collider other){
        if(other.tag=="plane"){
            //OVRInput.Update();
            //if(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5){
            start = 1;
            //selectedPlane = other.gameObject;
                
            //}else if(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) <= 0.5f){
            //    start = 0;
            //}
        }
    }


    void newLineRenderer()
        {
            positionCount = 0;
            gameObject.AddComponent<LineRenderer>();
            LineRenderer lineRenderer = selectedPlane.GetComponent<LineRenderer>();
            lineRenderer.startWidth = 5f;
            lineRenderer.endWidth = 5f;
            lineRenderer.useWorldSpace = true;
            lineRenderer.material = lineMat;
            lineRenderer.material.SetColor("_Color", Color.red);
            lineRenderer.sharedMaterial.SetColor("_Color", Color.red);
            lineRenderer.sharedMaterial.SetColor("_Color", Color.red);
            //lineRenderer.material.mainTextureScale = new Vector2(1.67f,1.67f);
            lineRenderer.SetColors(Color.red, Color.red);
            lineRenderer.positionCount = 1;
            lineRenderer.numCapVertices = 90;
            lineRenderer.SetPosition(0, gameObject.transform.position);
            lineRenderer.numCornerVertices = 90;
            lineRenderer.textureMode =  LineTextureMode.Tile;
            //lineRenderer.material.SetTextureScale("_MainTex", new Vector2(0.5f, 0.5f));
            // send position
            //TCPControllerClient.Instance.AddNewLine(gameObject.transform.position);

            currentLineRender = lineRenderer;
            //lines.Add(lineRenderer);
        }

    void updateLine(){
            if(prevPointDistance == null)
            {
                prevPointDistance = gameObject.transform.position;
            }

            if(prevPointDistance != null && Mathf.Abs(Vector3.Distance(prevPointDistance, gameObject.transform.position)) >= 10f)
            {
                Vector3 dir = (gameObject.transform.position - Camera.main.transform.position).normalized;
                prevPointDistance = gameObject.transform.position;
                AddPoint(prevPointDistance, dir);
            }
    }

    void AddPoint(Vector3 position, Vector3 direction)
        {
            currentLineRender.SetPosition(positionCount, position);
            positionCount++;
            currentLineRender.positionCount = positionCount + 1;
            currentLineRender.SetPosition(positionCount, position);
            
            // send position
            //TCPControllerClient.Instance.UpdateLine(position);
    }
}
