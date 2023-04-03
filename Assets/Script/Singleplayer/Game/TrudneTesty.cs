using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Diagnostics;
using System;
using System.IO;

public class TrudneTesty : MonoBehaviour{
    [Header("Categories")]
    [SerializeField] private GameObject[] buttonCategories;
    private bool[] categories = {false, false, false, false};
    [SerializeField] private GameObject PanelCategories;
    [SerializeField] private GameObject PanelTest;
    [SerializeField] private GameObject PanelStatystyki;
    [SerializeField] private GameObject PanelTrudnetesty;
    [SerializeField] private TextMeshProUGUI NumberQuestionT;
    [Header("Pytania")]
    int numer;
    public string PathN;
    public Testy @Testy;
    public JoinToRoom @JoinToRoom;
    [SerializeField] private List<int> SPytania;
    [SerializeField] private List<int> EPytania;
    [SerializeField] private List<int> OPytania;
    [SerializeField] private List<int> UPytania;
    [Header("UI")]
    [SerializeField] private Button[] buttons;
    [SerializeField] private TextMeshProUGUI[] answerT;
    [SerializeField] private TextMeshProUGUI questionT;
    [SerializeField] Image image;
    private void Awake() {
        GameObject singleObject = GameObject.Find("SingleObject(Clone)");
        @JoinToRoom = singleObject.GetComponent<JoinToRoom>();
    }
    private void Start() {
        PathN = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "1z11", @JoinToRoom.TextName, "Statystyki", "NieZdane");
    }
    private void Update() {
        if(categories[0]){
            NumberQuestionT.text = $"{numer} z {SPytania.Count}";
        }
        if(categories[1]){
            NumberQuestionT.text = $"{numer} z {EPytania.Count}";
        }
        if(categories[2]){
            NumberQuestionT.text = $"{numer} z {OPytania.Count}";
        }
        if(categories[3]){
            NumberQuestionT.text = $"{numer} z {UPytania.Count}";
        }
    }
    public void Check(){
        read(Path.Combine(PathN, "SO.txt"), SPytania, 0);
        read(Path.Combine(PathN, "ELSK.txt"), EPytania, 1);
        read(Path.Combine(PathN, "EE.txt"), OPytania, 2);
        read(Path.Combine(PathN, "UTK.txt"), UPytania, 3);
        if(SPytania.Count == 0){
            buttonCategories[0].SetActive(false);
        }else{
            buttonCategories[0].SetActive(true);
        }
        if(EPytania.Count == 0){
            buttonCategories[1].SetActive(false);
        }else{
            buttonCategories[1].SetActive(true);
        }
        if(OPytania.Count == 0){
            buttonCategories[2].SetActive(false);
        }else{
            buttonCategories[2].SetActive(true);
        }
        if(UPytania.Count == 0){
            buttonCategories[3].SetActive(false);
        }else{
            buttonCategories[3].SetActive(true);
        }
    }
    private void read(string path, List<int> beforeL, int i){
        string[] lines = File.ReadAllLines(path);
        foreach (string line in lines)
        {
            string[] numbers = line.Split(',');
            foreach (string number in numbers)
            {
                int value;
                if (int.TryParse(number, out value))
                {
                    beforeL.Add(value);
                }
            }
        }

    }
    public void SO(){
        categories[0] = true;
        PanelCategories.SetActive(false);
        PanelTest.SetActive(true);
        UI();
    }
    public void ELSK(){
        categories[1] = true;
        PanelCategories.SetActive(false);
        PanelTest.SetActive(true);
        UI();
    }
    public void EE(){
        categories[2] = true;
        PanelCategories.SetActive(false);
        PanelTest.SetActive(true);
        UI();
    }
    public void UTK(){
        categories[3] = true;
        PanelCategories.SetActive(false);
        PanelTest.SetActive(true);
        UI();
    }
    public void zakoncz(){
        PanelCategories.SetActive(true);
        PanelTest.SetActive(false);
        PanelTrudnetesty.SetActive(false);
        PanelStatystyki.SetActive(true);
        numer = 0;
    }
    private void UI(){
        for(int i =0; i<4; i++){
            buttons[i].GetComponent<Image>().color = Color.white;
        }
        if(categories[0]){
            NumberQuestionT.text = $"{numer} z {SPytania.Count}";
            answerT[0].text = @Testy.OdpAPytanS[SPytania[numer]];
            answerT[1].text = @Testy.OdpBPytanS[SPytania[numer]];
            answerT[2].text = @Testy.OdpCPytanS[SPytania[numer]];
            answerT[3].text = @Testy.OdpDPytanS[SPytania[numer]];
            questionT.text = @Testy.PytaniaS[SPytania[numer]];
            image.sprite = @Testy.zdjeciaPytanS[SPytania[numer]];
        }
        if(categories[1]){
            NumberQuestionT.text = $"{numer} z {OPytania.Count}";
            answerT[0].text = @Testy.OdpAPytanE[EPytania[numer]];
            answerT[1].text = @Testy.OdpBPytanE[EPytania[numer]];
            answerT[2].text = @Testy.OdpCPytanE[EPytania[numer]];
            answerT[3].text = @Testy.OdpDPytanE[EPytania[numer]];
            questionT.text = @Testy.PytaniaE[EPytania[numer]];
            image.sprite = @Testy.zdjeciaPytanE[EPytania[numer]];
        }
        if(categories[2]){
            NumberQuestionT.text = $"{numer} z {OPytania.Count}";
            answerT[0].text = @Testy.OdpAPytanO[OPytania[numer]];
            answerT[1].text = @Testy.OdpBPytanO[OPytania[numer]];
            answerT[2].text = @Testy.OdpCPytanO[OPytania[numer]];
            answerT[3].text = @Testy.OdpDPytanO[OPytania[numer]];
            questionT.text = @Testy.PytaniaO[OPytania[numer]];
            image.sprite = @Testy.zdjeciaPytanO[OPytania[numer]];
        }
        if(categories[3]){
            NumberQuestionT.text = $"{numer} z {UPytania.Count}";
            answerT[0].text = @Testy.OdpAPytanU[UPytania[numer]];
            answerT[1].text = @Testy.OdpBPytanU[UPytania[numer]];
            answerT[2].text = @Testy.OdpCPytanU[UPytania[numer]];
            answerT[3].text = @Testy.OdpDPytanU[UPytania[numer]];
            questionT.text = @Testy.PytaniaU[UPytania[numer]];
            image.sprite = @Testy.zdjeciaPytanU[UPytania[numer]];
        }
    }
    public void LeftArrow(){
        if(numer <= 0){
            if(categories[0]){
                numer = SPytania.Count;
            }
            if(categories[1]){
                numer = EPytania.Count;
            }
            if(categories[2]){
                numer = OPytania.Count;
            }
            if(categories[3]){
                numer = UPytania.Count;
            }
        }else{
            numer--;
        }
        UI();
        interactable(true);
    }
    public void RightArrow(){
        int maks = 0;
        if(categories[0]){
            maks = SPytania.Count;
        }
        if(categories[1]){
            maks = EPytania.Count;
        }
        if(categories[2]){
            maks = OPytania.Count;
        }
        if(categories[3]){
            maks = UPytania.Count;
        }
        if(numer >= maks){
            numer = 0;
        }else{
            numer++;
        }
        UI();
        interactable(true);
    }
    private void interactable(bool aktywnosc){
        for(int i = 0; i < buttons.Length; i++){
            buttons[i].interactable = aktywnosc;
        }
    }
    private void Sprawdzanie(string[] listaPoprawnych, List<int> lista, int numerG, int kategoria){
        if(categories[kategoria]){
            if(answerT[numerG].text == listaPoprawnych[lista[numer]]){
                buttons[numerG].GetComponent<Image>().color = Color.green;
            }else{
                buttons[numerG].GetComponent<Image>().color = Color.red;
                for(int i =0; i<4; i++){
                    if(answerT[i].text == listaPoprawnych[lista[numer]]){
                        buttons[i].GetComponent<Image>().color = Color.green;
                    }
                }
            }
        }
    }
    public void OdpA(){
        interactable(false);
        Sprawdzanie(@Testy.OdpGPytanS, SPytania, 0, 0);
        Sprawdzanie(@Testy.OdpGPytanE, EPytania, 0, 1);
        Sprawdzanie(@Testy.OdpGPytanO, OPytania, 0, 2);
        Sprawdzanie(@Testy.OdpGPytanU, UPytania, 0, 3);
    }
    public void OdpB(){
        interactable(false);
        Sprawdzanie(@Testy.OdpGPytanS, SPytania, 1, 0);
        Sprawdzanie(@Testy.OdpGPytanE, EPytania, 1, 1);
        Sprawdzanie(@Testy.OdpGPytanO, OPytania, 1, 2);
        Sprawdzanie(@Testy.OdpGPytanU, UPytania, 1, 3);
    }
    public void OdpC(){
        interactable(false);
        Sprawdzanie(@Testy.OdpGPytanS, SPytania, 2, 0);
        Sprawdzanie(@Testy.OdpGPytanE, EPytania, 2, 1);
        Sprawdzanie(@Testy.OdpGPytanO, OPytania, 2, 2);
        Sprawdzanie(@Testy.OdpGPytanU, UPytania, 2, 3);
    }
    public void OdpD(){
        interactable(false);
        Sprawdzanie(@Testy.OdpGPytanS, SPytania, 3, 0);
        Sprawdzanie(@Testy.OdpGPytanE, EPytania, 3, 1);
        Sprawdzanie(@Testy.OdpGPytanO, OPytania, 3, 2);
        Sprawdzanie(@Testy.OdpGPytanU, UPytania, 3, 3);
    }
}