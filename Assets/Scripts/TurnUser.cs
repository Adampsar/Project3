using UnityEngine;
using System.Collections;

public class TurnUser : MonoBehaviour {

    public bool playerturn;
    public bool leveladvance = false;
    public int level;
    public bool dead = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //playerturn = true;
        if (GameObject.Find("Enemy") == null) {
            playerturn = true;
        }
        if (playerturn == true) {
            GameObject.Find("player").GetComponent<Player>().playerturn = true;
        }
        else {
            GameObject.Find("player").GetComponent<Player>().playerturn = false;
        }

        if (dead == true) {
            GameObject.Find("Quit").GetComponent<MeshRenderer>().enabled = true;
            GameObject.Find("Quit").GetComponent<Collider>().enabled = true;

            GameObject.Find("Retry").GetComponent<MeshRenderer>().enabled = true;
            GameObject.Find("Retry").GetComponent<Collider>().enabled = true;

            GameObject.Find("GAME OVER").GetComponent<MeshRenderer>().enabled = true;
        }
        if (leveladvance == true) {
            Application.LoadLevel(level);
        }
    }

    void FixedUpdate()
    {
        
    }
}
