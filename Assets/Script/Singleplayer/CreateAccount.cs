using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;
using System.IO;

public class CreateAccount : MonoBehaviour{
    public GUISingleplayer @GUISingleplayer;
    public JoinToSinglePlayer @JoinToSinglePlayer;
    private string[] hehe18 =
    {"chuj","chuja", "chujek", "chuju", "chujem", "chujnia","chujowy", "chujowa", "chujowe", "cipa", "cipę", "cipe", "cipą","cipie", "dojebać","dojebac", "dojebie", "dojebał", "dojebal","dojebała", "dojebala", "dojebałem", "dojebalem", "dojebałam","dojebalam", "dojebię", "dojebie", "dopieprzać", "dopieprzac","dopierdalać", "dopierdalac", "dopierdala", "dopierdalał","dopierdalal", "dopierdalała", "dopierdalala", "dopierdoli","dopierdolił", "dopierdolil", "dopierdolę", "dopierdole", "dopierdoli","dopierdalający", "dopierdalajacy", "dopierdolić", "dopierdolic","dupa", "dupie", "dupą", "dupcia", "dupeczka", "dupy", "dupe", "huj","hujek", "hujnia", "huja", "huje", "hujem", "huju", "jebać", "jebac","jebał", "jebal", "jebie", "jebią", "jebia", "jebak", "jebaka", "jebal","jebał", "jebany", "jebane", "jebanka", "jebanko", "jebankiem","jebanymi", "jebana", "jebanym", "jebanej", "jebaną", "jebana","jebani", "jebanych", "jebanymi", "jebcie", "jebiący", "jebiacy","jebiąca", "jebiaca", "jebiącego", "jebiacego", "jebiącej", "jebiacej","jebia", "jebią", "jebie", "jebię", "jebliwy", "jebnąć", "jebnac","jebnąc", "jebnać", "jebnął", "jebnal", "jebną", "jebna", "jebnęła","jebnela", "jebnie", "jebnij", "jebut", "koorwa", "kórwa", "kurestwo","kurew", "kurewski", "kurewska", "kurewskiej", "kurewską", "kurewska","kurewsko", "kurewstwo", "kurwa", "kurwaa", "kurwami", "kurwą", "kurwe","kurwę", "kurwie", "kurwiska", "kurwo", "kurwy", "kurwach", "kurwami","kurewski", "kurwiarz", "kurwiący", "kurwica", "kurwić", "kurwic","kurwidołek", "kurwik", "kurwiki", "kurwiszcze", "kurwiszon","kurwiszona", "kurwiszonem", "kurwiszony", "kutas", "kutasa", "kutasie","kutasem", "kutasy", "kutasów", "kutasow", "kutasach", "kutasami","matkojebca", "matkojebcy", "matkojebcą", "matkojebca", "matkojebcami","matkojebcach", "nabarłożyć", "najebać", "najebac", "najebał","najebal", "najebała", "najebala", "najebane", "najebany", "najebaną","najebana", "najebie", "najebią", "najebia", "naopierdalać","naopierdalac", "naopierdalał", "naopierdalal", "naopierdalała","naopierdalala", "naopierdalała", "napierdalać", "napierdalac","napierdalający", "napierdalajacy", "napierdolić", "napierdolic","nawpierdalać", "nawpierdalac", "nawpierdalał", "nawpierdalal","nawpierdalała", "nawpierdalala", "obsrywać", "obsrywac", "obsrywający","obsrywajacy", "odpieprzać", "odpieprzac", "odpieprzy", "odpieprzył","odpieprzyl", "odpieprzyła", "odpieprzyla", "odpierdalać","odpierdalac", "odpierdol", "odpierdolił", "odpierdolil","odpierdoliła", "odpierdolila", "odpierdoli", "odpierdalający","odpierdalajacy", "odpierdalająca", "odpierdalajaca", "odpierdolić","odpierdolic", "odpierdoli", "odpierdolił", "opieprzający","opierdalać", "opierdalac", "opierdala", "opierdalający","opierdalajacy", "opierdol", "opierdolić", "opierdolic", "opierdoli","opierdolą", "opierdola", "piczka", "pieprznięty", "pieprzniety","pieprzony", "pierdel", "pierdlu", "pierdolą", "pierdola", "pierdolący","pierdolacy", "pierdoląca", "pierdolaca", "pierdol", "pierdole","pierdolenie", "pierdoleniem", "pierdoleniu", "pierdolę", "pierdolec","pierdola", "pierdolą", "pierdolić", "pierdolicie", "pierdolic","pierdolił", "pierdolil", "pierdoliła", "pierdolila", "pierdoli","pierdolnięty", "pierdolniety", "pierdolisz", "pierdolnąć","pierdolnac", "pierdolnął", "pierdolnal", "pierdolnęła", "pierdolnela","pierdolnie", "pierdolnięty", "pierdolnij", "pierdolnik", "pierdolona","pierdolone", "pierdolony", "pierdołki", "pierdzący", "pierdzieć","pierdziec", "pizda", "pizdą", "pizde", "pizdę", "piździe", "pizdzie","pizdnąć", "pizdnac", "pizdu", "podpierdalać", "podpierdalac","podpierdala", "podpierdalający", "podpierdalajacy", "podpierdolić","podpierdolic", "podpierdoli", "pojeb", "pojeba", "pojebami","pojebani", "pojebanego", "pojebanemu", "pojebani", "pojebany","pojebanych", "pojebanym", "pojebanymi", "pojebem", "pojebać","pojebac", "pojebalo", "popierdala", "popierdalac", "popierdalać","popierdolić", "popierdolic", "popierdoli", "popierdolonego","popierdolonemu", "popierdolonym", "popierdolone", "popierdoleni","popierdolony", "porozpierdalać", "porozpierdala", "porozpierdalac","poruchac", "poruchać", "przejebać", "przejebane", "przejebac","przyjebali", "przepierdalać", "przepierdalac", "przepierdala","przepierdalający", "przepierdalajacy", "przepierdalająca","przepierdalajaca", "przepierdolić", "przepierdolic", "przyjebać","przyjebac", "przyjebie", "przyjebała", "przyjebala", "przyjebał","przyjebal", "przypieprzać", "przypieprzac", "przypieprzający","przypieprzajacy", "przypieprzająca", "przypieprzajaca","przypierdalać", "przypierdalac", "przypierdala", "przypierdoli","przypierdalający", "przypierdalajacy", "przypierdolić","przypierdolic", "qrwa", "rozjebać", "rozjebac", "rozjebie","rozjebała", "rozjebią", "rozpierdalać", "rozpierdalac", "rozpierdala","rozpierdolić", "rozpierdolic", "rozpierdole", "rozpierdoli","rozpierducha", "skurwić", "skurwiel", "skurwiela", "skurwielem","skurwielu", "skurwysyn", "skurwysynów", "skurwysynow", "skurwysyna","skurwysynem", "skurwysynu", "skurwysyny", "skurwysyński","skurwysynski", "skurwysyństwo", "skurwysynstwo", "spieprzać","spieprzac", "spieprza", "spieprzaj", "spieprzajcie", "spieprzają","spieprzaja", "spieprzający", "spieprzajacy", "spieprzająca","spieprzajaca", "spierdalać", "spierdalac", "spierdala", "spierdalał","spierdalała", "spierdalal", "spierdalalcie", "spierdalala","spierdalający", "spierdalajacy", "spierdolić", "spierdolic","spierdoli", "spierdoliła", "spierdoliło", "spierdolą", "spierdola","srać", "srac", "srający", "srajacy", "srając", "srajac", "sraj","sukinsyn", "sukinsyny", "sukinsynom", "sukinsynowi", "sukinsynów","sukinsynow", "śmierdziel", "udupić", "ujebać", "ujebac", "ujebał","ujebal", "ujebana", "ujebany", "ujebie", "ujebała", "ujebala","upierdalać", "upierdalac", "upierdala", "upierdoli", "upierdolić","upierdolic", "upierdoli", "upierdolą", "upierdola", "upierdoleni","wjebać", "wjebac", "wjebie", "wjebią", "wjebia", "wjebiemy","wjebiecie", "wkurwiać", "wkurwiac", "wkurwi", "wkurwia", "wkurwiał","wkurwial", "wkurwiający", "wkurwiajacy", "wkurwiająca", "wkurwiajaca","wkurwić", "wkurwic", "wkurwi", "wkurwiacie", "wkurwiają", "wkurwiali","wkurwią", "wkurwia", "wkurwimy", "wkurwicie", "wkurwiacie", "wkurwić","wkurwic", "wkurwia", "wpierdalać", "wpierdalac", "wpierdalający","wpierdalajacy", "wpierdol", "wpierdolić", "wpierdolic", "wpizdu","wyjebać", "wyjebac", "wyjebali", "wyjebał", "wyjebac", "wyjebała","wyjebały", "wyjebie", "wyjebią", "wyjebia", "wyjebiesz", "wyjebie","wyjebiecie", "wyjebiemy", "wypieprzać", "wypieprzac", "wypieprza","wypieprzał", "wypieprzal", "wypieprzała", "wypieprzala", "wypieprzy","wypieprzyła", "wypieprzyla", "wypieprzył", "wypieprzyl", "wypierdal","wypierdalać", "wypierdalac", "wypierdala", "wypierdalaj","wypierdalał", "wypierdalal", "wypierdalała", "wypierdalala","wypierdalać", "wypierdolić", "wypierdolic", "wypierdoli","wypierdolimy", "wypierdolicie", "wypierdolą", "wypierdola","wypierdolili", "wypierdolił", "wypierdolil", "wypierdoliła","wypierdolila", "zajebać", "zajebac", "zajebie", "zajebią", "zajebia","zajebiał", "zajebial", "zajebała", "zajebiala", "zajebali", "zajebana","zajebani", "zajebane", "zajebany", "zajebanych", "zajebanym","zajebanymi", "zajebiste", "zajebisty", "zajebistych", "zajebista","zajebistym", "zajebistymi", "zajebiście", "zajebiscie", "zapieprzyć","zapieprzyc", "zapieprzy", "zapieprzył", "zapieprzyl", "zapieprzyła","zapieprzyla", "zapieprzą", "zapieprza", "zapieprzy", "zapieprzymy","zapieprzycie", "zapieprzysz", "zapierdala", "zapierdalać","zapierdalac", "zapierdalaja", "zapierdalał", "zapierdalaj","zapierdalajcie", "zapierdalała", "zapierdalala", "zapierdalali","zapierdalający", "zapierdalajacy", "zapierdolić", "zapierdolic","zapierdoli", "zapierdolił", "zapierdolil", "zapierdoliła","zapierdolila", "zapierdolą", "zapierdola", "zapierniczać","zapierniczający", "zasrać", "zasranym", "zasrywać", "zasrywający","zesrywać", "zesrywający", "zjebać", "zjebac", "zjebał", "zjebal","zjebała", "zjebala", "zjebana", "zjebią", "zjebali", "zjeby"};
    private bool isMatch;
    [SerializeField] private Button dalejB;
    [SerializeField] private TMP_InputField[] Name;
    [SerializeField] private GameObject panel;
    [SerializeField] private TextMeshProUGUI text_alarm;
    private string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

    private void Update() {
        if(Input.anyKey){
            panel.SetActive(false);
            if(panel.activeSelf){
                Name[0].text = "";
                Name[1].text = "";
            }
        }

    }
    public void Create(){
        if(Check(Name[0].text) && Check(Name[1].text)){
            string Folderpatch = Path.Combine(path, "1z11");
            if(!Directory.Exists(Folderpatch)){
                Directory.CreateDirectory(Folderpatch);
                File.SetAttributes(Folderpatch, File.GetAttributes(Folderpatch) | FileAttributes.ReadOnly | FileAttributes.Hidden);
            }else{
                string NazwaFolderu = $"{Name[0].text}.{Name[1].text}";
                string pathName = Path.Combine(Folderpatch, NazwaFolderu);
                    Directory.CreateDirectory(pathName);
                    Debug.Log("Utworzono: " + pathName);

                    Name[0].text = "";
                    Name[1].text = "";
                    @GUISingleplayer.Exit();
                    @JoinToSinglePlayer.ButtonL();
            }
        }else{
            panel.SetActive(true);
        }
    }
    private bool Check(string nick){
        if(nick.Length >= 1 && nick.Length <= 15){
            var curse = System.Text.RegularExpressions.Regex.IsMatch(nick, string.Join("|", hehe18), RegexOptions.IgnoreCase);
            if(!curse){
                Regex regex = new Regex(@"^[^\s\d]+$");
                isMatch = regex.IsMatch(nick);

                if(isMatch){
                    string Folderpatch = Path.Combine(path, "1z11");
                    string pathName = Path.Combine(Folderpatch, $"{Name[0].text}.{Name[1].text}");
                    if(Directory.Exists(pathName)){
                        text_alarm.text = "Już takie konto istnieje";
                        return false;
                    }else{
                        return true;
                    }
                }else{
                    text_alarm.text = "W imieniu znajduje się cyfra lub inny znak";
                    return false;
                }

            }else{
                text_alarm.text = "Imie nie może zawierać wulgaryzmów";
                return false;
            }
        }else{
            text_alarm.text = "Imie musi mieć od 1 do 15 liter";
            return false;
        }
    }
}
