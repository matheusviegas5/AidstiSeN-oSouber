using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respostas : MonoBehaviour
{
    public Perguntas perguntas;
    public bool trigger;
    public Button botaoParar;
    public Button botaoAjuda;
    public GameObject painelAjuda;

    public Button[] botoes;
    // Start is called before the first frame update


    public void CertououErrado()
    {
        botaoParar.interactable = false;
        botaoAjuda.interactable = false;
        painelAjuda.SetActive(false);
        PlateiaTensa();
        try
        {
            RespostaEsta();
            if (Perguntas.acertou && !trigger)
            {
                
                StartCoroutine(FalaCertaRespota());
                this.GetComponent<Animator>().SetTrigger("acertou");
                trigger = true;
            }
            else if (!Perguntas.acertou && !trigger)
            {
               
                StartCoroutine(FalaErradaRespota());
                this.GetComponent<Animator>().SetTrigger("errou");
                trigger = true;
            }
        }
        catch (System.Exception)
        {
        }

    }

    public void ChamaGameManager()
    {
        try
        {
            if (Perguntas.acertou)
            {
                trigger = false;
                StartCoroutine(FalaExplicacaoDrAuzioCerto());
            }
            else
            {
                StartCoroutine(FalaExplicacaoDrAuzioErrado());
            }
        }
        catch (System.Exception)
        {


        }

    }

    public void DesativaBotoes()
    {
        for (int i = 0; i < botoes.Length; i++)
        {
            botoes[i].interactable = false;
        }
    }

    public void AtivaBotoes()
    {
        for (int i = 0; i < botoes.Length; i++)
        {
            botoes[i].interactable = true;
        }
        botaoParar.interactable = true;

    }
    void RespostaEsta()
    {
        int numeroFalaAguardar = Random.Range(1, 5);
        FindObjectOfType<AudioManager>().Play("falaResposta_" + numeroFalaAguardar);
    }

    IEnumerator FalaCertaRespota()
    {

        yield return new WaitForSeconds(2);
        int numeroCertaResposta = Random.Range(5, 7);
        FindObjectOfType<AudioManager>().Play("falaResposta_" + numeroCertaResposta);
        FindObjectOfType<AudioManager>().Play("respostaCerta");
        yield return new WaitForSeconds(0.5f);
        Sistema.AnimacaoJogador(5);
        PlateiaAplauso();

    }

    IEnumerator FalaErradaRespota()
    {

        yield return new WaitForSeconds(2);
        int numeroErradaResposta = Random.Range(9, 13);
        FindObjectOfType<AudioManager>().Play("falaResposta_" + numeroErradaResposta);
        FindObjectOfType<AudioManager>().Play("respostaErrada");
        yield return new WaitForSeconds(0.5f);
        Sistema.AnimacaoJogador(6);
        PlateiaTriste();
    }

    IEnumerator FalaExplicacaoDrAuzioCerto()
    {
        int numeroErradaResposta = Random.Range(13, 17);
        FindObjectOfType<AudioManager>().Play("falaResposta_" + numeroErradaResposta);
        yield return new WaitForSeconds(FindObjectOfType<AudioManager>().Lenght("falaResposta_" + numeroErradaResposta) + 0.5f);
        perguntas.CorotinaAcertou();
    }

    IEnumerator FalaExplicacaoDrAuzioErrado()
    {
        int numeroErradaResposta = Random.Range(13, 17);
        FindObjectOfType<AudioManager>().Play("falaResposta_" + numeroErradaResposta);
        yield return new WaitForSeconds(FindObjectOfType<AudioManager>().Lenght("falaResposta_" + numeroErradaResposta) + 0.5f);
        perguntas.Errou();
    }
    void PlateiaTensa()
    {
        int plateiaTensanumero = Random.Range(1, 3);
        FindObjectOfType<AudioManager>().Play("plateiaTensa_" + plateiaTensanumero);
    }

    void PlateiaTriste()
    {
        int plateiaTensanumero = Random.Range(1, 4);
        FindObjectOfType<AudioManager>().Play("plateiaTriste_" + plateiaTensanumero);
    }
    void PlateiaAplauso()
    {
        int plateiaTensanumero = Random.Range(1, 5);
        FindObjectOfType<AudioManager>().Play("plateiaAplauso_" + plateiaTensanumero);
    }
}
