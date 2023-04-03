using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;
using System.IO;
using System;

public class Konwersja : MonoBehaviour{
    [SerializeField] private GameObject ButtonStart;
    [SerializeField] private GameObject ButtonEnd;
    [SerializeField] private GameObject[] TimerObject;
    [SerializeField] private GameObject panelC;
    [SerializeField] private TMP_InputField[] TextConvert;
    [SerializeField] private string[] liczba = new string[4];
    [SerializeField] private TextMeshProUGUI[] sprawdzanieT;
    [SerializeField] private TextMeshProUGUI TextButton;
    private int randomLiczba;
    public UISingleplayer @UISingleplayer;


    private Stopwatch stopwatch;
    private bool isTiming;
    [SerializeField] TextMeshProUGUI timerT;
    [SerializeField] TextMeshProUGUI timerTRecord;
    private void Start() {
        stopwatch = new Stopwatch();
        isTiming = false;
        string path = Path.Combine(@UISingleplayer.path, "Obliczanie", "Konwersja.txt");
        string FileContent = File.ReadAllText(path);
        if(FileContent == ""){
            File.WriteAllText(path, "00:00:00.0000000");
        }else{
            timerTRecord.text = FileContent;
        }
    }
    private void Update() {
        if(isTiming)
        timerT.text = stopwatch.Elapsed.ToString();
    }
    public void Obliczanie(){
        TextButton.text = "SPRAWDŹ";
        ButtonStart.SetActive(false);
        ButtonEnd.SetActive(true);
        TimerObject[0].SetActive(true);
        TimerObject[1].SetActive(true);
        panelC.SetActive(true);
        Losowanie();
        StartTimer();
    }
    private void Losowanie(){
        randomLiczba = UnityEngine.Random.Range(0, 4);

        liczba[2] = UnityEngine.Random.Range(1, 10001).ToString();
        liczba[0] = System.Convert.ToString(int.Parse(liczba[2]), 2);
        liczba[1] = System.Convert.ToString(int.Parse(liczba[2]), 8);
        liczba[3] = System.Convert.ToString(int.Parse(liczba[2]), 16).ToUpper();

        switch(randomLiczba){
            case 0: //binarny
            TextConvert[0].text = liczba[0];
                break;
            case 1: //oktalny
            TextConvert[1].text = liczba[1];
                break;
            case 2: //decymalny
            TextConvert[2].text = liczba[2];
                break;
            case 3: //heksadecymalny
            TextConvert[3].text = liczba[3];
                break;
        }
        for(int i = 0; i < TextConvert.Length; i++){
            if(i == randomLiczba){
                TextConvert[i].interactable = false;
            }else{
                TextConvert[i].interactable = true;
            }
        }
    }
    public void Sprawdzanie(){
        if(TextButton.text == "SPRAWDŹ"){
            for(int i = 0; i < TextConvert.Length; i++){
                TextConvert[i].interactable = false;
                if(liczba[i] == TextConvert[i].text.ToUpper() && liczba[randomLiczba] != liczba[i]){
                    sprawdzanieT[i].text = "Dobrze!";
                }else if(liczba[randomLiczba] != liczba[i]){
                    sprawdzanieT[i].text = "Źle!";
                }
            }
            StopTimer();
            checkRecord();
            TextButton.text = "ZAKOŃCZ";
        }else{
            for(int i =0; i < TextConvert.Length; i++){
                sprawdzanieT[i].text = "";
                TextConvert[i].text = "";
            }
            stopwatch.Reset();
            TextButton.text = "SPRAWDŹ";
            ButtonStart.SetActive(true);
            ButtonEnd.SetActive(false);
            TimerObject[0].SetActive(false);
            TimerObject[1].SetActive(false);
            panelC.SetActive(false);
            @UISingleplayer.StatystykiP();
        }
    }

    private void StartTimer(){
        stopwatch.Start();
        isTiming = true;
    }
    private void StopTimer(){
        if (isTiming){
            stopwatch.Stop();
            isTiming = false;
            UnityEngine.Debug.Log("Elapsed time: " + stopwatch.Elapsed);
        }
    }
    private void checkRecord(){
        if(liczba[0] == TextConvert[0].text.ToUpper() && liczba[1] == TextConvert[1].text.ToUpper() && liczba[2] == TextConvert[2].text.ToUpper() && liczba[3] == TextConvert[3].text.ToUpper()){
            string path = Path.Combine(@UISingleplayer.path, "Obliczanie", "Konwersja.txt");
            string FileContent = File.ReadAllText(path);
            TimeSpan time1 = TimeSpan.Parse(timerT.text);
            TimeSpan time2 = TimeSpan.Parse(FileContent);
            if(time1 > time2 || FileContent == "00:00:00.0000000"){
                File.WriteAllText(path, timerT.text);
                timerTRecord.text = timerT.text;
            }
        }
    }
}