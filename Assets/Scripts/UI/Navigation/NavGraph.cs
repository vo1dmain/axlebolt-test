
using System;
using System.Collections.Generic;

using UnityEngine;

namespace Assets.Scripts.UI.Navigation
{
    [CreateAssetMenu(menuName = "Scriptable Object/UI/Navigation Graph")]
    public class NavGraph : ScriptableObject
    {
        [SerializeField]
        private string _startNodeId;
        public string StartNodeId => _startNodeId;


        [SerializeField]
        private List<NavNode> _nodes;
        internal IEnumerable<NavNode> Nodes => _nodes;



        internal NavNode FindNodeWithId(string nodeId)
        {
            var node = _nodes.Find(node => node.Id.Equals(nodeId));

            if (node is null) throw new ArgumentException($"No destination with such id (\"{nodeId}\")");

            return node;
        }

        internal NavNode GetStartNode()
        {
            return FindNodeWithId(_startNodeId);
        }



        private void OnValidate()
        {
            NavIdGenerator.Generate(_nodes);

            if (_nodes.Count > 0) _startNodeId = _nodes[0].Id;
        }
    }
}
