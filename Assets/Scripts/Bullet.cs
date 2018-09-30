using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float bulletSpeed, count, timer;

    void Start()
    {
        timer = count;
    }

	void Update () {
        timer -= Time.deltaTime;
        GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
        if(timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
