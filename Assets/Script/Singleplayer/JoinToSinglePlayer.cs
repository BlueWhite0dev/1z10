using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;
using TMPro;

public class JoinToSinglePlayer : MonoBehaviour{
    private string directoryPath  = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "1z11");
    [SerializeField] private List<string> folderNames = new List<string>(); //!Do usuniecia
    [SerializeField] private GameObject[] arrowsObject;
    [SerializeField] private TextMeshProUGUI userNameT;
    private int i;
    private void Start() {
        ButtonL();
    }
    public void ButtonL() {
        if(Directory.Exists(directoryPath)){
            string[] subdirectoryEntries = Directory.GetDirectories(directoryPath);
            folderNames.Clear();
            foreach(string subdirectory in subdirectoryEntries){
                string folderName = Path.GetFileName(subdirectory);
                folderName = folderName.Replace(".", " ");
                folderNames.Add(folderName);
            }
            Debug.Log(folderNames.Count);
            userNameT.text = $"{i+1}. {folderNames[0]}";
            if(folderNames.Count <= 1){
                arrowsObject[1].SetActive(false);
            }else{
                arrowsObject[1].SetActive(true);
            }


            if(folderNames[0] == folderNames[0]){
                arrowsObject[0].SetActive(false);
            }else{
                arrowsObject[0].SetActive(true);
            }

        }else{
            Debug.Log("Nie ma"); //! Do zmiany
        }
    }
    public void arrowL() {
        if(folderNames[i] != folderNames[0]){
            i--;
            userNameT.text = $"{i+1}. {folderNames[i]}";
            arrowsObject[1].SetActive(true);
            if(folderNames[i] == folderNames[0]){
                arrowsObject[0].SetActive(false);
            }else{
                arrowsObject[0].SetActive(true);
            }
        }else{
                arrowsObject[0].SetActive(false);
        }
    }
    public void arrowR() {
        if(folderNames[i] != folderNames[folderNames.Count-1]){
            i++;
            userNameT.text = $"{i+1}. {folderNames[i]}";
            arrowsObject[0].SetActive(true);
            if(folderNames[i] == folderNames[folderNames.Count-1]){
                arrowsObject[1].SetActive(false);
            }else{
                arrowsObject[1].SetActive(true);
            }
        }else{
                arrowsObject[1].SetActive(false);
        }
    }
}
