using Project.Scripts.Interactable.Static;
using TMPro;
using UnityEngine;

public class Contrasena1627 : MonoBehaviour
{
    [SerializeField] int level;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] UnlockableObject door;
    int[] combination = new int[4];
    int position = 0;


    private void Update()
    {
        if(position ==4)
        {
            if (combination[0] == 1 && combination[1] == 6 && combination[2] == 2 && combination[3] == 7)
            {
                door.Unlock();
                text.text = ";)";
            }
            else
            {
                text.text = "";
                position = 0;  
            }
            
        }
    }
    public void AddLevel(int level)
    {
        combination[position] = level;
        text.text += level.ToString();
        position++;
    }


}
