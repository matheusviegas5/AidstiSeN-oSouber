using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StringDinheiro : MonoBehaviour
{
    public Text acertar;
    public Text parar;
    public Text errar;
    public Text errarDesejaContinuar;
    private void Start()
    {
        AtualizaDinheiro();
    }

    public void AtualizaDinheiro()
    {
        if (Perguntas.questao == 1) 
        {
            acertar.text = "Mil";
            parar.text = "-";
            errar.text = "-";
            errarDesejaContinuar.text = "-";
        } 
        else if (Perguntas.questao == 2)
        {
            acertar.text = "10 mil";
            parar.text = "Mil";
            errar.text = "-";
            errarDesejaContinuar.text = "-";
        }
        else if (Perguntas.questao == 3)
        {
            acertar.text = "100 mil";
            parar.text = "Dez mil";
            errar.text = "Mil";
            errarDesejaContinuar.text = "Mil";

        }
        else if (Perguntas.questao == 4)
        {
            acertar.text = "200 mil";
            parar.text = "100 mil";
            errar.text = "10 mil";
            errarDesejaContinuar.text = "10 mil";

        }
        else if (Perguntas.questao == 5)
        {
            acertar.text = "500 mil";
            parar.text = "200 mil";
            errar.text = "100 mil";
            errarDesejaContinuar.text = "100 mil";


        }
        else if (Perguntas.questao == 6)
        {
            acertar.text = "1 MILHÃO";
            parar.text = "500 mil";
            errar.text = "200 mil";
            errarDesejaContinuar.text = "200 mil";

        }


;




    }
}
