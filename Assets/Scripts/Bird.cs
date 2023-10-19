
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bird : MonoBehaviour
{
    public float jumpSpeed;
    public float rotateRatio;
    Rigidbody2D rb;
    public TMP_Text scoreText;
    public GameObject endScreen;
    public GameObject YellowBird;
    public GameObject RedBird;
    public GameObject BlueBird;

    public float speed;
    private int score = 0;
    public GameObject flashEffect;
    public AudioSource jumpSound;
    public AudioSource deathSound;
    public GameObject tutorialScreen;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        RandomizeBird();
        Pipe.speed = 0;
        rb.gravityScale = 0;
    }
    void RandomizeBird()
    {
        int randomIndex = Random.Range(1, 4);
        switch (randomIndex)
        {
            case 1:
                YellowBird.SetActive(true);
                break;
            case 2:
                RedBird.SetActive(true);
                break;
            case 3:
                BlueBird.SetActive(true);
                break;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && speed > 0)
        {
            Jump();
            jumpSound.Play();
            Pipe.speed = speed;
            tutorialScreen.SetActive(false);
        }

        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotateRatio);
    
    }
    void Jump()
    {
        rb.velocity = Vector2.up * jumpSpeed;
        rb.gravityScale = 3;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }
    void Die ()
    {
        Pipe.speed = 0;
        jumpSpeed = 0;
        PlayerPrefs.SetInt("Score", score);
        flashEffect.SetActive(true);
        Invoke("ShowMenu", 1f);
        deathSound.Play();
        
    }
    void ShowMenu()
    {
        endScreen.SetActive(true);
        scoreText.gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        scoreText.text = score.ToString();
    }
}
