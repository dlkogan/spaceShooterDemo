using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private float _rotateSpeed = 5f;

    private Player _player;
    [SerializeField]
    private GameObject _explosionPrefab;
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
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime, Space.Self);
        transform.Translate(Vector3.down * _speed * Time.deltaTime, Space.World);
        if(transform.position.y < -5.89f) {
            transform.position = new Vector3(Random.Range(-10f, 10f), 4.9f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            other.transform.GetComponent<Player>().damage(1);
            Destroy(this.gameObject);
            GameObject _newExplosion = Instantiate(_explosionPrefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            Destroy(_newExplosion, 2f);
        }
        else if(other.tag == "Laser") {
            // GameObject _newExplosion = Instantiate(_explosionPrefab, new Vector3(this.position.x, this.position.y, this.position.z), Quaternion.Identity);
            GameObject _newExplosion = Instantiate(_explosionPrefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            Destroy(_newExplosion, 2f);
            Destroy(this.gameObject);
            Destroy(other.gameObject);

            
        }
 
    }

}
