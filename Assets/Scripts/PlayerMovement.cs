using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float forwardForce = 500f;
    public float horizontalForce = 50f;
    public Vector3 right = new Vector3(0.1f, 0f, 0f);

	// Use this for initialization
	void Start () {
        rb.useGravity = true;
	}

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(horizontalForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }else if (Input.GetKey("q"))
        {
            rb.AddForce(-horizontalForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        //if (Input.GetKey("d"))
        //{
        //    if (rb.position.x >= 5 && rb.position.x < 6)
        //    {
        //        Debug.Log("In first if.");
        //        rb.MovePosition(new Vector3(15, rb.position.y, rb.position.z));
        //    }
        //    else if (rb.position.x < 5)
        //    {
        //        Debug.Log("In second if");
        //        rb.MovePosition(new Vector3(5, rb.position.y, rb.position.z));
        //    }
        //}
    }
}
