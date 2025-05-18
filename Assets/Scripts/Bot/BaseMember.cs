using Base;
using UnityEngine;

namespace Bot
{
    public class BaseMember : MonoBehaviour
    {
        public IBase Base { get; private set; }

        public void SetBase(IBase @base)
        {
            Base = @base;
        }
    }
}