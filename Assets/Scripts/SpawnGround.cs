using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpawnGround : MonoBehaviour {

	public int GridSize;
	public float blockWidth, blockHight, StartX, StartY;
	public GameObject Block;

	Sprite currentSelection;
	public GameObject GeneralBuilding;
	public GameObject currentBuilding;
	public bool selected;

	public Color c1, c2;
	public Sprite[] Size2LimitedBuildings;
	public Sprite[] Size1UnlimitedBuildings;
	public GameObject content, buttonObject;

	Button butt;
	public GameObject ClickPanel;


	// Oyun acildiginda Baslayan fonksiyonlar
	void Start(){
		SpawnTiles ();
		SetTheBuildings ();
		SpawnBuildings ();
	}



	// Gridi Olusturdugum fonksiyon
	void SpawnTiles(){
		for (int i = 1; i <= GridSize; i++) {
			if (i < (int)GridSize / 2) {
				for (int j = 1; j <= i; j++) {
					if (i % 2 == 0) {
						float x = StartX + (i - 1) * (-(blockWidth / 2)) + ((j-1) * (blockWidth)); 
						float y = StartY - (((i - 1) * blockHight))/2;
						GameObject k = Instantiate (Block, new Vector3 (x, y, 0), Quaternion.Euler(0,0,0)) as GameObject;
						k.transform.SetParent (GameObject.Find ("All").transform);
						k.name = i.ToString () +"-"+ j.ToString ();
						k.GetComponent<SpriteRenderer> ().color = c1;

					} else {
						float x = StartX + (i - 1) * (-(blockWidth / 2)) + ((j-1) * (blockWidth)); 
						float y = StartY - (i - 1) * blockHight/2;
						GameObject k = Instantiate (Block, new Vector3 (x, y, 0), Quaternion.Euler(0,0,0)) as GameObject;
						k.transform.SetParent (GameObject.Find ("All").transform);
						k.GetComponent<SpriteRenderer> ().color = c2;
						k.name = i.ToString () +"-"+ j.ToString ();
					}
				}
			}else if (i >= (int)GridSize / 2) {
				for (int j = 1; j <= GridSize-i; j++) {
					if (i % 2 == 0) {
						float x = StartX + (GridSize- i - 1) * (-(blockWidth / 2)) + ((j-1) * (blockWidth)); 
						float y = StartY - (((i - 1) * blockHight))/2;
						GameObject k = Instantiate (Block, new Vector3 (x, y, 0), Quaternion.Euler(0,0,0)) as GameObject;
						k.transform.SetParent (GameObject.Find ("All").transform);
						k.name = i.ToString () +"-"+ j.ToString ();
						k.GetComponent<SpriteRenderer> ().color = c1;

					} else {
						float x = StartX + (GridSize - i - 1) * (-(blockWidth / 2)) + ((j-1) * (blockWidth)); 
						float y = StartY - (i - 1) * blockHight/2;
						GameObject k = Instantiate (Block, new Vector3 (x, y, 0), Quaternion.Euler(0,0,0)) as GameObject;
						k.transform.SetParent (GameObject.Find ("All").transform);
						k.GetComponent<SpriteRenderer> ().color = c2;
						k.name = i.ToString () +"-"+ j.ToString ();
					}
				}
			}

		}
	}




	// Eklenilen objeleri olusturdugum fonksiyon
	void SpawnBuildings(){
		for (int i = 0; i < Size2LimitedBuildings.Length; i++) {
			if(PlayerPrefs.HasKey(Size2LimitedBuildings[i].name)){
				string n = PlayerPrefs.GetString(Size2LimitedBuildings[i].name);
				GameObject z = Instantiate(GeneralBuilding, GameObject.Find(n).transform.position,Quaternion.identity)as GameObject;
				z.AddComponent<PolygonCollider2D> ();
				z.tag = "buildings";
				char c = n [0];
				int j = 0;
				string g = "";
				string h = "";
				while (c != '-') {
					g += c.ToString ();
					j++;
					c = n [j];
				}
				j++;
				while (j < n.Length) {
					c = n [j];
					h += c.ToString ();
					j++;
				}
				int gg = int.Parse (g);
				int hh = int.Parse (h);
				GameObject.Find (gg.ToString () + "-" + hh.ToString ()).tag = "filled";
					GameObject p, q, r;
					p = q = r = null;

					if (gg < GridSize/2+1) {
						p = GameObject.Find ((gg - 1).ToString () + "-" + hh.ToString ());
						q = GameObject.Find ((gg - 1).ToString () + "-" + (hh - 1).ToString ());
						r = GameObject.Find ((gg - 2).ToString () + "-" + (hh - 1).ToString ());
					}else 	if (gg == GridSize/2+1) {
						p = GameObject.Find ((gg - 1).ToString () + "-" + (hh+1).ToString ());
						q = GameObject.Find ((gg - 1).ToString () + "-" + (hh).ToString ());
						r = GameObject.Find ((gg - 2).ToString () + "-" + (hh - 1).ToString ());
					}else 	if (gg > GridSize/2+1) {
						p = GameObject.Find ((gg - 1).ToString () + "-" + (hh+1).ToString ());
						q = GameObject.Find ((gg - 1).ToString () + "-" + (hh).ToString ());
						r = GameObject.Find ((gg - 2).ToString () + "-" + (hh + 1).ToString ());
					}

					p.tag = q.tag = r.tag = "filled";
				content.transform.Find (Size2LimitedBuildings [i].name).GetComponent<Button> ().interactable = false;
				content.transform.Find (Size2LimitedBuildings [i].name).transform.GetChild(0).GetComponent<Text> ().text = "0";
				z.GetComponent<SpriteRenderer> ().sprite = Size2LimitedBuildings [i];
				z.GetComponent<SpriteRenderer> ().sortingOrder = gg;
				z.name = n;
			}
		}


		for (int i = 0; i < Size1UnlimitedBuildings.Length; i++) {
			string spriteName = Size1UnlimitedBuildings [i].name;
			int o = PlayerPrefs.GetInt (spriteName + "count");
			for (int k = 0; k < o; k++) {
				if(PlayerPrefs.HasKey(Size1UnlimitedBuildings[i].name + k.ToString())){
					string n = PlayerPrefs.GetString(Size1UnlimitedBuildings[i].name+k.ToString());
					GameObject z = Instantiate(GeneralBuilding, GameObject.Find(n).transform.position,Quaternion.identity)as GameObject;
					z.AddComponent<PolygonCollider2D> ();
					z.tag = "buildings";

					char c = n [0];
					int j = 0;
					string g = "";
					string h = "";
					while (c != '-') {
						g += c.ToString ();
						j++;
						c = n [j];
					}
					j++;
					while (j < n.Length) {
						c = n [j];
						h += c.ToString ();
						j++;
					}
					int gg = int.Parse (g);
					int hh = int.Parse (h);
					GameObject.Find (gg.ToString () + "-" + hh.ToString ()).tag = "filled";
					z.GetComponent<SpriteRenderer> ().sprite = Size1UnlimitedBuildings [i];
					z.name = n;
					z.GetComponent<SpriteRenderer> ().sortingOrder = gg;
				}
			}

		}
	}



	// Reset Fonksiyonu (Reset butonuna basip oyun tekrar baslatildiginda sahne bos gelir)
	public void OnResetClick(){
		PlayerPrefs.DeleteAll ();
		Application.Quit ();
	}



	// Ekranın alt tarafına olusturulan objeler olusturmak icin yazdigim fonksiyon
	void SetTheBuildings(){
		int i = Size1UnlimitedBuildings.Length + Size2LimitedBuildings.Length - 1;
		for (int j = 0; j <= i; j++) {
			GameObject p = Instantiate (buttonObject, new Vector3 (9000, 0, 0), Quaternion.identity) as GameObject;
			p.transform.SetParent (content.transform);
			p.GetComponent<RectTransform>().localPosition = new Vector3 (60+(j*150), 0, 0);
			p.transform.localScale = new Vector3 (1, 1, 1);
			if (j < Size2LimitedBuildings.Length) {
				p.GetComponent<Image> ().sprite = Size2LimitedBuildings [j];
				p.name = Size2LimitedBuildings [j].name;
				//p.tag = "more";
				p.transform.GetChild (0).GetComponent<Text> ().text = "1";
				p.transform.GetComponent<Button> ().onClick.AddListener (delegate {
					OnBuildingButtonClick ();
				});
			} else {
				p.GetComponent<Image> ().sprite = Size1UnlimitedBuildings [j - Size2LimitedBuildings.Length];
				//p.tag = "1";
				p.name = Size1UnlimitedBuildings [j - Size2LimitedBuildings.Length].name;
				p.transform.GetChild (0).GetComponent<Text> ().text = "i";
				p.transform.GetComponent<Button> ().onClick.AddListener (delegate {
					OnBuildingButtonClick ();
				});
			}
			p.tag = "UI";
			content.GetComponent<RectTransform> ().sizeDelta += new Vector2 (150, 0);
			content.transform.localPosition = new Vector3 (0, 0, 0);
		}
	}



	// Kullanıcı objelere tıkladığında tetikledigim fonksiyon.
	public void OnBuildingButtonClick(){
		if (currentBuilding != null) {
			Destroy (currentBuilding);
		}
		currentSelection = EventSystem.current.currentSelectedGameObject.GetComponent<Image> ().sprite;
		Vector3 v = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		v.z = 0;
		currentBuilding = Instantiate (GeneralBuilding, v, Quaternion.identity) as GameObject;
		currentBuilding.AddComponent<CircleCollider2D> ();
		currentBuilding.GetComponent<CircleCollider2D> ().radius = 0.1f;
		//currentBuilding.transform.localScale = new Vector3 (0.5f, 1, 0);
		currentBuilding.GetComponent<SpriteRenderer> ().sprite = currentSelection;
		currentBuilding.GetComponent<CircleCollider2D> ().offset = new Vector2 (0, 0);
		if (EventSystem.current.currentSelectedGameObject.transform.GetChild (0).GetComponent<Text> ().text == "1") {
			butt = EventSystem.current.currentSelectedGameObject.GetComponent<Button> ();
			currentBuilding.tag = "more";
		} else {
			currentBuilding.tag = "1";
		}
		selected = true;
	}



	void Update(){
		// Buradaki kontrolu isometric üzerinde doğru yere objeleri koymasi icin yazdim.
		if (selected && currentBuilding != null) {
			RaycastHit2D hit = Physics2D.Raycast (new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y), Vector2.zero, 0f);
			if (hit != null && hit.transform != null && (hit.transform.tag == "block" || hit.transform.tag == "filled")) {
				string n = hit.transform.name;
				if (currentBuilding.tag == "1" ) {
					currentBuilding.transform.position = hit.transform.position;
					if (hit.transform.tag == "filled") {
						currentBuilding.GetComponent<SpriteRenderer> ().color = Color.red - new Color (0, 0, 0, 0.5f);
					} else if (hit.transform.tag == "block") {
						currentBuilding.GetComponent<SpriteRenderer> ().color = Color.green - new Color (0, 0, 0, 0.3f);
					}
						
				} else {
					string d = n [n.Length - 1].ToString ();
					char c = n [0];
					int j = 0;
					string g = "", h = "";
					while (c != '-') {
						g += c.ToString ();
						j++;
						c = n [j];
					}
					j++;
					while (j < n.Length) {
						c = n [j];
						h += c.ToString ();
						j++;
					}
					if (((d == "1" && int.Parse (g) < 21) || (g == h))) {
						//currentBuilding.transform.position = hit.transform.position;
					}else{
						int gg = int.Parse (g);
						int hh = int.Parse (h);
						GameObject p, q, r;
						p = q = r = null;

						if (gg < GridSize/2+1) {
							p = GameObject.Find ((gg - 1).ToString () + "-" + hh.ToString ());
							q = GameObject.Find ((gg - 1).ToString () + "-" + (hh - 1).ToString ());
							r = GameObject.Find ((gg - 2).ToString () + "-" + (hh - 1).ToString ());
						}else 	if (gg == GridSize/2+1) {
							p = GameObject.Find ((gg - 1).ToString () + "-" + (hh+1).ToString ());
							q = GameObject.Find ((gg - 1).ToString () + "-" + (hh).ToString ());
							r = GameObject.Find ((gg - 2).ToString () + "-" + (hh - 1).ToString ());
						}else 	if (gg > GridSize/2+1) {
							p = GameObject.Find ((gg - 1).ToString () + "-" + (hh+1).ToString ());
							q = GameObject.Find ((gg - 1).ToString () + "-" + (hh).ToString ());
							r = GameObject.Find ((gg - 2).ToString () + "-" + (hh + 1).ToString ());
						}
							

						if (hit.transform.tag == "block" && p.tag == "block" && q.tag == "block" && r.tag == "block") {
							currentBuilding.GetComponent<SpriteRenderer> ().color = Color.green - new Color (0, 0, 0, 0.3f);
						} else {
							currentBuilding.GetComponent<SpriteRenderer> ().color = Color.red - new Color (0, 0, 0, 0.5f);
						}

						currentBuilding.transform.position = hit.transform.position;
					}
				}
			}
		}
		if (Input.GetMouseButtonDown (1)) {
			Debug.Log ("doing");
			selected = false;
			Destroy (currentBuilding);
			currentSelection = null;
		}


		if (Input.GetMouseButtonDown (0) && selected) {
			RaycastHit2D hit = Physics2D.Raycast (new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y), Vector2.zero, 0f);
			if (hit != null && hit.transform != null && hit.transform.tag == "block") {
				string n = hit.transform.name;

				char c = n [0];
				int j = 0;
				string g = "", h = "";
				while (c != '-') {
					g += c.ToString ();
					j++;
					c = n [j];
				}
				j++;
				while (j < n.Length) {
					c = n [j];
					h += c.ToString ();
					j++;
				}

				int gg = int.Parse (g);
				int hh = int.Parse (h);

				if (currentBuilding.tag == "1") {
					string spriteName = currentBuilding.GetComponent<SpriteRenderer> ().sprite.name;
					PlayerPrefs.SetString (spriteName + PlayerPrefs.GetInt(spriteName+"count").ToString(), n);
					PlayerPrefs.SetInt (spriteName + "count", PlayerPrefs.GetInt (spriteName + "count")+1);

					currentBuilding.GetComponent<SpriteRenderer> ().sortingOrder = gg;
					currentBuilding.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1,1);
					currentBuilding.tag = "buildings";
					currentBuilding.AddComponent<PolygonCollider2D> ();

					currentBuilding = null;
					hit.transform.tag = "filled";
					StartCoroutine (SetSelectedFalse ());
				}else{
					

					Debug.Log (g + "-" + h);

					GameObject p, q, r;
					p = q = r = null;

					if (gg < GridSize/2+1) {
						p = GameObject.Find ((gg - 1).ToString () + "-" + hh.ToString ());
						q = GameObject.Find ((gg - 1).ToString () + "-" + (hh - 1).ToString ());
						r = GameObject.Find ((gg - 2).ToString () + "-" + (hh - 1).ToString ());
					}else 	if (gg == GridSize/2+1) {
						p = GameObject.Find ((gg - 1).ToString () + "-" + (hh+1).ToString ());
						q = GameObject.Find ((gg - 1).ToString () + "-" + (hh).ToString ());
						r = GameObject.Find ((gg - 2).ToString () + "-" + (hh - 1).ToString ());
					}else 	if (gg > GridSize/2+1) {
						p = GameObject.Find ((gg - 1).ToString () + "-" + (hh+1).ToString ());
						q = GameObject.Find ((gg - 1).ToString () + "-" + (hh).ToString ());
						r = GameObject.Find ((gg - 2).ToString () + "-" + (hh + 1).ToString ());
					}
						
					if (p.tag == "block" && q.tag == "block" && r.tag == "block") {
						if (butt != null) {
							butt.interactable = false;
							butt.transform.GetChild (0).GetComponent<Text> ().text = "0";
						}
						PlayerPrefs.SetString (currentBuilding.GetComponent<SpriteRenderer> ().sprite.name, n);
						currentBuilding.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1,1);
						currentBuilding.GetComponent<SpriteRenderer> ().sortingOrder = gg;
						currentBuilding.AddComponent<PolygonCollider2D> ();
						currentBuilding.tag = "buildings";
						hit.transform.tag = p.tag = q.tag = r.tag = "filled";
						StartCoroutine (SetSelectedFalse ());
						currentBuilding = null;
					}
				}
			}
		}

		// Pop gosterimi icin
		if (Input.GetMouseButtonDown (0) && !selected) {
			RaycastHit2D hit = Physics2D.Raycast (new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y), Vector2.zero, 0f);
			if(hit != null && hit.transform != null && hit.transform.tag == "buildings"){
				ClickPanel.transform.localPosition = new Vector3 (0, 0, 0);
				ClickPanel.transform.GetChild (0).GetComponent<Text> ().text = "you Have clicked on " + hit.transform.name;
			}
		}

	}

	// Popup silmek icin
	public void OnClickPanelClick(){
		ClickPanel.transform.localPosition = new Vector3 (9000, 0, 0);
	}

	// Popup icin koydugum bekleme suresi 
	IEnumerator SetSelectedFalse(){
		yield return new WaitForSeconds (0.3f);
		selected = false;
	}
}
