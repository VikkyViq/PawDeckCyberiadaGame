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
				temp.transform.GetChild(5).GetComponent<Text>().text = "candies";
				temp.transform.GetChild(6).GetComponent<Text>().text = "nazwa";
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("candies");
				break;
			case 1:
				temp.transform.GetChild(5).GetComponent<Text>().text = "chips";
				temp.transform.GetChild(6).GetComponent<Text>().text = "nazwa";
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("chips");
				break;
			case 2:
				temp.transform.GetChild(5).GetComponent<Text>().text = "cookies";
				temp.transform.GetChild(6).GetComponent<Text>().text = "nazwa";
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("cookies");
				break;
			case 3:
				temp.transform.GetChild(5).GetComponent<Text>().text = "tościk";
				temp.transform.GetChild(6).GetComponent<Text>().text = "nazwa";
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("tościk");
				break;
			case 4:
				temp.transform.GetChild(5).GetComponent<Text>().text = "pancakes";
				temp.transform.GetChild(6).GetComponent<Text>().text = "nazwa";
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("pancakes");
				break;
			case 5:
				temp.transform.GetChild(5).GetComponent<Text>().text = "sugar cubes";
				temp.transform.GetChild(6).GetComponent<Text>().text = "nazwa";
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("sugar_cubes");
				break;
			case 6:
				temp.transform.GetChild(5).GetComponent<Text>().text = "mini candies";
				temp.transform.GetChild(6).GetComponent<Text>().text = "nazwa";
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("mini_candies");
				break;
			case 7:
				temp.transform.GetChild(5).GetComponent<Text>().text = "marshmallows";
				temp.transform.GetChild(6).GetComponent<Text>().text = "nazwa";
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("marshmallows");
				break;
			case 8:
				temp.transform.GetChild(5).GetComponent<Text>().text = "pancakes";
				temp.transform.GetChild(6).GetComponent<Text>().text = "nazwa";
				temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("pancakes");
				break;
			case 9:
				temp.transform.GetChild(5).GetComponent<Text>().text = "icecream";
				temp.transform.GetChild(6).GetComponent<Text>().text = "nazwa";
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
		else if (number == 10) 
		{
			//temp.transform.GetChild (1).GetComponent<RawImage> ().color = returnColor (color);
			temp.transform.GetChild(5).GetComponent<Text>().text = "pretzel";
			temp.transform.GetChild(6).GetComponent<Text>().text = "Zablokuj przeciwnika";
			temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("pretzel");

		}
		else if(number == 11)
        {
			temp.transform.GetChild(5).GetComponent<Text>().text = "lollipops";
			temp.transform.GetChild(6).GetComponent<Text>().text = "nazwa";
			temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("lollipops");
		}
		else if(number == 12)
        {
			temp.transform.GetChild(5).GetComponent<Text>().text = "popcorn";
			temp.transform.GetChild(6).GetComponent<Text>().text = "Zmuś przeciwnika do wzięcia 2 kart";
			temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("popcorn");
		}
		else if (number == 13) {
			temp.transform.GetChild(5).GetComponent<Text>().text = "donut";
			temp.transform.GetChild(6).GetComponent<Text>().text = "Zmień kolor kart na stosie";
			temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("donut");
		}
		else if(number == 14)
        {
			temp.transform.GetChild(5).GetComponent<Text>().text = "monster";
			temp.transform.GetChild(6).GetComponent<Text>().text = "Zmuś przeciwnika do wzięcia 4 kart";
			temp.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("monster");
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
