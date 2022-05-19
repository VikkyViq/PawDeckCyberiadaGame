using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Card : MonoBehaviour {

	/*
	* 1-9 are regular
	* 10 is skip
	* 11 is reverse
	* 12 is draw 2
	* 13 is wild
	* 14 is wild draw 4
	*/

	int number;
	string color;
	GameObject cardObj;

	public Card (int numb, string color, GameObject obj) { //defines the object
		number = numb;
		this.color = color;
		cardObj = obj;
	}
	public GameObject loadCard(int x, int y, Transform parent) { //when ran, it tells where to load the card on the screen
		GameObject temp = loadCard (parent);
		temp.transform.localPosition = new Vector2 (x, y+540);
		return temp;
	}
	public GameObject loadCard(Transform parent) { //does all the setup for loading. Used if card doesn't need a specific position		
		GameObject temp = Instantiate (cardObj);
		//temp.name = color + number;
		switch(number)
        {
			case 0:
				
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("candies");
				break;
			case 1:
				temp.GetComponentInChildren<Text>().text = "nazwa".ToString();
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("candies");
				break;
			case 2:
				temp.GetComponentInChildren<Text>().text = "nazwa".ToString();
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("chips");
				break;
			case 3:
				temp.GetComponentInChildren<Text>().text = "nazwa".ToString();
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("mini_candies");
				break;
			case 4:
				temp.GetComponentInChildren<Text>().text = "nazwa".ToString();
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("sugar_cubes");
				break;
			case 5:
				temp.GetComponentInChildren<Text>().text = "nazwa".ToString();
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("popcorn");
				break;
			case 6:
				temp.GetComponentInChildren<Text>().text = "nazwa".ToString();
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("cokies");
				break;
			case 7:
				temp.GetComponentInChildren<Text>().text = "nazwa".ToString();
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("candies");
				break;
			case 8:
				temp.GetComponentInChildren<Text>().text = "nazwa".ToString();
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("candies");
				break;
			case 9:
				temp.GetComponentInChildren<Text>().text = "nazwa".ToString();
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("icecream");
				break;
			/*case 10:
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("pretzel");
				break;
			case 11:
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("popcorn");
				break;
			case 12:
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("donut");
				break;
			case 13:
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("monster");
				break;*/
		}
		if (number < 10)
		{
			foreach (Transform childs in temp.transform)
			{
				if (childs.name.Equals("Cover"))
					break;
				childs.GetComponent<Text>().text = number.ToString();
			}
			temp.transform.GetChild(1).GetComponent<Text>().color = returnColor(color);
		}
		else if (number == 10 || number == 11 || number==12) {
			temp.transform.GetChild (1).GetComponent<RawImage> ().color = returnColor (color);
		}
		else if (number == 13) {
			temp.transform.GetChild (0).GetComponent<Text> ().text = "nazwa";
			temp.transform.GetChild (2).GetComponent<Text> ().text = "opis";
		}

		temp.GetComponent<RawImage> ().texture = Resources.Load (color + "Card") as Texture2D;
		temp.transform.SetParent (parent);
		temp.transform.localScale = new Vector3 (1, 1, 1);
		return temp;
	}
	Color returnColor(string what) { //returns a color based on the color string
		switch (what) {
		case "Green":
			return new Color32 (255, 255, 255, 0);
		case "Blue":
			return new Color32 (255, 255, 255, 0);
		case "Red":
			return new Color32 (255, 255, 255, 0);
		case "Yellow":
			return new Color32 (255, 255, 255, 0);
		}
		return new Color (0, 0, 0);
	}
	public int getNumb() { //accessor for getting the number
		return number;
	}
	public string getColor() { //accessor for getting the color
		return color;
	}
	public bool Equals(Card other) { //overides the original Equals so that color or number must be equal
		return other.getNumb () == number || other.getColor ().Equals (color);
	}
	public void changeColor(string newColor) { //mutator that changes the color of a wild card to make the color noticable
		color = newColor;
	}
}
