using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Archimede { 
    private static float acc;
    private static float timer;
    public const int massa = 1;
    private const float offRoadSpeed = 6.8f;
    public const float turnpower = 3;
    public const int hp = 70;


    public static float acceleration(float speed, bool isOffRoad)
    {
        if (!isOffRoad)
        {
            if (speed == 0 || speed == 3.5 || speed == 7.5 || speed == 8 || speed == 8.5)
            {
                acc = 0;
            }
            if (speed < 3.5)
            {
                acc = 7;
            }
            if (speed > 3.5 && speed < 7.5)
            {
                acc = 8;
            }
            if ((speed > 7.5 && speed < 8) || (speed > 8 && speed < 8.5))
            {
                acc = 1;
            }

            if (acc != 0)
            {
                speed += acc * Time.deltaTime;
                timer = 0;
            }
            if (acc == 0 && speed == 3.5)
            {
                timer += 1 * Time.deltaTime;
                if (timer == 0.5)
                    speed += 0.1f;
            }
            if (acc == 0 && (speed == 7.5 || speed == 8))
            {
                timer += 1 * Time.deltaTime;
                if (timer == 1)
                    speed += 0.1f;
            }
        }
        else
        {
            if (speed == 0 || speed == 3.5 || speed == offRoadSpeed)
            {
                acc = 0;
            }
            if (speed < 3.5)
            {
                acc = 5.6f;
            }
            if (speed > 3.5 && speed < offRoadSpeed)
            {
                acc = 6.4f;
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
            if (acc == 0 && speed == 3.5)
            {
                timer += 1 * Time.deltaTime;
                if (timer == 0.5)
                    speed += 0.1f;
            }
            if (acc == 0 && (speed == offRoadSpeed))
            {
                timer += 1 * Time.deltaTime;
                if (timer == 1)
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
                speed -= 2.89f * Time.deltaTime;
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
                speed -= 3.61f * Time.deltaTime;
            }
            else if (speed > -4)
            {
                speed -= Time.deltaTime;
            }
        }
        return speed;
    }
}