using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class GUISingleplayer : MonoBehaviour
{
    [SerializeField] private GameObject[] panel; //Singleplayer, Tworzenie, Logowanie
    [SerializeField] private TextMeshProUGUI textE;
    [SerializeField] private GameObject AccountObject;



    [HideInInspector] public string TextName;
    [SerializeField] private TextMeshProUGUI TextNameTObject;
    private void Awake() {
        GameObject SingleObject = GameObject.Find("SingleObject(Clone)");
        if(SingleObject == null){
            Instantiate(AccountObject);
        }else{
            Destroy(SingleObject);
        }
    }
    public void Create(){
        panel[0].SetActive(false);
        panel[1].SetActive(true);
        panel[2].SetActive(false);
        textE.text = "Cofnij";
    }
    public void Login(){
        panel[0].SetActive(false);
        panel[1].SetActive(false);
        panel[2].SetActive(true);
        textE.text = "Cofnij";
    }
    public void Exit(){
        if(panel[1].activeSelf || panel[2].activeSelf){
            panel[0].SetActive(true);
            panel[1].SetActive(false);
            panel[2].SetActive(false);
            textE.text = "Wyjście";
        }else{
            Application.Quit();
        }
    }
    public void Enter(){
        string originalText = TextNameTObject.text;
        TextName = Regex.Replace(originalText, @"^\d+\.\s", "").Replace(" ", ".");
    }
}
