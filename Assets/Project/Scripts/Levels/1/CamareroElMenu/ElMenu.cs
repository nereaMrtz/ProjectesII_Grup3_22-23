using Project.Scripts.Interactable.Static;
using Project.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

public class ElMenu : MonoBehaviour
{
    [SerializeField] Sprite[] menuSprites;
    [SerializeField] Button menu;
    [SerializeField] Sprite openDoor;
    [SerializeField] UnlockableObject door;
    [SerializeField] GameObject pauseMenu;
    int actualSprite;

    private void Start()
    {
        menu.image.sprite=menuSprites[actualSprite];
    }

    public void NextMenu()
    {
        if (actualSprite+1 <= menuSprites.Length - 1)
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
            pauseMenu.SetActive(false);
            GameManager.Instance.SetPause(false);
            Time.timeScale = 1;

            if (door.IsUnlocked())
            {
                return;
            }
            door.Unlock();
        }
    }
}
