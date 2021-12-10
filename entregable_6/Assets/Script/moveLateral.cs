using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLateral : MonoBehaviour
{

    public float speed = 10f;
    private float lowerLim = 20f;
    private playerController playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }


        if (transform.position.x > lowerLim)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < -lowerLim)
        {
            Destroy(gameObject);
        }
    }
}
