using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class BuscarQuestao : MonoBehaviour
{
    public Text numeroPergunta;
    public Text pergunta;
    public Text alt_1;
    public Text alt_2;
    public Text alt_3;
    public Text alt_4;
    public int questao;
    private List<string> visitados = new List<string>();
    

    public void BuscaQuestao()
    {

        int numeroDeQuestoes = 19;
        questao = Random.Range(1, numeroDeQuestoes + 1);

        if (!visitados.Contains(questao.ToString()))
        {


            print("questao sorteada = " + questao);
            try
            {
                //var json = (Path.Combine(Application.streamingAssetsPath, "Questão " + questao + ".json"));
                //UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(json);
                //www.SendWebRequest();
                //while (!www.isDone)
                //{
                //}
                //string jsonString = www.downloadHandler.text;

                string json = System.IO.File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "Questão " + questao + ".json"));
                Questoes users = JsonUtility.FromJson<Questoes>(json);



                pergunta.text = users.pergunta;
                numeroPergunta.text = users.numeroPergunta;
                alt_1.text = users.alt_1;
                alt_2.text = users.alt_2;
                alt_3.text = users.alt_3;
                alt_4.text = users.alt_4;
                Perguntas.respostaCerta = int.Parse(users.resposta);

                visitados.Add(users.numeroPergunta);


            }
            catch (System.Exception ex)
            {

                Debug.Log(ex);
            }

        }

        else BuscaQuestao();



    }

}

