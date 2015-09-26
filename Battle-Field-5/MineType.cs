//-----------------------------------------------------------------------
// <copyright file="MineType.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace MineFieldApp
{
    /// <summary>
    /// An enumeration for the different mine types
    /// </summary>
    public enum MineType
    {
        /// <summary>
        /// Explosion area has the following shape
        /// *-*
        /// -*-
        /// *-*
        /// </summary>
        One = 1,

        /// <summary>
        /// Explosion area has the following shape
        /// ***
        /// ***
        /// ***
        /// </summary>
        Two = 2,

        /// <summary>
        /// Explosion area has the following shape
        /// --*--
        /// -***-
        /// *****
        /// -***-
        /// --*--
        /// </summary>
        Three = 3,

        /// <summary>
        /// Explosion area has the following shape
        /// -***-
        /// *****
        /// *****
        /// *****
        /// -***- 
        /// </summary>
        Four = 4,

        /// <summary>
        /// Explosion area has the following shape
        /// *****
        /// *****
        /// *****
        /// *****
        /// ***** 
        /// </summary>
        Five = 5
    }
}
