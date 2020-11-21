using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotoesUI : MonoBehaviour
{

    public static int personagem;
    public GameObject painelTutorial;
    public GameObject painelAjuda;
    public GameObject ajudaDado;
    private Perguntas perguntas;
    public static bool ajudaDoDrauzio = false;
    public Button botaoParar;
    public Button botaoPlacas;
    public Button botaoDado;
    

    void Start()
    {
        ajudaDoDrauzio = false;
        try
        {
            perguntas = GetComponent<Perguntas>();
        }
        catch (System.Exception)
        {
        }
    }
    // Start is called before the first frame update


    public void MenuInicial()
    {
        SceneManager.LoadScene("MenuInicial");
    }
    public void SelecionarPersonagem()
    {
        SceneManager.LoadScene("SelecionarPersonagem");
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void PulaTutorial()
    {
        painelTutorial.SetActive(false);
    }

    public void PainelAjuda()
    {
        if (painelAjuda.activeSelf)
        {
        painelAjuda.SetActive(false);
        }
        else painelAjuda.SetActive(true);
        perguntas.AtivaBotoesAjuda();
    }

    public void AjudaDado()
    {
        ajudaDado.SetActive(true);
        GetComponent<DadoQuestoes>().RolaDados();
        int valor = Random.Range(1, 5);
        FindObjectOfType<AudioManager>().Play("ajudaDado_" + valor);
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            SceneManager.LoadScene("SelecionarPersonagem");
        }
    }

    public void ajudaDrauzio()
    {
        DesativarBotoesAjuda();
        StartCoroutine(FalaAjudaDrauzio());
        ajudaDoDrauzio = true;
    }

    public void SairJogo()
    {
        Application.Quit();
    }

    IEnumerator FalaAjudaDrauzio()
    {
        int valor = Random.Range(1, 5);
        FindObjectOfType<AudioManager>().Play("ajudaAuzio_" + valor);
        yield return new WaitForSeconds(FindObjectOfType<AudioManager>().Lenght("ajudaAuzio_" + valor));
        perguntas.ajudaDrauzio("sim");
    }

    void DesativarBotoesAjuda()
    {
        botaoParar.interactable = false;
        botaoPlacas.interactable = false;
        botaoDado.interactable = false;
    }
}
