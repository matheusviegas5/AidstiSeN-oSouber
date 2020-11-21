using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoAjuda : MonoBehaviour
{
    public GameObject painelAjuda;
    private Image corBotao;
    // Start is called before the first frame update
    void Start()
    {
        corBotao = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (painelAjuda.activeSelf)
        {        
            corBotao.color = new Color32(255, 255, 225, 130);
        }
        else
        {
            corBotao.color = new Color32(255, 255, 225, 255);
        }

    }
}
