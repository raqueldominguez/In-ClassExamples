﻿using System;
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

namespace VowelsAndConsonants
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {

           string word = txtWord.Text;
           lstConsonants.Items.Clear();
           lstVowels.Items.Clear();

            for (int i = 0; i < word.Length; i++)
            {
               string letter = word[i].ToString().ToLower();

               if (letter == "a" || letter == "e" || letter == "i" || letter == "o" || letter == "u")
               {
                    lstVowels.Items.Add(letter);
               }
                else
                {
                    lstConsonants.Items.Add(letter);
                }
            }

            txtWord.Clear();
        }
    }
}
