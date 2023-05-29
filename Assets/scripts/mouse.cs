using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mouse : MonoBehaviour
{
    public float forceOnMouse = 75f;
    Animator mouseAnimator;
    public ParticleSystem jetPack;
    Rigidbody2D rb;
    public float forwardVelocity = 3;
    bool jetPackActive;
    bool isDead = false;
    uint coins = 0;
    public Text coinsCollected;
    public Button restartButton;
    float emissionPower;
    public Slider emissionSlider;
    public Text distanceCovered;
    float initialPosition;
    public AudioClip coinCollectionSound;
    public AudioClip canCollectionSound;
    public AudioSource jetpackAudio;
    public AudioSource footstepsAudio;
    public AudioSource[] audioSources;
    public float volumeLevel = 1.0f;
    public Slider volumeSlider;
    public Button adsButton;
    bool isGround;
    
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position.x;
        emissionPower = 1.0f;
        restartButton.gameObject.SetActive(false);
        adsButton.gameObject.SetActive(false);
        jetPackActive = true;
        rb=GetComponent<Rigidbody2D>();
        mouseAnimator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        volumeLevel = volumeSlider.value;
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].volume = volumeLevel;
            
        }

        var jetPackEmision = jetPack.emission;
        if (jetPackActive)
        {
            jetPackEmision.rateOverTime = 300;
        }
        else
        {
            jetPackEmision.rateOverTime = 75;
        }
        jetPackActive = Input.GetButton("Fire1") && !isDead && (emissionPower>0);
        if (jetPackActive)
        {
            rb.AddForce(new Vector2(0, forceOnMouse));
            emissionPower -= Time.deltaTime * 0.1f;
            emissionSlider.value = emissionPower;
            print("emission power while flying:" + emissionPower);
        }
        else
        {
            jetPackActive = false;
            //emissionPower += Time.deltaTime * 0.07f;
            print("emission power while running:" + emissionPower);
        }
        if (emissionPower <= 0 && isGround)
        {
            Time.timeScale = 0;
            adsButton.gameObject.SetActive(true);
        }
        if (!isDead)
        {
            rb.velocity = (new Vector2(forwardVelocity, rb.velocity.y));
            float distanceFromInitial = transform.position.x- initialPosition;
            distanceCovered.text = distanceFromInitial.ToString("F0") + " M";
        }

        if (isDead)
        {
            restartButton.gameObject.SetActive(true);
            //adsButton.gameObject.SetActive(false);
        }
            
        //AdjustFootstepsAndJetpackSound(jetPackActive);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
            coinCollider(collision);
        else if (collision.gameObject.tag == "emissionPower")
            emissionPow(collision);
        else
            hitByLaser(collision);

    }
    void coinCollider(Collider2D collision)
    {
        coins++;
        coinsCollected.text = coins.ToString();
        print("coins: "+coins);
        //AudioSource.PlayClipAtPoint(coinCollectionSound, transform.position);
        
        AudioSource coinColect = collision.gameObject.GetComponent<AudioSource>();
        coinColect.Play();


        //audioSources[0].audioClip
        //collision.gameObject.SetActive(false);
        collision.gameObject.GetComponent<SpriteRenderer>().enabled=false;
        //Destroy(collision.gameObject);
    }
    
    void emissionPow(Collider2D collision)
    {        
        emissionPower += 0.2f;
        if (emissionPower > 1)
            emissionPower = 1;
        emissionSlider.value = emissionPower;
        print("emission power after collecting:" + emissionPower);
        //AudioSource.PlayClipAtPoint(canCollectionSound, transform.position);
        AudioSource coinColect = collision.gameObject.GetComponent<AudioSource>();
        coinColect.Play();
        collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //Destroy(collision.gameObject);
    }
    public void emissionPow()
    {
        Time.timeScale = 1;
        print("inside EmissionPo() after ad is shown");
        adsButton.gameObject.SetActive(false);
        emissionPower = 0.5f;
        //if (emissionPower > 1)
        //    emissionPower = 1;
        emissionSlider.value = emissionPower;
    }
    void hitByLaser(Collider2D collision)
    {
        if (!isDead)
        {
            AudioSource laserZap = collision.gameObject.GetComponent<AudioSource>();
            laserZap.Play();
        }
        isDead = true;
        mouseAnimator.SetBool("isDead", true);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            var jetPackEmision = jetPack.emission;
            jetPackEmision.enabled = false;
            isGround = true;
            mouseAnimator.SetBool("isGrounded", true);
            jetpackAudio.enabled = false;
            footstepsAudio.enabled = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            var jetPackEmision = jetPack.emission;
            jetPackEmision.enabled = true;
            isGround = false;
            mouseAnimator.SetBool("isGrounded", false);
            jetpackAudio.enabled = true;
            footstepsAudio.enabled = false;
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(0);
        
    }
    void AdjustFootstepsAndJetpackSound(bool jetpackActive)
    {
        if (jetpackActive)
        {
            jetpackAudio.volume = 1.0f;
        }
        else
        {
            jetpackAudio.volume = 0.3f;
        }
    }
}
