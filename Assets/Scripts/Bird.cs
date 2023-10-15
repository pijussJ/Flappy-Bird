
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
    public GameObject DayBackground;
    public GameObject NightBackground;
    public float speed;
    private int score = 0;
    //private AudioSource audio;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Pipe.speed = speed;
        RandomizeBird();
        RandomizeBackground();
        
        //audio = GameObject.Find("ScoreSound").GetComponent<AudioSource>();
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
    void RandomizeBackground()
    {
        int randomIndex = Random.Range(1, 3);
        switch (randomIndex)
        {
            case 1:
                DayBackground.SetActive(true);
                break;
            case 2:
                NightBackground.SetActive(true);
                break;
        }

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }
        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotateRatio);
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }
    void Die ()
    {
        Pipe.speed = 0;
        jumpSpeed = 0;
        Invoke("ShowMenu", 1f);
        

        //var currentScene = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(currentScene);
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
        //audio.Play();
    }
}
