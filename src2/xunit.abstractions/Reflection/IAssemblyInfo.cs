using System;
using System.Collections.Generic;

namespace Xunit.Abstractions
{
    /// <summary>
    /// Represents information about an assembly. The primary implementation is based on runtime
    /// reflection, but may also be implemented by runner authors to provide non-reflection-based
    /// test discovery (for example, AST-based runners like CodeRush or Resharper).
    /// </summary>
    public interface IAssemblyInfo
    {
        /// <summary>
        /// Gets the on-disk location of the assembly under test. If the assembly path is not
        /// known (for example, in AST-based runners), you must return <c>null</c>.
        /// </summary>
        /// <remarks>
        /// This is used by the test framework wrappers to find the co-located unit test framework
        /// assembly (f.e., xunit.dll or xunit2.dll). AST-based runners will need to directly create
        /// instances of <see cref="Xunit1"/> and <see cref="Xunit2"/> (using the constructors that
        /// support an explicit path to the test framework DLL) rather than relying on the
        /// use of <see cref="XunitFrontController"/>.
        /// </remarks>
        string AssemblyPath { get; }

        /// <summary>
        /// Gets all the custom attributes for the given assembly.
        /// </summary>
        /// <param name="attributeType">The type of the attribute</param>
        /// <returns>The matching attributes that decorate the assembly</returns>
        IEnumerable<IAttributeInfo> GetCustomAttributes(Type attributeType);

        /// <summary>
        /// Gets a <see cref="ITypeInfo"/> for the given type.
        /// </summary>
        /// <param name="typeName">The fully qualified type name.</param>
        /// <returns>The <see cref="ITypeInfo"/> if the type exists, or <c>null</c> if not.</returns>
        ITypeInfo GetType(string typeName);

        /// <summary>
        /// Gets all the types for the assembly.
        /// </summary>
        /// <param name="includePrivateTypes">Set to <c>true</c> to return all types in the assembly,
        /// or <c>false</c> to return only public types.</param>
        /// <returns>The types in the assembly.</returns>
        IEnumerable<ITypeInfo> GetTypes(bool includePrivateTypes);
    }
}