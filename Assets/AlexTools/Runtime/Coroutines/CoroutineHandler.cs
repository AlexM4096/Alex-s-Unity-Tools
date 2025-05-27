using System;
using System.Collections;
using UnityEngine;

namespace AlexTools.Coroutines
{
    public sealed class CoroutineHandler : IDisposable
    {
        private readonly IEnumerator _enumerator;
        private readonly MonoBehaviour _runner;
        
        private Coroutine _coroutine;

        internal CoroutineHandler(IEnumerator enumerator, MonoBehaviour runner)
        {
            _enumerator = enumerator;
            _runner = runner;
        }

        public void Start()
        {
            _coroutine = _runner.StartCoroutine(_enumerator);
        }

        public void Stop()
        {
            if (_coroutine == null) return;
            _runner.StopCoroutine(_coroutine);
        }

        public void Restart()
        {
            Stop();
            Start();
        }

        public void Dispose() => Stop();
    }
}