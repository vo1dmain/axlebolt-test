
using System;
using System.Collections.Generic;

using Assets.Scripts.Utils.Extensions;

using UnityEngine;

namespace Assets.Scripts.UI.Navigation
{
    public class UINavigator : MonoBehaviour
    {
        [SerializeField]
        private NavGraph _graph;
        public NavGraph Graph => _graph;



        private string _currentSectionId;
        public string CurrentSectionId => _currentSectionId;



        public event Action<string> Navigated;



        public void NavigateTo(string destinationId)
        {
            _currentSectionId?.Let(it => _backStack.Push(it));
            NavigateInternal(destinationId);
        }

        public bool NavigateUp()
        {
            try
            {
                var destinationId = _backStack.Pop();
                NavigateInternal(destinationId);

                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }



        internal void NavigateToStartNode()
        {
            NavigateTo(_graph.StartNodeId);
        }

        internal void Init()
        {
            foreach (var node in _graph.Nodes)
            {
                node.Section.AttachNavigator(this);
            }
        }



        private void NavigateInternal(string destinationId)
        {
            var node = _graph.FindNodeWithId(destinationId);
            _currentSectionId = node.Id;
            Navigated?.Invoke(_currentSectionId);
        }



        private readonly Stack<string> _backStack = new();
    }
}
