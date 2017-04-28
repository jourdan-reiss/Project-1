using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    private Camera _camera;
    private float defaultCameraHeight;
    protected CircleCollider2D playerCollider;
    private Vector3 defaultCameraPosition;
	private Vector3 lastPlayerPosition;
	private float DistanceToMove;
    private bool hazardIsInTrigger;



    public float targetCameraSize;
    public float zoomSpeed;


	private Player player;


	void Start ()
	{

	    _camera = GetComponent<Camera>();
		player = FindObjectOfType<Player>();
		lastPlayerPosition = player.transform.position; //the initial position at start, and the position on the last frame

	    defaultCameraPosition = _camera.transform.position;
	    defaultCameraHeight = _camera.orthographicSize; //camera size is a real number, so we use floats. Ortho camera sizes only measure from middle to top in viewpoint
	}


   public void ActivateZoomMethod()
    {
        hazardIsInTrigger = true;
        StartCoroutine(ZoomInOnPlayer());
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

   public  void DeactivateZoomMethod()
    {
        Debug.Log("Reset Camera Position");
        hazardIsInTrigger = false;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02F;
    }

    IEnumerator ZoomInOnPlayer() //runs when called, waits until boolean is true before zooming in. Once false, it should zoom out
    {
        while (hazardIsInTrigger)
        {
            CircleCollider2D target = GetTarget();
            OrthoZoom(target.bounds.center, targetCameraSize, zoomSpeed);


            yield return null;
        }


        Debug.Log("The boolean has been set to false");

        while (!hazardIsInTrigger)
        {
            OrthoZoom(defaultCameraPosition, defaultCameraHeight, 2 * zoomSpeed);

            yield return null;
        }
    }

    void OrthoZoom(Vector2 center, float regionHeight, float smoothing) // uses lerp to move the camera position to desired position and reduce the camera size.
    {
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, new Vector3(center.x, center.y, defaultCameraPosition.z), Time.deltaTime * smoothing);
        _camera.orthographicSize = Mathf.Lerp(_camera.orthographicSize, regionHeight, Time.deltaTime * smoothing);
    }

    CircleCollider2D GetTarget() //gets the player collider so that I can zoom in on the player directly.
    {

        playerCollider = player.GetComponent<CircleCollider2D>();
        return playerCollider;
    }

 	public void FixedUpdate () 
	{
		DistanceToMove = player.transform.position.x  - lastPlayerPosition.x;
		transform.position = new Vector3 (transform.position.x + DistanceToMove, transform.position.y, transform.position.z);
		lastPlayerPosition = player.transform.position;
	}

}
