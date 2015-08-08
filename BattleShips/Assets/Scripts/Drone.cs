using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour
{
    //variables
    public GameObject target, weapon, blueBase, redBase, hardPoint;
    public GameObject currentWaypoint, firstWaypoint, secondWaypoint, thirdWaypoint, enemyBase;
    public float shipSpeed = 1.0f , turnSpeed = 1.0f;
    public string team, lane, enemyTag, enemyBaseTag;
    public GameObject N1, N2, N3, C1, C2, C3, S1, S2, S3;
    Quaternion targetRotation;

    // Use this for initialization
    void Start()
    {
        if (team == "Red")
        {
            this.gameObject.tag = "RedTeam";
            enemyTag = "BlueTeam";
            enemyBaseTag = "BlueBase";
            enemyBase = blueBase;

            if (lane == "N")
            {
                firstWaypoint = N1;
                secondWaypoint = N2;
                thirdWaypoint = N3;
            }
            if (lane == "C")
            {
                firstWaypoint = C1;
                secondWaypoint = C2;
                thirdWaypoint = C3;
            }
            if (lane == "S")
            {
                firstWaypoint = S1;
                secondWaypoint = S2;
                thirdWaypoint = S3;
            }
        }
        else if(team == "blue")
        {
            this.gameObject.tag = "BlueTeam";
            enemyTag = "RedTeam";
            enemyBaseTag = "RedBase";
            enemyBase = redBase;

            if (lane == "N")
            {
                firstWaypoint = N3;
                secondWaypoint = N2;
                thirdWaypoint = N1;
            }
            if (lane == "C")
            {
                firstWaypoint = C3;
                secondWaypoint = C2;
                thirdWaypoint = C1;
            }
            if (lane == "S")
            {
                firstWaypoint = S3;
                secondWaypoint = S2;
                thirdWaypoint = S1;
            }
        }
        currentWaypoint = firstWaypoint;
        target = currentWaypoint;
    }

    // Update is called once per frame
    void Update()
    {
        faceTarget();
        moveTowardsTarget();
        fireAtTarget();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == enemyTag)
        {
            target = other.gameObject;
        }
        if ((other.tag == "Waypoint") & (currentWaypoint = firstWaypoint))
        {
            currentWaypoint = secondWaypoint;
            target = currentWaypoint;
        } else if ((other.tag == "Waypoint") & (currentWaypoint = secondWaypoint))
        {
            currentWaypoint = thirdWaypoint;
        } else if ((other.tag == "Waypoint") & (currentWaypoint = thirdWaypoint))
        {
            currentWaypoint = enemyBase;
            target = currentWaypoint;
        }
        Debug.Log("Hit Trigger");
    }
    void OnTriggerExit(Collider other)
    {
        target = currentWaypoint;
    }
    void faceTarget()
    {

        targetRotation = Quaternion.LookRotation(target.transform.position - this.transform.position);
        transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * turnSpeed);
        Debug.Log("Rotating...");
    }
    void moveTowardsTarget()
    {
      //  if (target != currentWaypoint)
     //   {
            transform.Translate(Vector3.forward * shipSpeed * Time.deltaTime);
        Debug.Log("Moving...");
      //  }
    }
    void fireAtTarget()
    {
        if(target.tag == enemyTag)
        {
            Network.Instantiate(weapon, hardPoint.transform.position, hardPoint.transform.rotation, 1);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            Vector3 pos = transform.localPosition;
            stream.Serialize(ref pos);
        }
        else
        {
            Vector3 pos = Vector3.zero;
            stream.Serialize(ref pos);
        }
    }

}
