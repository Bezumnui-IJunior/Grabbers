using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Bases.Base _base;
    [SerializeField] private List<Bots.Bot> _bots;

    private void Awake()
    {
        _base.Init();

        foreach (Bots.Bot bot in _bots)
            bot.Init();
    }
}