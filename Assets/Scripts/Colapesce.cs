using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Colapesce
{
    private static float acc;
    private static float timer;
    private const float offRoadSpeed = 7.2f;
    public const int massa = 2;
    public const float turnpower = 3;
    public const int hp = 85;

    
    public static float acceleration(float speed, bool isOffRoad)
    {
        if (!isOffRoad)
        {
            if (speed == 0 || speed == 2.5 || speed == 6.5 || speed == 7.5 || speed == 8 || speed == 8.5 || speed == 8.7 || speed == 9)
            {
                acc = 0;
            }
            if (speed < 2.5)
            {
                acc = 5;
            }
            if (speed > 2.5 && speed < 6.5)
            {
                acc = 8;
            }
            if (speed > 6.5 && speed < 7.5)
            {
                acc = 2;
            }
            if ((speed > 7.5 && speed < 8) || (speed > 8 && speed < 8.5))
            {
                acc = 0.5f;
            }
            if (speed > 8.5 && speed < 8.7)
            {
                acc = 0.4f;
            }
            if (speed > 8.7 && speed < 9)
            {
                acc = 0.6f;
            }

            if (acc != 0)
            {
                speed += acc * Time.deltaTime;
                timer = 0;
            }
            if (acc == 0 && ((speed == 2.5) || (speed == 6.5) || (speed == 7.5) || (speed == 8) || (speed == 8.5) || (speed == 8.7)))
            {
                timer += 1 * Time.deltaTime;
                if (timer == 0.5)
                    speed += 0.1f;
            }
        }
        else
        {
            if (speed == 0 || speed == 2.5 || speed == 6.5 || speed == offRoadSpeed)
            {
                acc = 0;
            }
            if (speed < 2.5)
            {
                acc = 4;
            }
            if (speed > 2.5 && speed < 6.5)
            {
                acc = 6.4f;
            }
            if (speed > 6.5 || speed < offRoadSpeed)
            {
                acc = 1.6f;
            }
            if (speed > offRoadSpeed)
            {
                acc = -6.4f;
            }

            if (acc != 0)
            {
                speed += acc * Time.deltaTime;
                timer = 0;
            }
            if (acc == 0 && ((speed == 2.5) || (speed == 6.5) || (speed == offRoadSpeed)))
            {
                timer += 1 * Time.deltaTime;
                if (timer == 0.5)
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
                speed -= 3 * Time.deltaTime;
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