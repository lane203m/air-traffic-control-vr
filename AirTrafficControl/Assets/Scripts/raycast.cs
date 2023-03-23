using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raycast : MonoBehaviour
{
    public GameObject[] planes;
    public LineRenderer lr;
    [Range(0.0f, 20.0f)]
    private RaycastHit hit;

    //[SerializeField] private string selectableTag = "Selectable";
    //[SerializeField] private Material highlightMaterial;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, LayerMask.GetMask("UI")))
        {
           /* var selection = hit.transform;
            var selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = highlightMaterial;
            }
            */
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, hit.point);
            lr.startColor = Color.blue;
            lr.endColor = Color.blue;
            //hit.collider.gameObject.GetComponent<Button>().Select(); //turns button red
            if (hit.collider.tag == "Selectable")
            {
                
            }
        }
        else
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, hit.point);
            lr.startColor = Color.grey;
            lr.endColor = Color.grey;


        }
        
    }
}
