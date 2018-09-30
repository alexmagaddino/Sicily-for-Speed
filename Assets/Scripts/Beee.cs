using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beee : MonoBehaviour {

    public float sheepSpeed;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * sheepSpeed;
        Destroy(gameObject, 20);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Carro")
        {
            col.gameObject.GetComponent<CarController>().SheepStorm();
            Destroy(gameObject);
        }
        else if(col.gameObject.tag == "Sheep")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
