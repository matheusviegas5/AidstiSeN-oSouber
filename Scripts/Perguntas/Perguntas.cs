using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Perguntas : MonoBehaviour
{
    // Debug.Log("Audio clip length : " + m_AudioSource.clip.length);

    //VER AJUDA QUE REAPARECE APÓS RESPONDER PERGUNTA
    public static int respostaCerta;
    public static int questao;
    public GameObject canvasPerguntas;
    public static bool acertou;
    public GameObject panel;

    public GameObject[] resposta;

    public GameObject dinheiro;

    public Button botaoAjuda;
    public GameObject painelAjuda;
    public GameObject rolaDado;
    public GameObject desejaContinuar;
    public GameObject dinheiro_parar;
    public Button botaoAjuda1;
    public Button botaoAjuda2;
    public Button botaoAjuda3;
    public Text informacao;

    private Text dinheiro_txt;
    public StringDinheiro dinheiro_strg;

    private Button[] alternativa;

    private AudioSource musicaTema;
    // public Button botaoParar;
    private BuscarQuestao buscaQuestao;

    private int ultimaPergunta = 7;

    private Sistema sistema;
    void Awake()
    {
        buscaQuestao = this.GetComponent<BuscarQuestao>();
        alternativa = new Button[4];
        questao = 1;
        dinheiro_txt = dinheiro.GetComponent<Text>();
        AssociaBotoesAlternativas();
        musicaTema = GameObject.Find("MusicaTema").GetComponent<AudioSource>();
        sistema = GetComponent<Sistema>();
    }


    void AssociaBotoesAlternativas()
    {
        for (int i = 0; i < alternativa.Length; i++)
        {
            alternativa[i] = resposta[i].GetComponent<Button>();
        }
    }
    //private void Update()
    //{
    //    //if (Input.GetKeyDown(KeyCode.P))
    //    //{
    //    //    buscaQuestao.BuscaQuestao();
    //    //    print(respostaCerta);
    //    //}
    //}

    public void StartaCorotinaFazerPergunta()
    {
        StartCoroutine(FazerPergunta());
    }
    IEnumerator FazerPergunta()
    {
        DesativaBotoesAlternativas();
        DesativaBotoes();
        DesativaAlternativas();

        TocaMusicaTensa();

        //E vamos para a pergunta que pode valer (valor)
        buscaQuestao.BuscaQuestao(); //sorteia questão
        print("Respostas certa " + respostaCerta);
        Sistema.AnimacaoSilvio(8);
        Sistema.CorteCamera(7);
        FalaPergunta(1, 4); //1, 2 ou 3
        yield return new WaitForSeconds(TamanhoFalaPergunta());
        FalaBolitas(questao);
        yield return new WaitForSeconds(TamanhoFalaBolitas());
        // StartCoroutine(ResetaSistema());

        //Pergunta
        Sistema.AnimacaoJogador(2);
        Sistema.CorteCamera(2);
        PerguntaEnunciado();
        yield return new WaitForSeconds(TamanhoPerguntaEnunciado());
        StartCoroutine(FalaAlternativas());
    }

    IEnumerator FalaAlternativas()
    {
        //E as alternativas são
        Sistema.AnimacaoSilvio(8);
        Sistema.CorteCamera(6);
        FalaAguardar(1, 5); //1 a 4;
        yield return new WaitForSeconds(TamanhoFalaAguardar() + 0.5f);
        //a)
        resposta[0].SetActive(true);
        Sistema.AnimacaoJogador(2);
        Sistema.CorteCamera(1);
        PerguntaAlternativa("A");
        yield return new WaitForSeconds(TamanhoAlternativa("A") + 0.3f);
        //b)
        sistema.PlateiaAplaude();      
        resposta[1].SetActive(true);
        Sistema.CorteCamera(16);
        PerguntaAlternativa("B");
        yield return new WaitForSeconds(TamanhoAlternativa("B") + 0.3f);
        //c)
        resposta[2].SetActive(true);
        Sistema.AnimacaoSilvio(9);
        Sistema.CorteCamera(14);
        PerguntaAlternativa("C");
        yield return new WaitForSeconds(TamanhoAlternativa("C") + 0.3f);
        //d)
        resposta[3].SetActive(true);
        Sistema.AnimacaoJogador(3);
        Sistema.CorteCamera(2);
        PerguntaAlternativa("D");
        yield return new WaitForSeconds(TamanhoAlternativa("D"));
        AtivaBotaoPainelAjuda();
        AtivaBotoesAlternativas();

    }
    public void Resposta1()
    {
        if (respostaCerta == 1) acertou = true;
        else acertou = false; ;
    }
    public void Resposta2()
    {
        if (respostaCerta == 2) acertou = true;
        else acertou = false; ;

    }
    public void Resposta3()
    {
        if (respostaCerta == 3) acertou = true;
        else acertou = false; ;
    }
    public void Resposta4()
    {
        if (respostaCerta == 4) acertou = true;
        else acertou = false; ;
    }


    IEnumerator Acertou()
    {
        TocaMusicaAuzio();
        ajudaDrauzio("nao");
        //canvasPerguntas.SetActive(false);
        panel.SetActive(false);
        questao++;
        dinheiro_strg.AtualizaDinheiro();
        yield return null;

    }
    public void Errou()
    {
        //this.GetComponent<FimdeJogo>().Errou();
        panel.SetActive(false);
        ajudaDrauzio("nao");
        //canvasPerguntas.SetActive(false);
    }

    public void ajudaDrauzio(string simouNao)
    {

        StartCoroutine(ajudaDrauzioSequencia(simouNao));

    }
    IEnumerator ajudaDrauzioSequencia(string simouNao)
    {
        GetComponent<RespostaPlateia>().ResetarPlacas();
        if (simouNao == "sim") DesativaBotoesAlternativas();
        else TocaMusicaAuzio();
        //Dr. Auzio explica
        //Obrigado Silvio!
        Sistema.AnimacaoSilvio(10);
        Sistema.CorteCamera(11);
        ExplicacaoDrauzio(1, 5);
        yield return new WaitForSeconds(TamanhoExplicacaoDrauzio());
        //Explicacao
        PerguntaAuzio(); //explicação em si 
        Sistema.AnimacaoDrauzio(12);
        Sistema.CorteCamera(9);
        yield return new WaitForSeconds(TamanhoPerguntaAuzio() / 3); //tempo da explicacao
                                                                     //plateia animacao 18
        Sistema.CorteCamera(15);
        yield return new WaitForSeconds(TamanhoPerguntaAuzio() / 3); //tempo da explicacao 2
        Sistema.AnimacaoJogador(2);
        Sistema.CorteCamera(1);
        yield return new WaitForSeconds((TamanhoPerguntaAuzio() / 3) + 0.5f); //tempo da explicacao 3
        //Volto contigo silvio
        Sistema.AnimacaoDrauzio(13);
        Sistema.CorteCamera(9);
        ExplicacaoDrauzio(5, 9);
        yield return new WaitForSeconds(TamanhoExplicacaoDrauzio());
        //reseta animacao drauzio
        Sistema.drauzioAnimator.SetBool("exit", true);
        yield return new WaitForSeconds(0.1f);
        Sistema.drauzioAnimator.SetBool("exit", false);
        Sistema.CorteCamera(2);
        if (simouNao == "nao")
        {
            TocaMusicaTema();
            buscaQuestao.BuscaQuestao();
            if (questao == ultimaPergunta)
            {
                StartCoroutine(umMilhaoBolitas());
                // StopCoroutine(ajudaDrauzioSequencia("sim"));
            }

            else if (Perguntas.acertou)
            {
                StartCoroutine(Parabenizacao());
            }
            else
            {
                
                panel.SetActive(false);
                this.GetComponent<FimdeJogo>().Errou();
            }


        }
        else AtivaBotoesAlternativas();


        // AtivaBotaoPainelAjuda();
    }

    IEnumerator Parabenizacao()
    {
        TocaMusicaTema();
        //Obrigado dr auzio

        //
        Sistema.AnimacaoDrauzio(13);
        Sistema.CorteCamera(10);
        FalaParabens(1, 5);
        yield return new WaitForSeconds(TamanhoFalaParabens() + 0.5f);
        //arabens por conquistar bolitas
        Sistema.AnimacaoJogador(5);
        Sistema.CorteCamera(4);
        FalaParabens(5, 9);
        yield return new WaitForSeconds(TamanhoFalaParabens() + 0.5f);
        FalaBolitas(questao - 1);
        yield return new WaitForSeconds(TamanhoFalaBolitas());

        ////vamos para a pergunta que vale x
        //Sistema.AnimacaoSilvio(8);
        //Sistema.CorteCamera(8);
        //FalaParabens(9, 13);
        //yield return new WaitForSeconds(TamanhoFalaParabens());
        StartCoroutine(DesejaContinuar());
    }

    IEnumerator DesejaContinuar()
    {
        ////Fazer Pergunta
        //Sistema.AnimacaoSilvio(8);
        //Sistema.CorteCamera(7);
        //FalaPergunta(1, 4); //1, 2 ou 3//  e vamos para a pergunta....
        //yield return new WaitForSeconds(TamanhoFalaPergunta()); 
        //Pergunta
        Sistema.AnimacaoSilvio(8);
        Sistema.CorteCamera(7);
        FalaPergunta(1, 4); //1, 2 ou 3
        yield return new WaitForSeconds(TamanhoFalaPergunta());
        FalaBolitas(questao);
        yield return new WaitForSeconds(TamanhoFalaBolitas());
        Sistema.AnimacaoJogador(2);
        Sistema.CorteCamera(2);
        PerguntaEnunciado();
        yield return new WaitForSeconds(TamanhoPerguntaEnunciado());
        //animacao plateia 15
        Sistema.CorteCamera(15);
        FalaPergunta(6, 11); //quer responder ou retirar premio
        yield return new WaitForSeconds(TamanhoFalaPergunta());
        Sistema.AnimacaoSilvio(9);
        Sistema.CorteCamera(13);

        canvasPerguntas.SetActive(true);
        panel.SetActive(true);
        desejaContinuar.SetActive(true);
        DesativaBotoesAlternativas();
        DesativaAlternativas();
        dinheiro_parar.SetActive(false);
        DesativaBotoes();
        informacao.text = "Deseja responder a essa pergunta valendo " + dinheiro_txt.text + " bolitas?";
    }

    public void Continuar_Sim()
    {
        if (informacao.text == "Tem certeza disso?")
        {
            sistema.PlateiaAplaude();
            PlateiaAplauso();
            panel.SetActive(false);
            this.GetComponent<FimdeJogo>().ParoudeJogar();
        }
        else
        {
            //sistema.PlateiaAplaude();
           // PlateiaAplauso();
            dinheiro_parar.SetActive(true);
            //AtivaBotaoPainelAjuda();
            desejaContinuar.SetActive(false);
            StartCoroutine(FalaAlternativas());
        }
    }

    public void Parar_Nao()
    {
        if (informacao.text == "Tem certeza disso?")
        {
            informacao.text = "Deseja responder a essa pergunta valendo " + dinheiro_txt.text + " bolitas?";
        }
        else informacao.text = "Tem certeza disso?";
    }

    IEnumerator umMilhaoBolitas()
    {
        this.GetComponent<FimdeJogo>().Ganhou();
        yield return null;
    }
    public void AtivaBotoesAjuda()
    {
        if (!DadoQuestoes.ajudaDado)
        {
            botaoAjuda1.interactable = true;
        }
        else
        {
            if (rolaDado.activeSelf) rolaDado.SetActive(false);
        }
        if (!RespostaPlateia.ajudaPlateia) botaoAjuda2.interactable = true;
        else GetComponent<RespostaPlateia>().ResetarPlacas();
        if (!BotoesUI.ajudaDoDrauzio) botaoAjuda3.interactable = true;
    }

    void AtivaBotaoPainelAjuda()
    {
        botaoAjuda.interactable = true;
    }

    void DesativaBotoes()
    {
        painelAjuda.SetActive(false);
        botaoAjuda.interactable = false;
        botaoAjuda1.interactable = false;
        botaoAjuda2.interactable = false;
        botaoAjuda3.interactable = false;
    }


    public void AtivaAlternativas()
    {
        for (int i = 0; i < resposta.Length; i++)
        {
            resposta[i].SetActive(true);
        }
    }

    public void DesativaAlternativas()
    {
        for (int i = 0; i < resposta.Length; i++)
        {
            resposta[i].SetActive(false);
        }

    }

    public void CorotinaAcertou()
    {
        StartCoroutine(Acertou());
    }

    private void DesativaBotoesAlternativas()
    {
        for (int i = 0; i < alternativa.Length; i++)
        {
            alternativa[i].interactable = false;
        }
        //botaoParar.interactable = false;

    }

    private void AtivaBotoesAlternativas()
    {
        for (int i = 0; i < alternativa.Length; i++)
        {
            alternativa[i].interactable = true;
        }
        //botaoParar.interactable = true;
    }
    void PerguntaEnunciado()
    {
        int questao = buscaQuestao.questao;
        FindObjectOfType<AudioManager>().Play("perguntaEnunciado_" + questao);
    }
    float TamanhoPerguntaEnunciado()
    {
        int questao = buscaQuestao.questao;
        float tamanhoPerguntaEnunciado = FindObjectOfType<AudioManager>().Lenght("perguntaEnunciado_" + questao);
        return tamanhoPerguntaEnunciado;
    }
    private int numeroFalaPergunta;

    void FalaPergunta(int min, int max)
    {
        numeroFalaPergunta = Random.Range(min, max);
        FindObjectOfType<AudioManager>().Play("falaPergunta_" + numeroFalaPergunta);
    }
    float TamanhoFalaPergunta()
    {
        float tamanhoFalaPergunta = FindObjectOfType<AudioManager>().Lenght("falaPergunta_" + numeroFalaPergunta);
        return tamanhoFalaPergunta;
    }

    private int numeroFalaAguardar;

    void FalaAguardar(int min, int max)
    {
        numeroFalaAguardar = Random.Range(min, max);
        FindObjectOfType<AudioManager>().Play("falaAguardar_" + numeroFalaAguardar);
    }

    float TamanhoFalaAguardar()
    {
        float tamanhoFalaAguardar = FindObjectOfType<AudioManager>().Lenght("falaAguardar_" + numeroFalaAguardar);
        return tamanhoFalaAguardar;
    }

    void PerguntaAlternativa(string alternativa)
    {
        int questao = buscaQuestao.questao;
        FindObjectOfType<AudioManager>().Play("perguntaAlternativa" + alternativa + "_" + questao);
    }
    float TamanhoAlternativa(string alternativa)
    {
        int questao = buscaQuestao.questao;
        float tamanhoAlternativa = FindObjectOfType<AudioManager>().Lenght("perguntaAlternativa" + alternativa + "_" + questao);
        print("perguntaAlternativa" + alternativa + "_" + questao);
        return tamanhoAlternativa;
    }

    private int numeroExplicacaoDrauzio;

    void ExplicacaoDrauzio(int min, int max)
    {
        numeroExplicacaoDrauzio = Random.Range(min, max);
        FindObjectOfType<AudioManager>().Play("falaDrExplica_" + numeroExplicacaoDrauzio);
    }

    float TamanhoExplicacaoDrauzio()
    {
        float tamanhoExplicacaoDrauzio = FindObjectOfType<AudioManager>().Lenght("falaDrExplica_" + numeroExplicacaoDrauzio);
        return tamanhoExplicacaoDrauzio;
    }


    void PerguntaAuzio()
    {
        int questao = buscaQuestao.questao;
        FindObjectOfType<AudioManager>().Play("perguntaAuzio_" + questao);
    }
    float TamanhoPerguntaAuzio()
    {
        int questao = buscaQuestao.questao;
        float tamanhoPerguntaAuzio = FindObjectOfType<AudioManager>().Lenght("perguntaAuzio_" + questao);
        return tamanhoPerguntaAuzio;
    }

    private int numeroFalaParabens;

    void FalaParabens(int min, int max)
    {
        numeroFalaParabens = Random.Range(min, max);
        FindObjectOfType<AudioManager>().Play("falaParabens_" + numeroFalaParabens);
    }

    float TamanhoFalaParabens()
    {
        float tamanhoFalaParabens = FindObjectOfType<AudioManager>().Lenght("falaParabens_" + numeroFalaParabens);
        return tamanhoFalaParabens;
    }

    private int numeroFalaBolitas;

    void FalaBolitas(int valor)
    {
        if (valor == 1) numeroFalaBolitas = Random.Range(3, 5);
        else if (valor == 2) numeroFalaBolitas = Random.Range(5, 7);
        else if (valor == 3) numeroFalaBolitas = Random.Range(7, 9);
        else if (valor == 4) numeroFalaBolitas = Random.Range(9, 11);
        else if (valor == 5) numeroFalaBolitas = Random.Range(11, 13);
        else if (valor == 6) numeroFalaBolitas = Random.Range(13, 15);
        FindObjectOfType<AudioManager>().Play("bolitas_" + numeroFalaBolitas);
    }

    float TamanhoFalaBolitas()
    {
        float tamanhoFalaBolitas = FindObjectOfType<AudioManager>().Lenght("bolitas_" + numeroFalaBolitas);
        return tamanhoFalaBolitas;
    }

    public AudioSource[] musicaTensa;
    private int numeroMusicaTensa;
    void TocaMusicaTensa()
    {
        try
        {
        musicaTema.Pause();
        }
        catch (System.Exception)
        {
            print("nao pausou musica");
        }
        numeroMusicaTensa = Random.Range(1, 3);
        musicaTensa[numeroMusicaTensa].Play();
    }
    public AudioSource musicaAuzio;
    void TocaMusicaAuzio()
    {
        for (int i = 0; i < musicaTensa.Length; i++)
        {
            musicaTensa[i].Stop();
        }
        musicaTema.Pause();
        musicaAuzio.Play();
    }
    void TocaMusicaTema()
    {
        for (int i = 0; i < musicaTensa.Length; i++)
        {
            musicaTensa[i].Stop();
        }
        musicaTema.Play();
        musicaAuzio.Stop();
    }
    void PlateiaAplauso()
    {
        int plateiaTensanumero = Random.Range(1, 5);
        FindObjectOfType<AudioManager>().Play("plateiaAplauso_" + plateiaTensanumero);
    }
}
