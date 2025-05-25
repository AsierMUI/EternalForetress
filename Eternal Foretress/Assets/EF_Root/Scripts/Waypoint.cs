using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    public static Transform[] points;

    void Awakw ()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; 1 < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
