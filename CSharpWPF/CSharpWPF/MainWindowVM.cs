using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using System.Windows.Input;

namespace CSharpWPF
{
    public class MainWindowVM : BindableBase
    {
        /// <summary>
        /// カウンター
        /// </summary>
        private int _cnt = 0;
        public int Cnt
        {
            get { return _cnt; }
            set { SetProperty(ref _cnt, value); }
        }

        /// <summary>
        /// ボタンクリックコマンド
        /// </summary>
        private DelegateCommand _clickCommand;
        public DelegateCommand ClickCommand
        {
            get
            {
                return _clickCommand ?? ( _clickCommand = new DelegateCommand( this, () =>
                {
                    Cnt++;
                }));
            }
        }

        /// <summary>
        /// Loadコマンド
        /// </summary>
        private DelegateCommand _loadedCommand;
        public DelegateCommand LoadedCommand
        {
            get
            {
                return _loadedCommand ?? (_loadedCommand = new DelegateCommand(this, () =>
                {
                    Console.WriteLine("Load!");
                }));
            }
        }

        /// <summary>
        /// MouseMoveコマンド
        /// </summary>
        private DelegateCommand _mouseMoveCommand;
        public DelegateCommand MouseMoveCommand
        {
            get
            {
                return _mouseMoveCommand ?? (_mouseMoveCommand = new DelegateCommand(this, point =>
                {
                    var pos = (System.Windows.Point)point;
                    Console.WriteLine( $"X={pos.X},Y={pos.Y}");
                }));
            }
        }
    }

}
