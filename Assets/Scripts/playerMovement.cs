using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerMovement : MonoBehaviour {
    private float speed;
    private int score;
    public Text scoreText;
    public GameObject playerBird;

    private Vector3 pos;

    // Use this for initialization
    void Start () {
        speed = 3;
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {

        float ax = Input.GetAxis("Horizontal");
        float ay = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(ax, ay) * Time.deltaTime * 0.1f);

        moveUpdate();
        updateScore();
        flyUp();
    }

    private void updateScore()
    {
        score = Mathf.RoundToInt(Time.time);
        scoreText.text = score.ToString();
    }

    private void flyUp()
    {
        if(transform.position.y < 0)
        {
            transform.position = Vector3.MoveTowards(playerBird.transform.position,
                new Vector3(transform.position.x, 0, transform.position.z), 
                Time.deltaTime * speed);
        }
    }

    void moveUpdate()
    {
        if (Input.touchCount > 0)
        {
            Vector3 touchPosition = Input.GetTouch(0).position;
            touchPosition.z = playerBird.transform.position.z - Camera.main.transform.position.z;
            touchPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            touchPosition.y = playerBird.transform.position.y;
            playerBird.transform.position = Vector3.MoveTowards(playerBird.transform.position, touchPosition, Time.deltaTime * speed);
        }
        /*
        if(Application.platform == RuntimePlatform.Android)
        {
            pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 1));
        }
        else
        {
            pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
        }

        transform.position = new Vector3(pos.x + 2, pos.y + 2, pos.z);
        */
    }
}
