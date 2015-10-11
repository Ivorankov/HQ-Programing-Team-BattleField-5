//-----------------------------------------------------------------------
// <copyright file="GameWindow.xaml.cs" company="BattleField-5 team">
//     Telerik teamwork project.
// </copyright>
//-----------------------------------------------------------------------
namespace BattleFieldWpf
{
    using System;
    using System.Linq;
    using System.Windows;
    using MineFieldApp;
    using MineFieldApp.Cells;
    using MineFieldApp.Engines;

    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        /// <summary>
        /// Stores <see cref="IEngine"/> object
        /// </summary>
        private IEngine engine;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameWindow" /> class
        /// </summary>
        /// <param name="fieldSize">The size of the game field</param>
        /// <param name="isExplosionChained">Used to determine if explosions will chain</param>
        public GameWindow(int fieldSize, bool isExplosionChained)
        {
            this.InitializeComponent();
            ICellDamageHandler damageHandler = new DefaultDamageHandler();

            var renderer = new WpfRenderer(this);
            var engine = new Engine(renderer, damageHandler);
            this.engine = engine;
            var field = new GameField(fieldSize, isExplosionChained);
            this.engine.Init(field);
        }
    }
}