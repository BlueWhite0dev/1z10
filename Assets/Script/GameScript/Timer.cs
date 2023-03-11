using System.Collections;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class Timer : MonoBehaviourPunCallbacks{
    public Zmienne zmienne;
    public LosowanieGracza losowanieGracza;
    public LosowaniePytania losowaniePytania;

    public void StartTimer(){
        if(!zmienne.rPanel.activeSelf){
            zmienne.time = (float)PhotonNetwork.CurrentRoom.CustomProperties["ValueTime"];
            //if(PhotonNetwork.IsMasterClient){
                photonView.RPC("StartTimerRPC", RpcTarget.All, zmienne.time, PhotonNetwork.Time);
            //}
        }
    }
    [PunRPC]
    public IEnumerator StartTimerRPC(float czas, double startTime){
        while (zmienne.time > 0 && zmienne.buttonColor[0].GetComponent<Image>().color == Color.white){
            double elapsed = PhotonNetwork.Time - startTime;
            zmienne.time = czas - (float)elapsed;
            zmienne.timer.text = zmienne.time.ToString("0");
            yield return null;
        }
        if(zmienne.time <= 0 && zmienne.buttonColor[0].GetComponent<Image>().color == Color.white){
            Debug.Log("Przegrales");
            losowanieGracza.LoseLife(zmienne.randomPlayer);
            //losowaniePytania.RoundBreak();
            losowaniePytania.ColorButton();
            StartCoroutine(losowaniePytania.WaitAndRoundBreak());
        }
    }
}
