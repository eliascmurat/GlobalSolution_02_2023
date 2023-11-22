using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayLevel : MonoBehaviour
{
    private int idLevel;
    
    public Text txtPergunta;
    public Text txtResposta1;
    public Text txtResposta2;
    public Text txtResposta3;
    public Text txtInfoResposta;

    public string[] perguntas;
    public string[] alternativas1;
    public string[] alternativas2;
    public string[] alternativas3;
    public string[] alternativasCorretas;

    private int idPergunta;

    private float acertos;
    private float quantidadePerguntas;
    private float media;
    private int notaFinal;
    
    void Start()
    {
        idLevel = PlayerPrefs.GetInt("idLevel");
        idPergunta = 0;
        quantidadePerguntas = perguntas.Length;

        txtPergunta.text = perguntas[idPergunta];
        txtResposta1.text = alternativas1[idPergunta];
        txtResposta2.text = alternativas2[idPergunta];
        txtResposta3.text = alternativas3[idPergunta];

        txtInfoResposta.text = "Respondendo " + (idPergunta + 1) + " de " + quantidadePerguntas + " perguntas.";
    }

    public void GetAnswer(string alternativa)
    {
        switch (alternativa)
        {
            case "01":
                if (alternativas1[idPergunta] == alternativasCorretas[idPergunta])
                {
                    acertos++;
                }
                break;
            case "02":
                if (alternativas2[idPergunta] == alternativasCorretas[idPergunta])
                {
                    acertos++;
                }
                break;
            case "03":
                if (alternativas3[idPergunta] == alternativasCorretas[idPergunta])
                {
                    acertos++;
                }
                break;
        }
        
        NextQuestion();
    }

    private void NextQuestion()
    {
        idPergunta++;

        if (idPergunta <= (quantidadePerguntas - 1))
        {
            txtPergunta.text = perguntas[idPergunta];
            txtResposta1.text = alternativas1[idPergunta];
            txtResposta2.text = alternativas2[idPergunta];
            txtResposta3.text = alternativas3[idPergunta];

            txtInfoResposta.text = "Respondendo " + (idPergunta + 1) + " de " + quantidadePerguntas + " perguntas.";
        }
        else
        {
            media = 10 * (acertos / quantidadePerguntas);
            notaFinal = Mathf.RoundToInt(media);

            if (notaFinal > PlayerPrefs.GetInt("notaFinal" + idLevel))
            {
                PlayerPrefs.SetInt("notaFinal" + idLevel, notaFinal);
                PlayerPrefs.SetInt("acertos" + idLevel, (int) acertos);
            }
            
            PlayerPrefs.SetInt("notaFinalTemp" + idLevel, notaFinal);
            PlayerPrefs.SetInt("acertosTemp" + idLevel, (int) acertos);
            
            SceneManager.LoadScene("Final");
        }
    }
}
