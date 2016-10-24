using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float movedistence;
    public float delaystall;
    public bool ___________________;

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
        if (turncontroler.GetComponent<TurnUser>().playerturn == false && movesleft > 0)
        {
            if (delay < Time.time)
            {
                delay = Time.time + delaystall;
                Enemymove();
                movesleft--;
            }
        }
        else
        {
            turncontroler.GetComponent<TurnUser>().playerturn = true;
            movesleft = movedistence;
        }
    }

    void Enemymove()
    {
            playerposition = GameObject.Find("player").transform.position;
            enemyposition = enemy.transform.position;
            if (playerposition.y - .5f > enemyposition.y && !Physics.Raycast(transform.position, Vector3.up, 3, groundPhysicsLayerMask))
            {
                enemy.position = enemy.position + Vector3.up * 3f;
                if (transform.rotation.z != 180)
                {
                    transform.eulerAngles = new Vector3(0, 0, 180);
                }
            }
            else if (playerposition.y + .5f < enemyposition.y && !Physics.Raycast(transform.position, Vector3.down, 3, groundPhysicsLayerMask))
            {
                enemy.position = enemy.position + Vector3.down * 3f;
                if (transform.rotation.z != 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }
            else if (playerposition.x - .5f > enemyposition.x && !Physics.Raycast(transform.position, Vector3.right, 3, groundPhysicsLayerMask))
            {
                enemy.position = enemy.position + Vector3.right * 3f;
                if (transform.rotation.z != 90)
                {
                    transform.eulerAngles = new Vector3(0, 0, 90);
                }
            }
            else if (playerposition.x + .5f < enemyposition.x && !Physics.Raycast(transform.position, Vector3.left, 3, groundPhysicsLayerMask))
            {
                enemy.position = enemy.position + Vector3.left * 3f;
                if (transform.rotation.z != 270)
                {
                    transform.eulerAngles = new Vector3(0, 0, 270);
                }
            }
    }
}
