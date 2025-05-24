using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour
{

    public Transform FantasmaVerde;

    public Transform spawnPoint;

    public float timeBetweenWaves = 6f;
    private float countdown = 10f;

    public Text waveCountdownText;

    private int waveIndex = 0;


    // Update is called once per frame
    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave ()
    {
        waveIndex++;


        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }


    }

    void SpawnEnemy()
    {
        Instantiate(FantasmaVerde, spawnPoint.position, spawnPoint.rotation);
    }

}
