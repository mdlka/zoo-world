using System.Collections.Generic;
using UnityEngine;

namespace ZooWorld
{
    public class ObjectPool<TItem> : IPool<TItem> where TItem : MonoBehaviour
    {
        private readonly Stack<TItem> _availableItems = new();
        private readonly IFactory<TItem> _factory;

        public ObjectPool(IFactory<TItem> factory, int prewarm) : this(factory)
        {
            for (int i = 0; i < prewarm; i++)
            {
                var item = _factory.Create();
                item.gameObject.SetActive(false);
                
                _availableItems.Push(item);
            }
        }
        
        public ObjectPool(IFactory<TItem> factory)
        {
            _factory = factory;
        }

        public TItem Get()
        {
            var item = _availableItems.Count > 0 ? _availableItems.Pop() : _factory.Create();
            item.gameObject.SetActive(true);
            
            return item;
        }

        public void Return(TItem item)
        {
            item.gameObject.SetActive(false);
            _availableItems.Push(item);
        }
    }
}