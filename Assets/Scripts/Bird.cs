
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bird : MonoBehaviour
{
    public float jumpSpeed;
    public float rotateRatio;
    Rigidbody2D rb;
    public TMP_Text scoreText;
    private int score = 0;
    private AudioSource audio;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GameObject.Find("ScoreSound").GetComponent<AudioSource>();
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
        var currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        scoreText.text = score.ToString();
        audio.Play();
    }
}
