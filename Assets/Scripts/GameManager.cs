using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{



	/* THIS GAMEMANAGER SCRIPT WILL DEAL WITH:
	   - COMMUNICATING WITH THE WAVE CLASS AND INSTANTIATING WAVES (done)
	   - COMMUNICATING WITH THE SCOREMANAGER
	   - GAME OVER AND RESTARTS (done)


		THIS CLASS ALSO WILL DEAL WITH INSTANTIAING WAVES BY INITIALLY CONVERTING THE POINTER TO A POINT IN WORLDSPACE.
	*/

	public GameObject wavePrefab;

    private bool _gameOver = false;
    private bool inCooldown;


    public static int score;
    public static int playerDeathCount = 0;
    public static float distanceTravelled;
    public static int difficultyAdditive;


    private Player player;
    private Vector2 pointerPosition;
    private IEnumerator coroutine;



    public float holdDownTimer;
    public float coolDownTimer;
    public Text scoreText;
    public Button restartButton;
    public Button gameOverRestart;
    public GameObject gameOverMenu;


	private Wave currentWave; //gets a reference to the Wave class, which our wave parent prefab uses

    private void Start()
    {
        Time.timeScale = 1f;

        Button button = restartButton.GetComponent<Button>();
        Button gameOverbutton = gameOverRestart.GetComponent<Button>();

        button.onClick.AddListener(Restart);
        gameOverbutton.onClick.AddListener(Restart);

        coroutine = WaveCreationSequence();
        StartCoroutine(coroutine);

        score = 0;

        Debug.Log(playerDeathCount);
    }


    void Update ()
    {
        distanceTravelled = Time.timeSinceLevelLoad;
        if ((int)distanceTravelled % 100 == 0)
        {
            difficultyAdditive += 1;
        }
    }

    IEnumerator WaveCreationSequence()
		/*This is a three-stage process which checks for each stage of a button press and does specific things
		 *at each phase. First, it calls the Wave Prepare method, which instantiates the outline as a gameobject.
		 *Next, it fixes itself to the cursor's worldposition, or position on the game screeen.
		 *Then, once the player releases the button, it sets the solid object at the last known position.
         *Using a coroutine allows me to add a cooldown timer so the player can't spawn too many waves at once.
		 */
    {
        while (true)
        {

            while (!Input.GetButtonDown("Fire1"))
            {
                yield return null;
            }


            WavePrepare();
            holdDownTimer = Time.time;


            while (Input.GetButton("Fire1"))
            {
                currentWave.transform.position = WorldPosition();
                currentWave.transform.position = new Vector3(
                    Mathf.Clamp(currentWave.transform.position.x, -1.45f, 3.4f),
                    -0.42f, currentWave.transform.position.z);
                if (Time.time - holdDownTimer >= 1.5f)
                {
                    currentWave.gameObject.transform.localScale = new Vector3(1.5F, 1.5F, 0);
                }

                if (Time.time - holdDownTimer >= 2.5f)
                {
                    currentWave.gameObject.transform.localScale = new Vector3(2F, 2F, 0F);
                }
                yield return null;
            }




            currentWave.SetSolid();
            currentWave.Attach();
            holdDownTimer = 0f;

            yield return new WaitForSeconds(coolDownTimer);
        }
    }

    public void ScoreCount()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
        if (score % 20 == 0)
        {
            difficultyAdditive += 1;
        }
    }

    Vector3 WorldPosition ()
	{
		return Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x,Input.mousePosition.y , 10f)); //screen to worldpoint is a method called directly from the main camera, converting pixel 2D co-ordinates into 3D co-ordinates.
	}



    public void PlayerHasBeenHit()
    {
        Debug.Log("Changing boolean...");
        _gameOver = true;
        GameOver();
        Time.timeScale = 0f;


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
	        distanceTravelled = 0f;
	}


    //new method, will deal with the game over state.
    void GameOver()
    {
        if (_gameOver)
        {
            Debug.Log("...Game Over");
            playerDeathCount += 1;
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;

        }
    }
}

