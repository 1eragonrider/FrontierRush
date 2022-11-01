using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Nugget nuggetPrefab;
    public Rocks rocksPrefab;
    public Cactus cactusPrefab;
    public PlayerSprite player;
    public float spawnTime = 1f;
    public float spawnRate = 3f;
    public float spawnDistance = 2f;


    void Start()
    {
        transform.position = new Vector3(6,0,0);
        InvokeRepeating(nameof(Spawn), spawnTime, spawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < 1; i++)
        {
            // random spawn point
            float yMin = -spawnDistance;
            float yMax = spawnDistance;

            Vector3 spawnPosition = this.transform.position + new Vector3(0,Random.Range(yMin,yMax),0);
            Vector3 spawnPoint = this.transform.position + spawnPosition;
            Quaternion spawnRotation = Quaternion.identity;

            int spawnObjectDecider = Random.Range(0, 3);
            Vector2 Movementdirection = new Vector2(-50, 0);

            switch(spawnObjectDecider)
            {
                case 0: 
                    Nugget nugget = Instantiate(nuggetPrefab, spawnPoint, spawnRotation);
                    nugget.SetMovement(Movementdirection);
                    break;
                case 1:
                    Rocks rocks = Instantiate(rocksPrefab, spawnPoint, spawnRotation);
                    rocks.SetMovement(Movementdirection);
                    break;
                case 2:
                    Cactus cactus = Instantiate(cactusPrefab, spawnPoint, spawnRotation);
                    cactus.SetMovement(Movementdirection);
                    break;
                default:
                    break;
            }
        }
    }


}
