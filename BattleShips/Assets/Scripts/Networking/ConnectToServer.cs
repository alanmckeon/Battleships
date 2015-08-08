using UnityEngine;
using System.Collections;

public class ConnectToServer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings("v1.0");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnConnectedToMaster ()
    {
                try {
            PhotonNetwork.JoinRandomRoom();
        }
        catch
        {
            Debug.Log("Failed to join Random Room");
        }
        try
        {
            Debug.Log("Creating Room..");
            PhotonNetwork.CreateRoom(null);
        }
        catch
        {
            Debug.LogError("Failed to Create Room");
        }
    }
}
