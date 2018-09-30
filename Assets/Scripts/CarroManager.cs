using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarroManager : MonoBehaviour
{
    int PlayID,Arma;
    public int Vita,M;
    public int lastCheckPoint;
    public int CurrentLap;
    private int damage;
    public GameObject Cam;

    void Start()
    {
        PlayID = GetComponent<CarController>().PlID;
        Arma = GetComponent<CarController>().Arma;
        lastCheckPoint = 0;
        CurrentLap = 0;

        switch (PlayerPrefs.GetInt("Carro" + PlayID))
        {
            case 0:
                Vita = Polifemo.hp;
                break;

            case 1:
                Vita = Archimede.hp;
                break;

            case 2:
                Vita = Colapesce.hp;
                break;
            case 3:
                Vita = ScillaCariddi.hp;
                break;
        }
    }

    void Update()
    {
        if (Vita <= 0)
        {
            GameObject.Find("Pista").GetComponent<GameManager>().PlCount--;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Carro")
        {
            damage = 10; //inizializzazione danno a danno base
            //variazione danno in base alle velocità
            if (Mathf.Abs(gameObject.GetComponent<CarController>().speed) > Mathf.Abs(col.gameObject.GetComponent<CarController>().speed))
            {
                damage -= 2;
            }
            if (Mathf.Abs(gameObject.GetComponent<CarController>().speed) < Mathf.Abs(col.gameObject.GetComponent<CarController>().speed))
            {
                damage += 2;
            }
            //variazione danno in base alle masse
            if (gameObject.GetComponent<CarController>().Massa > col.gameObject.GetComponent<CarController>().Massa)
            {
                damage -= 5;
            }
            if (gameObject.GetComponent<CarController>().Massa < col.gameObject.GetComponent<CarController>().Massa)
            {
                damage += 5;
            }

            //variazione danno in base al punto di contatto

            Vector3 contactPoint = col.contacts[0].point;
            Vector3 localContactPoint = gameObject.transform.InverseTransformPoint(contactPoint);

            if (localContactPoint.y > 0)
            {
                damage = damage * 2;
            }
            if (localContactPoint.y < -1)
            {
                damage = damage / 2;
            }

            Vita -= damage;
        }
        else if (col.gameObject.tag == "CassaMun")
        {
            switch(Arma)
            {
                case 0:
                    M = 10;
                    break;
                case 1:
                    M = 5;
                    break;
                case 2:
                    M = 2;
                    break;
                case 3:
                    M = 3;
                    break;
                case 4:
                    M = 1;
                    break;
            }
            col.gameObject.GetComponent<CassaManager>().DistruggiCassa();
            GetComponent<BomberMan>().Mun += M;
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bullet") 
        {
            Vita -= 5;
            Destroy(col.gameObject);
        }

        //collision against the check point
        if (col.gameObject.tag == "Check")
        {
            if (lastCheckPoint == col.gameObject.GetComponent<CheckPoint>().showID() - 1)
            {
                lastCheckPoint++;
                if (lastCheckPoint == col.gameObject.GetComponent<CheckPoint>().showMaxID())
                {
                    lastCheckPoint = 0;
                }
                if (col.gameObject.GetComponent<CheckPoint>().showID() == 1)
                {
                    CurrentLap++;
                }
            }
        }
    }

    public void CarroMacchiato()
    {
        Cam.GetComponent<CameraManager>().Macchiato = true;
    }
}
