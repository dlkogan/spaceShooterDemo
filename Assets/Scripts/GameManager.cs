﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver = false;

    // Update is called once per frame
    void Update()
    {
        if(_isGameOver) {
            if(Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(1); //main game scene
            }
        }
    }
    public void endGame() {
        _isGameOver = true;
    }

    public void startGame() {
        SceneManager.LoadScene(1);
    }
}
