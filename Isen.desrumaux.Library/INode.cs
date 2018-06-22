using System;
using System.Collections.Generic;

namespace Isen.desrumaux.Library
{
    public interface INode
    {
        string Value { get; set; }
        
        Guid Id { get; }
        
        INode parent { get; set; }
        
        List<INode> children { get; set; }
        
        int Depth { get; }

        void AddChildNode(Node node);

        void AddNodes(IEnumerable<Node> nodeList);

        void RemoveChildNode(Guid id);
        
        void RemoveChildNode(INode node);
        
        /// <summary>
        /// Trouve un noeud dans la liste des enfants
        /// </summary>
        /// <param name="id">Id du noeud à chercher</param>
        /// <returns>Noeud trouvé ou Null</returns>
        Node FindTraversing(Guid id);
        
        /// <summary>
        /// Trouve un noeud dans la liste des enfants
        /// </summary>
        /// <param name="node">Objet à chercher</param>
        /// <returns>Noeud trouvé ou Null</returns>
        Node FindTraversing(Node node);
    }
}