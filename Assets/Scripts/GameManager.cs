using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using _Passive;

public class GameManager : MonoBehaviour
{



	/* THIS GAMEMANAGER SCRIPT WILL DEAL WITH:
	   - COMMUNICATING WITH THE WAVE CLASS AND INSTANTIATING WAVES (done)
	   - COMMUNICATING WITH THE SCOREMANAGER
	   - GAME OVER AND RESTARTS 

		MOST OF THE COMMUNICATION WILL HAPPEN IN UPDATE
		THIS CLASS ALSO WILL DEAL WITH THE INITIAL PHASE OF INSTANTIAING WAVES DUE TO CONVERTING THE POINTER TO A POINT IN WORLDSPACE.
	*/

	public GameObject wavePrefab;
	public GameObject thing;
    private bool _gameOver = false;


    public Button restartButton;
    public Button gameOverRestart;
    public GameObject gameOverMenu;
    private Player player;
	private Vector2 pointerPosition;
//    private LineManager _lineManager;


	private Wave currentWave; //gets a reference to the Wave class, which our wave parent prefab uses

    private void Start()
    {
//        _lineManager = FindObjectOfType<LineManager>();
        Button button = restartButton.GetComponent<Button>();
        Button gameOverbutton = gameOverRestart.GetComponent<Button>();

        button.onClick.AddListener(Restart);
        gameOverbutton.onClick.AddListener(Restart);
    }


    void Update ()
	{
		pointerPosition = Input.mousePosition;
		/*This is a three-stage process which checks for each stage of a button press and does specific things
		 *at each phase. First, it calls the Wave Prepare method, which instantiates the outline as a gameobject.
		 *Next, it fixes itself to the cursor's worldposition, or position on the game screeen.
		 *Then, once the player releases the button, it sets the solid object at the last known position.
		 */
		if (Input.GetButtonDown ("Fire1"))
			WavePrepare ();
		if (Input.GetButton ("Fire1")) 
		{
			currentWave.transform.position = WorldPosition ();
			currentWave.transform.position = new Vector3 (Mathf.Clamp (currentWave.transform.position.x,-1.45f, 3.4f), -0.42f, currentWave.transform.position.z);
		}
		if (Input.GetButtonUp ("Fire1"))
		{
			currentWave.SetSolid ();
			currentWave.Attach ();
		}


	}

	Vector3 WorldPosition ()
	{
		return Camera.main.ScreenToWorldPoint (new Vector3 (pointerPosition.x,pointerPosition.y , 10f)); //screen to worldpoint is a method called directly from the main camera, converting pixel 2D co-ordinates into 3D co-ordinates.
	}


    //trying to figure out if collision detection happens here or in Hazards
    public void PlayerHasBeenHit()
    {
        Debug.Log("Changing boolean...");
        _gameOver = true;
        GameOver();


    }

    void WavePrepare ()
	{
		GameObject prep = Instantiate (wavePrefab, WorldPosition (), Quaternion.identity) as GameObject;
		currentWave = prep.GetComponent <Wave> (); 
		currentWave.SetOutline ();
	}

	void Restart ()
	{
			SceneManager.LoadScene (0);
	}


    //new method, will deal with the game over state and stopping coroutines.
    void GameOver()
    {
        if (_gameOver)
        {
            Debug.Log("...Game Over");
            gameOverMenu.SetActive(true);
        }
    }
}

