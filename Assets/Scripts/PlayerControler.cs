using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed;
    public Transform movePoint;

    public LayerMask whatStopsMovement;

    Vector2 movement;

    //public GameObject gameOverText, restartButton, winText, reloadButton;

    void Start()
    {
        movePoint.parent = null;
        //gameOverText.SetActive(false);
        //winText.SetActive(false);
        //restartButton.SetActive(false);
        //reloadButton.SetActive(false);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .3f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }

            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .3f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
        }
    }
    /*private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("BoxDeath"))
        {
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            GetComponent<PlayerController>().enabled = false;
            TimeController.instance.EndTime();
            Debug.Log("Te toco");
        }

        if (collider.gameObject.tag.Equals("Roland"))
        {
            winText.SetActive(true);
            reloadButton.SetActive(true);
            GetComponent<PlayerController>().enabled = false;
            TimeController.instance.EndTime();
            Debug.Log("Ganaste");
        }*/
}
