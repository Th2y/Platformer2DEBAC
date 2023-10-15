using Ebac.Core.Singletons;
using UnityEngine;

public class UIGameManager : Singleton<UIGameManager>
{
    [SerializeField] private SOIntUpdate coinsSO;
    [SerializeField] private SOIntUpdate lifeSO;
    [SerializeField] private SOIntUpdate projectilesSO;

    public void UpdateCoins()
    {
        coinsSO.UpdateValue?.Invoke();
    }

    public void UpdateLife()
    {
        lifeSO.UpdateValue?.Invoke();
    }

    public void UpdateProjectiles()
    {
        projectilesSO.UpdateValue?.Invoke();
    }
}
