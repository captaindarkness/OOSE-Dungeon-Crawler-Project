using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	//Variable for setting starting health.
	public int startHealth;
	//Variable for setting amount of health per heart.
	public int healthPerHeart;

	//Maximum amount of health available.
	private int maxHealth;
	//Current health.
	private int currentHealth;

	//An array which holds the different heart images (full, ½ full etc.).
	public Texture[] heartImages;
	public GUITexture heartGUI;
	//Texture for 'Game Over'.
	public Texture gameOverTexture;

	private ArrayList hearts = new ArrayList();

	//Variable for setting maximum hearts on a row
	public float maxHeartsOnRow;
	//Vaiables for space between heart icons.
	private float spacingX;
	private float spacingY;
	//'Game Over' is set to false as default.
	bool gameOver = false;
	
	void Start () {
		spacingX = heartGUI.pixelInset.width;
		spacingY = -heartGUI.pixelInset.height;
		AddHearts(startHealth/healthPerHeart);
	}
	// Update is called once per frame
	void Update(){
		//If health reaches 0, the player will now move and 'Game Over' appears.
		if (currentHealth <= 0) {
			Move.alive = false;
			gameOver = true;
		} else {
			Move.alive = true;
		}
	}
	//GUI for 'Game Over'.
	void OnGUI(){
		if (gameOver) {
			GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),gameOverTexture);
		}
	}

	//Adds heart to the GUI
	public void AddHearts(int n) {
		//Sets the amount of hearts specified
		for (int i = 0; i <n; i ++) {
			//adds a new heart
			Transform newHeart = ((GameObject)Instantiate(heartGUI.gameObject,this.transform.position,Quaternion.identity)).transform;
			newHeart.parent = transform;

			//Sets the positions of the hearts
			int y = (int)(Mathf.FloorToInt(hearts.Count / maxHeartsOnRow));
			int x = (int)(hearts.Count - y * maxHeartsOnRow);
			//Get specifications for heart.
			newHeart.GetComponent<GUITexture>().pixelInset = new Rect(x * spacingX,y * spacingY,58,58);
			newHeart.GetComponent<GUITexture>().texture = heartImages[0];
			//Adds the heart.
			hearts.Add(newHeart);

		}
		//Updates variables.
		maxHealth += n * healthPerHeart;
		currentHealth = maxHealth;
		UpdateHearts();
	}

	//Takes or adds health. ('amount' has to be set to a negative number to remove health.)
	public void modifyHealth(int amount) {
		currentHealth += amount;
		currentHealth = Mathf.Clamp(currentHealth,0,maxHealth);
		UpdateHearts();
	}

	//Updates GUI to show the correct amount of hearts.
	void UpdateHearts() {
		//Heart is set to not being empty by default.
		bool restAreEmpty = false;
		int i =0;
		
		foreach (Transform heart in hearts) {
			//If the heart is empty.
			if (restAreEmpty) {
				// Heart is empty
				heart.guiTexture.texture = heartImages[0];
			}
			else {
				// Current iteration
				i += 1;
				if (currentHealth >= i * healthPerHeart) {
					// Health of current heart is full
					heart.guiTexture.texture = heartImages[heartImages.Length-1];
				}
				else {
					int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - currentHealth));
					// How much health is there per image
					int healthPerImage = healthPerHeart / heartImages.Length;
					int imageIndex = currentHeartHealth / healthPerImage;

					
					if (imageIndex == 0 && currentHeartHealth > 0) {
						imageIndex = 1;
					}

					heart.guiTexture.texture = heartImages[imageIndex];
					restAreEmpty = true;
				}
			}
			
		}
	}
}
