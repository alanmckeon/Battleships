using UnityEngine;
using System.Collections;

public class ConnectToServer : MonoBehaviour {

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

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

    void OnCreatedRoom()
    {
        PhotonNetwork.Instantiate("gameController", this.transform.position, this.transform.rotation, 0);
    }
}
