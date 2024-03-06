using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsgen : MonoBehaviour
{
    public GameObject obstacle;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = new Vector3(Random.Range(-0, 1),0,Random.Range(0, 3));
        Instantiate(obstacle,position,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
