using Project.Scripts.Interactable.Static;
using UnityEngine;
using UnityEngine.UI;

public class ElMenu : MonoBehaviour
{
    [SerializeField] Sprite[] menuSprites;
    [SerializeField] Button menu;
    [SerializeField] Sprite openDoor;
    [SerializeField] UnlockableObject door;
    int actualSprite=0;

    private void Start()
    {
        menu.image.sprite=menuSprites[actualSprite];
    }

    public void NextMenu()
    {
        if (actualSprite+1 <= menuSprites.Length)
        {
            menu.image.sprite = menuSprites[actualSprite + 1];
            actualSprite++;
        }
    }

    public void leftMenu()
    {
        if (actualSprite-1 >= 0)
        {
            menu.image.sprite = menuSprites[actualSprite - 1];
            actualSprite--;
        }
    }

    public void CheckDoorMenu()
    {
        if(menu.image.sprite == openDoor)
        {
            door.Unlock();
        }
    }
}
