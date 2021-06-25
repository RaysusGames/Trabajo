using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   [SerializeField] private float move, moveSpeed, rotation, rotationSpeed,timer;
    public bool reduc,onTime;
    float time;
    public GameObject meta1,meta2;

    private void Start()
    {
        moveSpeed = 5f;
        rotationSpeed = 100f;

    }

    private void Update()
    {
        move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        rotation = Input.GetAxis("Horizontal") * -rotationSpeed * Time.deltaTime;

        if (reduc)
        {
            timer += Time.deltaTime;

            if (timer >= 3)
            {
                reduc = false;
                timer = 0;
                moveSpeed = 5f;
            }
        }
       
        if (onTime)
        {
            time += Time.deltaTime;
        }
      
       
    }

    private void LateUpdate()
    {
        transform.Translate(0f, move, 0f);
        transform.Rotate(0f, 0f, rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Reduc"))
        {
            moveSpeed = 2;
            reduc = true;
        }
        if (collision.CompareTag("Bust"))
        {
            moveSpeed = 6;
        }
        else
        {
            moveSpeed = 5;
        }
        if (collision.CompareTag("Destroy"))
        {
            Destroy(this.gameObject);
            Debug.Log("GameOver");
        }
        if (collision.CompareTag("Meta"))
        {
            onTime = true;
            meta1.SetActive(true);
            meta2.SetActive(false);
        }
        if (collision.CompareTag ("Finishh"))
        {
            Debug.Log(time);
        }
    }
    
}
