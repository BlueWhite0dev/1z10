using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class LobbyManager : MonoBehaviourPunCallbacks{
    public LobbyGUI lobbyGUI;
    public TMP_InputField roomInputField;
    public GameObject lobbyPanel;
    public GameObject roomPanel;
    public TextMeshProUGUI roomName;
    public RoomItem roomItemPrefab;
    List<RoomItem> roomItemsList = new List<RoomItem>();
    public Transform contentObject;
    public float timeBetweenUpdates = 1.5f;
    float nextUpdateTime;
    public List<PlayerItem> playerItemsList = new List<PlayerItem>();
    public PlayerItem playerItemPrefab;
    public Transform playerItemParent;
    public GameObject playButton;
    public Button startButton;
    [Header("Settings Room")]
    public Toggle[] Categories;
    public Toggle Admin;
    public Toggle timerON;
    public TextMeshProUGUI timerT;
    public TextMeshProUGUI TextPlayer;
    int currentCount;
    private void Start() {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.JoinLobby();
    }
    public void OnClickCreate(){
        lobbyGUI.Sprawdzanie();
        if(roomInputField.text.Length >= 1){
            /*
            0.EE08
            1.SOPER
            2.ELSK
            3.UTK
            4.LSBD
            */
            var cat = Categories[1].isOn || Categories[2].isOn || Categories[3].isOn || Categories[4].isOn;
            if(cat && !Categories[0].isOn || !cat && Categories[0].isOn){
                RoomOptions roomOptions = new RoomOptions();
                roomOptions.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable();
                roomOptions.CustomRoomProperties.Add("EE08", Categories[0].isOn);
                roomOptions.CustomRoomProperties.Add("SOPER", Categories[1].isOn);
                roomOptions.CustomRoomProperties.Add("ELSK", Categories[2].isOn);
                roomOptions.CustomRoomProperties.Add("UTK", Categories[3].isOn);
                roomOptions.CustomRoomProperties.Add("Admin", Admin.isOn);
                roomOptions.CustomRoomProperties.Add("TIMEON", timerON.isOn);
                if(timerON.isOn){
                    float timer = float.Parse(timerT.text);
                    roomOptions.CustomRoomProperties.Add("ValueTime", timer);
                }else{
                    roomOptions.CustomRoomProperties.Add("ValueTime", 0);
                }
                PhotonNetwork.CreateRoom(roomInputField.text, roomOptions);
            }
        }
    }

    public override void OnJoinedRoom()
    {
        lobbyPanel.SetActive(false);
        roomPanel.SetActive(true);
        roomName.text = "Nazwa pokoju: " + PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if(Time.time >= nextUpdateTime){
            UpdateRoomList(roomList);
            nextUpdateTime = Time.time + timeBetweenUpdates;
        }
    }
    void UpdateRoomList(List<RoomInfo> list){
        foreach(RoomItem item in roomItemsList){
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();
        foreach(RoomInfo room in list){
            RoomItem newRoom = Instantiate(roomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            roomItemsList.Add(newRoom);
        }
    }
    public void JoinRoom(string roomName){
        PhotonNetwork.JoinRoom(roomName);
    }
    public void OnClickLeaveRoom(){
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    void UpdatePlayerList(){
        foreach(PlayerItem item in playerItemsList){
            Destroy(item.gameObject);
        }
        playerItemsList.Clear();
        if(PhotonNetwork.CurrentRoom == null){
            return;
        }
        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players){
            PlayerItem newPlayerItem = Instantiate(playerItemPrefab, playerItemParent);
            newPlayerItem.SetPlayerInfo(player.Value);
            playerItemsList.Add(newPlayerItem);
            if(player.Value == PhotonNetwork.LocalPlayer){
                newPlayerItem.ApplyLocalChanges();
            }
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        var minPlayer = PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 3 && !(bool)PhotonNetwork.CurrentRoom.CustomProperties["Admin"];
        var MinPlayerT = PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 2 && (bool)PhotonNetwork.CurrentRoom.CustomProperties["Admin"];
        if(currentCount >= 20){
            TextPlayer.text = "";
            currentCount = 0;
        }
        UpdatePlayerList();
        TextPlayer.text += "Gracz " + newPlayer.NickName + " dołączył do pokoju.\n";
        if(minPlayer || MinPlayerT){
            TextPlayer.text += "Można rozpocząć grę!\n";
        }
        currentCount++;
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        var minPlayer = PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 3 && !(bool)PhotonNetwork.CurrentRoom.CustomProperties["Admin"];
        var MinPlayerT = PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 2 && (bool)PhotonNetwork.CurrentRoom.CustomProperties["Admin"];
        if(currentCount >= 20){
            TextPlayer.text = "";
            currentCount = 0;
        }
        UpdatePlayerList();
        TextPlayer.text += "Gracz " + otherPlayer.NickName + " opuścił pokój.\n";
        if(minPlayer || MinPlayerT){
            TextPlayer.text += "Można rozpocząć grę!\n";
        }
        currentCount++;
    }
    private void Update() {
        var minPlayer = PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 3 && !(bool)PhotonNetwork.CurrentRoom.CustomProperties["Admin"];
        var MinPlayerT = PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount >= 2 && (bool)PhotonNetwork.CurrentRoom.CustomProperties["Admin"];

        if(minPlayer || MinPlayerT){
            playButton.SetActive(true);
        }else{
            playButton.SetActive(false);
        }
    }
    public void OnClickPlayButton(){
        PhotonNetwork.CurrentRoom.IsOpen = false;
        startButton.interactable = false;
        PhotonNetwork.LoadLevel("Game");
    }
}