using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Sockets;
using System.Globalization;


public class ConnectGUI : MonoBehaviour{
    public TextMeshProUGUI title;
    public TMP_InputField nickInput;
    public TextMeshProUGUI sampleName;
    public GameObject[] panel;
    public TextMeshProUGUI timeT;
    public GameObject[] ModeC; //2 - text
    private string[] Name =
    {"Ada", "Adalbert", "Adam", "Adela", "Adelajda", "Adrian", "Aga", "Agata", "Agnieszka", "Albert", "Alberta", "Aldona", "Aleksander", "Aleksandra", "Alfred", "Alicja", "Alina", "Amadeusz", "Ambroży", "Amelia", "Anastazja", "Anastazy", "Anatol", "Andrzej", "Aneta", "Angelika", "Angelina", "Aniela", "Anita", "Anna", "Antoni", "Antonina", "Anzelm", "Apolinary", "Apollo", "Apolonia", "Apoloniusz", "Ariadna", "Arkadiusz", "Arkady", "Arlena", "Arleta", "Arletta", "Arnold", "Arnolf", "August", "Augustyna", "Aurela", "Aurelia", "Aurelian", "Aureliusz", "Balbina", "Baltazar", "Barbara", "Bartłomiej", "Bartosz", "Bazyli", "Beata", "Benedykt", "Benedykta", "Beniamin", "Bernadeta", "Bernard", "Bernardeta", "Bernardyn", "Bernardyna", "Błażej", "Bogdan", "Bogdana", "Bogna", "Bogumił", "Bogumiła", "Bogusław", "Bogusława", "Bohdan", "Bolesław", "Bonawentura", "Bożena", "Bronisław", "Broniszław", "Bronisława", "Brunon", "Brygida", "Cecyl", "Cecylia", "Celestyn", "Celestyna", "Celina", "Cezary", "Cyprian", "Cyryl", "Dalia", "Damian", "Daniel", "Daniela", "Danuta", "Daria", "Dariusz", "Dawid", "Diana", "Dianna", "Dobrawa", "Dominik", "Dominika", "Donata", "Dorian", "Dorota", "Dymitr", "Edmund", "Edward", "Edwin", "Edyta", "Egon", "Eleonora", "Eliasz", "Eligiusz", "Eliza", "Elwira", "Elżbieta", "Emanuel", "Emanuela", "Emil", "Emilia", "Emilian", "Emiliana", "Ernest", "Ernestyna", "Erwin", "Erwina", "Eryk", "Eryka", "Eugenia", "Eugeniusz", "Eulalia", "Eustachy", "Ewelina", "Fabian", "Faustyn", "Faustyna", "Felicja", "Felicjan", "Felicyta", "Feliks", "Ferdynand", "Filip", "Franciszek", "Franciszek", "Salezy", "Franciszka", "Fryderyk", "Fryderyka", "Gabriel", "Gabriela", "Gaweł", "Genowefa", "Gerard", "Gerarda", "Gerhard", "Gertruda", "Gerwazy", "Godfryd", "Gracja", "Gracjan", "Grażyna", "Greta", "Grzegorz", "Gustaw", "Gustawa", "Gwidon", "Halina", "Hanna", "Helena", "Henryk", "Henryka", "Herbert", "Hieronim", "Hilary", "Hipolit", "Honorata", "Hubert", "Ida", "Idalia", "Idzi", "Iga", "Ignacy", "Igor", "Ildefons", "Ilona", "Inga", "Ingeborga", "Irena", "Ireneusz", "Irma", "Irmina", "Irwin", "Ismena", "Iwo", "Iwona", "Izabela", "Izolda", "Izyda", "Izydor", "Jacek", "Jadwiga", "Jagoda", "Jakub", "", "Jan", "", "Janina", "January", "Janusz", "Jarema", "Jarogniew", "Jaromir", "Jarosław", "Jarosława", "Jeremi", "Jeremiasz", "Jerzy", "Jędrzej", "Joachim", "Joanna", "Jolanta", "Jonasz", "Jonatan", "Jowita", "Józef", "Józefa", "Józefina", "Judyta", "Julia", "Julian", "Julianna", "Julita", "Juliusz", "Justyn", "Justyna", "Kacper", "Kaja", "Kajetan", "Kalina", "Kamil", "Kamila", "Karina", "Karol", "Karolina", "Kacper", "Kasper", "Katarzyna", "Kazimiera", "Kazimierz", "Kinga", "Klara", "Klarysa", "Klaudia", "Klaudiusz", "Klaudyna", "Klemens", "Klementyn", "Klementyna", "Kleopatra", "Klotylda", "Konrad", "Konrada", "Konstancja", "Konstanty", "", "Konstantyn", "Kordelia", "Kordian", "Kordula", "Kornel", "Kornelia", "Kryspin", "Krystian", "Krystyn", "Krystyna", "Krzysztof", "Ksenia", "Kunegunda", "Laura", "Laurenty", "Laurentyn", "Laurentyna", "Lech", "Lechosław", "Lechosława", "Leokadia", "Leon", "Leonard", "Leonarda", "Leonia", "Leopold", "Leopoldyna", "Lesław", "Lesława", "Leszek", "Lidia", "Ligia", "Lilian", "Liliana", "Lilianna", "Lilla", "Liwia", "Liwiusz", "Liza", "Lolita", "Longin", "Loretta", "Luba", "Lubomir", "Lubomira", "Lucja", "Lucjan", "Lucjusz", "Lucyna", "Ludmiła", "Ludomił", "Ludomir", "Ludosław", "Ludwik", "Ludwika", "Ludwina", "Luiza", "Lukrecja", "Lutosław", "Łucja", "Łucjan", "Łukasz", "Maciej", "Madlena", "Magda", "Magdalena", "", "Makary", "Maksym", "Maksymilian", "Malina", "Malwin", "Malwina", "Małgorzata", "Manfred", "Manfreda", "Manuela", "Marcel", "Marcela", "Marceli", "Marcelina", "Marcin", "Marcjan", "Marcjanna", "Marcjusz", "Marek", "Margareta", "Maria", "MariaMagdalena", "Marian", "Marianna", "Marietta", "Marina", "Mariola", "Mariusz", "Marlena", "Marta", "Martyna", "Maryla", "Maryna", "Marzanna", "Marzena", "Mateusz", "Matylda", "Maurycy", "Melania", "Melchior", "Metody", "Michalina", "Michał", "Mieczysław", "Mieczysława", "Mieszko", "Mikołaj", "Milena", "Miła", "Miłosz", "Miłowan", "Miłowit", "Mira", "Mirabella", "Mirella", "Miron", "Mirosław", "Mirosława", "Modest", "Monika", "Nadia", "Nadzieja", "Napoleon", "Narcyz", "Narcyza", "Nastazja", "Natalia", "Natasza", "Nikita", "Nikodem", "Nina", "Nora", "Norbert", "Norberta", "Norma", "Norman", "Oda", "Odila", "Odon", "Ofelia", "Oksana", "Oktawia", "Oktawian", "Olaf", "Oleg", "Olga", "Olgierd", "Olimpia", "Oliwia", "Oliwier", "Onufry", "Orfeusz", "Oskar", "Otto", "Otylia", "Pankracy", "Parys", "Patrycja", "Patrycy", "Patryk", "Paula", "Paulina", "Paweł", "Pelagia", "Petronela", "Petronia", "Petroniusz", "Piotr", "Pola", "Polikarp", "Protazy", "Przemysław", "Radomił", "Radomiła", "Radomir", "Radosław", "Radosława", "Radzimir", "Rafael", "Rafaela", "Rafał", "Rajmund", "Rajmunda", "Rajnold", "Rebeka", "Regina", "Remigiusz", "Rena", "Renata", "Robert", "Roberta", "Roch", "Roderyk", "Rodryg", "Rodryk", "Roger", "Roksana", "Roland", "Roma", "Roman", "Romana", "Romeo", "Romuald", "Rozalia", "Rozanna", "Róża", "Rudolf", "Rudolfa", "Rudolfina", "Rufin", "Rupert", "Ryszard", "Ryszarda", "Sabina", "Salomea", "Salomon", "Samuel", "Samuela", "Sandra", "Sara", "Sawa", "Sebastian", "Serafin", "Sergiusz", "Sewer", "Seweryn", "Seweryna", "Sędzisław", "Sędziwoj", "Siemowit", "Sława", "Sławomir", "Sławomira", "Sławosz", "Sobiesław", "Sobiesława", "Sofia", "Sonia", "Stanisław", "Stanisława", "Stefan", "Stefania", "Sulimiera", "Sulimierz", "Sulimir", "Sydonia", "Sykstus", "Sylwan", "Sylwana", "Sylwester", "Sylwia", "Sylwiusz", "Symeon", "Szczepan", "Szczęsna", "Szczęsny", "Szymon", "Ścibor", "Świętopełk", "Tadeusz", "Tamara", "Tatiana", "Tekla", "Telimena", "Teodor", "Teodora", "Teodozja", "Teodozjusz", "Teofil", "Teofila", "Teresa", "Tobiasz", "Toma", "Tomasz", "Tristan", "Trojan", "Tycjan", "Tymon", "Tymoteusz", "Tytus", "Unisław", "Ursyn", "Urszula", "Violetta", "Wacław", "Wacława", "Waldemar", "Walenty", "Walentyna", "Waleria", "Walerian", "Waleriana", "Walery", "Walter", "Wanda", "Wasyl", "Wawrzyniec", "Wera", "Werner", "Weronika", "Wieńczysła", "Wiesław", "Wiesława", "Wiktor", "Wiktoria", "Wilhelm", "Wilhelmina", "Wilma", "Wincenta", "Wincenty", "Wińczysła", "Wiola", "Wioletta", "Wirgiliusz", "Wirginia", "Wirginiusz", "Wisław", "Wisława", "Wit", "Witalis", "Witold", "Witolda", "Witołd", "Witomir", "Wiwanna", "Władysława", "Władysław", "Włodzimierz", "Włodzimir", "Wodzisław", "Wojciech", "Wojciecha", "Zachariasz", "Zbigniew", "Zbysław", "Zbyszko", "Zdobysław", "Zdzisław", "Zdzisława", "Zenobia", "Zenobiusz", "Zenon", "Zenona", "Ziemowit", "Zofia", "Zula", "Zuzanna", "Zygfryd", "Zygmunt", "Zyta", "Żaklina", "Żaneta", "Żanna", "Żelisław", "Żytomir"};
    int i;
    private void Update() {
        TimeU();
        title.text = $"{nickInput.text}@gmail.com";
    }
    private void Awake() {
        i = Random.Range(0, Name.Length - 1);
    }
    private void Start() {
        StartCoroutine(Text());
    }
    IEnumerator Text(){
        sampleName.text = "";
        foreach(char c in Name[i]){
            sampleName.text += c;
            yield return new WaitForSeconds(0.4f);
        }
        yield return new WaitForSeconds(0.6f);
        for (int j = sampleName.text.Length; j > 0; j--) {
            sampleName.text = sampleName.text.Substring(0, j - 1);
            yield return new WaitForSeconds(0.3f);
        }
        i = Random.Range(0, Name.Length - 1);
        StartCoroutine(Text());
    }
    public void Singleplayer(){
        panel[0].SetActive(false);

        panel[1].SetActive(true);
        ModeC[0].SetActive(true);

        panel[2].SetActive(false);
        ModeC[1].SetActive(false);
        ModeC[2].SetActive(false);
    }
    public void Multiplayer(){
        panel[0].SetActive(false);

        panel[1].SetActive(false);
        ModeC[0].SetActive(false);

        panel[2].SetActive(true);
        ModeC[1].SetActive(true);
        ModeC[2].SetActive(true);
    }
    public void Exit(){
        Application.Quit();
    }
    public void TimeU(){
        string dayOfWeek = System.DateTime.Now.ToString("dddd", new CultureInfo("pl-PL")).ToUpper();
        string date = System.DateTime.Now.ToString("dd.MM.yyyy");
        string time = System.DateTime.Now.ToString("HH:mm:ss");
        string dateTimeString = $"{dayOfWeek}\n{date}\n{time}";
        timeT.text = dateTimeString;
    }
}