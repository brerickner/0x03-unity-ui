using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public float speed = 80.0f;
	private Rigidbody rigid;
	private int score = 0;
	public int health = 5;
	
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
			Debug.Log($"Score: {score}");
			Destroy(other.gameObject);
		}
		
		/// Tracking health
		if (other.tag == "Trap")
		{
			health--;
			Debug.Log($"Health: {health}");
			Destroy(other.gameObject);
		}
		
		/// Winning!
		if (other.tag == "Goal")
		{
			Debug.Log("You win!");
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
