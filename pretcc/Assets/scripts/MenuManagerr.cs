using UnityEngine;

public class MenuManagerr : MonoBehaviour
{
    public GameObject menu;
    public GameObject game;

    public void IniciarJogo()
    {
        menu.SetActive(false);
        game.SetActive(true);
    }
}