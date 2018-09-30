using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Macchia : MonoBehaviour {
    public float timer;

	void Update () {

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            gameObject.SetActive(false);
        }	
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Carro")
        {
            col.GetComponent<CarroManager>().CarroMacchiato();
        }
    }
}
