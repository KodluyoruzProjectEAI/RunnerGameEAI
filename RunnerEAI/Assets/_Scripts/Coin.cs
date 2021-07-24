using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Managers;

namespace _coin
{
    public class Coin : MonoBehaviour
    {
        GameObject _gameObject;
        Vector3 _position;
        PlayerController playerController;
        GameManager gameManager;
        private void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
        }
        private void Update()
        {
            //_position = transform.TransformPoint(Vector3.right * 2);
            //Instantiate(_gameObject, _position, _gameObject.transform.rotation);
            //transform.Rotate(0, 0, 90 * Time.deltaTime);
        }
        private void OnTriggerEnter(Collider other)
        {
            playerController = other.GetComponent<PlayerController>();
            if (playerController)
            {
                Destroy(gameObject);
                
            }
        }
    }

}
