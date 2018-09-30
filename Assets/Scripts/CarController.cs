using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CarController : MonoBehaviour
{

    public float speed;
    public float turnpower;
    public float Massa;
    public int PlID, Arma;
    bool IsSheepped;
    bool isOffRoad;
    private float timer, count;
    private float acc;
    Vector3 dir;

    // Use this for initialization
    void Start()
    {
        speed = 0;
        isOffRoad = false;
        switch (PlayerPrefs.GetInt("Carro" + PlID))
        {
            case 0:
                turnpower = Polifemo.turnpower;
                Massa = Polifemo.massa;
                break;

            case 1:
                turnpower = Archimede.turnpower;
                Massa = Archimede.massa;
                break;

            case 2:
                turnpower = Colapesce.turnpower;
                Massa = Colapesce.massa;
                break;
            case 3:
                turnpower = ScillaCariddi.turnpower;
                Massa = ScillaCariddi.massa;
                break;
        }
    }



    void FixedUpdate()
    {
        dir = Vector3.up;

        transform.Translate(dir * Time.deltaTime * speed);
        if (speed != 0)
        {
            if (Input.GetAxis("Turn" + PlID) == -1)
            {
                transform.Rotate(Vector3.forward * turnpower);
            }

            if (Input.GetAxis("Turn" + PlID) == 1)
            {
                transform.Rotate(Vector3.forward * -turnpower);
            }
        }
        if (Input.GetAxis("Accellerator" + PlID) > 0 && Input.GetAxis("Brake" + PlID) > 0)
        {
            if (speed > 0.2)
            {
                speed -= 1f * Time.deltaTime;
            }
            if (speed < -0.2)
            {
                speed += 1f * Time.deltaTime;
            }
            if (speed > -0.2 && speed < 0.2)
            {
                speed = 0;
            }
        }

        if (Input.GetAxis("Accellerator" + PlID) > 0 && Input.GetAxis("Brake" + PlID) == 0)
        {

            if (IsSheepped)
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    IsSheepped = false;
                }
            }
            else
            {
                switch (PlayerPrefs.GetInt("Carro" + PlID))
                {
                    case 0:
                        speed = Polifemo.acceleration(speed,isOffRoad);
                        break;

                    case 1:
                        speed = Archimede.acceleration(speed,isOffRoad);
                        break;

                    case 2:
                        speed = Colapesce.acceleration(speed,isOffRoad);
                        break;
                    case 3:
                        speed = ScillaCariddi.acceleration(speed,isOffRoad);
                        break;
                }

            }
        }


        //Moto Decelerato
        if (Input.GetAxis("Brake" + PlID) > 0)
        {
            if (IsSheepped)
            {
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    IsSheepped = false;
                }
            }
            else
            {
                switch (PlayerPrefs.GetInt("Carro" + PlID))
                {
                    case 0:
                        speed = Polifemo.deceleration(speed, isOffRoad);
                        break;

                    case 1:
                        speed = Archimede.deceleration(speed, isOffRoad);
                        break;

                    case 2:
                        speed = Colapesce.deceleration(speed, isOffRoad);
                        break;
                    case 3:
                        speed = ScillaCariddi.deceleration(speed, isOffRoad);
                        break;
                }
            }
        }



        //Moto inerziale
        if (Input.GetAxis("Accellerator" + PlID) < 0.5f && Input.GetAxis("Brake" + PlID) < 0.5f)
        {
            if (!isOffRoad)
            {
                if (speed > 0.2)
                {
                    speed -= 1f * Time.deltaTime;
                }
                if (speed < -0.2)
                {
                    speed += 1f * Time.deltaTime;
                }
                if (speed > -0.2 && speed < 0.2)
                {
                    speed = 0;
                }
            }
            else
            {
                if (speed > 0.2)
                {
                    speed -= 1.5f * Time.deltaTime;
                }
                if (speed < -0.2)
                {
                    speed += 1.5f * Time.deltaTime;
                }
                if (speed > -0.2 && speed < 0.2)
                {
                    speed = 0;
                }
            }
            
        }
    }


    void OnTriggerStay2D(Collider2D col)
    {
        if (!IsSheepped)
        {
            if (col.gameObject.tag == "fuoristrada")
            {
                isOffRoad = true;
            }
            if (col.gameObject.tag == "strada")
            {
                isOffRoad = false;
            }
        }
    }

    public void SheepStorm()
    {
        timer = count;
        IsSheepped = true;
    }

}






