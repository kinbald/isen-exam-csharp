using System;
using System.Collections.Generic;

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
    }
}