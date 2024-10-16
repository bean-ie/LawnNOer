using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawnmowerController : MonoBehaviour
{

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (!Input.GetKey(KeyCode.S))
                transform.Rotate(0, -100 * Time.fixedDeltaTime, 0);
            else
                transform.Rotate(0, 100 * Time.fixedDeltaTime, 0);
            //rb.MoveRotation(Quaternion.Euler(0, -100 * Time.deltaTime, 0));
            /*if (!Input.GetKey(KeyCode.S))
                rb.AddTorque(0, -60, 0);
            else
                rb.AddTorque(0, 60, 0);*/
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (!Input.GetKey(KeyCode.S))
                transform.Rotate(0, 100 * Time.fixedDeltaTime, 0);
            else
                transform.Rotate(0, -100 * Time.fixedDeltaTime, 0);
            //rb.MoveRotation(Quaternion.Euler(0, 100 * Time.deltaTime, 0));
            /*if (!Input.GetKey(KeyCode.S))
                rb.AddTorque(0, 60, 0);
            else
                rb.AddTorque(0, -60, 0);*/
        }
        if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.forward * 500);
        }
        if (Input.GetKey(KeyCode.S)) {
            rb.AddForce(Quaternion.Euler(0, transform.eulerAngles.y, 0) * Vector3.forward * -500);
        }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(rb.velocity * -10);
        }

        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        if (transform.position.y < -5) transform.position = new Vector3(0, 0.5f, 0);
    }
}
