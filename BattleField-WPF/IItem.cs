//-----------------------------------------------------------------------
// <copyright file="IItem.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace BattleFieldWpf
{
    using System.Windows.Media;

    /// <summary>
    /// Interface for related items
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// Used to return references to ImageBrush objects
        /// </summary>
        /// <param name="index">Value that specifies brush type</param>
        /// <returns>Returns reference to ImageBrush object</returns>
        ImageBrush GetBrush(int index);
    }
}
