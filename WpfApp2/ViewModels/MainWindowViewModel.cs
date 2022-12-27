using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfApp2.Models;

namespace WpfApp2.ViewModels
{

    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool hasCalculated;
        

        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private string display;                 //Дисплей калькулятора
        public string Display
        {
            get => display;
            set
            {
                display = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; set; }   //Команда ввода символа в окно
        public ICommand ClearCommand { get; set; } // Команда очистки окна калькулятора
        public ICommand ResultCommand { get; set; } // Команда вывода результата
        public ICommand BackspaceCommand { get; set; }  // Команда удаления символа с дисплея
        public ICommand SquaredCommand { get; set; }    // Команда возведения в квадрат
        public ICommand SquareRootCommand { get; set; }  // Команда нахождения квадратного корня
        public ICommand MemoryCommand { get; set; }  //
        public ICommand CallMemoryCommand { get; set; }  //

        public double m = 0;

        private void OnCallMemory(object p)
        {
            Display =  m.ToString();
        }
        private void RecMemory(object p)
        {
            m = Ariph.Memory(Display);
        }
        private void OnSquareRoot(object p)
        {
            Display = Ariph.SquareRoot(Display).ToString();
            hasCalculated = true;
        }
        private void OnSquared(object p)
        {
            Display = Ariph.Squared(Display).ToString();
            hasCalculated = true;
        }

        private void Backspace(object p)
        {
            if (display == null)
            {
                Display += 0;
            }
            if (display.Length >= 1)
            {
                Display = display.Substring(0, display.Length - 1);
            }
        }
        private void Clear(object p)
        {
            Display = string.Empty;
        }
        private void Calculate(object display)
        {
            Display = Ariph.Result(Display).ToString();
            hasCalculated = true;
        }

        private void OnAddCommandExecute(object p)
        {
            if (hasCalculated)
            {
                Clear(p);
                hasCalculated = false;
            }
            Display += p;
        }
        private bool CanAddCommandExecuted(object p)
        {
            return true;
        }

        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecuted);
            ClearCommand = new RelayCommand(Clear);
            ResultCommand = new RelayCommand(Calculate);
            BackspaceCommand = new RelayCommand(Backspace);
            SquaredCommand = new RelayCommand(OnSquared);
            SquareRootCommand = new RelayCommand(OnSquareRoot);
            MemoryCommand = new RelayCommand(RecMemory);
            CallMemoryCommand = new RelayCommand(OnCallMemory);
        }
    }
}
