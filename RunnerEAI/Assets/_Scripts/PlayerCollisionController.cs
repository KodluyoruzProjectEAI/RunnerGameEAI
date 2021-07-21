using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace PlayerCollision
{
    public class PlayerCollisionController : MonoBehaviour
    {

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "_obstacle")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log("kontrol");
            }
        }
    }
}

