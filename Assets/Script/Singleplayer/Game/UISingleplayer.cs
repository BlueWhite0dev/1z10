using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;
using System.Globalization;

public class UISingleplayer : MonoBehaviour{
    private JoinToRoom @JoinToRoom;
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private GameObject[] panel;
    [SerializeField] private GameObject PanelLeft;
    [HideInInspector] public string path;

    [SerializeField] private TextMeshProUGUI Time;
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI titleZdania;
    [SerializeField] private TextMeshProUGUI CzyZdaszT;
    [SerializeField] private string line;
    [SerializeField] private string[] split;
    int procenty;
    int numerSlajdu;
    public void TimeU(){
        string dayOfWeek = System.DateTime.Now.ToString("dddd", new CultureInfo("pl-PL")).ToUpper();
        string date = System.DateTime.Now.ToString("dd.MM.yyyy");
        string time = System.DateTime.Now.ToString("HH:mm:ss");
        string dateTimeString = $"{dayOfWeek}\n{date}\n{time}";
        Time.text = dateTimeString;
    }
    private void Awake() {
        GameObject singleObject = GameObject.Find("SingleObject(Clone)");
        @JoinToRoom = singleObject.GetComponent<JoinToRoom>();
        Document();
    }
    private void Start() {
        Name.text = $"Witaj, {@JoinToRoom.TextName.Split(".")[0]}!";
    }
    private void Update() {
        TimeU();
        if(Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "1z11", JoinToRoom.TextName, "Statystyki"))){
            CzyZdasz();
        }
    }

    private void Document(){
        path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "1z11", JoinToRoom.TextName, "Statystyki");
        if (!Directory.Exists(path)){
            Directory.CreateDirectory(path);
            Directory.CreateDirectory(Path.Combine(path, "Testy"));
            Directory.CreateDirectory(Path.Combine(path, "Obliczanie"));
            Directory.CreateDirectory(Path.Combine(path, "NieZdane"));
            Directory.CreateDirectory(Path.Combine(path, "Testy", "Zdawalnosc"));

            using (File.Create(Path.Combine(path, "Testy", "EE.txt"))) { }
            using (File.Create(Path.Combine(path, "Testy", "ELSK.txt"))) { }
            using (File.Create(Path.Combine(path, "Testy", "SO.txt"))) { }
            using (File.Create(Path.Combine(path, "Testy", "UTK.txt"))) { }
            using (File.Create(Path.Combine(path, "Testy", "Zdawalnosc", "EE.txt"))) { }
            using (File.Create(Path.Combine(path, "Testy", "Zdawalnosc", "ELSK.txt"))) { }
            using (File.Create(Path.Combine(path, "Testy", "Zdawalnosc", "SO.txt"))) { }
            using (File.Create(Path.Combine(path, "Testy", "Zdawalnosc", "UTK.txt"))) { }

            using (File.Create(Path.Combine(path, "Obliczanie", "Konwersja.txt"))) { }

            using (File.Create(Path.Combine(path, "NieZdane", "EE.txt"))) { }
            using (File.Create(Path.Combine(path, "NieZdane", "ELSK.txt"))) { }
            using (File.Create(Path.Combine(path, "NieZdane", "SO.txt"))) { }
            using (File.Create(Path.Combine(path, "NieZdane", "UTK.txt"))) { }

            File.WriteAllText(Path.Combine(path, "Testy", "EE.txt"), "0/0");
            File.WriteAllText(Path.Combine(path, "Testy", "ELSK.txt"), "0/0");
            File.WriteAllText(Path.Combine(path, "Testy", "SO.txt"), "0/0");
            File.WriteAllText(Path.Combine(path, "Testy", "UTK.txt"), "0/0");
            File.WriteAllText(Path.Combine(path, "Testy", "Zdawalnosc", "EE.txt"), "0/5");
            File.WriteAllText(Path.Combine(path, "Testy", "Zdawalnosc", "ELSK.txt"), "0/5");
            File.WriteAllText(Path.Combine(path, "Testy", "Zdawalnosc", "SO.txt"), "0/5");
            File.WriteAllText(Path.Combine(path, "Testy", "Zdawalnosc", "UTK.txt"), "0/5");
        }
    }
    private void CzyZdasz(){

        switch(numerSlajdu){
            case 0: //ogolne
                line = File.ReadAllText(Path.Combine(path, "Testy", "EE.txt"));
                split = line.Split("/");
                titleZdania.text = "Ilość zrobionych testów";
                CzyZdaszT.text = $"Egzamin EE.08\nZdane: {split[0]}\nNie zdane: {split[1]}";
                break;

            case 1: //SOPER
                line = File.ReadAllText(Path.Combine(path, "Testy", "SO.txt"));
                split = line.Split("/");
                titleZdania.text = "Ilość zrobionych testów";
                CzyZdaszT.text = $"Systemy Operacyjne\nZdane: {split[0]}\nNie zdane: {split[1]}";
                break;

            case 2: //ELSK
                line = File.ReadAllText(Path.Combine(path, "Testy", "ELSK.txt"));
                split = line.Split("/");
                titleZdania.text = "Ilość zrobionych testów";
                CzyZdaszT.text = $"Sieci Komputerowe\nZdane: {split[0]}\nNie zdane: {split[1]}";
                break;

            case 3: //UTK
                line = File.ReadAllText(Path.Combine(path, "Testy", "UTK.txt"));
                split = line.Split("/");
                titleZdania.text = "Ilość zrobionych testów";
                CzyZdaszT.text = $"Sprzęt komputerowy\nZdane: {split[0]}\nNie zdane: {split[1]}";
                break;
            case 4: //zdawalnosc OGOLNE
                line = File.ReadAllText(Path.Combine(path, "Testy", "Zdawalnosc", "EE.txt"));
                split = line.Split("/");
                titleZdania.text = "Możliwość zdania";
                procenty = (int.Parse(split[0])/int.Parse(split[1]))*100;
                CzyZdaszT.text = $"Egzamin EE.08\n{split[0]}/{split[1]}\nW procentach: {procenty}%";
                break;
            case 5: //zdawalnosc SOPER
                line = File.ReadAllText(Path.Combine(path, "Testy", "Zdawalnosc", "SO.txt"));
                split = line.Split("/");
                titleZdania.text = "Możliwość zdania";
                procenty = (int.Parse(split[0])/int.Parse(split[1]))*100;
                CzyZdaszT.text = $"Systemy Operacyjne\n{split[0]}/{split[1]}\nW procentach: {procenty}%";
                break;
            case 6: //zdawalnosc ELSK
                line = File.ReadAllText(Path.Combine(path, "Testy", "Zdawalnosc", "ELSK.txt"));
                split = line.Split("/");
                titleZdania.text = "Możliwość zdania";
                procenty = (int.Parse(split[0])/int.Parse(split[1]))*100;
                CzyZdaszT.text = $"Sieci Komputerowe\n{split[0]}/{split[1]}\nW procentach: {procenty}%";
                break;
            case 7: //zdawalnosc UTK
                line = File.ReadAllText(Path.Combine(path, "Testy", "Zdawalnosc", "UTK.txt"));
                split = line.Split("/");
                titleZdania.text = "Możliwość zdania";
                procenty = (int.Parse(split[0])/int.Parse(split[1]))*100;
                CzyZdaszT.text = $"Sprzęt komputerowy\n{split[0]}/{split[1]}\nW procentach: {procenty}%";
                break;
        }
    }
    public void LeftArrow(){
        if(numerSlajdu<=0){
            numerSlajdu = 7;
        }else{
            numerSlajdu--;
        }
    }
    public void RightArrow(){
        if(numerSlajdu>=7){
            numerSlajdu = 0;
        }else{
            numerSlajdu++;
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
    public void TrudneTesty(){
        ShowPanel(2);
    }

    public void KonwersjaP(){
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
