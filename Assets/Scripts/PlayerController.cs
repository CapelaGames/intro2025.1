using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 input;
    private Camera playerCamera;

    private bool grounded = false;
    private int score = 0;
    private int totalCollectables;
    private float timer = 0;

    public TMP_Text scoreText;
    public TMP_Text timerText;

    public float speed = 500f;
    public float walkSpeed = 500f;
    public float sprintSpeed = 1000f;
    public float jumpSpeed = 1000f;

    void Start()
    {
        totalCollectables = GameObject.FindGameObjectsWithTag("Collectable").Length;
        scoreText.text = "0 / " + totalCollectables;

        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main;
    }

    void Update()
    {
        //INCLUDE THIS AT TOP using UnityEngine.SceneManagement;
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (transform.position.y < -40f)
        {
            SceneManager.LoadScene(0);
        }

        if (score < totalCollectables)
        {
            timer += Time.deltaTime;
        }
        //Mathf.Round(timer * 100) / 100;
        //Mathf.Floor
        //Mathf.Ceil
        timerText.text = "Time: " + timer.ToString("F2");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = walkSpeed;
        }

        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        input.Normalize();

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rb.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        Transform cam = playerCamera.transform;

        //new Vector3(input.x, 0f, input.y)
        Vector3 moveDirection = (cam.right * input.x + cam.forward * input.y);
        moveDirection.y = 0f;
        moveDirection.Normalize();
        rb.AddForce(moveDirection * speed * Time.deltaTime);
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Collectable")
        {
            score++;
            scoreText.text = score + " / " + totalCollectables;
            Destroy(other.gameObject);
        }
    }
}
