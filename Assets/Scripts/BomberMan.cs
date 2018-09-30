using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberMan : MonoBehaviour {
    public GameObject bullet, Sheep, Balista, Fango, Macchia;
    public Transform Spawn,Bomber,CrossAir;
    public AudioClip[] Suoni;
    public AudioSource Source;
    int PlID,ArmaID;
    public int Mun;
    public float count, timer;


    void Start()
    {
        PlID = GetComponent<CarController>().PlID;
        ArmaID = GetComponent<CarController>().Arma;
        Source = Bomber.GetComponent<AudioSource>();
    }

    void FixedUpdate () {
        timer -= Time.deltaTime;
        CrossAir.position = new Vector3(transform.position.x + (Input.GetAxis("Turret" + PlID))*2, transform.position.y  -(Input.GetAxis("Turret" +PlID + "-2"))*2);
        if (Input.GetButton("Shoot" + PlID))
        {
            Shoot();    
        }
             
        float angle = 0;

        Vector3 relative = Bomber.InverseTransformPoint(CrossAir.position);
        angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
        Bomber.Rotate(0, 0, -angle);
    }

    void Shoot()
    {
        if (timer < 0)
        {
            if (Mun > 0)
            {
                switch (ArmaID)
                {
                    case 0:
                        Instantiate(bullet, Spawn.position, Bomber.rotation);
                        Source.clip = Suoni[0];
                        break;
                    case 1:
                        Instantiate(Sheep, CrossAir.position, Bomber.rotation);
                        Source.clip = Suoni[1];
                        break;
                    case 2:
                        Instantiate(Balista, CrossAir.position, Bomber.rotation);
                        Source.clip = Suoni[2];
                        break;
                    case 3:
                        Instantiate(Fango, transform.position - Vector3.down , Quaternion.identity);
                        Source.clip = Suoni[3];
                        break;
                    case 4:
                        Macchia.GetComponent<Macchia>().timer = 2;
                        Macchia.SetActive(true);
                        Source.clip = Suoni[4];
                        break;
                }
                timer = count;
                Mun--;
                Source.Play();
            }
        }
    }
}
