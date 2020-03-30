using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooting : MonoBehaviour
{
    // Start is called before the first frame updatepublic GameObject Ball;
    public GameObject ballPrefab;
    public float Force = 50.0f;
    public Vector3 Torque = new Vector3(100, 0, 0);
    private bool cursorLocked = false;
    void Start()
    {
        LockCursor();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject ball = (GameObject)Instantiate(ballPrefab, transform.position,
            Quaternion.identity);
            ball.name = "projectile";
            ball.transform.position = transform.TransformPoint(Vector3.forward);
            ball.GetComponent<Rigidbody>().velocity =
            transform.TransformDirection(new Vector3(0, 0, Force));
            ball.GetComponent<Rigidbody>().AddTorque(Torque);
        }
        if (Input.GetKeyDown(KeyCode.C))
            LockCursor();
    }
    void LockCursor()
    {
        if (!cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            cursorLocked = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            cursorLocked = false;
        }
    }

}
