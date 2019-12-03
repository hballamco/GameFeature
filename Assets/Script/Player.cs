using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Serialized Fields
    [SerializeField] float vSpeed;
    [SerializeField] float hSpeed;
    [SerializeField] float Reach = 2.0f;
    [SerializeField] AudioClip warp;

    Vector3 keyPreviousPosition;
    GameObject keyObject;

    private GameController gc;
    public Vector3 offset;

    //Game Component
    Rigidbody rb;
    RaycastHit hit;
    AudioSource warpAudio;

    // Start is called before the first frame update
    void Start()
    {

        //Find the Game Controller
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        //Get Copy of the Game Controller Script
        gc = gameControllerObject.GetComponent<GameController>();
        
        rb = GetComponent<Rigidbody>();
        warpAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        keyPreviousPosition = gc.keyObj.position;
        //Switch
        var fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, Reach) && hit.transform.tag == "Key" && Input.GetKey(KeyCode.Space))
        {
            warpAudio.Play();
            gc.keyObj.position = gameObject.transform.position - offset;
            gameObject.transform.position = keyPreviousPosition + offset;
        }
    }

    void Move() // Player moves and rotates when ASWD
    {
        float verticalThrow = Input.GetAxis("Vertical");
        float horizontalThrow = Input.GetAxis("Horizontal");

        if (horizontalThrow != 0)
        {
            transform.Rotate(Vector3.up * horizontalThrow * hSpeed);
        }
        if (verticalThrow != 0)
        {
            transform.Translate(Vector3.forward * verticalThrow * vSpeed);

        }
        else
        {

        }
    }
}
