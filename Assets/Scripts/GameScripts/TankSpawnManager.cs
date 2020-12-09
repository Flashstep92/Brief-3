using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TankSpawnManager : MonoBehaviour
{
    public List<Transform> allPossibleSpawnPoints = new List<Transform>(); // this a list of all the possible tank spawn locations
    private List<Transform> startingAllPossibleSpawnPoints = new List<Transform>();// storing the starting value of all possible spawn points
    public List<GameObject> minePrefabs = new List<GameObject>(); // a list of all the possible tank prefabs
    private List<GameObject> allMinesSpawnedIn = new List<GameObject>(); // a list of all the tanks spawned in

    private void OnEnable()
    {
        TankGameEvents.SpawnTanksEvent += SpawnTanks;
        TankGameEvents.OnResetGameEvent += Reset;
        TankGameEvents.OnRoundResetEvent += Reset;
    }

    private void OnDisable()
    {
        TankGameEvents.SpawnTanksEvent -= SpawnTanks;
        TankGameEvents.OnResetGameEvent -= Reset;
        TankGameEvents.OnRoundResetEvent -= Reset;
    }

    /// <summary>
    /// This is called in our scene help us with debugging.
    /// </summary>
    private void OnDrawGizmos()
    {
        // loops through all the possible spawn points
        for(int i=0; i<allPossibleSpawnPoints.Count; i++)
        {
            Gizmos.color = Color.blue; // set the colour of our gizmo to blue
            Gizmos.DrawSphere(allPossibleSpawnPoints[i].position, 0.25f); // draw a gizmo for our spawn point location
        }
    }

    /// <summary>
    /// Resets our game and destroys the current tanks
    /// </summary>
    private void Reset()
    {
        for (int i = 0; i < allMinesSpawnedIn.Count; i++)
        {
            Destroy(allMinesSpawnedIn[i]);// destroy each tank we spawned in
        }
        allMinesSpawnedIn.Clear(); // clear the list so we can start fresh
        startingAllPossibleSpawnPoints.Clear(); // clear our starting spawn points
        // get a new copy of all the possible spawn points
        for (int i = 0; i < allPossibleSpawnPoints.Count; i++)
        {
            startingAllPossibleSpawnPoints.Add(allPossibleSpawnPoints[i]); // do a hard copy, and copy across all the possible spawn points to our private list
        }
    }

    private void SpawnTanks(int NumberToSpawn)
    {
        if (minePrefabs.Count >= NumberToSpawn && allPossibleSpawnPoints.Count >= NumberToSpawn)
        {
            // we good to go
            for (int i = 0; i < NumberToSpawn; i++)
            {
                // checking if I have enough unique prefabs so I can spawn different tanks
                // spawn in a tank prefab, at a random spawn point
                Transform tempSpawnPoint = startingAllPossibleSpawnPoints[Random.Range(0, startingAllPossibleSpawnPoints.Count)]; // getting a random spawn point
                GameObject clone = Instantiate(minePrefabs[i], tempSpawnPoint.position, minePrefabs[i].transform.rotation);
                startingAllPossibleSpawnPoints.Remove(tempSpawnPoint); // remove the temp spawn point from our possible spawn point list
                allMinesSpawnedIn.Add(clone); // keep track of the tank we just spawned in
            }
        }
        else
        {
            Debug.LogError("Number of tanks to spawn is less than either the number of spawn points, or the number tank prefabs");
        }

        TankGameEvents.OnTanksSpawnedEvent?.Invoke(allMinesSpawnedIn); // tell the game that our tanks have been spawned in!
    }
}
