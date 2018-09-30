using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CassaManager : MonoBehaviour {
    public float count, timer;
    bool IsCollided;
    
    void  Update()
    {
        if (IsCollided)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                IsCollided = false;
                GetComponent<BoxCollider2D>().enabled = true;
                GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    public void DistruggiCassa()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        IsCollided = true;
        timer = count;
        
    }
}
