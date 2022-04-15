
using UnityEngine;

namespace Assets.Scripts.Repulsor.Field
{
    public partial class RepulsionFieldSpec : ScriptableObject
    {

        public readonly IEditor Editor;
        
        
        public RepulsionFieldSpec()
        {
            Editor = new SpecEditor(this);
        }



        private class SpecEditor : IEditor
        {
            private readonly RepulsionFieldSpec _spec;



            internal SpecEditor(RepulsionFieldSpec spec)
            {
                _spec = spec;
            }



            public void SetRadius(float radius)
            {
                _spec._radius = radius;
            }
        }

        public interface IEditor
        {
            public void SetRadius(float radius);
        }
    }
}
