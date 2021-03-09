using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StatusPlayerUI : MonoBehaviour
{
    private PlayerDescription player;

    public TextMeshProUGUI rol,status;
    public GameObject AssasinPanel;
    void Start()
    {
        player = new PlayerDescription();
        rol.text = (player.IsNavigator)?"Rol: Navegante":"Rol: Traidor";
        status.text = (player.IsAlive)?"Estado: Vivo":"Estado: Funado";
        if(!player.IsNavigator)
        {
            rol.color = Color.red;
            AssasinPanel.SetActive(true);
        }
        player.printToString();

    }

    void Update()
    {
        rol.text = (player.IsNavigator)?"Rol: Navegante":"Rol: Traidor";
        status.text = (player.IsAlive)?"Estado: Vivo":"Estado: Funado";
        if(!player.IsNavigator)
        {
            rol.color = Color.red;
            AssasinPanel.SetActive(true);
        }
        player.printToString();
    }


}
