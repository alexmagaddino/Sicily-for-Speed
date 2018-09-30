using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public int ID;
    public static int MaxID;

    static CheckPoint()
    {
        MaxID = 0;
    }
    
    // Use this for initialization
    void Start()
    {
        MaxID++;
    }
    
    public int showID()
    {
        return ID;
    }

    public int showMaxID()
    {
        return MaxID;
    }
}