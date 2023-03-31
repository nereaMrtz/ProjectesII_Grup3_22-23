using TMPro;
using UnityEngine;

namespace Project.Scripts.Levels._1.Equacion
{
    public class Title_Equación : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _titleText;

        [SerializeField] private Door_Equacion _door;

        private int[] _keyPressCounter = new int[4];

        private string _numberLevel;

        private void Start()
        {
            int _spaceIndex = 0;
            for (int i = 0; i < _titleText.text.Length; i++)
            {
                if (_titleText.text[i] == ' ')
                {
                    _spaceIndex = i;
                    break;
                }
            }

            _numberLevel = _titleText.text.Substring(0, _spaceIndex + 1);
            _door.OpenDoor();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _keyPressCounter[0]++;
                RewriteTitle();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                _keyPressCounter[1]++;
                RewriteTitle();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                _keyPressCounter[2]++;
                RewriteTitle();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                _keyPressCounter[3]++;
                RewriteTitle();
            }
        }

        private void RewriteTitle()
        {
            _titleText.text = _numberLevel + _keyPressCounter[0] + " = " + _keyPressCounter[1] + " = " + _keyPressCounter[2] + " = " + _keyPressCounter[3];

            int initialValue = _keyPressCounter[0];

            for (int i = 1; i < _keyPressCounter.Length; i++)
            {
                bool check = _keyPressCounter[i] == initialValue;
                if (!check)
                {
                    _door.CloseDoor();
                    return;
                }
            }

            _door.OpenDoor();
        }
    }
}
