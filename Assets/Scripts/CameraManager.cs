using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour {
    public int ID;
    public Text TextOnScreen;
    private int CurrentLap;
    private int hp;
    Transform PlayerToFollow;
    public Image Macchia;
    public bool Macchiato;
    float timer = 5;
    private int Mun;

    void Start()
    {
        PlayerToFollow = GameObject.Find("Player" + ID).transform;
        PlayerToFollow.GetComponent<CarroManager>().Cam = gameObject;
    }

	void Update () {
        if(Macchiato)
        {
            Macchia.gameObject.SetActive(true);
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Macchia.gameObject.SetActive(false);
                timer = 5;
                Macchiato = false;
            }
        }
        transform.position = new Vector3(PlayerToFollow.position.x, PlayerToFollow.position.y, -10);
        /*transform.rotation = Quaternion.Euler(0, 0, PlayerToFollow.rotation.z);
        if (Input.GetAxis("Turn"+ID) == 1)
        {
            transform.position += Vector3.right;
        }
        else if(Input.GetAxis("Turn"+ID) == -1)
        {
            transform.position += Vector3.left;
        }*/

        CurrentLap = GameObject.Find("Player" + ID).GetComponent < CarroManager>().CurrentLap;
        hp = GameObject.Find("Player" + ID).GetComponent < CarroManager>().Vita;
        Mun = GameObject.Find("Player" + ID).GetComponent < BomberMan>().Mun;
        TextOnScreen.text = "Current lap: " + CurrentLap + "\n HP: " + hp + "\n Munizioni: " + Mun;

        //Macchia
        /*
        if(GameObject.Find("Player" + ID).GetComponent<CarroManager>().spotted)
        {
            gameObject.AddComponent<Image>() = new Image(Macchia );
            gameObject.GetComponent<Canvas>().GetComponent<Image>(). =
        }
        */
    }
}
