using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balista : MonoBehaviour {

    public Transform T,Spawn;
    public GameObject bullet;
    float timer;
    bool TA;
    public AudioSource S;
	
	// Update is called once per frame
    void Start()
    {
        timer = 2;
    }

	void Update () {
        if (TA)
        {
            float angle = 0;

            Vector3 relative = transform.InverseTransformPoint(T.position);
            angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
            transform.Rotate(0, 0, -angle);
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Instantiate(bullet, Spawn.position, transform.rotation);
                S.Play();
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag != "CassaMun" && col.gameObject.tag != "strada" && col.gameObject.tag != "fuoristrada" && col.gameObject.tag != "Check")
        {
            T = col.transform;
            TA = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        T = null;
        TA = false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.GetComponent<CarroManager>().Vita -= 5;
        Destroy(gameObject);
    }
}
