using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
public class LosowanieGracza : MonoBehaviourPunCallbacks{
    public Zmienne zmienne;
    public BreakScript breakScript;
    // metoda wywoływana przy wejściu nowego gracza do pokoju
    public override void OnPlayerEnteredRoom(Player newPlayer){
        if((bool)PhotonNetwork.CurrentRoom.CustomProperties["Admin"]){
            // dodanie nowego gracza do listy
                zmienne.playerList.Add(newPlayer.NickName);
                zmienne.playersInRoom.Add(newPlayer);
        }else{
            if(!newPlayer.IsMasterClient){
                // dodanie nowego gracza do listy
                zmienne.playerList.Add(newPlayer.NickName);
                zmienne.playersInRoom.Add(newPlayer);
            }
        }
    }
    // metoda wywoływana przy opuszczeniu pokoju przez gracza
    public override void OnPlayerLeftRoom(Player otherPlayer){
        // usunięcie gracza z listy
        zmienne.playerList.Remove(otherPlayer.NickName);
        zmienne.playersInRoom.Remove(otherPlayer);
    }
    public void Start() {
        // pobranie aktualnej listy graczy z pokoju
        Player[] playerArray = PhotonNetwork.PlayerList;
        // dodanie 3 żyć dla każdego gracza
        for (int i = 0; i < playerArray.Length; i++){
            int playerIndex = playerArray[i].ActorNumber - 1;
            playerArray[i].SetCustomProperties(new ExitGames.Client.Photon.Hashtable() { { "Lives", 3 } });
        }
        // dodanie nicków graczy do naszej listy
        foreach (Player player in playerArray)
        {
            if((bool)PhotonNetwork.CurrentRoom.CustomProperties["Admin"]){
                zmienne.playerList.Add(player.NickName);
                zmienne.playersInRoom.Add(player);
            }else{
                if(!player.IsMasterClient){
                    zmienne.playerList.Add(player.NickName);
                    zmienne.playersInRoom.Add(player);
                }
            }
        }

        // aktualizacja liczby graczy w elemencie Text
        zmienne.playerCountText.text = zmienne.playerList.Count.ToString();
    }
    public void LoseLife(Player player){
        if(PhotonNetwork.IsMasterClient){
            int lives = (int)player.CustomProperties["Lives"];
            player.SetCustomProperties(new ExitGames.Client.Photon.Hashtable() { { "Lives", lives - 1 }});
        }
    }



    private void Update() {
        zmienne.activePlayers = 0;
        foreach(Player player in zmienne.playersInRoom){
            if(player.CustomProperties["Lives"] != null){
                int lives = (int)player.CustomProperties["Lives"];
                if (lives > 0){
                    zmienne.activePlayers++;
                    }
                }
        }
    }
    public void losowanieGracza(){
        if (PhotonNetwork.IsMasterClient){
            if((bool)PhotonNetwork.CurrentRoom.CustomProperties["Admin"]){
                do{
                    zmienne.randomIndex = Random.Range(0, PhotonNetwork.PlayerList.Length);
                    zmienne.randomPlayer = PhotonNetwork.PlayerList[zmienne.randomIndex];
                }while((int)zmienne.randomPlayer.CustomProperties["Lives"] <= 0 || zmienne.losowanie == zmienne.randomIndex);
            }else{
                do{
                    zmienne.randomIndex = Random.Range(0, PhotonNetwork.PlayerList.Length);
                    zmienne.randomPlayer = PhotonNetwork.PlayerList[zmienne.randomIndex];
                }while((int)zmienne.randomPlayer.CustomProperties["Lives"] <= 0 || zmienne.randomPlayer.IsMasterClient || zmienne.losowanie == zmienne.randomIndex);
            }
            zmienne.losowanie = zmienne.randomIndex;

            Debug.Log("Gracz wylosowany: " + zmienne.randomPlayer.NickName);
            photonView.RPC("SetPlayer", RpcTarget.Others, zmienne.randomIndex);
            }
    }
    [PunRPC]
    public void SetPlayer(int playerIndex){
        zmienne.randomIndex = playerIndex;
        zmienne.randomPlayer = PhotonNetwork.PlayerList[zmienne.randomIndex];
    }
}