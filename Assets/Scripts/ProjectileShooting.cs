using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooting : MonoBehaviour
{
    public GameObject projectile;
    public float force = 50f;
    public Vector3 torque = new Vector3(100, 0, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectile = (GameObject)Instantiate(this.projectile, transform.position,
            Quaternion.identity);
            projectile.name = "projectile";
            projectile.transform.position = transform.TransformPoint(Vector3.forward);
            projectile.GetComponent<Rigidbody>().velocity =
            transform.TransformDirection(new Vector3(0, 0, force));
            projectile.GetComponent<Rigidbody>().AddTorque(torque);
        }
    }
}
