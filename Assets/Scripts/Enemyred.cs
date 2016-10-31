using UnityEngine;
using System.Collections;

public class Enemyred : MonoBehaviour {

    public float movedistence;
    public float delaystall;
    public float movedirection = 0;

    public bool ___________________;

    public bool wall = false;
    public Vector3 destination;
    public Vector3 walldestionation;
    public float delay;
    public Vector3 playerposition;
    public Vector3 enemyposition;
    public int groundPhysicsLayerMask;
    public GameObject turncontroler;
    public Rigidbody enemy;
    public float movesleft;

    // Use this for initialization
    void Start () {
        enemy = GetComponent<Rigidbody>();
        turncontroler = GameObject.Find("Main Camera");
        groundPhysicsLayerMask = LayerMask.GetMask("Wall");
        movesleft = movedistence;
    }
	
	// Update is called once per frame
	void Update () {

	}

    void FixedUpdate()
    {

        if (turncontroler.GetComponent<TurnUser>().playerturn == true)
        {
            movesleft = movedistence;
        }
        if (turncontroler.GetComponent<TurnUser>().playerturn == false && movesleft > 0 && movedirection == 0)
        {
            GetComponent<AudioSource>().Play();
            Enemymove();
            movesleft--;
        }
        else if(movesleft == 0 && wall == false)
        {
            turncontroler.GetComponent<TurnUser>().playerturn = true;
            movesleft = movedistence;
        }

        if (movedirection == 1 && enemy.position != destination)
        {
            enemy.position = Vector3.Lerp(enemy.position, destination, .5f);
        }
        else if (movedirection == 2 && enemy.position != destination)
        {
            enemy.position = Vector3.Lerp(enemy.position, destination, .5f);
        }
        else if (movedirection == 3 && enemy.position != destination)
        {
            enemy.position = Vector3.Lerp(enemy.position, destination, .5f);
        }
        else if (movedirection == 4 && enemy.position != destination)
        {
            enemy.position = Vector3.Lerp(enemy.position, destination, .5f);
        }
        else if (wall == true && movedirection < 5) {
            movedirection = movedirection + 4;
        }
        //===============================================================================
        //===============================================================================
        else if (movedirection == 5 && enemy.position != walldestionation && wall == true)
        {
            enemy.position = Vector3.Lerp(enemy.position, walldestionation, .5f);
        }
        else if (movedirection == 6 && enemy.position != walldestionation && wall == true)
        {
            enemy.position = Vector3.Lerp(enemy.position, walldestionation, .5f);
        }
        else if (movedirection == 7 && enemy.position != walldestionation && wall == true)
        {
            enemy.position = Vector3.Lerp(enemy.position, walldestionation, .5f);
        }
        else if (movedirection == 8 && enemy.position != walldestionation && wall == true)
        {
            enemy.position = Vector3.Lerp(enemy.position, walldestionation, .5f);
        }
        else
        {
            wall = false;
            movedirection = 0;
        }
    }

    void Enemymove()
    {
            playerposition = GameObject.Find("player").transform.position;
            enemyposition = enemy.transform.position;
        if (playerposition.x - .5f > enemyposition.x)
        {
            movedirection = 3;
            if (!Physics.Raycast(transform.position, Vector3.right, 3, groundPhysicsLayerMask))
            {
                destination = enemy.position + Vector3.right * 3f;
                if (transform.rotation.z != 180)
                {
                    transform.eulerAngles = new Vector3(0, 0, 90);
                }
            }
            else
            {
                wall = true;
                destination = enemy.position + Vector3.right * .5f;
                walldestionation = enemy.position;
                if (transform.rotation.z != 180)
                {
                    transform.eulerAngles = new Vector3(0, 0, 90);
                }
            }
        }

        else if (playerposition.x + .5f < enemyposition.x)
        {
            movedirection = 4;
            if (!Physics.Raycast(transform.position, Vector3.left, 3, groundPhysicsLayerMask))
            {
                destination = enemy.position + Vector3.left * 3f;
                if (transform.rotation.z != 270)
                {
                    transform.eulerAngles = new Vector3(0, 0, 270);
                }
            }
            else
            {
                wall = true;
                destination = enemy.position + Vector3.left * .5f;
                walldestionation = enemy.position;
                if (transform.rotation.z != 270)
                {
                    transform.eulerAngles = new Vector3(0, 0, 270);
                }
            }
        }

        else if (playerposition.y - .5f > enemyposition.y)
            {
                movedirection = 1;
                if (!Physics.Raycast(transform.position, Vector3.up, 3, groundPhysicsLayerMask))
                {
                    destination = enemy.position + Vector3.up * 3f;
                    if (transform.rotation.z != 180)
                    {
                        transform.eulerAngles = new Vector3(0, 0, 180);
                    }
                }
                else {
                    wall = true;
                    destination = enemy.position + Vector3.up * .5f;
                    walldestionation = enemy.position;
                    if (transform.rotation.z != 180)
                    {
                        transform.eulerAngles = new Vector3(0, 0, 180);
                    }
                }
            }
        else if (playerposition.y + .5f < enemyposition.y)
        {
            movedirection = 2;
            if (!Physics.Raycast(transform.position, Vector3.down, 3, groundPhysicsLayerMask))
            {
                destination = enemy.position + Vector3.down * 3f;
                if (transform.rotation.z != 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }
            else
            {
                wall = true;
                destination = enemy.position + Vector3.down * .5f;
                walldestionation = enemy.position;
                if (transform.rotation.z != 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }
        }
    }
}
