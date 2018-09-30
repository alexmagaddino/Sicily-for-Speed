using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Polifemo
{
    private static float acc;
    private static float timer;
    private const float offRoadSpeed = 8;
    public const int massa = 4;
    public const float turnpower = 3;
    public const int hp = 100;

 
    public static float acceleration(float speed, bool isOffRoad)
    {
        if (!isOffRoad)
        {
            if (speed == 0 || speed == 3 || speed == 6 || speed == 8 || speed == 9 || speed == 9.5 || speed == 10)
            {
                acc = 0;
            }
            if ((speed < 3) || (speed > 3 && speed < 6))
            {
                acc = 6;
            }
            if (speed > 6 && speed < 8)
            {
                acc = 4;
            }
            if ((speed > 8 && speed < 9) || (speed > 9 && speed < 9.5) || (speed > 9.5 && speed < 10))
            {
                acc = 2;
            }

            if (acc != 0)
            {
                speed += acc * Time.deltaTime;
                timer = 0;
            }
            if (acc == 0 && speed == 3)
            {
                timer += 1 * Time.deltaTime;
                if (timer == 1)
                    speed += 0.1f;
            }
            if (acc == 0 && (speed == 6 || speed == 8 || speed == 9 || speed == 9.5))
            {
                timer += 1 * Time.deltaTime;
                if (timer == 1.5)
                    speed += 0.1f;
            }
        }
        else
        {
            if (speed == 0 || speed == 3 || speed == 6 || speed == offRoadSpeed)
            {
                acc = 0;
            }
            if (speed < 3)
            {
                acc = 4.8f;
            }
            if (speed > 3 && speed < 6)
            {
                acc = 3.2f;
            }
            if (speed > 6 || speed < offRoadSpeed)
            {
                acc = 3.2f;
            }
            if (speed > offRoadSpeed)
            {
                acc = -4.8f;
            }

            if (acc != 0)
            {
                speed += acc * Time.deltaTime;
                timer = 0;
            }
            if (acc == 0 && speed == 3)
            {
                timer += 1 * Time.deltaTime;
                if (timer == 1)
                    speed += 0.1f;
            }
            if (acc == 0 && (speed == 6 || speed == offRoadSpeed))
            {
                timer += 1 * Time.deltaTime;
                if (timer == 1.5)
                    speed += 0.1f;
            }


        }
        return speed;
    }
  


    public static float deceleration(float speed, bool isOffRoad)
    {
        if (!isOffRoad)
        {
            if (speed > 0)
            {
                speed -= 2.82f * Time.deltaTime;
            }
            else if (speed > -5)
            {
                speed -= 1.5f * Time.deltaTime;
            }
        }
        else
        {
            if (speed > 0)
            {
                speed -= 3.52f * Time.deltaTime;
            }
            else if (speed > -4)
            {
                speed -= Time.deltaTime;
            }

        }
        return speed;
    }
}