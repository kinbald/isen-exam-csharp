using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isen.desrumaux.Library
{
    public class Node : INode, IEquatable<Node>
    {
        public string Value { get; set; }
        public Guid Id { get; }
        public INode parent { get; set; }
        public List<INode> children { get; set; }

        public int Depth
        {
            get => parent?.Depth + 1 ?? 0;
        }

        public Node(string value)
        {
            Value = value;
            Id = Guid.NewGuid();
            children = new List<INode>();
        }

        public void AddChildNode(Node node)
        {
            node.parent = this;
            children.Add(node);
        }

        public void AddNodes(IEnumerable<Node> nodeList)
        {
            foreach (var node in nodeList)
            {
                AddChildNode(node);
            }
        }

        public void RemoveChildNode(Guid id)
        {
            foreach (var node in children.ToList())
            {
                if (node.Id.Equals(id))
                {
                    children.Remove(node);
                }
            }
        }

        public void RemoveChildNode(INode node)
        {
            foreach (var child in children.ToList())
            {
                if (child.Equals(node))
                {
                    children.Remove(child);
                }
            }
        }

        /// <inheritdoc />
        public Node FindTraversing(Guid id)
        {
            if (Id == id)
            {
                return this;
            }

            if (children != null)
            {
                foreach (var child in children)
                {
                    var elemenTraversing = child.FindTraversing(id);
                    if (elemenTraversing != null) return elemenTraversing;
                }
            }

            return null;
        }

        /// <inheritdoc />
        public Node FindTraversing(Node node)
        {
            if (Equals(node))
            {
                return this;
            }

            if (children != null)
            {
                foreach (var child in children)
                {
                    var elemenTraversing = child.FindTraversing(node);
                    if (elemenTraversing != null) return elemenTraversing;
                }
            }

            return null;
        }

        public bool Equals(Node other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Value, other.Value) && Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Node) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ Id.GetHashCode();
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Depth; i++)
            {
                sb.Append("|-");
            }

            sb.Append($"{Value} {{{Id}}}");
            foreach (var child in children)
            {
                sb.AppendLine();
                sb.Append($"{child}");
            }
            return sb.ToString();
        }
    }
}