using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class LevelManager : Singleton<LevelManager>
    {
        public static event System.Action OnNextLevel;

        [SerializeField] List<GameObject> levelList;
        int currentLevel ;
        void Awake()
        {
            currentLevel = 0;
            StartSingleton(this);
            //levelList = new List<GameObject>();
        }
        void OnEnable()
        {
            OnNextLevel += NextLevel;
        }
        void OnDisable()
        {
            OnNextLevel -= NextLevel;    
        }
        void Start()
        {
            DisableLevels();
            levelList[currentLevel].SetActive(true);
        }
        void NextLevel()
        {
            DisableLevels();
            currentLevel++;
            levelList[currentLevel].SetActive(true);
        }
        void DisableLevels()
        {
            foreach (GameObject go in levelList)
            {
                go.SetActive(false);
            }
        }
        public void NextLevelButton()
        {
            OnNextLevel?.Invoke();
        }
    }

}
