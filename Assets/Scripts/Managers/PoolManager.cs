using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class PoolManager : MonoBehaviour
    {
        public static PoolManager instance;

        [SerializeField] private DisplayButton displayButtonPrefab;
        [SerializeField] private int count;

        private readonly List<DisplayButton> _buttons = new List<DisplayButton>();
    
        private void Start()
        {
            FillPool();
        }

        private void FillPool()
        {
            for (int i = 0; i < count; i++)
            {
                _buttons.Add(Instantiate(displayButtonPrefab, transform));
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
