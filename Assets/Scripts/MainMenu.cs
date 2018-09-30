using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Text PlayerCTxt;
    public InputField[] PlayerNames;
    public GameObject[] MenuSect;


    void Start()
    {
        PlayerCTxt.text = "Players: " + PlayerPrefs.GetInt("PlayerCounter");
        PlayerNames[0].text = PlayerPrefs.GetString("Player1");
        PlayerNames[1].text = PlayerPrefs.GetString("Player2");
        PlayerNames[2].text = PlayerPrefs.GetString("Player3");
        PlayerNames[3].text = PlayerPrefs.GetString("Player4");
    }

	public void OnPlayClick()
    {
        if (PlayerPrefs.GetInt("PlayerCounter") != 2 && PlayerPrefs.GetInt("PlayerCounter") != 3 && PlayerPrefs.GetInt("PlayerCounter") != 4)
        {
            PlayerPrefs.SetInt("PlayerCounter", 2);
        }
        else
        {
            //if(PlayerNames[0].text != " " || PlayerNames[0].text != null)
              //  PlayerPrefs.SetString("Player1", PlayerNames[0].text);
            //else
                PlayerPrefs.SetString("Player1", "Player 1");

//            if (PlayerNames[1].text != " " || PlayerNames[1].text != null)
  //              PlayerPrefs.SetString("Player2", PlayerNames[1].text);
    //        else
                PlayerPrefs.SetString("Player2", "Player 2");

      //      if (PlayerNames[2].text != " " || PlayerNames[2].text != null)
        //        PlayerPrefs.SetString("Player3", PlayerNames[2].text);
          //  else
                PlayerPrefs.SetString("Player3", "Player 3");

            //if (PlayerNames[3].text != " " || PlayerNames[3].text != null)
              //  PlayerPrefs.SetString("Player4", PlayerNames[3].text);
           // else
                PlayerPrefs.SetString("Player4", "Player 4");
            Application.LoadLevel("Level01");
        }
    }

    public void On2Click()
    {
        PlayerPrefs.SetInt("PlayerCounter", 2);
        PlayerCTxt.text = "Players: 2";
    }

    public void On3Click()
    {
        PlayerPrefs.SetInt("PlayerCounter",3);
        PlayerCTxt.text = "Players: 3";
    }

    public void On4Click()
    {
        PlayerPrefs.SetInt("PlayerCounter", 4);
        PlayerCTxt.text = "Players: 4";
    }
    
    public void SelCarro1(int ID)
    {
        PlayerPrefs.SetInt("Carro1", ID);
    }

    public void SelCarro2(int ID)
    {
        PlayerPrefs.SetInt("Carro2", ID);
    }

    public void SelCarro3(int ID)
    {
        PlayerPrefs.SetInt("Carro3", ID);
    }

    public void SelCarro4(int ID)
    {
        PlayerPrefs.SetInt("Carro4", ID);
    }
}
