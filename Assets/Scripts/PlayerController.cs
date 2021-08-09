using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float speed = 80.0f;
	private Rigidbody rigid;
	private int score = 0;
	public int health = 5;
	public Text scoreText;
	public Text healthText;
	public Text winLoseText;
	public Image winLoseBG;
	
	/// <summary>
	///  Increments score when the Player touches a coin 
	/// </summary>
	/// <param name="other">coin</param>
	void OnTriggerEnter(Collider other)
	{
		/// Keeping score
		if (other.tag == "Pickup")
		{
			score++;
			// Debug.Log($"Score: {score}");
			SetScoreText();
			Destroy(other.gameObject);
		}
		
		/// Tracking health
		if (other.tag == "Trap")
		{
			health--;
			SetHealthText();
			// Debug.Log($"Health: {health}");
			Destroy(other.gameObject);
		}
		
		/// Winning!
		if (other.tag == "Goal")
		{
			winLoseBG.gameObject.SetActive(true);
			WinnerWinner();
			// Debug.Log("You win!");
		}		
	}
	
	/// Gets rigidbody at start for player
	void Start() {
		rigid = GetComponent<Rigidbody>();
	}

	/// Use fixed when working with physics
	void FixedUpdate()
	{
		/// Gets horizontal position when key "a" or "d"/right-left arrowkeys
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		Vector3 move = new Vector3(horizontal, 0.0f, vertical);
		
		/// Takes the vector3 move and applies it to direction of addforce and * by speed
		rigid.AddForce(move * speed);
		// transform.position += move * speed;
	}
	
	/// Player health expiration
	void Update (){
		if (health == 0)
		{
			Debug.Log("Game Over!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			// SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			// SceneManager.LoadScene(0);
		}
	}
	/// <summary>
	/// Updates ScoreText obj with Player's current score
	/// </summary>
	void SetScoreText(){
		scoreText.text = $"Score: {score}";
	}
	/// <summary>
	/// Updates the HealthText object with the Player‘s current health
	/// </summary>
	void SetHealthText(){
		healthText.text = $"Health: {health}";
	}
	/// <summary>
	/// Displays you win when Player touches the Goal
	/// </summary>
	void WinnerWinner(){
		winLoseText.text = "You Win!";
		// winLoseText.color = Color.white;
		// winLoseBG.color = Color.green;
	}
}
		
		// public float speed = 500f;



    	// FixedUpdate is called when messing with Physics 
    
		///Add forward force
		//rb.AddForce(0, 0, 2000 * Time.deltaTime);
		
		/// **Input Actions** WASD||arrow keys
		
		// /// Move up
		// if ( Input.GetKey("w") || Input.GetKeyDown(KeyCode.UpArrow))
		// {
		// 	rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
		// }
		
		// /// Move down
		// if ( Input.GetKey("s") || Input.GetKeyDown(KeyCode.DownArrow))
		// {
		// 	rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
		// }

		// /// Move right
		// if ( Input.GetKey("d") || Input.GetKeyDown(KeyCode.UpArrow))
		// {
		// 	rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
		// 
