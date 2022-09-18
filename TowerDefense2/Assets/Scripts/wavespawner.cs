using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wavespawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform SpawnPoint;

    public float TimeBetweenWavens = 5f;
    private float countDown = 2f;

    public Text WaveTimertext;

    private int waveIndex = 0;

    void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(spawnwaves());
            countDown = TimeBetweenWavens;

        }

        countDown -= Time.deltaTime;

        WaveTimertext.text = Mathf.Round(countDown).ToString();
    }
    IEnumerator spawnwaves()
    {
        for (int i = 0; i < waveIndex; i++)
        {
            spawnenemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveIndex++;
    }
    void spawnenemy()
    {
        Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }
}
