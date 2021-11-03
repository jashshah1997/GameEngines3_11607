using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1.0f;
    private static float x_pos = 4;
    private static float y_pos = 0;
    private static bool firstRun = true;

    // Start is called before the first frame update
    void Start()
    {
        if (!firstRun)
            gameObject.transform.position = new Vector3(x_pos, y_pos, 0);
        firstRun = false;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(inputX * moveSpeed, inputY * moveSpeed, 0);
        x_pos = gameObject.transform.position.x;
        y_pos = gameObject.transform.position.y;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bush")
        {
            if (Random.Range(0, 250) < 2)
            {
                SceneManager.LoadScene("FightScene");
            }
        }
    }
}
