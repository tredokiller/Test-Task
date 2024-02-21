using System;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class PoolManager : MonoBehaviour
    {
        [SerializeField] private Transform spawnTransform;
        
        public static PoolManager instance;

        [SerializeField] private DisplayButton displayButtonPrefab;
        [SerializeField] private int count;

        private readonly List<DisplayButton> _buttons = new List<DisplayButton>();

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            FillPool();
        }

        private void FillPool()
        {
            for (int i = 0; i < count; i++)
            {
                var button = Instantiate(displayButtonPrefab, spawnTransform);
                
                button.gameObject.SetActive(false);
                _buttons.Add(button);
            }
        }

        public DisplayButton GetButton()
        {
            foreach (var button in _buttons)
            {
                if (button.gameObject.activeSelf == false)
                {
                    return button;
                }
            }

            return null;
        }
    }
}
