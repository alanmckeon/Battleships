using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public float gameTime, spawnFrequency = 7.0f, timeSinceSpawn;
    public Transform redSpawn, blueSpawn;
    Drone redDroneSettings;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        gameTime += Time.deltaTime;
        while (gameTime > 5.0f & timeSinceSpawn >= spawnFrequency)
        {
            spawnDrones();
            timeSinceSpawn = 0;
        }
        timeSinceSpawn += Time.deltaTime;
    }

    void spawnDrones()
    {
        GameObject redDrone = PhotonNetwork.Instantiate("Drone", redSpawn.transform.position, this.transform.rotation, 0);
        redDroneSettings = redDrone.GetComponent<Drone>();
        redDroneSettings.team = "Red";
        redDroneSettings.lane = "N";
        GameObject redDrone2 = PhotonNetwork.Instantiate("Drone", redSpawn.transform.position, this.transform.rotation, 0);
        redDroneSettings = redDrone2.GetComponent<Drone>();
        redDroneSettings.team = "Red";
        redDroneSettings.lane = "C";
        GameObject redDrone3 = PhotonNetwork.Instantiate("Drone", redSpawn.transform.position, this.transform.rotation, 0);
        redDroneSettings = redDrone3.GetComponent<Drone>();
        redDroneSettings.team = "Red";
        redDroneSettings.lane = "S";

    }
    
}
