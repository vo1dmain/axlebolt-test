using UnityEngine;

namespace Assets.Scripts.UI.Navigation
{
    [System.Serializable]
    internal class NavNode
    {
        [SerializeField]
        private string _id;
        internal string Id => _id;

        [SerializeField]
        private BaseSection _section;
        internal BaseSection Section => _section;
    }
}
