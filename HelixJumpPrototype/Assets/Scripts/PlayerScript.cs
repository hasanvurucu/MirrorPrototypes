using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private Transform cameraTransform;
    private float minPosY = 1f;
    private Vector3 cameraPos;
    private float offset;

    private float timer = 0f;
    private bool jumpEnabled = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cameraPos = cameraTransform.position;
        offset = transform.position.y - cameraPos.y;
    }


    void Update()
    {
        HandleCameraPosition();

        if(jumpEnabled == false)
        {
            timer += Time.deltaTime;
            if(timer >= 0.5f)
            {
                jumpEnabled = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(jumpEnabled == true)
        {
            rb.AddForce(Vector3.up * jumpForce);
            jumpEnabled = false;
        }
        if(collision.gameObject.tag == "Killer")
        {
            SceneManager.LoadScene("main");
        }
        if(collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("main");
        }

    }

    private void HandleCameraPosition()
    {
        if (transform.position.y <= minPosY)
        {
            minPosY = transform.position.y;
        }
        cameraPos.y = minPosY + 5f;
        cameraTransform.position = cameraPos;
    }
}
