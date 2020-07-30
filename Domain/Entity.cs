using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public abstract class Entity<TId> : IDeletableObject
    {
        public virtual TId Id { get; protected set; }
        public virtual bool Deleted { get; set; }

        public override bool Equals(object obj) => Equals(obj as Entity<TId>);

        private static bool IsTransient(Entity<TId> obj) => (obj != null && Equals(obj.Id, default(TId)));

        private Type GetUnproxiedType() => GetType();

        protected virtual bool Equals(Entity<TId> other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (!IsTransient(other) && !IsTransient(this) && Equals(Id, other.Id))
            {
                var otherType = other.GetUnproxiedType();
                var thisType = this.GetUnproxiedType();
                return thisType.IsAssignableFrom(otherType) ||
                    otherType.IsAssignableFrom(thisType);
            }

            return false;
        }

        public override int GetHashCode()
        {
            if (Equals(Id, default(TId)))
                return base.GetHashCode();
            return Id.GetHashCode(); 
        }
    }
}
    