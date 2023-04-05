using UnityEngine;

namespace Project.Scripts.Levels._1.Notob
{
    public class Controller_Notob : MonoBehaviour
    {
        [SerializeField] private Letter_Notob[] _letters;

        [SerializeField] private GameObject _button;

        private bool _letterClicked;

        public void CheckOrder() 
        {
            for (int i = 0; i < _letters.Length - 1; i++)
            {
                if (!(Vector3.Distance(_letters[i].transform.position, _letters[i + 1].transform.position) < 1.0f &&
                    Mathf.Abs(Vector3.Angle(_letters[i + 1].transform.position - _letters[i].transform.position, Vector3.right)) < 15.0f))
                {
                    return;
                }
            }
            _button.SetActive(true);
            for (int i = 0; i < _letters.Length; i++)
            {
                Destroy(_letters[i].gameObject);
            }
            Destroy(this);
        }

        public bool IsLetterClicked()
        {
            return _letterClicked;
        }

        public void SetLetterClicked(bool letterClicked)
        {
            _letterClicked = letterClicked;
        }
    }
}
