using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator playeraAnim;
    private AudioSource playerAudio; 
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public AudioClip explodeSound;
    public AudioClip moneySound;
    public Text text;
    public float jumpforce = 10;
    public float gravityModifier;
    public bool IsOnGround = true;
    public bool gameOver;
    public float time = 0f;
    public float timespeed = 5f;


    
    void Start()
    {
      rb = GetComponent<Rigidbody>();
      playeraAnim = GetComponent<Animator>();
      Physics.gravity *= gravityModifier;
      playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && IsOnGround && !gameOver)
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Acceleration); //Forcemode.impulse hizlica basmayi saglar.
            IsOnGround = false;
            playeraAnim.SetTrigger("Jump_trig");
            dirt.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f); 
        }
        

        if(!gameOver)
        {
            time += Time.deltaTime * timespeed;
            text.text = time.ToString("0");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
            dirt.Play();
        }
        if (collision.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(collision.gameObject);
        } 
        else if (collision.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(collision.gameObject);

        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            playeraAnim.SetBool("Death_b", true);
            playeraAnim.SetInteger("DeathType_int", 1);
            explosion.Play();
            dirt.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }

}
