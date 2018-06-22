using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Isen.desrumaux.Library
{
    public class Node<T> : INode<T>, IEquatable<INode<T>>
    {
        /// <inheritdoc />
        public T Value { get; set; }
        
        /// <inheritdoc />
        public Guid Id { get; }
        
        /// <inheritdoc />
        public INode<T> parent { get; set; }
        
        /// <inheritdoc />
        public List<INode<T>> children { get; set; }

        /// <inheritdoc />
        public int Depth => parent?.Depth + 1 ?? 0;

        /// <inheritdoc />
        public Node(T value = default(T))
        {
            Value = value;
            Id = Guid.NewGuid();
            children = new List<INode<T>>();
        }

        /// <inheritdoc />
        public void AddChildNode(INode<T> node)
        {
            node.parent = this;
            children.Add(node);
        }

        /// <inheritdoc />
        public void AddNodes(IEnumerable<INode<T>> nodeList)
        {
            foreach (var node in nodeList)
            {
                AddChildNode(node);
            }
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public void RemoveChildNode(INode<T> node)
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
        public INode<T> FindTraversing(Guid id)
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
        public INode<T> FindTraversing(INode<T> node)
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

        /// <inheritdoc />
        public bool Equals(INode<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Value, other.Value) && Id.Equals(other.Id);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Node<T>) obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ Id.GetHashCode();
            }
        }

        /// <inheritdoc />
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