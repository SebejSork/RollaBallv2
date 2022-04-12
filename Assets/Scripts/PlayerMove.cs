using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //public Text winText;
    //public Text countText;
    public float speed;
    private Rigidbody rb;
    public bool isP1;
    //private int count;
    float moveHorizontal;
    float moveVertical;
    private Vector3 startLoctation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //count = 0;
        //countText.text= "Count:" + count.ToString();
        //winText.text = "";
        startLoctation = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y <= -20) {
            transform.position = startLoctation;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        if (isP1) {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
            if(Input.GetKey(KeyCode.Space)) {
                rb.AddForce(0,20,0);
            }
        }
        if (!isP1) {
            moveHorizontal = Input.GetAxis("Player2Horizontal");
            moveVertical = Input.GetAxis("Player2Vertical");
        }
        
     Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

     rb.AddForce (movement * speed);
        
    }
    void OnTriggerEnter(Collider other){
        Destroy(other.gameObject);
        if (other.gameObject.CompareTag("Pick Up"))
        {other.gameObject.SetActive (false);
        //count = count + 1;
//SetCountText();
    }
}
//void SetCountText() {
    //countText.text = "Count: " + count.ToString();
    //if (count >= 12){
    //    winText.text = "You Win!";
    //}
//}
}
