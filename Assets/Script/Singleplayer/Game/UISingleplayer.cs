using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;

public class UISingleplayer : MonoBehaviour{
    private JoinToRoom @JoinToRoom;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private GameObject[] panel;
    [SerializeField] private GameObject PanelLeft;
    public string path;
    private void Awake() {
        GameObject singleObject = GameObject.Find("SingleObject(Clone)");
        @JoinToRoom = singleObject.GetComponent<JoinToRoom>();
        Document();
    }
    private void Start() {
        Name.text = $"Witaj, {@JoinToRoom.TextName.Split(".")[0]}!";
    }

    private void Document(){
        path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "1z11", JoinToRoom.TextName, "Statystyki");
        if (!Directory.Exists(path)){
            Directory.CreateDirectory(path);
            Directory.CreateDirectory(Path.Combine(path, "Testy"));
            Directory.CreateDirectory(Path.Combine(path, "Obliczanie"));
            Directory.CreateDirectory(Path.Combine(path, "NieZdane"));

            File.Create(Path.Combine(path, "Testy", "EE.txt"));
            File.Create(Path.Combine(path, "Testy", "ELSK.txt"));
            File.Create(Path.Combine(path, "Testy", "SO.txt"));
            File.Create(Path.Combine(path, "Testy", "UTK.txt"));

            File.Create(Path.Combine(path, "Obliczanie", "Konwersja.txt"));
            File.Create(Path.Combine(path, "Obliczanie", "Adresowanie.txt"));

            File.Create(Path.Combine(path, "NieZdane", "EE.txt"));
            File.Create(Path.Combine(path, "NieZdane", "ELSK.txt"));
            File.Create(Path.Combine(path, "NieZdane", "SO.txt"));
            File.Create(Path.Combine(path, "NieZdane", "UTK.txt"));
        }
    }
    public void StatystykiP(){
        ShowPanel(0);
        PanelLeft.SetActive(true);
    }

    public void TestyP(){
        ShowPanel(1);
        PanelLeft.SetActive(false);
    }

    public void KonwersjaP(){
        ShowPanel(2);
    }

    public void AdresowanieP(){
        ShowPanel(3);
    }

    private void ShowPanel(int panelIndex){
        for (int i = 0; i < panel.Length; i++){
            panel[i].SetActive(i == panelIndex);
        }
    }
    public void ExitButton(){
        Application.Quit();
    }
}
