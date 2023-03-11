using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using UnityEngine.UI;

public class BreakScript : MonoBehaviourPunCallbacks{
    public Zmienne zmienne;
    public Timer timer;
    public LosowaniePytania losowaniePytania;
    public LosowanieGracza losowanieGraczaTU;
    public GUIInGame guiInGame;
    public double startTime;
    private bool isBreakStopped = false;

    public void Update() {
        if(!zmienne.rPanel.activeSelf){
            Widocznosc();
        }
        zmienne.rTextPlayer.text = "";
        int playerNumber = 1;
        foreach (Player player in PhotonNetwork.PlayerList){
            if(player.CustomProperties.ContainsKey("Lives")){
                if((bool)PhotonNetwork.CurrentRoom.CustomProperties["Admin"]){
                    if((int)player.CustomProperties["Lives"] <= 0){
                        zmienne.rTextPlayer.text += "<color=red>" + playerNumber + ". " + player.NickName + "</color=red>" + " - " + player.CustomProperties["Lives"] + " HP - <b>ODPADŁ</b>" + "\n";
                    }else{
                        if(zmienne.activePlayers == 1){
                        zmienne.rTextPlayer.text += "<color=yellow>" + playerNumber + ". " + player.NickName + "</color=yellow>" + " - " + player.CustomProperties["Lives"] + " HP - <b>WYGRAŁ</b>" + "\n";
                        }else{
                            zmienne.rTextPlayer.text += playerNumber + ". " + player.NickName + " - " + player.CustomProperties["Lives"] + " HP" + "\n";
                        }
                    }
                    playerNumber++;
                }else{
                    if(!player.IsMasterClient){

                        if((int)player.CustomProperties["Lives"] <= 0){
                            zmienne.rTextPlayer.text += "<color=red>" + playerNumber + ". " + player.NickName + "</color=red>" + " - " + player.CustomProperties["Lives"] + " HP - <b>ODPADŁ</b>" + "\n";
                        }else{
                            if(zmienne.activePlayers == 1){
                            zmienne.rTextPlayer.text += "<color=yellow>" + playerNumber + ". " + player.NickName + "</color=yellow>" + " - " + player.CustomProperties["Lives"] + " HP - <b>WYGRAŁ</b>" + "\n";
                            }else{
                                zmienne.rTextPlayer.text += playerNumber + ". " + player.NickName + " - " + player.CustomProperties["Lives"] + " HP" + "\n";
                            }
                        }
                        playerNumber++;
                    }
                }
            }
        }
    }


    [PunRPC]
    public void SetRPanelActive(bool isActive) {
        zmienne.rPanel.SetActive(false);
    }
    public void StopBreak(){
        photonView.RPC("StopBreakRPC", RpcTarget.All);
    }
    public override void OnLeftRoom(){
        PhotonNetwork.LocalPlayer.CustomProperties.Clear();
        PhotonNetwork.LoadLevel("Lobby");
    }

    [PunRPC]
    public void StopBreakRPC(){
        if(zmienne.activePlayers <= 1){
            PhotonNetwork.LeaveRoom();
        }else{
            photonView.RPC("SetRPanelActive", RpcTarget.Others, false); //! 3
            losowaniePytania.Awakes(); //! 1 PYTANIE
            //guiInGame.ZdjeciaW();
            losowanieGraczaTU.losowanieGracza(); //! 2 GRACZ
            zmienne.rPanel.SetActive(false); //! 3 PANEL
            if((bool)PhotonNetwork.CurrentRoom.CustomProperties["TIMEON"]){
                timer.StartTimer(); //! 4 CZAS
            }else{
                zmienne.timer.text = "UNLIMIT";
            }
        }
    }
    public void StartTimer(){
        if(zmienne.rPanel.activeSelf){
            StartCoroutine(TimerCoroutine());
        }
    }
    private IEnumerator TimerCoroutine() {
        float remainingTime = 10f;
        float startTime = (float)PhotonNetwork.Time;
        while (remainingTime > 0f && zmienne.rPanel.activeSelf) {
            double elapsed = PhotonNetwork.Time - startTime;
            remainingTime = 10f - (float)elapsed;
            yield return null;
        }
        if(zmienne.rPanel.activeSelf) {
            StopBreak();
        }
    }
    //public void Widocznosc(){
    //
    //}
    //[PunRPC]
    public void Widocznosc(){
        if(PhotonNetwork.LocalPlayer.ActorNumber == PhotonNetwork.PlayerList[zmienne.randomIndex].ActorNumber && zmienne.buttonColor[0].GetComponent<Image>().color == Color.white){
            zmienne.button[0].interactable = true;
            zmienne.button[1].interactable = true;
            zmienne.button[2].interactable = true;
            zmienne.button[3].interactable = true;
        }else{
            zmienne.button[0].interactable = false;
            zmienne.button[1].interactable = false;
            zmienne.button[2].interactable = false;
            zmienne.button[3].interactable = false;
        }
    }
}