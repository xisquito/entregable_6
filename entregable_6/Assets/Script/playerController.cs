using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
   
    
    private Rigidbody playerRigidBody;
    public float jumpForce = 10;
    public float gravityModifier = 2f;
    public bool gameOver;
    private AudioSource playerAudioSource;
    private AudioSource cameraAudioSource;
    public AudioClip jumpClip;
    public AudioClip explosionClip;
    public ParticleSystem explosionParticleSystem;
    private float limY = 15f;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerAudioSource = GetComponent<AudioSource>();
        cameraAudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        cameraAudioSource.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAudioSource.PlayOneShot(jumpClip, 1f);
        }

        if (transform.position.y <= -0.5f)
        {
            playerAudioSource.PlayOneShot(explosionClip, 1f);
            gameOver = true;
            Debug.Log(message: "GAME OVER");
            explosionParticleSystem.Play();
            cameraAudioSource.volume = 0.05f;
            Destroy(gameObject);
        }

        if (transform.position.y >= limY)
        {
            transform.position = new Vector3(transform.position.x, limY, transform.position.z);
        }


    }
    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!gameOver)
        {
            if (otherCollider.gameObject.CompareTag("Bomb"))
            {

                gameOver = true;
                explosionParticleSystem.Play();
                cameraAudioSource.volume = 0.05f;
                playerAudioSource.PlayOneShot(explosionClip, 0.4f);

            }
        }
    }

}
