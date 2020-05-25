using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _score;
    // Start is called before the first frame update
    [SerializeField]
    private Sprite[] _livesSprites;
    [SerializeField]
    private Image _livesIMG;
    [SerializeField]
    private Text _gameOver;
    private bool _isGameOver = false;

    void Start()
    {
        _gameOver.transform.gameObject.SetActive(false);
        _livesIMG.sprite = _livesSprites[3];
        _score.text = "Score: " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateScoreText(int newScore) {
        _score.text = "Score: " + newScore.ToString();
    }
    public void updateLives(int livesIMGIndex) {
        _livesIMG.sprite = _livesSprites[livesIMGIndex];
        if(livesIMGIndex == 0) {
            _isGameOver = true;
            StartCoroutine(gameOverFlicker());
        }
    }
    //Create a flicker IEnumerator
    //if lives is 0 start this coRoutine
    void gameOverFlicker() {
        while(_isGameOver) {
            bool isVis = true;
            yield return new WaitForSeconds(0.4f);
            _gameOver.transform.gameObject.SetActive(!isVis);
        }
    }
}
