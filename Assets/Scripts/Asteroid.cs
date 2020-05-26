using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 3f;
    private Player _player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if(_player == null) {
            Debug.Log("Player is NULL");
        }
        transform.Rotate(0f,0f,0.2f, Space.Self);
        transform.Translate(Vector3.down * _speed * Time.deltaTime, Space.World);
        if(transform.position.y < -5.89f) {
            transform.position = new Vector3(Random.Range(-10f, 10f), 4.9f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            other.transform.GetComponent<Player>().damage(1);
            Destroy(this.gameObject);

        }
        else if(other.tag == "Laser") {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

}
