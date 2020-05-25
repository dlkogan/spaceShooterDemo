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
    [SerializeField]
    private Text _restartText;
    private GameManager _gameManager;

    void Start()
    {
        _gameOver.text = "";
        _restartText.transform.gameObject.SetActive(false);
        _livesIMG.sprite = _livesSprites[3];
        _score.text = "Score: " + 0;
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(_gameManager == null) {
            Debug.LogError("GameManager is NULL");
        }
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
            gameOverSequence();
        }
    }
    
    void gameOverSequence() {
        _gameManager.endGame();
        _gameOver.text = "GAME OVER";
        _restartText.transform.gameObject.SetActive(true);
        StartCoroutine(gameOverFlicker());
    }
    IEnumerator gameOverFlicker() {
        while(true) {
            _gameOver.text = "GAME OVER";
            yield return new WaitForSeconds(Random.Range(0.09f, 1f));
            _gameOver.text = "";
            yield return new WaitForSeconds(Random.Range(0.09f, 1f));
        }
    }
}
