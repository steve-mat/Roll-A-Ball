using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody rbody;

    private float speed = 20.0f;

    private int scoreCount;

    private Text scoreText;

    public Text winText;

	void Start () {

        rbody = GetComponent<Rigidbody>();
        scoreText = GameObject.FindGameObjectWithTag("Score Text").GetComponent<Text>();
        scoreCount = 0;
        SetScoreText();

	}
	
	void FixedUpdate () {

        HandleMovement();

	}

    private void HandleMovement() {

        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movementVector = new Vector3(horizontalMovement, transform.position.y, verticalMovement);

        rbody.AddForce(movementVector * speed);

    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Pick Up")) {
            Destroy(other.gameObject);
            scoreCount++;
            SetScoreText();
        }
    }

    private void SetScoreText() {
        scoreText.text = "Score: " + scoreCount.ToString();
        if(scoreCount == 10) {
            winText.gameObject.SetActive(true);
            //Time.timeScale = 0f;  - freeze game after winning
        }
    }
}
