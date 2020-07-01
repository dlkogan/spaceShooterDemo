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
    [SerializeField]
    private GameObject _explosionPrefab;
    private Player _player;

    private Animator _anim;
    private AudioSource _audioSource;
  
    void Start()
    {
         _player = GameObject.Find("Player").GetComponent<Player>();
         _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
         if(_player == null) {
             Debug.Log("Player is Null in Enemy");
         }
         if(_anim == null) {
             Debug.Log("Animator is NULL in Enemy");
         }
         if(_audioSource == null)
        {
            Debug.Log("AudioSource is null is Enemey");
        }
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

        if (other.tag == "Player") {
            other.transform.GetComponent<Player>().damage(1);
            _speed = 0;
            _anim.SetTrigger("Enemy_Dead");
            _audioSource.Play();
            Destroy(this.gameObject, 2.5f);

        }
        if(other.tag == "Laser") {
            Destroy(other.gameObject);
            if(_player != null) {
                _player.updateScore(10);
            }
            _speed = 0;
            _anim.SetTrigger("Enemy_Dead");
            _audioSource.Play();
            Destroy(this.gameObject, 2.5f);


        }
        
    }

}
