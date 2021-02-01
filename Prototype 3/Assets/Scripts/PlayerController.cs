using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 10.0f;
    public float gravityModifier;
    public bool isOnGround = true;
    private bool gameOver = false;
    private Animator anim;
    public ParticleSystem explosionParticle;
    public ParticleSystem walkParticle;
    public AudioClip[] jumpSound;
    public AudioClip[] crashSound;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;

        anim.SetFloat("Speed_f", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("Jump_trig");
            isOnGround = false;
            walkParticle.Stop();
            playerAudio.PlayOneShot(jumpSound[Random.Range(0,3)], 1.0f);
        }

        /*if (isOnGround)
        {
            
        }
        else
        {
            
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            walkParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            anim.SetFloat("Speed_f", 0.0f);
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);
            gameOver = true;
            explosionParticle.Play();
            walkParticle.Stop();
            playerAudio.PlayOneShot(crashSound[Random.Range(0, 3)], 1.0f);
        }
        
    }

    public bool isGameOver()
    {
        return gameOver;
    }
}
