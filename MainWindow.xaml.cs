using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    enum ChoiceOperation
    {
        Addition,
        Division,
        Multiplication,
        Substraction
    }
    public partial class MainWindow : Window
    {
        ChoiceOperation choiceOperation = ChoiceOperation.Addition;
        double lastNumber = 0, result;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void checkResultValue(string val)
        {
            if ((string)resultLabel.Content == "0")
            {
                resultLabel.Content = val;
            } else
            {
                resultLabel.Content = $"{resultLabel.Content}{val}";
            }
        }

        private void AcBtn_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            lastNumber = 0;
        }

        private void PlusMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            double currentVal;
            if (double.TryParse(resultLabel.Content.ToString(), out currentVal))
            {
                currentVal = currentVal * -1;
                resultLabel.Content = currentVal.ToString();
            }
        }

        private void PercBtn_Click(object sender, RoutedEventArgs e)
        {
            double currentVal;
            if (double.TryParse(resultLabel.Content.ToString(), out currentVal))
            {
                currentVal = lastNumber != 0.0 ? lastNumber * currentVal / 100 : currentVal / 100;
                resultLabel.Content = currentVal.ToString();
            }
        }

        private void DivideBtn_Click(object sender, RoutedEventArgs e)
        {
            double currentVal;
            if (double.TryParse(resultLabel.Content.ToString(), out currentVal))
            {
                lastNumber = (int)lastNumber != 0 ? lastNumber / currentVal : currentVal;
                resultLabel.Content = "0";
                choiceOperation = ChoiceOperation.Division;
            }
        }

        private void SevenBtn_Click(object sender, RoutedEventArgs e)
        {
            checkResultValue(sevenBtn.Content.ToString());
        }

        private void EightBtn_Click(object sender, RoutedEventArgs e)
        {
            checkResultValue(eightBtn.Content.ToString());
        }

        private void NineBtn_Click(object sender, RoutedEventArgs e)
        {
            checkResultValue(nineBtn.Content.ToString());
        }

        private void TimesBtn_Click(object sender, RoutedEventArgs e)
        {
            double currentVal;
            if (double.TryParse(resultLabel.Content.ToString(), out currentVal))
            {
                lastNumber = (int)lastNumber != 0 ? currentVal * lastNumber : currentVal;
                resultLabel.Content = "0";
                choiceOperation = ChoiceOperation.Multiplication;
            }
        }

        private void FourBtn_Click(object sender, RoutedEventArgs e)
        {
            checkResultValue(fourBtn.Content.ToString());
        }

        private void FiveBtn_Click(object sender, RoutedEventArgs e)
        {
            checkResultValue(fiveBtn.Content.ToString());
        }

        private void SixBtn_Click(object sender, RoutedEventArgs e)
        {
            checkResultValue(sixBtn.Content.ToString());
        }

        private void MinusBtn_Click(object sender, RoutedEventArgs e)
        {
            double currentVal;
            if (double.TryParse(resultLabel.Content.ToString(), out currentVal))
            {
                lastNumber = currentVal - lastNumber;
                resultLabel.Content = "0";
                choiceOperation = ChoiceOperation.Substraction;
            }
        }

        private void OneBtn_Click(object sender, RoutedEventArgs e)
        {
            checkResultValue(oneBtn.Content.ToString());
        }

        private void TwoBtn_Click(object sender, RoutedEventArgs e)
        {
            checkResultValue(twoBtn.Content.ToString());
        }

        private void ThreeBtn_Click(object sender, RoutedEventArgs e)
        {
            checkResultValue(threeBtn.Content.ToString());
        }

        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            double currentVal;
            if (double.TryParse(resultLabel.Content.ToString(), out currentVal))
            {
                lastNumber = lastNumber + currentVal;
                resultLabel.Content = "0";
                choiceOperation = ChoiceOperation.Addition;
            }
        }

        private void ZeroBtn_Click(object sender, RoutedEventArgs e)
        {
            checkResultValue(zeroBtn.Content.ToString());
        }

        private void DecimalBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains("."))
            {
                checkResultValue(decimalBtn.Content.ToString());
            }
        }

        private void divide(double divisor, double dividend) 
        {
            if (divisor == 0.0 || (int)dividend == 0.0)
            {
                MessageBox.Show("Syntax Error you should not divide by zero", "Division by Zero", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                resultLabel.Content = $"{divisor / dividend}";
            }
        }

        private void EqualBtn_Click(object sender, RoutedEventArgs e)
        {
            double currentVal;
            if (double.TryParse(resultLabel.Content.ToString(), out currentVal))
            {
                switch(choiceOperation)
                {
                    case ChoiceOperation.Addition:
                        resultLabel.Content = $"{lastNumber + currentVal}";
                        break;
                    case ChoiceOperation.Substraction:
                        resultLabel.Content = $"{lastNumber - currentVal}";
                        break;
                    case ChoiceOperation.Division:
                        divide(lastNumber, currentVal);
                        break;
                    case ChoiceOperation.Multiplication:
                        resultLabel.Content = $"{lastNumber * currentVal}";
                        break;
                    default:
                        resultLabel.Content = $"{lastNumber + currentVal}";
                        break;
                }
                lastNumber = 0;
            }
        }
    }
}
