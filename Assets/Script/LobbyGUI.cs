using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using System;
using UnityEngine.SceneManagement;

public class LobbyGUI : MonoBehaviour{
    [SerializeField] private TextMeshProUGUI title;
    public LobbyManager lobbyManager;
    public TextMeshProUGUI assistT;
    private void Start() {
        title.text = $"{PhotonNetwork.NickName }@gmail.com";
    }
    public void Click1(){ //exit
        Application.Quit();
    }
    public void Click2(){ //menu
        PhotonNetwork.NickName = "";
        SceneManager.LoadScene("ConnectToServer");
    }
    public void Sprawdzanie(){
        var CatB = lobbyManager.Categories[1].isOn || lobbyManager.Categories[2].isOn || lobbyManager.Categories[3].isOn || lobbyManager.Categories[4].isOn;
        assistT.text = "";
        if(lobbyManager.roomInputField.text.Length < 1){
            assistT.text = "Nazwa pokoju jest zbyt krótka";
        }else if(!CatB && !lobbyManager.Categories[0].isOn){
            assistT.text = "Wybierz chociaż jedną kategorię";
        }else if(lobbyManager.Categories[0].isOn && CatB){
            assistT.text = "Nie można tworzyć pokoju z pytaniami ogólnymi wraz z inną kategorią";
        }
    }
}