using UnityEngine;
using System.Collections.Generic;

public class CoroutineFactory : Singleton<CoroutineFactory>
{
    [SerializeField] private CustomCoroutine _makeCoroutine; 
    private Queue<CustomCoroutine> _waitingCoroutineGroup;
    protected override void Initialize()
    {
        base.Initialize();
        _waitingCoroutineGroup = new Queue<CustomCoroutine>();
    }

    public CustomCoroutine CreateCoroutine()
    {
        var pooledCoroutine = _waitingCoroutineGroup.Count > 0? _waitingCoroutineGroup.Dequeue() : Instantiate(_makeCoroutine);
        pooledCoroutine.transform.parent = transform;
        
        pooledCoroutine.OnPooling();

        return pooledCoroutine;
    }

    public void PoolCoroutine(CustomCoroutine endCoroutine)
    {
        _waitingCoroutineGroup.Enqueue(endCoroutine);
    }
}