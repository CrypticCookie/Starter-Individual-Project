using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitMovement : MonoBehaviour
{

    public float speed;
    float tp;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Stop), 12f);
    }

    // Update is called once per frame
    void Update()
    {
        //tp = Random.Range(-8.0f, 8.0f);
        Invoke(nameof(Movement), 2f);
        
    }

    void Movement()
    {
        transform.Translate(Vector2.down * speed);
    }

    void Stop()
    {
        speed = 0;
    }
}

   /* private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "ground")
        {
            this.transform.position = transform.position + new Vector3(tp, 6f, 0f);

        }
    }
   */
//}
