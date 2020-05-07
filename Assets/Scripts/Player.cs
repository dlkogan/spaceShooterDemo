using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    void Start()
    {
        transform.position = new Vector3(0, -4.89f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        calculateMovement();
        shootLaser();
    }
    void shootLaser() {
        if(Input.GetKeyDown(KeyCode.Space)) {
           Instantiate(_laserPrefab, transform.position + new Vector3(0,1,0), Quaternion.identity);
 
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
}
