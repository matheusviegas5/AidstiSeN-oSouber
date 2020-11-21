using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CadastrarQuestao : MonoBehaviour
{

    public Text numeroPergunta;
    public Text pergunta;
    public Text alt_1;
    public Text alt_2;
    public Text alt_3;
    public Text alt_4;
    public Text resposta;
    public void Cadastrar()
    {

        Questoes user = new Questoes();
        user.alt_1 = alt_1.text;
        user.alt_2 = alt_2.text;
        user.alt_3 = alt_3.text;
        user.alt_4 = alt_4.text;
        user.numeroPergunta = numeroPergunta.text;
        user.pergunta = pergunta.text;
        user.resposta = resposta.text;



        string json = "";

        string filePath = Path.Combine(Application.streamingAssetsPath, "Questão " + numeroPergunta.text + ".json");
        print(filePath);

        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }
        if (!File.Exists(filePath))
        {
            json = JsonUtility.ToJson(user);
            print("Questao" + numeroPergunta + "Cadastrada!");

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath))
            {
                file.WriteLine(json);
                
            }
        }
        else
        {
            print("Questao já existe");

            json = System.IO.File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "Questão " + numeroPergunta.text + ".json"));

            Questoes users = JsonUtility.FromJson<Questoes>(json);
            alt_1.text = users.alt_2;
            alt_2.text = users.alt_2;
            alt_3.text = users.alt_3;
            alt_4.text = users.alt_4;
            resposta.text = user.resposta;
            numeroPergunta.text = users.numeroPergunta;

        }
    }
}
