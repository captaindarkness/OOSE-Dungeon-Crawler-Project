using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	//Variable for setting starting health
	public int startHealth;
	//Variable for setting amount of health per heart
	public int healthPerHeart;

	//Maximum amount of health available
	private int maxHealth;
	//Current health
	private int currentHealth;

	//An array which holds the different heart images (full, ½ full etc.)
	public Texture[] heartImages;
	public GUITexture heartGUI;

	//An Array List which holds the hearts
	private ArrayList hearts = new ArrayList();
	
	// Spacing:
	//Variable for setting maximum hearts on a row
	public float maxHeartsOnRow;
	private float spacingX;
	private float spacingY;
	
	
	void Start () {
		spacingX = heartGUI.pixelInset.width;
		spacingY = -heartGUI.pixelInset.height;
	
		AddHearts(startHealth/healthPerHeart);
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

			newHeart.GetComponent<GUITexture>().pixelInset = new Rect(x * spacingX,y * spacingY,58,58);
			newHeart.GetComponent<GUITexture>().texture = heartImages[0];
			hearts.Add(newHeart);

		}
		maxHealth += n * healthPerHeart;
		currentHealth = maxHealth;
		UpdateHearts();
	}

	
	public void modifyHealth(int amount) {
		currentHealth += amount;
		currentHealth = Mathf.Clamp(currentHealth,0,maxHealth);
		UpdateHearts();
	}

	void UpdateHearts() {
		bool restAreEmpty = false;
		int i =0;
		
		foreach (Transform heart in hearts) {
			
			if (restAreEmpty) {
				heart.guiTexture.texture = heartImages[0]; // heart is empty
			}
			else {
				i += 1; // current iteration
				if (currentHealth >= i * healthPerHeart) {
					heart.guiTexture.texture = heartImages[heartImages.Length-1]; // health of current heart is full
				}
				else {
					int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - currentHealth));
					int healthPerImage = healthPerHeart / heartImages.Length; // how much health is there per image
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
