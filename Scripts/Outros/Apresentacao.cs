using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apresentacao : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvasPerguntas;
    public Perguntas perguntas;
    private Coroutine apresentacao;
    public GameObject pularAprsentacao;
    private bool triggerPular;
    void Start()
    {
        canvasPerguntas.SetActive(false);
        //StartCoroutine(SequenciaAprsentacao());
        apresentacao = StartCoroutine(SequenciaAprsentacao());
        pularAprsentacao.SetActive(true);
        triggerPular = false;
    }

    IEnumerator SequenciaAprsentacao()
    {
        //Boas vindas!
        Sistema.AnimacaoSilvio(8);
        Sistema.CorteCamera(6);
        FalaApresentacao(1, 4);
        yield return new WaitForSeconds(TamanhoFalaApresentacao());
        PularouNao();
        yield return new WaitForSeconds(0.1f);
        //Comecamos agora o Show do Milao
        //sistema da plateia animacao 16
        Sistema.CorteCamera(7);
        FalaApresentacao(4, 7);
        yield return new WaitForSeconds(TamanhoFalaApresentacao());
        PularouNao();
        yield return new WaitForSeconds(0.1f);
        //Como funciona o jogo
        Sistema.AnimacaoJogador(1);
        Sistema.CorteCamera(3);
        FalaApresentacao(7, 9); //AIDS TI
        yield return new WaitForSeconds(TamanhoFalaApresentacao());
        PularouNao();
        yield return new WaitForSeconds(0.1f);
        //Mostraremos perguntas sobre um problema sério que afeta uma parte da população brasileira: AIDS/HIV
        //sistema da plateia animacao 14
        Sistema.CorteCamera(15);
        FalaApresentacao(9, 11);
        yield return new WaitForSeconds(TamanhoFalaApresentacao());
        PularouNao();
        yield return new WaitForSeconds(0.1f);
        //O seu trabalho é responder corretamente, mostrando que você sabe como se cuidar e informar os outros
        Sistema.AnimacaoJogador(1);
        Sistema.CorteCamera(1);
        FalaApresentacao(11, 13);
        yield return new WaitForSeconds(TamanhoFalaApresentacao());
        PularouNao();
        yield return new WaitForSeconds(0.1f);
        //Após cada pergunta, nosso médico de plantão, Dr. Áuzio irá falar brevemente sobre o que falamos na questão
        Sistema.AnimacaoDrauzio(11);
        Sistema.CorteCamera(9);
        FalaApresentacao(13, 15);
        yield return new WaitForSeconds(TamanhoFalaApresentacao());
        PularouNao();
        yield return new WaitForSeconds(0.1f);
        pularAprsentacao.SetActive(false);

        //Quanto mais você acertar, maior será seu prêmio.Boa sorte!
        //sistema da plateia animacao 19
        Sistema.CorteCamera(12);
        FalaApresentacao(15, 17);
        yield return new WaitForSeconds(TamanhoFalaApresentacao());

        canvasPerguntas.SetActive(true);
        perguntas.StartaCorotinaFazerPergunta();
    }

    private int numeroFalaApresentacao;

    void FalaApresentacao(int min, int max)
    {
        numeroFalaApresentacao = Random.Range(min, max);
        FindObjectOfType<AudioManager>().Play("falaApresentacao_" + numeroFalaApresentacao);
    }
    float TamanhoFalaApresentacao()
    {
        float tamanhoFalaAguardar = FindObjectOfType<AudioManager>().Lenght("falaApresentacao_" + numeroFalaApresentacao);
        return tamanhoFalaAguardar;
    }

    public void PularApresentacao()
    {
        triggerPular = true;
        pularAprsentacao.SetActive(false);
    }

    public void PularouNao()
    {
        if (triggerPular)
        {
            StopCoroutine(apresentacao);
            canvasPerguntas.SetActive(true);
            perguntas.StartaCorotinaFazerPergunta();
        }
    }
}
