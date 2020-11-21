using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesativaBotao : MonoBehaviour
{
    public Button drauzio, plateia, dado, rolaDado;
    public void DesativarBotaoDrauzio()
    {
        drauzio.interactable = false;
    }
    public void DesativarBotaoDado()
    {
        dado.interactable = false;
    }
    public void DesativarBotaoPlateia()
    {
        plateia.interactable = false;
    }

    public void DesativarBotaoRolaDado()
    {
        rolaDado.interactable = false;
    }
}
