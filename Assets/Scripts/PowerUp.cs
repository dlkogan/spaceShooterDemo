using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private int _powerType = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if(transform.position.y < -4.89f) {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            Player player = other.transform.GetComponent<Player>();
            if(player != null) {

            switch(_powerType) {
                case 0:
                    player.togglePowerup("tripleShot");
                    break;
                case 1:
                    player.togglePowerup("speedUp");
                    break;
                case 2:
                    player.togglePowerup("shieldsUp");
                    break;
                default:
                    Debug.Log("oops");
                    break;
            }
                
            }
            Destroy(this.gameObject);
        }
    }


}
