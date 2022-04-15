using System;
using System.Collections.Generic;
using System.Linq;

using UnityEditor.Experimental.GraphView;

using UnityEngine;

namespace Assets.Scripts.UI.Navigation
{
    internal static class NavIdGenerator
    {
        internal static void Generate(IEnumerable<NavNode> nodes)
        {
            var directory = $"{Application.dataPath}/Generated/Scripts/UI/Navigation";
            var path = $"{directory}/NavIds.cs";

            var ids = nodes.Select(node => $"public const string {node.Id.ToUpper()} = \"{node.Id}\";");

            var code = $@"public static class NavIds
{{
    {string.Join($"{Environment.NewLine}\t", ids)}
}}";

            System.IO.Directory.CreateDirectory(directory);
            System.IO.File.WriteAllText(path, code);
        }
    }
}

