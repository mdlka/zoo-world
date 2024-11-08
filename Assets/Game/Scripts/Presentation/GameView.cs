using TMPro;
using UnityEngine;

namespace ZooWorld
{
    public class GameView : MonoBehaviour, IGameView
    {
        [SerializeField] private TMP_Text _text;
        
        public void Render(int deadPreys, int deadPredators)
        {
            _text.text = $"Dead preys: {deadPreys}\nDead predators: {deadPredators}";
        }
    }
}