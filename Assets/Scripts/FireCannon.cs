using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireCannon : MonoBehaviour
{

    public GameObject cannonball;
    public float cannonballSpeed = 10;
    public Transform pof;
    public Transform barrel;
    public AudioSource audioSource;
    public Text counter;
    public Button start;

    private void Start()
    {
       int timerCount = 10;
       bool timerActive = false;
    }


    // Update is called once per frame
    void Update()
    {
        //float rotateCannon = Input.GetAxis("Mouse X");
        //barrel.Rotate(0, rotateCannon, 0);

        float rotateBarrelVert = Input.GetAxis("Mouse Y");
        barrel.Rotate(-rotateBarrelVert, 0, 0);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1, 0 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1, 0 * Time.deltaTime);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            FireCannonball();

            audioSource.Play(0);

        }
    }

    void FireCannonball()
    {

        GameObject ball = Instantiate(cannonball, pof.position, Quaternion.identity);

        Rigidbody rigidbody = ball.GetComponent<Rigidbody>();

        rigidbody.velocity = cannonballSpeed * pof.forward;

        StartCoroutine(RemoveCannonball(ball));

    }

    IEnumerator RemoveCannonball(GameObject ball)
    {
        yield return new WaitForSeconds(2f);
        Destroy(ball);
    }


}
