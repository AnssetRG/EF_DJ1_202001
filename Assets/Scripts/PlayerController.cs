using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletPrefab;
    private Rigidbody2D myRB;
    private BoxCollider2D collider2D;
    private Animator animator;
    private string actual_tag;
    private float time_enlapsed;
    [SerializeField]
    private LayerMask platform_layer;
    private bool is_grounded = true;
    private float distance_to_ground;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2D = GetComponent<BoxCollider2D>();
        actual_tag = "Red";
        time_enlapsed = 0.25f;
        distance_to_ground = collider2D.bounds.extents.y;
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
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded())
        {
            myRB.AddForce(Vector2.up * 100);
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

    bool isGrounded()
    {
        float extraHeight = 0.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(collider2D.bounds.center, Vector2.down, collider2D.bounds.extents.y + extraHeight, platform_layer);
        Color rayColor;
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
            Debug.Log(raycastHit.collider.name);
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(collider2D.bounds.center, Vector2.down * (collider2D.bounds.extents.y + extraHeight), rayColor, 0.1f);
        return raycastHit.collider != null;
    }
}
