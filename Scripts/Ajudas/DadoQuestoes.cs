using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DadoQuestoes : MonoBehaviour
{

    public Text numeroSorteadoTxt;
    public Text numeroRolandoTxt;
    public GameObject[] resposta;
    private int j;
    public static bool ajudaDado = false;

    private void Start()
    {
        ajudaDado = false;
    }
    public void SortearDado()
    {
        StopCoroutine(RolandoDados());
        numeroRolandoTxt.gameObject.SetActive(false);
        int numeroSorteado = Random.Range(1, 4);
        numeroSorteadoTxt.text = numeroSorteado.ToString();
        try
        {

            for (int i = 0; i < numeroSorteado; i++)
            {
                do
                {
                    j = Random.Range(1, 5);

                } while ((j == Perguntas.respostaCerta) || !resposta[j].activeSelf);

                resposta[j].SetActive(false);

            }
        }
        catch (System.Exception)
        {


        }

        ajudaDado = true;
    }

    private bool trigger;
    public void RolaDados()
    {
        if (!trigger)
        {
            StartCoroutine(RolandoDados());
            trigger = true;
        }
    }

    IEnumerator RolandoDados()
    {
        numeroRolandoTxt.text = "1";
        yield return new WaitForSeconds(0.05f);
        numeroRolandoTxt.text = "3";
        yield return new WaitForSeconds(0.05f);
        numeroRolandoTxt.text = "2";
        yield return new WaitForSeconds(0.05f);
        numeroRolandoTxt.text = "1";
        yield return new WaitForSeconds(0.05f);
        numeroRolandoTxt.text = "2";
        yield return new WaitForSeconds(0.05f);
        numeroRolandoTxt.text = "1";
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(RolandoDados());
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.H))
    //    {
    //        for (int i = 0; i < resposta.Length; i++)
    //        {
    //            resposta[i].SetActive(true);
    //        }
    //    }
    //}
}
