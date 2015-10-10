//-----------------------------------------------------------------------
// <copyright file="BrushFactory.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace BattleFieldWpf
{
    using System.Collections.Generic;

    /// <summary>
    /// Class that stores <see cref="IItem.cs" /> items
    /// </summary>
    public class BrushFactory
    {
        /// <summary>
        /// Stores a collection of <see cref="IItem.cs"/>
        /// </summary>
        private Dictionary<int, IItem> collection = new Dictionary<int, IItem>();

        /// <summary>
        /// Adds element <see cref="IItem.cs"/> to the collection
        /// </summary>
        /// <param name="index">Value that specifies the index of the item in the collection</param>
        /// <param name="cell">Item to be added in the collection</param>
        public void Save(int index, IItem cell)
        {
            this.collection.Add(index, cell);
        }

        /// <summary>
        /// Gets <see cref="IItem.cs"/> from the collection
        /// </summary>
        /// <param name="index">Value that specifies the index of the item in the collection</param>
        /// <returns>Returns reference <see cref="IItem.cs"/></returns>
        public IItem Get(int index)
        {
            return this.collection[index];
        }
    }
}
