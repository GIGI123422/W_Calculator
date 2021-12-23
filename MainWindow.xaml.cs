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

namespace W_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool opFlag = false; // true: 연산차 클릭된 직후, false: 아님
        private double saved = 0; // 연산자 버튼이 클릭될 때 txtResult에 있던 값
        private string op;

        public MainWindow()
        {
            InitializeComponent();
        }

        // 숫자 버튼 처리
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (txtResult.Text == "0" || opFlag == true)
            {
                txtResult.Text = btn.Content.ToString(); 
                opFlag = false;
            }
            else
                txtResult.Text += btn.Content.ToString();
        }

        // 소수점 처리
        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            if (txtResult.Text.Contains("."))
                return;
            else
                txtResult.Text += ".";
        }

        // PlusMinus 처리
        private void btnPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            double v = double.Parse(txtResult.Text);
            v = -v;
            txtResult.Text = v.ToString();
        }

        // 사칙연산자가 클릭되었을 때 처리
        private void Op_Click(object sender, RoutedEventArgs e)
        {
            opFlag = true; // 숫자를 세로 써주기 위함
            saved = double.Parse(txtResult.Text);

            Button btn = sender as Button;
            op = btn.Content.ToString();

            txtExp.Text += txtResult.Text + " " + op;
        }

        // = 버튼 처리
        private void btnEqual_Click(object sender, RoutedEventArgs e)
        {
            double v = double.Parse(txtResult.Text);

            switch (op)
            {
                case "+":
                    txtResult.Text = (saved + v).ToString();
                    break;
                case "-":
                    txtResult.Text = (saved + v).ToString();
                    break;
                case "÷":
                    txtResult.Text = (saved + v).ToString();
                    break;
                case "x":
                    txtResult.Text = (saved + v).ToString();
                    break;
            }
            txtExp.Text = saved + " " + op + v.ToString() + " =";
        }
    }
}
