using System;
using HotChocolate.Language;

#nullable enable

namespace HotChocolate.Types.Descriptors
{
    public sealed class SyntaxTypeReference
        : TypeReference
        , ISyntaxTypeReference
        , IEquatable<SyntaxTypeReference>
    {
        public SyntaxTypeReference(
            ITypeNode type,
            TypeContext context,
            string? scope = null,
            bool[]? nullable = null)
            : base(context, scope, nullable)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
        }

        public ITypeNode Type { get; }

        
        public bool Equals(SyntaxTypeReference? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (!IsEqual(other))
            {
                return false;
            }

            return Type.IsEqualTo(other.Type);
        }

        public bool Equals(ISyntaxTypeReference? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (other is SyntaxTypeReference c)
            {
                return Equals(c);
            }

            return false;
        }

        public override bool Equals(ITypeReference? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (other is SyntaxTypeReference c)
            {
                return Equals(c);
            }

            return false;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is SyntaxTypeReference c)
            {
                return Equals(c);
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return base.GetHashCode() ^ Type.GetHashCode() * 397;
            }
        }

        public override string ToString()
        {
            return $"{Context}: {Type}";
        }

        public ISyntaxTypeReference WithType(ITypeNode type)
        {
            if (type is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return new SyntaxTypeReference(
                type, 
                Context,
                Scope,
                Nullable);
        }

        public ISyntaxTypeReference WithContext(TypeContext context = TypeContext.None)
        {
            return new SyntaxTypeReference(
                Type, 
                context,
                Scope,
                Nullable);
        }

        public ISyntaxTypeReference WithScope(string? scope = null)
        {
            return new SyntaxTypeReference(
                Type, 
                Context,
                scope,
                Nullable);
        }

        public ISyntaxTypeReference WithNullable(bool[]? nullable = null)
        {
            return new SyntaxTypeReference(
                Type, 
                Context,
                Scope,
                nullable);
        }

        public ISyntaxTypeReference With(
            Optional<ITypeNode> type = default, 
            Optional<TypeContext> context = default, 
            Optional<string?> scope = default, 
            Optional<bool[]?> nullable = default)
        {
            if (type.HasValue && type.Value is null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return new SyntaxTypeReference(
                type.HasValue ? type.Value! : Type,
                context.HasValue ? context.Value : Context,
                scope.HasValue ? scope.Value : Scope,
                nullable.HasValue ? nullable.Value : Nullable);
        }
    }
}
