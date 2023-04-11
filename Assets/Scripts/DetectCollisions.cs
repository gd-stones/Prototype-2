using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the other tag was the Player, if it was remove a life
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Game over");
            gameManager.AddLives(-1);
            Destroy(gameObject);
        }
        // Check if the other tag was an Animal, if so add points to the score
        else if (other.CompareTag("Animal"))
        {
            //gameManager.AddScore(5);
            other.GetComponent<AnimalHunger>().FeedAnimal(1);
            Destroy(other.gameObject);
            //Destroy(other.gameObject);
        }
        //else
        //{
        //    Destroy(gameObject);
        //    Destroy(other.gameObject);
        //}
    }
}
