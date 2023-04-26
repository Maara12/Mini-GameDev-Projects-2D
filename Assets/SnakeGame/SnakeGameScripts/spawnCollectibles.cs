using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCollectibles : MonoBehaviour
{

    [SerializeField]
    private Collider2D spawnArea;

    Bounds spawnbounds;

    // Start is called before the first frame update
    void Start()
    {
        spawnbounds = spawnArea.bounds;
        SpawnCollectibleAtRandomPosUsingBounds();

    }

    private void SpawnCollectibleAtRandomPosUsingBounds()
    {

        float randomXPosA = Random.Range(spawnbounds.min.x,
            spawnbounds.max.x);
        float randomYPosB = Random.Range(spawnbounds.min.y,
            spawnbounds.max.y);

        Vector2 foodPosition = new Vector2(Mathf.Round(randomXPosA), Mathf.Round(randomYPosB));
        
        this.transform.position = foodPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Food Collidedddd",other);

        if(other.tag == "Player")
        {
            SpawnCollectibleAtRandomPosUsingBounds();
        }
    }

    /*
    private void SpawnAtRandomPosClassic()
    {
        float randomXPos = Mathf.Round(Random.Range(-25.5f, 25.5f));
        float randomYPos = Mathf.Round(Random.Range(-14f, 14f));

        Vector2 foodPosition = new Vector2(randomXPos, randomYPos);
        //Instantiate(foodPrefab);
        transform.position = foodPosition;
    }*/
    

}
