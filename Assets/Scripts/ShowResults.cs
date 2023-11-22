using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowResults : MonoBehaviour
{
    private int idLevel;

    public Text txtNota;
    public Text txtInfoLevel;

    public GameObject estrela1;
    public GameObject estrela2;
    public GameObject estrela3;

    private int notaFinal;
    private int acertos;
    
    void Start()
    {
        idLevel = PlayerPrefs.GetInt("idLevel");
        
        estrela1.SetActive(false);
        estrela2.SetActive(false);
        estrela3.SetActive(false);
        
        notaFinal = PlayerPrefs.GetInt("notaFinalTemp" + idLevel);
        acertos = PlayerPrefs.GetInt("acertosTemp" + idLevel);

        txtNota.text = notaFinal.ToString();
        txtInfoLevel.text = "Você acertou " + acertos + " de 6 perguntas";

        if (notaFinal >= 9)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(true);
        }
        else if (notaFinal >= 7)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(false);
        }
        else if (notaFinal >= 4)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(false);
            estrela3.SetActive(false);
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("T" + idLevel);
    }

}
