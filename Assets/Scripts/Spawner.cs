using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public GameObject go;
    public bool active;
    public Enemy(GameObject newGo, bool newBool)
    {
        go = newGo;
        active = newBool;
    }
}

public class Spawner : MonoBehaviour
{
    public GameObject spawn;
    public int amount = 1;
    public float delaySpawn = 1;
    public bool spawnsDead;

    private int getAmount;
    private float timer;
    private int spawned;
    private int enemyDead;

    public List<Enemy> enemies = new List<Enemy>();

    // Start is called before the first frame update
    private void Start()
    {
        GameManager.RoundComplete += ResetRound;

        ResetRound();

        while (spawned < getAmount)
        {
            // inc amount spawned
            spawned++;

            // new prefab instance
            GameObject instance = Instantiate(spawn, transform);
            enemies.Add(new Enemy(instance, false));

            // Remove spawned obj from spawner obj
            instance.transform.parent = null;
            instance.SetActive(false);
        }

        ResetRound();
    }

    // Update is called once per frame
    void Update()
    {
        // inc timer
        timer += Time.deltaTime;

        // if timer is > delay, spawn
        if (delaySpawn < timer)
        {
            if (spawned < getAmount)
            {
                timer = 0;

                // enemy state
                enemies[spawned].active = true;

                // enemy active
                enemies[spawned].go.SetActive(true);

                // set isKinematic
                StartCoroutine(SetKinematic(spawned));

                spawned++;
            }

            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                // if disabled
                if (enemies[i].go.activeSelf == false && enemies[i].active == true)
                {
                    //Reset spawn pos, set tracking as inactive
                    enemies[i].go.transform.position = transform.position;
                    enemies[i].active = false;
                    enemyDead++;
                }
            }

            if (enemyDead == enemies.Count)
            {
                spawnsDead = true;
            }
        }
    }

    private void ResetRound()
    {
        spawnsDead = false;
        getAmount = amount;
        spawned = 0;
        timer = 0;
        enemyDead = 0;
    }

    IEnumerator SetKinematic(int id)
    {
        // set isKinematic at start of the next frame; avoids confusion w/ other commands
        yield return null;
        enemies[id].go.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void OnDrawGizmos()
    {
        // draw wireframe mesh of spawn
        Gizmos.color = Color.red;

        if (spawn != null)
        {
            Gizmos.DrawWireMesh(spawn.GetComponent<MeshFilter>().sharedMesh,transform.position, spawn.transform.rotation, Vector3.one);
        }
    }
}
