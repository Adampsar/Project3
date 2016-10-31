using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public bool playerturn;
    public bool moved = false;
    public float movedirection = 0;

    public bool ___________________;

    public Vector3 destination;

    public int groundPhysicsLayerMask;
    public GameObject turncontroler;
    public Rigidbody player;
    public bool moveallowed;

    // Use this for initialization
    void Start () {
        player = GetComponent<Rigidbody>();
        turncontroler = GameObject.Find("Main Camera");
        groundPhysicsLayerMask = LayerMask.GetMask("Wall");
    }
	
	// Update is called once per frame
	void Update () {
        if (turncontroler.GetComponent<TurnUser>().playerturn == true && movedirection == 0 && moved == false)
        {
            PlayerMovment();
        }
    }

    void FixedUpdate()
    {

        if (moved == true && movedirection == 0) {    
            turncontroler.GetComponent<TurnUser>().playerturn = false;
            GetComponent<AudioSource>().Stop();
            moved = false;
        }
        if (movedirection == 1 && player.position != destination)
        {
            player.position = Vector3.Lerp(player.position, player.position + Vector3.up * 3f, .1f);
        }
        else if (movedirection == 2 && player.position != destination)
        {
            player.position = Vector3.Lerp(player.position, player.position + Vector3.down * 3f, .1f);
        }
        else if (movedirection == 3 && player.position != destination)
        {
            player.position = Vector3.Lerp(player.position, player.position + Vector3.right * 3f, .1f);
        }
        else if (movedirection == 4 && player.position != destination)
        {
            player.position = Vector3.Lerp(player.position, player.position + Vector3.left * 3f, .1f);
        }
        else {
            movedirection = 0;
        }
    }

    void PlayerMovment() {
        if (Input.GetKeyDown("w") && !Physics.Raycast(transform.position, Vector3.up, 3, groundPhysicsLayerMask))
        {
            GetComponent<AudioSource>().Play();
            movedirection = 1;
            destination = player.position + Vector3.up * 3f;
            if (transform.rotation.z != 180) {
                transform.eulerAngles = new Vector3(0, 0, 180);
            }
            moved = true;
        }
        else if (Input.GetKeyDown("s") && !Physics.Raycast(transform.position, Vector3.down, 3, groundPhysicsLayerMask))
        {
            GetComponent<AudioSource>().Play();
            movedirection = 2;
            destination = player.position + Vector3.down * 3f;
            if (transform.rotation.z != 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            moved = true;
        }
        else if (Input.GetKeyDown("d") && !Physics.Raycast(transform.position, Vector3.right, 3, groundPhysicsLayerMask))
        {
            GetComponent<AudioSource>().Play();
            movedirection = 3;
            destination = player.position + Vector3.right * 3f;
            if (transform.rotation.z != 90)
            {
                transform.eulerAngles = new Vector3(0, 0, 90);
            }
            moved = true;
        }
        else if (Input.GetKeyDown("a") && !Physics.Raycast(transform.position, Vector3.left, 3, groundPhysicsLayerMask))
        {
            GetComponent<AudioSource>().Play();
            movedirection = 4;
            destination = player.position + Vector3.left * 3f;
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
        else if (Input.GetKeyDown("r"))
        {
            Application.LoadLevel(GameObject.Find("Retry").GetComponent<MouseHover>().level);
        }
        else if (Input.GetKeyDown("q"))
        {
            Application.LoadLevel(0);
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
            coll.GetComponent<AudioSource>().Play();
            GameObject.Find("Lock").GetComponent<Collider>().enabled = false;
            GameObject.Find("Lock").GetComponent<Renderer>().enabled = false;
        }
    }
}
