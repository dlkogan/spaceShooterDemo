using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _enemyContainer;

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject[] _powerUps;
    [SerializeField]
    private GameObject _asteroidPrefab;
    [SerializeField]
    private bool _stopSpawning = false;
    void Start()
    {
        StartCoroutine(spawnEnemyRoutine());
        StartCoroutine(spawnPowerUpRoutine());
        StartCoroutine(spawnAsteroidRoutine());
        
    }

    // Update is called once per frame
    void Update() {

    }

    IEnumerator spawnEnemyRoutine() {
        while(!_stopSpawning) {
            GameObject newEnemy = Instantiate(_enemyPrefab, new Vector3(Random.Range(-10f, 10f), 5f, 0), Quaternion.identity);
            //MAKE SURE YOU PARENT IT TO THE TRANSFORM; ENEMYCONTAINER ITSELF IS NOT A TRANSFORM
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator spawnAsteroidRoutine() {
        while(!_stopSpawning) {
            GameObject newRoid = Instantiate(_asteroidPrefab, new Vector3(Random.Range(-10f, 10f), 5f, 0), Quaternion.identity);
            yield return new WaitForSeconds(6f);
        }
    }

    IEnumerator spawnPowerUpRoutine() {
        while(!_stopSpawning) {
            GameObject newPowerUp = Instantiate(_powerUps[Random.Range(0, 2)], new Vector3(Random.Range(-10f, 10f), 5f, 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(12f, 25f));
        }
    }

    public void onDeath() {
        _stopSpawning = true;
    }

}
