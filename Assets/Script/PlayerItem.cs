using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.Sprites;
public class PlayerItem : MonoBehaviourPunCallbacks{
    public TextMeshProUGUI playerName;
    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    public Image playerAvatar;
    public Sprite[] avatars;
    Player player;
    public GameObject button;
    public void SetPlayerInfo(Player _player){
        playerName.text = _player.NickName;
        player = _player;
        UpdatePlayerItem(player);
    }
    public void RandomAvatar(){
        playerProperties["playerAvatar"] = Random.Range(0, avatars.Length - 1);
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }
    public void ApplyLocalChanges(){
        button.SetActive(true);
    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if(player == targetPlayer){
            UpdatePlayerItem(targetPlayer);
        }
    }
    void UpdatePlayerItem(Player player){
        if(player.CustomProperties.ContainsKey("playerAvatar")){
            playerAvatar.sprite = avatars[(int)player.CustomProperties["playerAvatar"]];
            playerProperties["playerAvatar"] = (int)player.CustomProperties["playerAvatar"];
        }else{
            playerProperties["playerAvatar"] = 0;
        }
    }
}