using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate=1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;
    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn),spawnRate,spawnRate);
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
    private void Spawn()
    {
        GameObject pipes = Instantiate(pipePrefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        
        pipes.transform.Find("Top").position += new Vector3(0f, ((float)Random.Range(-1,1)) / 2.0f, 0f);
        pipes.transform.Find("Bottom").position += new Vector3(0f, ((float)Random.Range(-1, 1)) / 2.0f, 0f);
    }
}
