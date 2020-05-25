using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 3f;

    [SerializeField]
    private GameObject _laserPrefab;
    private Player _player;
  
    void Start()
    {
         _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //move down at 4 meters per second
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        //when off screen respawn at top
        if(transform.position.y < -5.89f) {
            transform.position = new Vector3(Random.Range(-10f, 10f), 4.9f, 0);
        }

        
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            other.transform.GetComponent<Player>().damage(1);
            Destroy(this.gameObject);
        }
        if(other.tag == "Laser") {
            Destroy(other.gameObject);
            if(_player != null) {
                _player.updateScore(10);
            }
            Destroy(this.gameObject);
           
            
            
            
        }
    }
}
