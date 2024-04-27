using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CalculadoraCientifica
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalculadoraCientifica calculadora;
        private List<string> memoriaOperaciones;

        public MainWindow()
        {
            InitializeComponent();
            calculadora = new CalculadoraCientifica();
            memoriaOperaciones = new List<string>();
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string operacion = (sender as Button).Content.ToString();
            txtDisplay.Text += operacion;
        }

        private void OperacionClick(object sender, RoutedEventArgs e)
        {
            string operacion = (sender as Button).Content.ToString();
            if (operacion == "=")
            {
                try
                {
                    double resultado = calculadora.Calcular(txtDisplay.Text);
                    txtDisplay.Text = resultado.ToString();
                    memoriaOperaciones.Add($"{txtDisplay.Text} = {resultado}");
                    txtMemoria.Text = string.Join(Environment.NewLine, memoriaOperaciones);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                txtDisplay.Text += operacion;
            }
        }

        private void BorrarClick(object sender, RoutedEventArgs e)
        {
            txtDisplay.Text = "";
        }

        private void RaizClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out double num))
            {
                double resultado = calculadora.Raiz(num);
                txtDisplay.Text = resultado.ToString();
            }
            else
            {
                MessageBox.Show("Ingrese un número válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void PotenciaClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out double num))
            {
                double resultado = calculadora.Potencia(num);
                txtDisplay.Text = resultado.ToString();
            }
            else
            {
                MessageBox.Show("Ingrese un número válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SenClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out double num))
            {
                double resultado = calculadora.Seno(num);
                txtDisplay.Text = resultado.ToString();
            }
            else
            {
                MessageBox.Show("Ingrese un número válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CosClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out double num))
            {
                double resultado = calculadora.Coseno(num);
                txtDisplay.Text = resultado.ToString();
            }
            else
            {
                MessageBox.Show("Ingrese un número válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TanClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtDisplay.Text, out double num))
            {
                double resultado = calculadora.Tangente(num);
                txtDisplay.Text = resultado.ToString();
            }
            else
            {
                MessageBox.Show("Ingrese un número válido", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    public class Calculadora
    {
        public double Calcular(string expresion)
        {
            // Implementación de la lógica de cálculo para operaciones básicas
            // ...
            return 0;
        }
    }

    public class CalculadoraCientifica : Calculadora
    {
        public double Raiz(double num)
        {
            return Math.Sqrt(num);
        }

        public double Potencia(double num)
        {
            return num * num;
        }

        public double Seno(double num)
        {
            return Math.Sin(num);
        }

        public double Coseno(double num)
        {
            return Math.Cos(num);
        }

        public double Tangente(double num)
        {
            return Math.Tan(num);
        }
    }
}