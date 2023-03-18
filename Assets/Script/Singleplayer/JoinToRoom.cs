using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class JoinToRoom : MonoBehaviour{
    public string TextName;
    private GameObject @GUISingleplayer;
    private void Awake() {
        DontDestroyOnLoad(gameObject);
        @GUISingleplayer = GameObject.Find("Singleplayer object");
    }
    private void Update() {
        if(SceneManager.GetActiveScene().name == "ConnectToServer" && @GUISingleplayer.GetComponent<GUISingleplayer>().TextName != ""){
            TextName = @GUISingleplayer.GetComponent<GUISingleplayer>().TextName;
            SceneManager.LoadScene(3);
        }
    }
}
