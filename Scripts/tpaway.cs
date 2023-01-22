using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpaway : MonoBehaviour
{
    float tp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tp = Random.Range(-8.0f, 8.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "fruit")
        {
           
            other.transform.position = transform.position + new Vector3(tp, 10f, 0f);
            
            
        }
    }

}
