using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform[] PlSpawn;
    public GameObject[] PlCar, CamOptions;
    public GameObject Player1, Player2, Player3, Player4;
    public int PlCount;
    public string[] Nick;


    void Start()
    {
        Nick[0] = PlayerPrefs.GetString("Player1");
        Nick[1] = PlayerPrefs.GetString("Player2");
        Nick[2] = PlayerPrefs.GetString("Player3");
        Nick[3] = PlayerPrefs.GetString("Player4");

        PlCount = PlayerPrefs.GetInt("PlayerCounter");
        switch(PlCount)
        {
            case 2:
                CamOptions[0].SetActive(true);
                CamOptions[1].SetActive(false);
                CamOptions[2].SetActive(false);
                Player1 = Instantiate(PlCar[PlayerPrefs.GetInt("Carro1")], PlSpawn[0].position, Quaternion.identity);
                Player1.name = "Player1";
                Player1.transform.FindChild("Nick").GetComponent<TextMesh>().text = Nick[0];
                Player1.GetComponent<CarController>().PlID = 1;
                Player2 = Instantiate(PlCar[PlayerPrefs.GetInt("Carro2")], PlSpawn[1].position, Quaternion.identity);
                Player2.name = "Player2";
                Player2.transform.FindChild("Nick").GetComponent<TextMesh>().text = Nick[1];
                Player2.GetComponent<CarController>().PlID = 2;
                break;
            case 3:
                CamOptions[0].SetActive(false);
                CamOptions[1].SetActive(true);
                CamOptions[2].SetActive(false);
                Player1 = Instantiate(PlCar[PlayerPrefs.GetInt("Carro1")], PlSpawn[0].position, Quaternion.identity);
                Player1.name = "Player1";
                Player1.transform.FindChild("Nick").GetComponent<TextMesh>().text = Nick[0];
                Player1.GetComponent<CarController>().PlID = 1;
                Player2 = Instantiate(PlCar[PlayerPrefs.GetInt("Carro2")], PlSpawn[1].position, Quaternion.identity);
                Player2.name = "Player2";
                Player2.transform.FindChild("Nick").GetComponent<TextMesh>().text = Nick[1];
                Player2.GetComponent<CarController>().PlID = 2;
                Player3 = Instantiate(PlCar[PlayerPrefs.GetInt("Carro3")], PlSpawn[2].position, Quaternion.identity);
                Player3.name = "Player3";
                Player3.transform.FindChild("Nick").GetComponent<TextMesh>().text = Nick[2];
                Player3.GetComponent<CarController>().PlID = 3;
                break;
            case 4:
                CamOptions[0].SetActive(false);
                CamOptions[1].SetActive(false);
                CamOptions[2].SetActive(true);
                Player1 = Instantiate(PlCar[PlayerPrefs.GetInt("Carro1")], PlSpawn[0].position, Quaternion.identity);
                Player1.name = "Player1";
                Player1.transform.FindChild("Nick").GetComponent<TextMesh>().text = Nick[0];
                Player1.GetComponent<CarController>().PlID = 1;
                Player2 = Instantiate(PlCar[PlayerPrefs.GetInt("Carro2")], PlSpawn[1].position, Quaternion.identity);
                Player2.name = "Player2";
                Player2.transform.FindChild("Nick").GetComponent<TextMesh>().text = Nick[1];
                Player2.GetComponent<CarController>().PlID = 2;
                Player3 = Instantiate(PlCar[PlayerPrefs.GetInt("Carro3")], PlSpawn[2].position, Quaternion.identity);
                Player3.name = "Player3";
                Player3.transform.FindChild("Nick").GetComponent<TextMesh>().text = Nick[2];
                Player3.GetComponent<CarController>().PlID = 3;
                Player4 = Instantiate(PlCar[PlayerPrefs.GetInt("Carro4")], PlSpawn[3].position, Quaternion.identity);
                Player4.name = "Player4";
                Player4.transform.FindChild("Nick").GetComponent<TextMesh>().text = Nick[3];
                Player4.GetComponent<CarController>().PlID = 4;
                break;
        }		
	}

    void Update()
    {
         if(PlCount == 1)
        {
            Application.LoadLevel("Menu");
        }
    }
}
