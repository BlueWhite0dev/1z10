using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEditor;
using System.Collections;
public class GUIInGame : MonoBehaviourPunCallbacks{
    public Zmienne zmienne;
    public LosowanieGracza losowanieGracza;
    bool isActive;
    int sinus;
    private void Start() {
        zmienne.rButton.SetActive(PhotonNetwork.IsMasterClient);
    }
    public void Update() {
        if(!zmienne.rPanel.activeSelf){
            if(zmienne.playerCountText != null){
            zmienne.playerCountText.text = $"{zmienne.activePlayers}/{zmienne.playersInRoom.Count.ToString()}";
            }
            var randomPlayerInstr = zmienne.randomPlayer != null && zmienne.randomPlayer.NickName != "" && zmienne.randomPlayer.CustomProperties["Lives"] != null;
            if(zmienne.healthText.text != null && randomPlayerInstr){
                if(PhotonNetwork.LocalPlayer.ActorNumber == PhotonNetwork.PlayerList[zmienne.randomIndex].ActorNumber){
                    zmienne.nameTitle.text = "Ty!";
                }else{
                    zmienne.nameTitle.text = zmienne.randomPlayer.NickName;
                }
                zmienne.healthText.text = $"{(int)zmienne.randomPlayer.CustomProperties["Lives"]}" + "/3";
            }
        }
    }
}