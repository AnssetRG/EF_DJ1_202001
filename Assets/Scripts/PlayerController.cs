using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletPrefab;
    private Rigidbody2D myRB;
    private Animator animator;
    private string actual_tag;
    private float time_enlapsed;
    private bool is_grounded = true;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        actual_tag = "Red";
        time_enlapsed = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRB.velocity = new Vector2(-5, myRB.velocity.y);
            animator.Play("WalkingLeft");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myRB.velocity = new Vector2(5, myRB.velocity.y);
            animator.Play("WalkingRight");
        }
        else
        {
            myRB.velocity = new Vector2(0, myRB.velocity.y);
            animator.Play("Idle");
        }

        if (Input.GetKey(KeyCode.UpArrow) && is_grounded)
        {
            myRB.AddForce(Vector2.up * 500);
            is_grounded = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            time_enlapsed += Time.deltaTime;
            if (time_enlapsed > 0.25f)
            {
                GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().SetUp(Vector2.up * 5, actual_tag);
                time_enlapsed = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            actual_tag = "Brown";
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            actual_tag = "Cream";
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            actual_tag = "Fly";
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            actual_tag = "Red";
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            actual_tag = "Yellow";
        }
    }
}
