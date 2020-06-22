using UnityEngine;

public class AtivarMenu : MonoBehaviour
{
    public GameObject menu;

    private void OnMouseDown()
    {
        if (LoadStage.menu == null || !LoadStage.menu.gameObject.activeInHierarchy)
        {
            menu.SetActive(true);
            LoadStage.menu = menu;
        }
    }
}
