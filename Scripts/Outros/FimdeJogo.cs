using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class FimdeJogo : MonoBehaviour
{
    public GameObject teladeFim;
    public Text dinheiroGanho_txt;
    public GameObject panel;
    public GameObject desejaContinuar;
    public Sistema sistema;

    private Coroutine parouJogo;
    private Coroutine ganhouJogo;
    private Coroutine errouJogo;

    public GameObject pularFimJogo;
    private bool triggerPular;

    private void Start()
    {
        pularFimJogo.SetActive(false);
        triggerPular = false;
    }
    public void Ganhou()
    {
        pularFimJogo.SetActive(true);
        // StartCoroutine(PremiacaoEncerramentoGanhou());
        ganhouJogo = StartCoroutine(PremiacaoEncerramentoGanhou());
    }
    public void ParoudeJogar()
    {
        pularFimJogo.SetActive(true);
        // StartCoroutine(PremiacaoEncerramentoParou());
        parouJogo = StartCoroutine(PremiacaoEncerramentoParou());
    }

    public void Errou()
    {
        pularFimJogo.SetActive(true);
        //StartCoroutine(PremiacaoEncerramentoErrou());
        errouJogo = StartCoroutine(PremiacaoEncerramentoErrou());
    }
    IEnumerator PremiacaoEncerramentoGanhou()
    {
        desejaContinuar.SetActive(false);
        panel.SetActive(false);
        //Sua jornada chegou ao fim
        Sistema.AnimacaoSilvio(8);
        Sistema.CorteCamera(8);
        FalaEncerrar(1, 5);
        yield return new WaitForSeconds(TamanhoFalaEncerrar());
        PularGanhou();
        yield return new WaitForSeconds(0.1f);


        //Nao fique triste voce ganhou... bolitas
        //animacao plateia 14
        Sistema.CorteCamera(16);
        FalaEncerrar(5, 9);
        yield return new WaitForSeconds(TamanhoFalaEncerrar());
        numeroFalaBolitas = Random.Range(13, 15);
        FindObjectOfType<AudioManager>().Play("bolitas_" + numeroFalaBolitas);
        yield return new WaitForSeconds(TamanhoFalaBolitas());
        PularGanhou();
        yield return new WaitForSeconds(0.1f);


        sistema.PlateiaAplaude();
        PlateiaAplauso();
        // PAUSA
        //animacao plateia 16
        Sistema.CorteCamera(15);
        yield return new WaitForSeconds(7);
        PularGanhou();
        yield return new WaitForSeconds(0.1f);

        //Agradecemos sua participação
        Sistema.AnimacaoSilvio(8);
        Sistema.CorteCamera(14);
        FalaEncerrar(13, 16);
        yield return new WaitForSeconds(TamanhoFalaEncerrar());
        PularGanhou();
        yield return new WaitForSeconds(0.1f);

        //Esperamos qu tenha aprendido
        Sistema.AnimacaoDrauzio(11);
        Sistema.CorteCamera(9);
        FalaEncerrar(9, 13);
        yield return new WaitForSeconds(TamanhoFalaEncerrar());
        PularGanhou();
        yield return new WaitForSeconds(0.1f);

        //Esse foi o aids ti
        Sistema.AnimacaoSilvio(8);
        Sistema.CorteCamera(7);
        FalaEncerrar(16, 20);
        yield return new WaitForSeconds(TamanhoFalaEncerrar());
        PularGanhou();

        pularFimJogo.SetActive(false);

        //luzes + plateia animacao
        Sistema.CorteCamera(13);
        yield return new WaitForSeconds(3);

        teladeFim.SetActive(true);

        dinheiroGanho_txt.text = "Você ganhou UM MILHÃO de bolitas!";

    }
    IEnumerator PremiacaoEncerramentoParou()
    {
        desejaContinuar.SetActive(false);
        panel.SetActive(false);
        //Sua jornada chegou ao fim
        Sistema.AnimacaoSilvio(8);
        Sistema.CorteCamera(8);
        FalaEncerrar(1, 5);
        yield return new WaitForSeconds(TamanhoFalaEncerrar());
        PularParou();
        yield return new WaitForSeconds(0.1f);

        //Nao fique triste voce ganhou... bolitas
        //animacao plateia 14
        Sistema.CorteCamera(16);
        FalaEncerrar(5, 9);
        yield return new WaitForSeconds(TamanhoFalaEncerrar());
        FalaBolitasParou(Perguntas.questao);
        yield return new WaitForSeconds(TamanhoFalaBolitas());
        PularParou();
        yield return new WaitForSeconds(0.1f);

        sistema.PlateiaAplaude();
        PlateiaAplauso();
        // PAUSA
        //animacao plateia 16
        Sistema.CorteCamera(15);
        yield return new WaitForSeconds(7);
        PularParou();
        yield return new WaitForSeconds(0.1f);

        //Agradecemos sua participação
        Sistema.AnimacaoSilvio(8);
        Sistema.CorteCamera(14);
        FalaEncerrar(13, 16);
        yield return new WaitForSeconds(TamanhoFalaEncerrar());
        PularParou();
        yield return new WaitForSeconds(0.1f);

        //Esperamos qu tenha aprendido
        Sistema.AnimacaoDrauzio(11);
        Sistema.CorteCamera(9);
        FalaEncerrar(9, 13);
        yield return new WaitForSeconds(TamanhoFalaEncerrar());
        PularParou();
        yield return new WaitForSeconds(0.1f);

        //Esse foi o aids ti
        Sistema.AnimacaoSilvio(8);
        Sistema.CorteCamera(7);
        FalaEncerrar(16, 20);
        yield return new WaitForSeconds(TamanhoFalaEncerrar());
        PularParou();
        yield return new WaitForSeconds(0.1f);

        pularFimJogo.SetActive(false);
        //luzes + plateia animacao
        Sistema.CorteCamera(13);
        yield return new WaitForSeconds(3);

        teladeFim.SetActive(true);

        if (Perguntas.questao == 2) dinheiroGanho_txt.text = "Você ganhou mil bolitas!";
        else if (Perguntas.questao == 3) dinheiroGanho_txt.text = "Você ganhou 10 mil bolitas!";
        else if (Perguntas.questao == 4) dinheiroGanho_txt.text = "Você ganhou 100 mil bolitas!";
        else if (Perguntas.questao == 5) dinheiroGanho_txt.text = "Você ganhou 200 mil bolitas!";
        else if (Perguntas.questao == 6) dinheiroGanho_txt.text = "Você ganhou 500 mil bolitas!";
        else dinheiroGanho_txt.text = "Você ganhou nada...";
    }
    IEnumerator PremiacaoEncerramentoErrou()
    {
        desejaContinuar.SetActive(false);
        panel.SetActive(false);
        //Sua jornada chegou ao fim
        Sistema.AnimacaoSilvio(8);
        Sistema.CorteCamera(8);
        FalaEncerrar(1, 5);
        yield return new WaitForSeconds(TamanhoFalaEncerrar());
        PularErrou();
        yield return new WaitForSeconds(0.1f);

        //Nao fique triste voce ganhou... bolitas
        //animacao plateia 14
        Sistema.CorteCamera(16);
        FalaEncerrar(5, 9);
        yield return new WaitForSeconds(TamanhoFalaEncerrar());
        FalaBolitasErrou(Perguntas.questao);
        yield return new WaitForSeconds(TamanhoFalaBolitas());
        PularErrou();
        yield return new WaitForSeconds(0.1f);


        sistema.PlateiaAplaude();
        PlateiaAplauso();
        // PAUSA
        //animacao plateia 16
        Sistema.CorteCamera(15);
        yield return new WaitForSeconds(7);
        PularErrou();
        yield return new WaitForSeconds(0.1f);

        //Agradecemos sua participação
        Sistema.AnimacaoSilvio(8);
        Sistema.CorteCamera(14);
        FalaEncerrar(13, 16);
        yield return new WaitForSeconds(TamanhoFalaEncerrar());
        PularErrou();
        yield return new WaitForSeconds(0.1f);

        //Esperamos qu tenha aprendido
        Sistema.AnimacaoDrauzio(11);
        Sistema.CorteCamera(9);
        FalaEncerrar(9, 13);
        yield return new WaitForSeconds(TamanhoFalaEncerrar());
        PularErrou();
        yield return new WaitForSeconds(0.1f);

        //Esse foi o aids ti
        Sistema.AnimacaoSilvio(8);
        Sistema.CorteCamera(7);
        FalaEncerrar(16, 20);
        yield return new WaitForSeconds(TamanhoFalaEncerrar());
        PularErrou();
        yield return new WaitForSeconds(0.1f);

        pularFimJogo.SetActive(false);

        //luzes + plateia animacao
        Sistema.CorteCamera(13);
        yield return new WaitForSeconds(3);

        teladeFim.SetActive(true);

        if (Perguntas.questao == 3) dinheiroGanho_txt.text = "Você ganhou mil bolitas!";
        else if (Perguntas.questao == 4) dinheiroGanho_txt.text = "Você ganhou 10 mil bolitas!";
        else if (Perguntas.questao == 5) dinheiroGanho_txt.text = "Você ganhou 100 mil bolitas!";
        else if (Perguntas.questao == 6) dinheiroGanho_txt.text = "Você ganhou 200 mil bolitas!";
        else dinheiroGanho_txt.text = "Você ganhou nada...";
    }

    private int numeroFalaEncerrar;

    void FalaEncerrar(int min, int max)
    {
        numeroFalaEncerrar = Random.Range(min, max);
        FindObjectOfType<AudioManager>().Play("falaEncerrar_" + numeroFalaEncerrar);
    }
    float TamanhoFalaEncerrar()
    {
        float tamanhoFalaPergunta = FindObjectOfType<AudioManager>().Lenght("falaEncerrar_" + numeroFalaEncerrar);
        return tamanhoFalaPergunta;
    }

    private int numeroFalaBolitas;
    void FalaBolitasErrou(int valor)
    {
        if (valor == 1 || valor == 2) numeroFalaBolitas = Random.Range(1, 3);
        else if (valor == 3) numeroFalaBolitas = Random.Range(3, 5);
        else if (valor == 4) numeroFalaBolitas = Random.Range(5, 7);
        else if (valor == 5) numeroFalaBolitas = Random.Range(7, 9);
        else if (valor == 6) numeroFalaBolitas = Random.Range(9, 11);

        FindObjectOfType<AudioManager>().Play("bolitas_" + numeroFalaBolitas);
    }

    void FalaBolitasParou(int valor)
    {
        if (valor == 1 ) numeroFalaBolitas = Random.Range(1, 3);
        else if (valor == 2) numeroFalaBolitas = Random.Range(3, 5);
        else if (valor == 3) numeroFalaBolitas = Random.Range(5, 7);
        else if (valor == 4) numeroFalaBolitas = Random.Range(7, 9);
        else if (valor == 5) numeroFalaBolitas = Random.Range(9, 11);
        else if (valor == 6) numeroFalaBolitas = Random.Range(11,13);

        FindObjectOfType<AudioManager>().Play("bolitas_" + numeroFalaBolitas);
    }
    float TamanhoFalaBolitas()
    {
        float tamanhoFalaBolitas = FindObjectOfType<AudioManager>().Lenght("bolitas_" + numeroFalaBolitas);
        return tamanhoFalaBolitas;
    }

    void PlateiaAplauso()
    {
        int plateiaTensanumero = Random.Range(1, 5);
        FindObjectOfType<AudioManager>().Play("plateiaAplauso_" + plateiaTensanumero);
    }

    public void PularfimJogo()
    {
        triggerPular = true;
        pularFimJogo.SetActive(false);
    }

    public void PularGanhou()
    {
        if (triggerPular)
        {
            StopCoroutine(ganhouJogo);
            teladeFim.SetActive(true);
            dinheiroGanho_txt.text = "Você ganhou UM MILHÃO de bolitas!";
        }
    }
    public void PularErrou()
    {
        if (triggerPular)
        {
            StopCoroutine(errouJogo);
            teladeFim.SetActive(true);

            if (Perguntas.questao == 3) dinheiroGanho_txt.text = "Você ganhou mil bolitas!";
            else if (Perguntas.questao == 4) dinheiroGanho_txt.text = "Você ganhou 10 mil bolitas!";
            else if (Perguntas.questao == 5) dinheiroGanho_txt.text = "Você ganhou 100 mil bolitas!";
            else if (Perguntas.questao == 6) dinheiroGanho_txt.text = "Você ganhou 200 mil bolitas!";
            else dinheiroGanho_txt.text = "Você ganhou nada...";
        }
    }
    public void PularParou()
    {
        if (triggerPular)
        {
            StopCoroutine(parouJogo);
            teladeFim.SetActive(true);

            if (Perguntas.questao == 2) dinheiroGanho_txt.text = "Você ganhou mil bolitas!";
            else if (Perguntas.questao == 3) dinheiroGanho_txt.text = "Você ganhou 10 mil bolitas!";
            else if (Perguntas.questao == 4) dinheiroGanho_txt.text = "Você ganhou 100 mil bolitas!";
            else if (Perguntas.questao == 5) dinheiroGanho_txt.text = "Você ganhou 200 mil bolitas!";
            else if (Perguntas.questao == 6) dinheiroGanho_txt.text = "Você ganhou 500 mil bolitas!";
            else dinheiroGanho_txt.text = "Você ganhou nada...";
        }
    }
}
