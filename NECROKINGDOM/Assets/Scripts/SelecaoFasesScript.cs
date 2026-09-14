using UnityEngine;
public class SelecaoFasesScript : MonoBehaviour
{
    [Header("Componentes")]
    public RectTransform conteudoFases;

    [Header("Limites do Eixo X")]
    [Tooltip("O valor máximo de X (geralmente 0, onde a primeira fase começa)")]
    public float xMaximo = 0f;

    [Tooltip("O valor mínimo de X (até onde você quer que ele vá para a esquerda, ex: -2000)")]
    public float xMinimo = -2000f;

    void LateUpdate()
    {
        if (conteudoFases == null) return;

        // Pega a posição atual do painel de fases
        Vector3 posicaoAtual = conteudoFases.anchoredPosition;

        // Limita o valor de X entre o mínimo e o máximo definidos
        posicaoAtual.x = Mathf.Clamp(posicaoAtual.x, xMinimo, xMaximo);

        // Aplica a posição travada de volta ao objeto
        conteudoFases.anchoredPosition = posicaoAtual;
    }
}
