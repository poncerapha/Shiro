using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    public float moveSpeed;
    public static PlayerMovement instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        playerRB = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(this.transform.position.y, bottomLeftLimit.y, topRightLimit.y), this.transform.position.z);
    }

    private void Move()
    {
        var verticalInput = Input.GetAxisRaw("Vertical");
        var horizontalInput = Input.GetAxisRaw("Horizontal");

        playerRB.velocity = new Vector2(horizontalInput, verticalInput) * moveSpeed;

    }

    public void SetBounds(Vector3 botLeft, Vector3 topRight)
    {
        bottomLeftLimit = botLeft + new Vector3(0.5f, 1f, 0f);
        topRightLimit = topRight + new Vector3(-0.5f, -1f, 0f);
    }
}
