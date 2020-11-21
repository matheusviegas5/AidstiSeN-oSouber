using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespostaPlateia : MonoBehaviour
{   
    public GameObject[] imagensPlacas;
    public Text[] placas;
    public Text[] alternativas;
    public static bool ajudaPlateia = false;

    private void Start()
    {
        ajudaPlateia = false;
    }
    // Update is called once per frame
    public void SortearPlacas()
    {
        for (int i = 0; i < imagensPlacas.Length; i++)
        {
            imagensPlacas[i].SetActive(true);
        }
        int valor = Random.Range(1, 5);
        FindObjectOfType<AudioManager>().Play("ajudaPlateia_" + valor);


        float um = 0, dois = 0, tres = 0, quatro = 0;

        for (int i = 0; i < placas.Length; i++)
        {
            float sorte = Random.Range(0, 101);
            if (sorte <= 40) //resposta certa
            {

                placas[i].text = Perguntas.respostaCerta.ToString();
                if (Perguntas.respostaCerta == 1) um++;
                else if (Perguntas.respostaCerta == 2) dois++;
                else if (Perguntas.respostaCerta == 3) tres++;
                else if (Perguntas.respostaCerta == 4) quatro++;

            }
            else
            {
                int respostaErrada;
                do
                {
                    respostaErrada = Random.Range(1, 5);

                } while (respostaErrada == Perguntas.respostaCerta);

                placas[i].text = respostaErrada.ToString();
                if (respostaErrada == 1) um++;
                else if (respostaErrada == 2) dois++;
                else if (respostaErrada == 3) tres++;
                else if (respostaErrada == 4) quatro++;



            }
        }
        alternativas[0].text = (System.Math.Round(((um * 100) / placas.Length), 2)).ToString() + "%";
        alternativas[1].text  = (System.Math.Round(((dois * 100) / placas.Length), 2)).ToString() + "%";
        alternativas[2].text = (System.Math.Round(((tres * 100) / placas.Length), 2)).ToString() + "%";
        alternativas[3].text = (System.Math.Round(((quatro * 100) / placas.Length), 2)).ToString() + "%";
        ajudaPlateia = true;
    }

    public void ResetarPlacas()
    {
        for (int i = 0; i < placas.Length; i++)
        {
        placas[i].text = " ";

        }
        for (int i = 0; i < imagensPlacas.Length; i++)
        {
            imagensPlacas[i].SetActive(false);
        }
        alternativas[0].text = " ";
        alternativas[1].text = " ";
        alternativas[2].text = " ";
        alternativas[3].text = " ";
    }
}
