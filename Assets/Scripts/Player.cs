﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private bool _tripleShot = false;
    [SerializeField]
    private GameObject _shieldObject;
    private bool _speedUp = false;
    private bool _shieldsUp = false;
    [SerializeField]
    private float _fireRate = 0.2f;
    private float _nextFire = 0.0f;
    [SerializeField]
    private int _lives = 3;
    //initialize spawnManager
    private SpawnManager _spawnManager;
    [SerializeField]
    private int _score = 0;
    private UIManager _uiManager;
    [SerializeField]
    private GameObject _hurtL;
    [SerializeField]
    private GameObject _hurtR;
    [SerializeField]
    private AudioClip _shoot;
    [SerializeField]
    private AudioSource _audioSource;
    private AudioSource _powerUpAudio;


    void Start()
    {
        
        transform.position = new Vector3(0, -4.89f, 0);
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _powerUpAudio = GetComponent<AudioSource>();
        if(_spawnManager == null) {
            Debug.Log("SpawnManager is null");
        }
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(_uiManager == null) {
            Debug.Log("ui manager is null");
        }
        if(_powerUpAudio == null)
        {
            Debug.Log("audioManager null in player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        calculateMovement();
        shootLaser();
    }
    void shootLaser() {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire) {
            _nextFire = Time.time + _fireRate;
            
            if (_tripleShot) {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            }
            else {
                Instantiate(_laserPrefab, transform.position + new Vector3(0,1.05f,0), Quaternion.identity);
            }
            _audioSource.PlayOneShot(_shoot);

        }
        

    }

    void calculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        float maxY = 4.9f;
        float minY = -4.89f;
        float maxX = 11.3f;
        float minX = -11.3f;
        if (transform.position.y >= maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY, 0);
        }
        else if (transform.position.y <= minY)
        {
            transform.position = new Vector3(transform.position.x, minY, 0);
        }

        if (transform.position.x >= maxX)
        {
            transform.position = new Vector3(minX, transform.position.y, 0);
        }
        else if (transform.position.x < minX)
        {
            transform.position = new Vector3(maxX, transform.position.y, 0);
        }
    }

    public void damage(int n) {
        if(!_shieldsUp) {
            showDamage();
            _lives -= n;
            _uiManager.updateLives(_lives);
            if(_lives < 1) {
                _spawnManager.onDeath();
                Destroy(this.gameObject);
            
            }
        } else {
            _shieldsUp = false;
            _shieldObject.SetActive(false);
            return;
        }

    }

    public void showDamage()
    {
        //We will check to see if any damage visualizer is there
        if(_lives == 3)
        {
            int num = Random.Range(0, 1);
            if(num <= 0)
            {
                _hurtL.SetActive(true);
            } else
            {
                _hurtR.SetActive(true);
            }
        }
        else
        {
            if(_hurtL.activeSelf)
            {
                _hurtR.SetActive(true);
            }
            else
            {
                _hurtL.SetActive(true);
            }
        }
        //If yes, make the other one visible
        //else, randomly choose one
    }

    public void togglePowerup(string powerType) {
        if(powerType == "tripleShot") {
            _tripleShot = true;
            StartCoroutine(powerUpCoolDown(powerType));
            
        } else if(powerType == "speedUp") {
            _speed = 10f;
            _speedUp = true;
            StartCoroutine(powerUpCoolDown(powerType));
            
        } else if(powerType == "shieldsUp") {
            _shieldsUp = true;
            _shieldObject.SetActive(true);
        } else {
            Debug.Log("That's not a real powerup!");
        }
        _powerUpAudio.Play();
        

    }

    IEnumerator powerUpCoolDown(string powerType) {
        if(powerType == "tripleShot") {
            while(_tripleShot) {
                yield return new WaitForSeconds(6.0f);
                _tripleShot = false;
            }
        } else if (powerType == "speedUp") {
            while(_speedUp) {
                yield return new WaitForSeconds(6.0f);
                _speed = 5f;
                _speedUp = false;
            }
        }

        
    }

    public void updateScore(int points) {
        _score += points;
        _uiManager.updateScoreText(_score);
    }
 

    
}