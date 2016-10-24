using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public bool playerturn;
    public bool moved = false;

    public bool ___________________;

    public int groundPhysicsLayerMask;
    public GameObject turncontroler;
    public Rigidbody player;

    // Use this for initialization
    void Start () {
        player = GetComponent<Rigidbody>();
        turncontroler = GameObject.Find("Main Camera");
        groundPhysicsLayerMask = LayerMask.GetMask("Wall");
    }
	
	// Update is called once per frame
	void Update () {
        if (turncontroler.GetComponent<TurnUser>().playerturn == true)
        {
            PlayerMovment();
        }
    }

    void FixedUpdate()
    {
        if (moved == true) {
            turncontroler.GetComponent<TurnUser>().playerturn = false;
            moved = false;
        }
    }

    void PlayerMovment() {
        if (Input.GetKeyDown("w") && !Physics.Raycast(transform.position, Vector3.up, 3, groundPhysicsLayerMask))
        {
            player.position = player.position + Vector3.up * 3f;
            if (transform.rotation.z != 180) {
                transform.eulerAngles = new Vector3(0, 0, 180);
            }
            moved = true;
        }
        else if (Input.GetKeyDown("s") && !Physics.Raycast(transform.position, Vector3.down, 3, groundPhysicsLayerMask))
        {
            player.position = player.position + Vector3.down * 3f;
            if (transform.rotation.z != 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            moved = true;
        }
        else if (Input.GetKeyDown("d") && !Physics.Raycast(transform.position, Vector3.right, 3, groundPhysicsLayerMask))
        {
            player.position = player.position + Vector3.right * 3f;
            if (transform.rotation.z != 90)
            {
                transform.eulerAngles = new Vector3(0, 0, 90);
            }
            moved = true;
        }
        else if (Input.GetKeyDown("a") && !Physics.Raycast(transform.position, Vector3.left, 3, groundPhysicsLayerMask))
        {
            player.position = player.position + Vector3.left * 3f;
            if (transform.rotation.z != 270)
            {
                transform.eulerAngles = new Vector3(0, 0, 270);
            }
            moved = true;
        }
        else if (Input.GetKeyDown("space"))
        {
            moved = true;
        }
    }

    void OnTriggerEnter(Collider collision) {
        GameObject coll = collision.gameObject;
        if (coll.tag == "Enemy")
        {
            GameObject.Find("Main Camera").GetComponent<TurnUser>().dead = true;
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
        else if (coll.tag == "Exit")
        {
            GameObject.Find("Main Camera").GetComponent<TurnUser>().leveladvance = true;
        }
        else if (coll.tag == "Key") {
            coll.GetComponent<Renderer>().enabled = false;
            coll.GetComponent<Collider>().enabled = false;
            GameObject.Find("Lock").GetComponent<Collider>().enabled = false;
            GameObject.Find("Lock").GetComponent<Renderer>().enabled = false;
        }
    }
}
