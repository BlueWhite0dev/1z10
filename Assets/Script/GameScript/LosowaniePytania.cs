using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.UI;
using System.Collections;
public class LosowaniePytania : MonoBehaviourPunCallbacks{
    public Zmienne zmienne;
    public LosowanieGracza losowanieGracza;
    public BreakScript breakScript;
    public void Awakes() {
        LosowanieLiczby();
        zmienne.button[0].onClick.AddListener(OnButtonClick0);
        zmienne.button[1].onClick.AddListener(OnButtonClick1);
        zmienne.button[2].onClick.AddListener(OnButtonClick2);
        zmienne.button[3].onClick.AddListener(OnButtonClick3);
    }
    public void LosowanieLiczby(){
        if(zmienne.rPanel.activeSelf){
            zmienne.liczbaK = 0;
            zmienne.liczbaK = Random.Range(1, 5);
            //Picture();
            switch(zmienne.liczbaK){
                case 1: //SOPER
                    if((bool)PhotonNetwork.CurrentRoom.CustomProperties["SOPER"]){
                        if(PhotonNetwork.IsMasterClient){
                            zmienne.randomLine = Random.Range(0, zmienne.PytaniaS.Length);
                            // Numer. Pytanie - odpowiedz
                            Debug.Log($"{zmienne.randomLine + 1}. {zmienne.PytaniaS[zmienne.randomLine]} - {zmienne.OdpGPytanS[zmienne.randomLine]}");
                            zmienne.QuestionT.text = zmienne.PytaniaS[zmienne.randomLine];
                            zmienne.buttonT[0].text = zmienne.OdpAPytanS[zmienne.randomLine];
                            zmienne.buttonT[1].text = zmienne.OdpBPytanS[zmienne.randomLine];
                            zmienne.buttonT[2].text = zmienne.OdpCPytanS[zmienne.randomLine];
                            zmienne.buttonT[3].text = zmienne.OdpDPytanS[zmienne.randomLine];
                            photonView.RPC("SetPictureActive", RpcTarget.All, zmienne.randomLine, zmienne.liczbaK);
                            photonView.RPC("SetNumberText", RpcTarget.Others, zmienne.PytaniaS[zmienne.randomLine], zmienne.OdpAPytanS[zmienne.randomLine], zmienne.OdpBPytanS[zmienne.randomLine], zmienne.OdpCPytanS[zmienne.randomLine], zmienne.OdpDPytanS[zmienne.randomLine], zmienne.OdpGPytanS[zmienne.randomLine]);
                        }
                    }else{
                        LosowanieLiczby();
                    }
                break;
                case 2: //ELSK
                    if((bool)PhotonNetwork.CurrentRoom.CustomProperties["ELSK"]){
                        if(PhotonNetwork.IsMasterClient){
                            zmienne.randomLine = Random.Range(0, zmienne.PytaniaE.Length);
                            // Numer. Pytanie - odpowiedz
                            Debug.Log($"{zmienne.randomLine + 1}. {zmienne.PytaniaE[zmienne.randomLine]} - {zmienne.OdpGPytanE[zmienne.randomLine]}");
                            zmienne.QuestionT.text = zmienne.PytaniaE[zmienne.randomLine];
                            zmienne.buttonT[0].text = zmienne.OdpAPytanE[zmienne.randomLine];
                            zmienne.buttonT[1].text = zmienne.OdpBPytanE[zmienne.randomLine];
                            zmienne.buttonT[2].text = zmienne.OdpCPytanE[zmienne.randomLine];
                            zmienne.buttonT[3].text = zmienne.OdpDPytanE[zmienne.randomLine];
                            photonView.RPC("SetPictureActive", RpcTarget.All, zmienne.randomLine, zmienne.liczbaK);
                            photonView.RPC("SetNumberText", RpcTarget.Others, zmienne.PytaniaE[zmienne.randomLine], zmienne.OdpAPytanE[zmienne.randomLine], zmienne.OdpBPytanE[zmienne.randomLine], zmienne.OdpCPytanE[zmienne.randomLine], zmienne.OdpDPytanE[zmienne.randomLine], zmienne.OdpGPytanE[zmienne.randomLine]);
                        }
                    }else{
                        LosowanieLiczby();
                    }
                break;
                case 3: //UTK
                    if((bool)PhotonNetwork.CurrentRoom.CustomProperties["UTK"]){
                        if(PhotonNetwork.IsMasterClient){
                            zmienne.randomLine = Random.Range(0, zmienne.PytaniaU.Length);
                            // Numer. Pytanie - odpowiedz
                            Debug.Log($"{zmienne.randomLine + 1}. {zmienne.PytaniaU[zmienne.randomLine]} - {zmienne.OdpGPytanU[zmienne.randomLine]}");
                            zmienne.QuestionT.text = zmienne.PytaniaU[zmienne.randomLine];
                            zmienne.buttonT[0].text = zmienne.OdpAPytanU[zmienne.randomLine];
                            zmienne.buttonT[1].text = zmienne.OdpBPytanU[zmienne.randomLine];
                            zmienne.buttonT[2].text = zmienne.OdpCPytanU[zmienne.randomLine];
                            zmienne.buttonT[3].text = zmienne.OdpDPytanU[zmienne.randomLine];
                            photonView.RPC("SetPictureActive", RpcTarget.All, zmienne.randomLine, zmienne.liczbaK);
                            photonView.RPC("SetNumberText", RpcTarget.Others, zmienne.PytaniaU[zmienne.randomLine], zmienne.OdpAPytanU[zmienne.randomLine], zmienne.OdpBPytanU[zmienne.randomLine], zmienne.OdpCPytanU[zmienne.randomLine], zmienne.OdpDPytanU[zmienne.randomLine], zmienne.OdpGPytanU[zmienne.randomLine]);
                        }
                    }else{
                        LosowanieLiczby();
                    }
                break;
                case 4: //OGOLNE
                    if((bool)PhotonNetwork.CurrentRoom.CustomProperties["EE08"]){
                        if(PhotonNetwork.IsMasterClient){
                            zmienne.randomLine = Random.Range(0, zmienne.PytaniaO.Length);
                            // Numer. Pytanie - odpowiedz
                            Debug.Log($"{zmienne.randomLine + 1}. {zmienne.PytaniaO[zmienne.randomLine]} - {zmienne.PytaniaO[zmienne.randomLine]}");
                            zmienne.QuestionT.text = zmienne.PytaniaO[zmienne.randomLine];
                            zmienne.buttonT[0].text = zmienne.OdpAPytanO[zmienne.randomLine];
                            zmienne.buttonT[1].text = zmienne.OdpBPytanO[zmienne.randomLine];
                            zmienne.buttonT[2].text = zmienne.OdpCPytanO[zmienne.randomLine];
                            zmienne.buttonT[3].text = zmienne.OdpDPytanO[zmienne.randomLine];
                            photonView.RPC("SetPictureActive", RpcTarget.All, zmienne.randomLine, zmienne.liczbaK);
                            photonView.RPC("SetNumberText", RpcTarget.Others, zmienne.PytaniaO[zmienne.randomLine], zmienne.OdpAPytanO[zmienne.randomLine], zmienne.OdpBPytanO[zmienne.randomLine], zmienne.OdpCPytanO[zmienne.randomLine], zmienne.OdpDPytanO[zmienne.randomLine], zmienne.OdpGPytanO[zmienne.randomLine]);
                        }
                    }else{
                        LosowanieLiczby();
                    }
                break;
                default:
                    LosowanieLiczby();
                break;
            }
        }
    }
    [PunRPC]
    void SetNumberText(string number, string odpA, string odpB, string odpC, string odpD, string odpG){
        zmienne.QuestionT.text = number;
        zmienne.buttonT[0].text = odpA;
        zmienne.buttonT[1].text = odpB;
        zmienne.buttonT[2].text = odpC;
        zmienne.buttonT[3].text = odpD;
        zmienne.goodAnswer = odpG;
        photonView.RPC("SetGoodAnswerRPC", RpcTarget.Others, odpG);
    }
    [PunRPC]
    void SetGoodAnswerRPC(string odpG){
        zmienne.goodAnswer = odpG;
    }
    public void OnButtonClick0(){
        photonView.RPC("OnButtonClick0RPC", RpcTarget.All);
    }
    [PunRPC]
    public void OnButtonClick0RPC(){
        ColorButton();
        Debug.Log($"{zmienne.buttonT[0].text} == {zmienne.goodAnswer}");
        if(zmienne.buttonT[0].text == zmienne.goodAnswer){
            Debug.Log("Dobrze!");
        }
        else{
            Debug.Log("Źle!");
            //odejmij jedno życie od gracza
            losowanieGracza.LoseLife(zmienne.randomPlayer);
        }
        StartCoroutine(WaitAndRoundBreak());
        zmienne.buttonColor[0].GetComponent<Image>().color = Color.yellow;
    }


    public void OnButtonClick1(){
        photonView.RPC("OnButtonClick1RPC", RpcTarget.All);
    }
    [PunRPC]
    public void OnButtonClick1RPC(){
        ColorButton();
        Debug.Log($"{zmienne.buttonT[1].text} == {zmienne.goodAnswer}");
        if(zmienne.buttonT[1].text == zmienne.goodAnswer){
            Debug.Log("Dobrze!");
        }
        else{
            Debug.Log("Źle!");
            //odejmij jedno życie od gracza
            losowanieGracza.LoseLife(zmienne.randomPlayer);
        }
        StartCoroutine(WaitAndRoundBreak());
        zmienne.buttonColor[1].GetComponent<Image>().color = Color.yellow;
    }


    public void OnButtonClick2(){
        photonView.RPC("OnButtonClick2RPC", RpcTarget.All);
    }
    [PunRPC]
    public void OnButtonClick2RPC(){
        ColorButton();
        Debug.Log($"{zmienne.buttonT[2].text} == {zmienne.goodAnswer}");
        if(zmienne.buttonT[2].text == zmienne.goodAnswer){
            Debug.Log("Dobrze!");
        }
        else{
            Debug.Log("Źle!");
            //odejmij jedno życie od gracza
            losowanieGracza.LoseLife(zmienne.randomPlayer);
        }


        StartCoroutine(WaitAndRoundBreak());
        zmienne.buttonColor[2].GetComponent<Image>().color = Color.yellow;
    }
    public void OnButtonClick3(){
        photonView.RPC("OnButtonClick3RPC", RpcTarget.All);
    }
    [PunRPC]
    public void OnButtonClick3RPC(){
        ColorButton();
        Debug.Log($"{zmienne.buttonT[3].text} == {zmienne.goodAnswer}");
        if(zmienne.buttonT[3].text == zmienne.goodAnswer){
            Debug.Log("Dobrze!");
        }
        else{
            Debug.Log("Źle!");
            //odejmij jedno życie od gracza
            losowanieGracza.LoseLife(zmienne.randomPlayer);
        }


        StartCoroutine(WaitAndRoundBreak());
        zmienne.buttonColor[3].GetComponent<Image>().color = Color.yellow;
    }
    public void RoundBreak(){
        photonView.RPC("RoundBreakRPC", RpcTarget.All);
    }
    [PunRPC]
    public void RoundBreakRPC(){
        zmienne.rPanel.SetActive(true);
        breakScript.StartTimer();
    }
    public void ColorButton(){
        for(int i=0; i <= 3; i++){
            if(zmienne.buttonT[i].text == zmienne.goodAnswer){
                zmienne.buttonColor[i].GetComponent<Image>().color = Color.green;
            }else{
                zmienne.buttonColor[i].GetComponent<Image>().color = Color.red;
            }
        }
    }
    public void ResetColorButton(){
        for(int i=0; i <= 3; i++){
            zmienne.buttonColor[i].GetComponent<Image>().color = Color.white;
        }
    }
    public IEnumerator WaitAndRoundBreak(){
        yield return new WaitForSeconds(8f);
        RoundBreak();
        ResetColorButton();
    }
    public void Picture(){
        switch(zmienne.liczbaK){
            case 1: //SOPER
                zmienne.picture.GetComponent<Image>().sprite = zmienne.zdjeciaPytanS[zmienne.randomLine];
                break;
            case 2: //ELSK
                zmienne.picture.GetComponent<Image>().sprite = zmienne.zdjeciaPytanE[zmienne.randomLine];
                break;
            case 3: //UTK
                zmienne.picture.GetComponent<Image>().sprite = zmienne.zdjeciaPytanU[zmienne.randomLine];
                break;
            case 4: //EE08
                zmienne.picture.GetComponent<Image>().sprite = zmienne.zdjeciaPytanO[zmienne.randomLine];
                break;
        }
    }
    [PunRPC]
    void SetPictureActive(int randomLine, int liczbaK){
        zmienne.randomLine = randomLine;
        zmienne.liczbaK = liczbaK;
        Picture();
    }
}