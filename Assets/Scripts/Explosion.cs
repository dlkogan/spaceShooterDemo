using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private AudioClip _explode;
    [SerializeField]
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GameObject.Find("Background").GetComponent<AudioSource>();
        if(!_audioSource)
        {
            Debug.Log("AudioSource is null in Explosion");
        } else
        {
            _audioSource.PlayOneShot(_explode);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
