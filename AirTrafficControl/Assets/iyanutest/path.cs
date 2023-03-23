using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class path : MonoBehaviour
{



    LineRenderer lineRender;

    private List<Vector3> pionts = new List<Vector3>();

    public Action<IEnumerable<Vector3>> onnewpathcreat = delegate { };

    // Start is called before the first frame update


    private void Awake()
    {
        lineRender = GetComponent<LineRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
            pionts.Clear();


        if (Input.GetKey(KeyCode.Mouse0)) { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

				if (Distancetolastpiont(hit.point) > 1f) {


					pionts.Add(hit.point-transform.forward);

					lineRender.SetPositions(pionts.ToArray());

					lineRender.positionCount = pionts.Count-1;
                }


            }










        }else if (Input.GetKeyUp(KeyCode.Mouse0))
        {


            onnewpathcreat(pionts);
        }

		if(Input.GetKeyDown(KeyCode.Space)){
			LineFollower Sphere = Transform.FindObjectOfType<LineFollower> ();
			Sphere.lineToFollow = lineRender;
			Sphere.enabled = true;
		}
        
    }

    public float Distancetolastpiont(Vector3 pioint)
    {

        if (!pionts.Any())
            return Mathf.Infinity;
        return Vector3.Distance(pionts.Last(), pioint);


    }
}
