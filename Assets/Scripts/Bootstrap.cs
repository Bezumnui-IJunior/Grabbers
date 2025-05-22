using System.Collections.Generic;
using Bases;
using UnityEngine;
using View;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private Base _base;
    [SerializeField] private List<Bots.Bot> _bots;
    [SerializeField] private BasesView _basesView;

    private void Awake()
    {
        _base.Init();

        foreach (Bots.Bot bot in _bots)
        {
            if (bot.enabled)
                bot.Init();
        }

        _basesView.Init();
    }
}